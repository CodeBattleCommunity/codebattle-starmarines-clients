using Newtonsoft.Json;

namespace CodeBattleNetCoreLibrary
{
	public class Portal
	{
		[JsonProperty("source")] public int Source { get; set; }
		[JsonProperty("target")] public int Target { get; set; }
	}
}
