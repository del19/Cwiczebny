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
    public class ProfitCalculationCommand : BaseCommand
	{
        private bool prettyPrint_2;




		public ProfitCalculationCommand(JSONObject arguments, bool prettyPrint) : base(arguments, prettyPrint)
		{
		}



		public override string CommandName
		{
			get
			{
                return "getProfitCalculation";
			}
		}



		public override string[] RequiredArguments
		{
			get
			{
                return new string[] { "cmd", "symbol", "volume", "openPrice", "closePrice" };
			}
		}

	}

}