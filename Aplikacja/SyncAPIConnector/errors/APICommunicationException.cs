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
	public class APICommunicationException : Exception
	{

		/// <summary>
		/// Creates a new instance of
		/// <code>APICommunicationException</code> without detail message.
		/// </summary>
		public APICommunicationException()
		{
		}

		/// <summary>
		/// Constructs an instance of
		/// <code>APICommunicationException</code> with the specified detail message.
		/// </summary>
		/// <param name="msg"> the detail message. </param>
		public APICommunicationException(string msg) : base(msg)
		{
		}
	}

}