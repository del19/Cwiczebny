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
	public class CommissionDefCommand : BaseCommand
	{



		public CommissionDefCommand(JSONObject arguments, bool prettyPrint) : base(arguments, prettyPrint)
		{
		}

		public override string toJSONString()
		{
			JSONObject obj = new JSONObject();
			obj.Add("command", commandName);
			obj.Add("prettyPrint", prettyPrint);
			obj.Add("arguments", arguments);
			obj.Add("extended", true);
			return obj.ToString();
		}

		public override string CommandName
		{
			get
			{
				return "getCommissionDef";
			}
		}



		public override string[] RequiredArguments
		{
			get
			{
				return new string[]{"symbol", "volume"};
			}
		}
	//	{
	//		“command”:	“getCommissionDef”, 	String
	//		“extended”:	true 			Boolean
	// 		"arguments": {
	//        			"symbol": "T.US",	String
	//        			"volume": 1.0		Floating number
	//    		}
	//	}
	}

}