using System;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.message.response
{

	using ERR_CODE = pl.xtb.api.message.error.ERR_CODE;

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class APIErrorResponse : Exception
	{

		private ERR_CODE code;
		private string errDesc;
		private string msg;

		/// <summary>
		/// Constructs an instance of
		/// <code>APIErrorResponse</code> with the specified detail message.
		/// </summary>
		/// <param name="msg"> the detail message. </param>
		public APIErrorResponse(ERR_CODE code, string errDesc, string msg) : base(msg)
		{
			this.code = code;
			this.errDesc = errDesc;
			this.msg = msg;
		}

		public override string Message
		{
			get
			{
				return "ERR_CODE = " + code.stringValue() + "ERR_DESC = " + errDesc + "\n" + msg + "\n" + base.Message;
			}
		}
	}

}