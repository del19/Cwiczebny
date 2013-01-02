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
	public class ChartLastInfoRecord
	{

		private string symbol;
		private PERIOD_CODE period;
		private long? start;

		public ChartLastInfoRecord(string symbol, PERIOD_CODE period, long? start)
		{
			this.symbol = symbol;
			this.period = period;
			this.start = start;
		}



		public virtual JSONObject toJSONObject()
		{
			JSONObject obj = new JSONObject();
			obj.Add("symbol", symbol);
			obj.Add("period", (long?)period.longValue());
			obj.Add("start", start);
			return obj;
		}
	}

}