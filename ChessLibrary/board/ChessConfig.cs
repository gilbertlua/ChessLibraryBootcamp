using System.Text.Json.Serialization;
namespace ChessLibrary
{
	public class ChessConfiguration
	{
		[JsonPropertyName("_configuration")]
		public string[][]? Configuration { get; set; }
	}

}