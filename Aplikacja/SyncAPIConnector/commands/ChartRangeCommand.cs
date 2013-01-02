/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.message.command
{

	using JSONObject = Newtonsoft.Json.Linq.JObject;
	using APICommandConstructionException = pl.xtb.api.message.error.APICommandConstructionException;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class ChartRangeCommand : BaseCommand
	{



		public ChartRangeCommand(JSONObject arguments, bool prettyPrint) : base(arguments, prettyPrint)
		{
		}

		public override string CommandName
		{
			get
			{
				return "getChartRangeRequest";
			}
		}



		public override string[] RequiredArguments
		{
			get
			{
				return new string[]{"info"};
			}
		}
	//	{
	//		“command”:	“getChartRangeRequest”, 	String
	//	 	“arguments”:	{
	//					“info”:   CHART_RANGE_INFO_RECORD
	//				}
	//	}

	}

}