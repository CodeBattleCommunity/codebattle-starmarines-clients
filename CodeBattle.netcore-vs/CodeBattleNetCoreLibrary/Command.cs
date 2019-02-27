using System.Collections.Generic;
using Newtonsoft.Json;

namespace CodeBattleNetCoreLibrary
{
	public class Command
	{
		[JsonProperty("actions")] public IList<ClientAction> Actions { get; set; }
	}
}
