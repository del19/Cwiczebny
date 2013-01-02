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
	public class AllSymbolsCommand : BaseCommand
	{

		public AllSymbolsCommand(bool prettyPrint) : base(new JSONObject(), prettyPrint)
		{
		}



		public override string CommandName
		{
			get
			{
				return "getAllSymbols";
			}
		}

		public override string[] RequiredArguments
		{
			get
			{
				return new string[]{};
			}
		}
	//{
	//		“command”:	“getAllSymbols”		String
	//	}

	}

}