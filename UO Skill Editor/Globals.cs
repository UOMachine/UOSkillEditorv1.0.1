using System;

namespace Editor
{
	/// <summary>
	/// Provides access to global variables.
	/// </summary>
	public static class Globals
	{
		#region Properties
		private static MessageLogger _Logger;

		/// <summary>
		/// Logs messages.
		/// </summary>
		public static MessageLogger Logger
		{
			get{ return _Logger; }
		}

		private static EditorSettings _Settings;

		/// <summary>
		/// Provides access to program settings.
		/// </summary>
		public static EditorSettings Settings
		{
			get{ return _Settings; }
		}

		private static LanguageManager _LanguageManager;

		/// <summary>
		/// Provides access to localized strings.
		/// </summary>
		public static LanguageManager LanguageManager
		{
			get{ return _LanguageManager; }
		}
		#endregion

		#region Methods
		/// <summary>
		/// Initializes global variables.
		/// </summary>
		public static void Initialize()
		{
			_Logger = new MessageLogger();
			_Settings = new EditorSettings();
			_LanguageManager = new LanguageManager( _Settings.Language );
		}
		#endregion
	}
}
