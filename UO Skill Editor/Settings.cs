using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Collections.Generic;

namespace Editor
{
	/// <summary>
	/// Intercace used for setting pages.
	/// </summary>
	public interface ISettingsPage
	{
		/// <summary>
		/// Resets values to default.
		/// </summary>
		void Reset();

		/// <summary>
		/// Verifies user input.
		/// </summary>
		/// <returns></returns>
		bool Verify();

		/// <summary>
		/// Saves settings.
		/// </summary>
		void Save();
	}

	/// <summary>
	/// Base class for managing settings.
	/// </summary>
	public class Settings
	{
		#region Constants
		private const string DEFAULT_FILENAME = "Settings.xml";

		private const string NODE_NAME_ROOT = "settings";
		private const string NODE_NAME_SETTING = "setting";
		private const string NODE_NAME_SETTING_NAME = "name";
		private const string NODE_NAME_SETTING_VALUE = "value";
		private const string NODE_NAME_SETTING_OPTION = "option";
		#endregion

		#region Properties
		private Dictionary<string, SettingEntry> _Dictionary = new Dictionary<string, SettingEntry>();
		private string _Filename;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs and loads Settings from default file.
		/// </summary>
		public Settings() : this( DEFAULT_FILENAME )
		{
		}

		/// <summary>
		/// Constructs and loads settings from file.
		/// </summary>
		/// <param name="filename"></param>
		public Settings( string filename )
		{
			_Filename = filename;

			XmlDocument doc = new XmlDocument();
			doc.Load( filename );

			XmlNodeList list = doc.GetElementsByTagName( NODE_NAME_SETTING );
			XmlNodeList optionsList;

			XmlElement e;
			XmlElement nameEl;
			XmlElement valueEl;
			XmlElement optionEl;

			List<string> options;
			string name = null;
			string value = null;

			foreach ( XmlNode node in list )
			{
				e = node as XmlElement;

				if ( e == null )
					continue;

				nameEl = e[ NODE_NAME_SETTING_NAME ];
				valueEl = e[ NODE_NAME_SETTING_VALUE ];
				optionsList = e.GetElementsByTagName( NODE_NAME_SETTING_OPTION );

				name = nameEl.InnerText;

				if ( valueEl != null )
					value = valueEl.InnerText;

				options = new List<string>();

				foreach ( XmlNode child in optionsList )
				{
					optionEl = child as XmlElement;

					if ( optionEl != null )
					{
						options.Add( child.InnerText );
					}
				}

				if ( !String.IsNullOrEmpty( name ) && !_Dictionary.ContainsKey( name ) )
					_Dictionary.Add( name, new SettingEntry( value, options ) );
			}
		}
		#endregion

		#region Methods
		/// <summary>
		/// Saves settings to already opened file.
		/// </summary>
		public void Save()
		{
			Save( _Filename );
		}

		/// <summary>
		/// Saves settings to specific file.
		/// </summary>
		/// <param name="filename">Place to store settings at.</param>
		public void Save( string filename )
		{
			if ( File.Exists( filename ) )
				File.Delete( filename );

			XmlTextWriter writer = new XmlTextWriter( _Filename, Encoding.UTF8 );

			writer.Formatting = Formatting.Indented;
			writer.WriteProcessingInstruction( "xml", "version='1.0' encoding='UTF-8'" );
			writer.WriteStartElement( NODE_NAME_ROOT );

			foreach ( KeyValuePair<string, SettingEntry> kvp in _Dictionary )
			{
				writer.WriteStartElement( NODE_NAME_SETTING );

				writer.WriteElementString( NODE_NAME_SETTING_NAME, kvp.Key );
				writer.WriteElementString( NODE_NAME_SETTING_VALUE, kvp.Value.Value );

				foreach ( string option in kvp.Value.Options )
					writer.WriteElementString( NODE_NAME_SETTING_OPTION, option );

				writer.WriteEndElement();
			}

			writer.WriteEndElement();
			writer.Flush();
			writer.Close();
		}

		/// <summary>
		/// Returns string based setting.
		/// </summary>
		/// <param name="name">Setting name.</param>
		/// <param name="defaultValue">Default value.</param>
		/// <returns>Setting value.</returns>
		protected string GetString( string name, string defaultValue )
		{
			SettingEntry entry = null;

			if ( _Dictionary.TryGetValue( name, out entry ) )
				return entry.Value;

			return defaultValue;
		}

		/// <summary>
		/// Returns bool based setting.
		/// </summary>
		/// <param name="name">Setting name.</param>
		/// <param name="defaultValue">Default value.</param>
		/// <returns>Setting value.</returns>
		protected bool GetBool( string name, bool defaultValue )
		{
			SettingEntry entry = null;

			if ( _Dictionary.TryGetValue( name, out entry ) )
			{
				bool result;

				if ( Boolean.TryParse( entry.Value, out result ) )
					return result;
			}

			return defaultValue;
		}

		/// <summary>
		/// Sets setting value.
		/// </summary>
		/// <param name="name">Setting name.</param>
		/// <param name="value">Value to set.</param>
		protected void SetValue( string name, string value )
		{
			SettingEntry entry = null;

			if ( _Dictionary.TryGetValue( name, out entry ) )
			{
				entry.Value = value;
			}
			else
			{
				_Dictionary.Add( name, new SettingEntry( value, new List<string>() ) );
			}
		}

		/// <summary>
		/// Returns setting options.
		/// </summary>
		/// <param name="name">Setting name.</param>
		/// <returns>Setting value.</returns>
		protected List<string> GetOptions( string name )
		{
			SettingEntry entry = null;

			if ( _Dictionary.TryGetValue( name, out entry ) )
				return entry.Options;

			return null;
		}
		#endregion

		#region Constructs
		private class SettingEntry
		{
			private string m_Value;

			public string Value
			{
				get { return m_Value; }
				set { m_Value = value; }
			}

			private List<string> m_Options;

			public List<string> Options
			{
				get { return m_Options; }
			}

			public SettingEntry( string value, List<string> options )
			{
				m_Value = value;
				m_Options = options;
			}
		}
		#endregion
	}
}
