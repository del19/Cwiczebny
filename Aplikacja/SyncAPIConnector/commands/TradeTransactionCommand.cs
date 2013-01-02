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
    public class TradeTransactionCommand : BaseCommand
    {



        public TradeTransactionCommand(JSONObject arguments, bool prettyPrint)
            : base(arguments, prettyPrint)
        {
        }

        public override string CommandName
        {
            get
            {
                return "tradeTransaction";
            }
        }



        public override string[] RequiredArguments
        {
            get
            {
                return new string[] { "tradeTransInfo" };
            }
        }
        //{
        //		“command”:	“tradeTransaction”, 	String
        //	 	“arguments”:	{
        //					“tradeTransInfo”: TRADE_TRANS_INFO
        //				}
        //	}
    }

}