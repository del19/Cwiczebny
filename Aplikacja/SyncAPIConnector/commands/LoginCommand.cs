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
	public class LoginCommand : BaseCommand
	{



		public LoginCommand(JSONObject arguments, bool prettyPrint) : base(arguments, prettyPrint)
		{
		}

		public override string CommandName
		{
			get
			{
				return "login";
			}
		}


	//{
	//		“command”:	“login”, 		String
	//	 	“arguments”:	{
	//					“userId”: 100,			Number
	//					“password”: “PASSWORD”	String
	//				}
	//	}



		public override string[] RequiredArguments
		{
			get
			{
				return new string[] {"userId", "password"};
			}
		}

	}

}