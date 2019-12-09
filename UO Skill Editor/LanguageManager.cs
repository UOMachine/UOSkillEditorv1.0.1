using System;
using System.Xml;
using System.Collections.Generic;

namespace Editor
{
	/// <summary>
	/// Represents localized string collection.
	/// </summary>
	public class LanguageManager
	{
		#region Constants
		private const string NODE_NAME_ROOT = "language";
		private const string ATTRIBUTE_NAME_TITLE = "title";
		private const string ATTRIBUTE_NAME_KEY = "key";
		#endregion

		#region Properties
		private string m_LanguageName;
 
		/// <summary>
		/// Determines language name.
		/// </summary>
		public string LanguageName
		{
			get { return m_LanguageName; }
		}

		private Dictionary<string, string> m_Language = new Dictionary<string,string>();
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new instnace of english LanguageManager.
		/// </summary>
		public LanguageManager() : this( "English.xml" )
		{
		}

		/// <summary>
		/// Constructs a new instance of LanguageManager.
		/// </summary>
		/// <param name="fileName">File to load definitions from.</param>
		public LanguageManager( string fileName )
		{
			m_Language.Clear();

			string key = null;
			string value = null;

			XmlDocument doc = new XmlDocument();
			doc.Load( fileName );

			XmlElement root = doc[ NODE_NAME_ROOT ];
			XmlElement e = null;

			if ( root != null )
			{
				m_LanguageName = root.GetAttribute( ATTRIBUTE_NAME_TITLE );

				foreach ( XmlNode node in root.ChildNodes )
				{
					e = node as XmlElement;

					if ( e != null )
					{
						key = e.GetAttribute( ATTRIBUTE_NAME_KEY );
						value = node.InnerText;

						if ( String.IsNullOrEmpty( key ) || m_Language.ContainsKey( key ) )
							throw new XmlException( "Empty or duplicate language key." );

						m_Language.Add( key, value );
					}
				}
			}
			else
				throw new XmlException( String.Format( "{0} is not a language file.", fileName ) );
		}
		#endregion

		#region Methods
		/// <summary>
		/// Returns string bound to <paramref name="key"/>.
		/// </summary>
		/// <param name="key">Key bound.</param>
		/// <param name="args">Parameters used to construct string.</param>
		/// <returns>String bound to <paramref name="key"/>.</returns>
		public string GetString( string key, params object[] args )
		{
			string value;

			if ( m_Language.TryGetValue( key, out value ) )
			{
				if ( args.Length > 0 )
					return String.Format( value, args );

				return value;
			}

			return String.Empty;
		}
		#endregion
	}
}
