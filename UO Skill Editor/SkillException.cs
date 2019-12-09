using System;
using System.Collections.Generic;
using System.Text;

namespace Editor
{
	/// <summary>
	/// Represents errors that occur during loading/saving skills.
	/// </summary>
	public class SkillException : Exception
	{
		#region Constructors
		/// <summary>
		/// Constructs a new instance of SkillException.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		public SkillException( string message ) : base( message )
		{
		}

		/// <summary>
		/// Constructs a new instance of SkillException.
		/// </summary>
		/// <param name="message">The message that describes the error.</param>
		/// <param name="args">Parameters used to construct message.</param>
		public SkillException( string message, params object[] args ) : base( String.Format( message, args ) )
		{
		}
		#endregion
	}
}
