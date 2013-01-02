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
	public class ChartLastCommand : BaseCommand
	{



		public ChartLastCommand(JSONObject arguments, bool prettyPrint) : base(arguments, prettyPrint)
		{
		}


		public override string CommandName
		{
			get
			{
                return "getChartLastRequest";
			}
		}



		public override string[] RequiredArguments
		{
			get
			{
				return new string[] {"info"};
			}
		}
	//	{
	//		“command”:	“getChartLastRequest”, 	String
	//	 	“arguments”:	{
	//					“info”:   CHART_LAST_INFO_RECORD
	//				}
	//	}

	}

}