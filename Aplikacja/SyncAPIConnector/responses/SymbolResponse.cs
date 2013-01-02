/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.message.response
{

	using JSONObject = Newtonsoft.Json.Linq.JObject;
	using APIReplyParseException = pl.xtb.api.message.error.APIReplyParseException;
	using SymbolRecord = pl.xtb.api.message.records.SymbolRecord;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class SymbolResponse : BaseResponse
	{

		private SymbolRecord symbol;


		public SymbolResponse(string body) : base(body)
		{
			JSONObject ob = (JSONObject) this.ReturnData;
			symbol = new SymbolRecord();
			symbol.FieldsFromJSONObject(ob);
		}

		public virtual SymbolRecord Symbol
		{
			get
			{
				return symbol;
			}
		}

	}

}