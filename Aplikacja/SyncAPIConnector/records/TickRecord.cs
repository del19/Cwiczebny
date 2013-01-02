/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.message.records
{

	using JSONObject = Newtonsoft.Json.Linq.JObject;
    using JSONArray = Newtonsoft.Json.Linq.JArray;
	using EXECUTION_CODE = pl.xtb.api.message.codes.EXECUTION_CODE;
    using System.Collections.Generic;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class TickRecord : BaseResponseRecord
	{

		private double? ask;
		private double? bid;
		private double? askVolume;
		private double? bidVolume;
		private EXECUTION_CODE exemode;
		private double? high;
		private double? low;
		private string symbol;
		private long? timestamp;
		private long? level;
        private Dictionary<long?,double?> profits;

		public TickRecord()
		{
		}

		
		public virtual double? Ask
		{
			get
			{
				return ask;
			}
		}

		public virtual double? Bid
		{
			get
			{
				return bid;
			}
		}

		public virtual double? AskVolume
		{
			get
			{
				return askVolume;
			}
		}

		public virtual double? BidVolume
		{
			get
			{
				return bidVolume;
			}
		}

		public virtual EXECUTION_CODE Exemode
		{
			get
			{
				return exemode;
			}
		}

		public virtual double? High
		{
			get
			{
				return high;
			}
		}

		public virtual double? Low
		{
			get
			{
				return low;
			}
		}

		public virtual string Symbol
		{
			get
			{
				return symbol;
			}
		}

		public virtual long? Timestamp
		{
			get
			{
				return timestamp;
			}
		}

		public virtual long? Level
		{
			get
			{
				return level;
			}
		}

        public virtual Dictionary<long?,double?> Profits
        {
            get
            {
                return profits;
            }
        }

        public void FieldsFromJSONObject(JSONObject value)
        {
            FieldsFromJSONObject(value, null);
        }

		public bool FieldsFromJSONObject(JSONObject value, string str)
		{
			this.ask = (double?)value["ask"];
			this.bid = (double?)value["bid"];
			this.askVolume = (double?)value["askVolume"];
			this.bidVolume = (double?)value["bidVolume"];
			this.exemode = new EXECUTION_CODE((long?)value["exemode"]);
			this.high = (double?)value["high"];
			this.low = (double?)value["low"];
			this.symbol = (string)value["symbol"];
			this.timestamp = (long?)value["timestamp"];
            this.level = (long?)value["level"];
            
            profits = new Dictionary<long?,double?>();
            if (value["profits"]!=null){
        	    
                JSONArray jsonarray = (JSONArray)value["profits"];
        	    
                foreach(JSONObject i in jsonarray){
                    
                    profits[(long?)i["order"]] =  (double?) i["profit"];
                }
        	
            }


            if ((ask == null) || (bid == null) || (symbol == null) || (timestamp == null) || (exemode == null)) return false;
            return true;
		}

        
        public virtual string ToString()
        {
            return "TickRecord{" + "ask=" + ask + ", bid=" + bid + ", askVolume=" + askVolume + ", bidVolume=" + bidVolume + ", exemode=" + exemode + ", high=" + high + ", low=" + low + ", symbol=" + symbol + ", timestamp=" + timestamp + ", level=" + level +", profitNum="+ profits.Count +'}';
        }
	}

}