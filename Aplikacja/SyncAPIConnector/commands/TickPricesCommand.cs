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
    public class TickPricesCommand : BaseCommand
    {



        public TickPricesCommand(JSONObject arguments, bool prettyPrint)
            : base(arguments, prettyPrint)
        {
        }

        public override string CommandName
        {
            get
            {
                return "getTickPrices";
            }
        }



        public override string[] RequiredArguments
        {
            get
            {
                return new string[] { "symbols", "timestamp" };
            }
        }
        //	{
        //		“command”:	“getTickPrices”, 	String
        //		"level": 0				Number, level price
        //level equals -1: all available levels greater than -1: only specified level
        //	 	“arguments”:	{
        //					“symbols”: [“KOMB.CZ”,”AGO.PL”,...],								Array of symbols
        //					“timestamp”: 1262944112000
        //Time
        //				}
        //	}

    }

}