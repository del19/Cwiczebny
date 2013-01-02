using System;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.message.response
{

	using JSONAware = Newtonsoft.Json.Linq.JContainer;
	using JSONObject = Newtonsoft.Json.Linq.JObject;
	using ERR_CODE = pl.xtb.api.message.error.ERR_CODE;
	using APIReplyParseException = pl.xtb.api.message.error.APIReplyParseException;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class BaseResponse
	{
	//    {
	//		“status“: true,				Boolean
	//		“returnData“: JSON value		JSON value
	//	}

		private bool? status;
		private string errorDescr;
		private ERR_CODE errCode;
		private object returnData;



		public BaseResponse(string body)
		{
			JSONObject ob;
			try
			{
				ob = (JSONObject)JSONObject.Parse(body);
                
			}
			catch (Exception x)
			{
				throw new APIReplyParseException("JSON Parse exception: " + body + "\n" + x.Message);
			}
			
			if (ob == null)
			{
				throw new APIReplyParseException("JSON Parse exception: " + body);
			}
			else
			{
				this.status = (bool?) ob["status"];
				this.errCode = new ERR_CODE((string)ob["errorCode"]);
				this.errorDescr = (string) ob["errorDescr"];
				this.returnData = (JSONAware) ob["returnData"];
				if (this.status == null)
				{
					Console.Error.WriteLine(body);
					throw new APIReplyParseException("JSON Parse error: " + "\"status\" is null!");
				}
				if ((this.status==null) || ((bool)!this.status))
				{
					Console.Error.WriteLine(body);
					throw new APIErrorResponse(errCode, errorDescr, body);
				}
			}
		}

		/// <returns> the returnData </returns>
		public virtual object ReturnData
		{
			get
			{
				return returnData;
			}
		}

		public virtual bool? Status
		{
			get
			{
				return status;
			}
		}



	}

}