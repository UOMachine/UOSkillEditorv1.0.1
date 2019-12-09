using System;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace Editor
{
	/// <summary>
	/// About dialog.
	/// </summary>
	public partial class AboutDialog : Form
	{
		#region Constructors
		/// <summary>
		/// Constructs a new instance of AboutDialog.
		/// </summary>
		public AboutDialog()
		{
			InitializeComponent();
			Initialize();
		}
		#endregion

		#region Methods
		private void Initialize()
		{
			Text = Globals.LanguageManager.GetString( "AboutDialog_Title" );

			_LabelTitle.Text = Globals.LanguageManager.GetString( "MainForm_Title" );
			_LabelSubtitle.Text = Globals.LanguageManager.GetString( "MainForm_Title" );
			_LabelCopyright.Text = Globals.LanguageManager.GetString( "AboutDialog_Copyright" );
			_LabelDescription.Text = Globals.LanguageManager.GetString( "AboutDialog_Description" );

			_LabelVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}

		private void LabelDescription_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
		{
			string link = _LabelDescription.Text.Substring( e.Link.Start, e.Link.Length );

			Process.Start( link );
		}
		#region Events
		#endregion
		#endregion
	}
}
