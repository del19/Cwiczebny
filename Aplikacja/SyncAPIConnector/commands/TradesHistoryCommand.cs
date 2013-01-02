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
    public class TradesHistoryCommand : BaseCommand
    {



        public TradesHistoryCommand(JSONObject arguments, bool prettyPrint)
            : base(arguments, prettyPrint)
        {
        }

        public override string CommandName
        {
            get
            {
                return "getTradesHistory";
            }
        }



        public override string[] RequiredArguments
        {
            get
            {
                return new string[] { "start", "end" };
            }
        }
        //{
        //   		“command”:	“getTradesHistory”	String
        //	 	“arguments”:	{
        //				     "start": 1275993488000,	Time
        //				     "end": 0				Time, 0 means
        //current time for simplicity
        //				}
        //	}
    }

}