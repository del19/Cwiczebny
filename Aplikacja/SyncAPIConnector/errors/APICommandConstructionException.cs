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
	public class APICommandConstructionException : Exception
	{

		/// <summary>
		/// Creates a new instance of
		/// <code>APICommandConstructionException</code> without detail message.
		/// </summary>
		public APICommandConstructionException()
		{
		}

		/// <summary>
		/// Constructs an instance of
		/// <code>APICommandConstructionException</code> with the specified detail
		/// message.
		/// </summary>
		/// <param name="msg"> the detail message. </param>
		public APICommandConstructionException(string msg) : base(msg)
		{
		}
	}

}