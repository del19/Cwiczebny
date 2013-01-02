using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pl.xtb.api.sync
{
    public class ServerData
    {
        public string address { get; private set; }
        public int mainPort { get; private set; }
        public int streamingPort { get; private set; }
        public string description { get; private set; }
        public bool secure { get; private set; }
        
        
        public ServerData(String address, int mainPort, int streamingPort, bool secure , string description)
        {
            this.address = address;
            this.mainPort = mainPort;
            this.streamingPort = streamingPort;
            this.secure = secure;
            this.description = description;
        }

        public static Dictionary<String, ServerData> DevelopmentServers
        {
            get
            {
                Dictionary<String, ServerData> dict = new Dictionary<String, ServerData>();
                return dict;
            }

        }

        public static Dictionary<String, ServerData> ProductionServers
        {
            get
            {
                Dictionary<String, ServerData> dict = new Dictionary<String, ServerData>();
                dict.Add("CONTEST", new ServerData("195.182.34.23", 5102, 5103, false, "Demo"));
                return dict;
            }

        }
    }


}
