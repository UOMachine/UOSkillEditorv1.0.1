using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Win32;

namespace Editor
{
	/// <summary>
	/// Program settings.
	/// </summary>
	public class EditorSettings : Settings
	{
		#region Constants
		private const string SETTING_NAME_LANGUAGE = "Language";
		private const string SETTING_NAME_USE_DEFAULT_PATHS = "UseDefaultPaths";
		private const string SETTING_NAME_SKILL_INDEXES = "SkillIndexes";
		private const string SETTING_NAME_SKILL_DATA = "SkillData";
		private const string SETTING_NAME_SKILL_GROUPS = "SkillGroups";
		private const string SETTING_NAME_SETTING_PAGES = "SettingPages";

		private static readonly string[] DefaultUltimaKeys = new string[]
		{
			@"Electronic Arts\EA Games\Ultima Online Classic",
			@"Electronic Arts\EA Games\Ultima Online High Seas Classic BETA", 
			@"Electronic Arts\EA Games\Ultima Online Stygian Abyss Classic", 
			@"Origin Worlds Online\Ultima Online\KR Legacy Beta", 
			@"EA Games\Ultima Online: Mondain's Legacy\1.00.0000", 
			@"Origin Worlds Online\Ultima Online\1.0", 
			@"Origin Worlds Online\Ultima Online Third Dawn\1.0",
			@"EA GAMES\Ultima Online Samurai Empire", 
			@"EA Games\Ultima Online: Mondain's Legacy", 
			@"EA GAMES\Ultima Online Samurai Empire\1.0", 
			@"EA GAMES\Ultima Online Samurai Empire\1.00.0000", 
			@"EA GAMES\Ultima Online: Samurai Empire\1.0", 
			@"EA GAMES\Ultima Online: Samurai Empire\1.00.0000", 
			@"EA Games\Ultima Online: Mondain's Legacy\1.0", 
			@"EA Games\Ultima Online: Mondain's Legacy\1.00.0000", 
			@"Origin Worlds Online\Ultima Online Samurai Empire BETA\2d\1.0", 
			@"Origin Worlds Online\Ultima Online Samurai Empire BETA\3d\1.0", 
			@"Origin Worlds Online\Ultima Online Samurai Empire\2d\1.0", 
			@"Origin Worlds Online\Ultima Online Samurai Empire\3d\1.0"
		};
		#endregion

		#region Properties
		private string _DefaultUltimaFolder;

		private string DefaultUltimaFolder
		{
			get
			{
				if ( !String.IsNullOrEmpty( _DefaultUltimaFolder ) )
					return _DefaultUltimaFolder;

				for ( int i = 0; i < DefaultUltimaKeys.Length; i++ )
				{
					if ( IntPtr.Size == 8 )
					{
						_DefaultUltimaFolder = GetExePath( @"Wow6432Node\" + DefaultUltimaKeys[ i ] );
					}
					else
					{
						_DefaultUltimaFolder = GetExePath( DefaultUltimaKeys[ i ] );
					}

					if ( _DefaultUltimaFolder != null )
						return _DefaultUltimaFolder;
				}

				return null;
			}
		}

		/// <summary>
		/// Gets or sets name of the language file.
		/// </summary>
		public string Language
		{
			get
			{
				return GetString( SETTING_NAME_LANGUAGE, DefaultLanguage );
			}
			set
			{
				SetValue( SETTING_NAME_LANGUAGE, value );
			}
		}

		/// <summary>
		/// Gets or sets name of the language file.
		/// </summary>
		public string DefaultLanguage
		{
			get { return "Eng.xml"; }
		}

		/// <summary>
		/// Gets possible language options.
		/// </summary>
		public List<string> LanguageOptions
		{
			get
			{
				return GetOptions( SETTING_NAME_LANGUAGE );
			}
		}

		/// <summary>
		/// Gets default path to skills.idx.
		/// </summary>
		public string DefaultSkillIndexes
		{
			get
			{
				return Path.Combine( DefaultUltimaFolder, "skills.idx" );
			}
		}

		/// <summary>
		/// Gets default path to skills.mul.
		/// </summary>
		public string DefaultSkillData
		{
			get
			{
				return Path.Combine( DefaultUltimaFolder, "skills.mul" );
			}
		}

		/// <summary>
		/// Gets default path to skillgrp.mul.
		/// </summary>
		public string DefaultSkillGroups
		{
			get
			{
				return Path.Combine( DefaultUltimaFolder, "skillgrp.mul" );
			}
		}

		/// <summary>
		/// Gets defualt path to client.exe.
		/// </summary>
		public string DefaultExePath
		{
			get
			{
				return Path.Combine( DefaultUltimaFolder, "client.exe" );
			}
		}

		/// <summary>
		/// Gets setting pages.
		/// </summary>
		public List<string> SettingPages
		{
			get
			{
				return GetOptions( SETTING_NAME_SETTING_PAGES );
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs and loads editor settings from default file.
		/// </summary>
		public EditorSettings() : base()
		{
		}
		#endregion

		#region Methods
		private string GetExePath( string subName )
		{
			try
			{
				RegistryKey key = Registry.LocalMachine.OpenSubKey( string.Format( @"SOFTWARE\{0}", subName ) );

				if ( key == null )
				{
					key = Registry.CurrentUser.OpenSubKey( string.Format( @"SOFTWARE\{0}", subName ) );

					if ( key == null )
					{
						return null;
					}
				}

				string path = key.GetValue( "ExePath" ) as string;

				if ( ( ( path == null ) || ( path.Length <= 0 ) ) || ( !Directory.Exists( path ) && !File.Exists( path ) ) )
				{
					path = key.GetValue( "Install Dir" ) as string;

					if ( ( ( path == null ) || ( path.Length <= 0 ) ) || ( !Directory.Exists( path ) && !File.Exists( path ) ) )
					{
						path = key.GetValue( "InstallDir" ) as string;

						if ( ( ( path == null ) || ( path.Length <= 0 ) ) || ( !Directory.Exists( path ) && !File.Exists( path ) ) )
							return null;
					}
				}

				if ( path.EndsWith( ".exe" ) )
					path = Path.GetDirectoryName( path );

				if ( ( path == null ) || !Directory.Exists( path ) )
				{
					return null;
				}

				return path;
			}
			catch
			{
				return null;
			}
		}
		#endregion
	}
}
