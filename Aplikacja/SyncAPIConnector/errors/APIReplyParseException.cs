using System;

/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
namespace pl.xtb.api.message.error
{

	/// 
	/// <summary>
	/// @author jdabrowski
	/// </summary>
	public class APIReplyParseException : Exception
	{

		/// <summary>
		/// Creates a new instance of
		/// <code>APIReplyParseException</code> without detail message.
		/// </summary>
		public APIReplyParseException()
		{
		}

		/// <summary>
		/// Constructs an instance of
		/// <code>APIReplyParseException</code> with the specified detail message.
		/// </summary>
		/// <param name="msg"> the detail message. </param>
		public APIReplyParseException(string msg) : base(msg)
		{
		}
	}

}