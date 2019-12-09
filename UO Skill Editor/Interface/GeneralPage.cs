using System;
using System.IO;
using System.Windows.Forms;

namespace Editor
{
	/// <summary>
	/// Represents general page.
	/// </summary>
	public partial class GeneralPage : UserControl, ISettingsPage
	{
		#region Constructors
		/// <summary>
		/// Constructs a new instance of GeneralPage.
		/// </summary>
		public GeneralPage()
		{
			InitializeComponent();
			Initialize();
		}
		#endregion

		#region Methods
		private void Initialize()
		{
			Tag = Globals.LanguageManager.GetString( "SettingsDialog_Title" );

			_LabelLanguage.Text = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_Language" );
			_LabelCurrentLangauge.Text = Globals.LanguageManager.GetString( "SettingsDialog_GeneralPage_CurrentLanguage" );

			_TextLanguage.Items.AddRange( Globals.Settings.LanguageOptions.ToArray() );
			_TextLanguage.SelectedItem = Globals.Settings.Language;
		}

		#region ISettingsPage
		/// <summary>
		/// Implements ISettingsPage.Reset function. Used to reset values to default.
		/// </summary>
		public void Reset()
		{
			_TextLanguage.Text = Globals.Settings.DefaultLanguage;
		}

		/// <summary>
		/// Implements ISettingsPage.Verify function. Used to validate values.
		/// </summary>
		public bool Verify()
		{
			return true;
		}

		/// <summary>
		/// Implements ISettingsPage.Save function. Used to reset values to default.
		/// </summary>
		public void Save()
		{
			Globals.Settings.Language = _TextLanguage.Text;
		}
		#endregion
		#endregion
	}
}
