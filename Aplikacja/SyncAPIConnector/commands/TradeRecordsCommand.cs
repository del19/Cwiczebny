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
    public class TradeRecordsCommand : BaseCommand
    {



        public TradeRecordsCommand(JSONObject arguments, bool prettyPrint)
            : base(arguments, prettyPrint)
        {
        }

        public override string CommandName
        {
            get
            {
                return "getTradeRecords";
            }
        }



        public override string[] RequiredArguments
        {
            get
            {
                return new string[] { "orders" };
            }
        }
        //	{
        //		“command”:	“getTradeRecords”, 	String
        //	 	“arguments”:	{
        //					“orders”: [7489839,7489841,...]										Array of  orders
        //				}
        //	}
    }

}