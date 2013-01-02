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
    public class TradesCommand : BaseCommand
    {



        public TradesCommand(JSONObject arguments, bool prettyPrint)
            : base(arguments, prettyPrint)
        {
        }

        public override string CommandName
        {
            get
            {
                return "getTrades";
            }
        }



        public override string[] RequiredArguments
        {
            get
            {
                return new string[] { "openedOnly" };
            }
        }
        //	{
        //		“command”:	“getTrades”		String
        //	 	“arguments”:	{
        //					“openedOnly”: true	Boolean, if true
        //then only opened trades will be returned
        //				}
        //	}
    }

}