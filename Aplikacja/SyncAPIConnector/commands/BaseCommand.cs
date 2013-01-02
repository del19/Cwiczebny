/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.message.command
{
    using JSONObject = Newtonsoft.Json.Linq.JObject;
    using APICommandConstructionException = pl.xtb.api.message.error.APICommandConstructionException;
    using Newtonsoft.Json.Linq;

    /// 
    /// <summary>
    /// @author jdabrowski
    /// </summary>
    public abstract class BaseCommand
    {
        //	{
        //		“command”:“commandName”, 			String
        //	 	“arguments”:	{
        //				“arg1Name”: 10,
        //				“arg2Name”: “Some text”,
        //				...
        //				},
        //		"prettyPrint": true				Boolean
        //	}

        protected internal string commandName;
        protected internal bool? prettyPrint;
        protected internal JSONObject arguments;



        public BaseCommand(JSONObject arguments, bool? prettyPrint)
        {
            this.commandName = CommandName;
            this.arguments = arguments;
            this.prettyPrint = prettyPrint;
            validateArguments();
        }

        public abstract string CommandName { get; }



        public abstract string[] RequiredArguments { get; }



        public virtual bool validateArguments()
        {
            selfCheck();
            foreach (string argName in RequiredArguments)
            {
                JToken tok;
                if (!this.arguments.TryGetValue(argName, out tok))
                {
                    throw new APICommandConstructionException("Arguments of [" + commandName + "] Command must contain \"" + argName + "\" field!");
                }
            }
            return true;
        }

        public virtual string toJSONString()
        {
            JSONObject obj = new JSONObject();
            obj.Add("command", commandName);
            obj.Add("prettyPrint", prettyPrint);
            obj.Add("arguments", arguments);
            return obj.ToString();
        }



        private void selfCheck()
        {
            if (commandName == null)
            {
                throw new APICommandConstructionException("commandName cannot be null");
            }
            if (arguments == null)
            {
                throw new APICommandConstructionException("arguments cannot be null");
            }
        }
    }

}