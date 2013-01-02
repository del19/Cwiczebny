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
	public class ConfirmPricedCommand : BaseCommand
	{



		public ConfirmPricedCommand(JSONObject arguments, bool prettyPrint) : base(arguments, prettyPrint)
		{
		}

		public override string CommandName
		{
			get
			{
				return "confirmPriced";
			}
		}



		public override string[] RequiredArguments
		{
			get
			{
				return new string[]{"requestId", "tradeTransInfo"};
			}
		}
	//	{
	//		"command": "confirmPriced", 	String
	//		"arguments": {
	//			"requestId": 43,	Number, id of initial request
	//			“tradeTransInfo”: TRADE_TRANS_INFO
	//		},
	//	}

	}

}