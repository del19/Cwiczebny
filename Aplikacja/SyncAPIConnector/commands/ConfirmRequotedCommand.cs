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
	public class ConfirmRequotedCommand : BaseCommand
	{



		public ConfirmRequotedCommand(JSONObject arguments, bool prettyPrint) : base(arguments, prettyPrint)
		{
		}

		public override string CommandName
		{
			get
			{
				return "confirmRequoted";
			}
		}



		public override string[] RequiredArguments
		{
			get
			{
				return new string[]{"requestId"};
			}
		}
	//	{
	//		"command": "confirmRequoted",	String
	//		"arguments": {
	//			"requestId": 43		Number, id of requoted request
	//    		},
	//	}
	}

}