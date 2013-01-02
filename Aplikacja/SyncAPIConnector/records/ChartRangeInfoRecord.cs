/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.message.records
{

	using PERIOD_CODE = pl.xtb.api.message.codes.PERIOD_CODE;
	using JSONObject = Newtonsoft.Json.Linq.JObject;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class ChartRangeInfoRecord
	{

		private string symbol;
		private PERIOD_CODE period;
		private long? start;
		private long? end;
		private long? ticks;

		public ChartRangeInfoRecord(string symbol, PERIOD_CODE period, long? start, long? end, long? ticks)
		{
			this.symbol = symbol;
			this.period = period;
			this.start = start;
			this.end = end;
			this.ticks = ticks;
		}

		public virtual JSONObject toJSONObject()
		{
			JSONObject obj = new JSONObject();
			obj.Add("symbol", symbol);
			obj.Add("period", (long?)period.longValue());
			obj.Add("start", start);
            obj.Add("end", end);
			obj.Add("ticks", ticks);
			return obj;
		}
	}

}