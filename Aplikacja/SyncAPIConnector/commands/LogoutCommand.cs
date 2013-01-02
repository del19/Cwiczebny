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
	public class LogoutCommand : BaseCommand
	{



		public LogoutCommand() : base(new JSONObject(), false)
		{
		}

		public override string toJSONString()
		{
			JSONObject obj = new JSONObject();
			obj.Add("command", this.commandName);
			return obj.ToString();
		}

		public override string CommandName
		{
			get
			{
				return "logout";
			}
		}



		public override string[] RequiredArguments
		{
			get
			{
				return new string[]{};
			}
		}
	//	{
	//		“command”:	“logout” 		String
	//	}
	}

}