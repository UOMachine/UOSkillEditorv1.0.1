using System;
using System.IO;
using System.Security.AccessControl;
using System.Reflection;

namespace Editor
{
	/// <summary>
	/// Represents a writer that can write messages to file.
	/// </summary>
	public class MessageLogger
	{
		#region Properties
		private string _Filename;

		/// <summary>
		/// Name of the file to log to.
		/// </summary>
		public string Filename
		{
			get { return _Filename; }
		}

		private TextWriter _LogWriter = null;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new MessageLogger.
		/// </summary>
		public MessageLogger()
		{
			string assembly = Assembly.GetExecutingAssembly().Location;
			string dir = Path.Combine( Path.GetDirectoryName( assembly ), "Logs" );

			if ( !Directory.Exists( dir ) )
				Directory.CreateDirectory( dir );

			_Filename = String.Format( "{0}\\{1}.txt", dir, DateTime.Now.ToString( "MM.dd.yy" ) );
		}

		/// <summary>
		/// Constructs a new MessageLogger.
		/// </summary>
		/// <param name="fileName">File to store messages to.</param>
		public MessageLogger( string fileName )
		{
			string dir = Path.GetDirectoryName( fileName );

			if ( !Directory.Exists( dir ) )
				Directory.CreateDirectory( dir );

			_Filename = fileName;
			_LogWriter = new StreamWriter( fileName, true );
		}
		#endregion

		#region Methods
		/// <summary>
		/// Writes exception details to file.
		/// </summary>
		/// <param name="e">Exception to log.</param>
		public void LogException( Exception e )
		{
			if ( _LogWriter == null )
				_LogWriter = new StreamWriter( _Filename, true );

			_LogWriter.WriteLine( String.Format( "{0}: {1}", DateTime.Now, e.Message ) );
			_LogWriter.WriteLine( String.Format( "       Stack trace: {0}", e.StackTrace ) );
			_LogWriter.WriteLine( "---------------------------------------------------------------------------------------------------" );
			_LogWriter.Flush();
		}

		/// <summary>
		/// Writes a string to log file.
		/// </summary>
		/// <param name="message">String to write.</param>
		public void LogMessage( string message )
		{
			if ( _LogWriter == null )
				_LogWriter = new StreamWriter( _Filename, true );

			_LogWriter.WriteLine( String.Format( "{0}: {1}", DateTime.Now, message ) );
			_LogWriter.Flush();
		}

		/// <summary>
		/// Flushes and closes log file.
		/// </summary>
		public void Close()
		{
			if ( _LogWriter != null )
			{
				_LogWriter.Flush();
				_LogWriter.Close();
			}
		}
		#endregion
	}
}
