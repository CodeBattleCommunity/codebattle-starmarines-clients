using CodeBattleNetCoreLibrary;
using System;
using Microsoft.Extensions.Configuration;

namespace CodeBattleNetCore
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var settings = new ConfigurationBuilder()
					.AddJsonFile("appsettings.json", false)
					.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
					.Build().Get<Settings>();

			var gcb = new GameClientStarMarines(settings.Server, settings.BotName, settings.Token);
			gcb.Run(() =>
			{
				if (gcb.GetErrors().Count != 0)
				{
					foreach (var error in gcb.GetErrors())
					{
						Console.WriteLine(error);
					}
				}
				foreach (var planet in gcb.GetMyPlanets())
				{
					foreach (var neighbour in planet.Neighbours)
					{
						if (neighbour != planet.Id)
						{
							gcb.SendDrones(planet.Id, neighbour, planet.Droids / planet.Neighbours.Length);
						}
					}
				}
				gcb.SendMessage();
			});

			Console.ReadKey(true);
		}
	}
}
