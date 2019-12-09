using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Editor
{
	/// <summary>
	/// Setting dialog.
	/// </summary>
	public partial class SettingsDialog : Form
	{
		#region Properties
		private UserControl _Current;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new instance of SettingsDialog.
		/// </summary>
		public SettingsDialog()
		{
			InitializeComponent();
			Initialize();
		}
		#endregion

		#region Methods
		private void Initialize()
		{
			_Current = null;
			UserControl page = null;
			
			foreach ( string name in Globals.Settings.SettingPages )
			{
				try
				{
					page = (UserControl) Activator.CreateInstance( Type.GetType( name, true ) );
				}
				catch ( Exception ex )
				{
					Globals.Logger.LogException( ex );
					ShowError( "SettingsDialog_Error_InvalidPage", name );
					return;
				}

				TreeNode node = new TreeNode( page.Tag.ToString() );
				node.Tag = page;
				_TreeView.Nodes.Add( node );

				if ( _Current == null )
				{
					_Current = page;
				}
				else
					page.Visible = false;

				_SplitContent.Panel1.Controls.Add( page );
				page.Location = new Point( page.Margin.Left, page.Margin.Top );
				page.Size = new Size( _SplitContent.Panel1.Width - page.Margin.Right - page.Margin.Left, _SplitContent.Panel1.Height - page.Margin.Top - page.Margin.Bottom );
			}

			Text = Globals.LanguageManager.GetString( "SettingsDialog_Title" );
			_ButtonReset.Text = Globals.LanguageManager.GetString( "SettingsDialog_Button_Reset" );
			_ButtonCancel.Text = Globals.LanguageManager.GetString( "SettingsDialog_Button_Cancel" );
			_ButtonSave.Text = Globals.LanguageManager.GetString( "SettingsDialog_Button_Save" );
		}

		private void ShowError( string key, params object[] args )
		{
			string message = Globals.LanguageManager.GetString( key, args );
			string title = Globals.LanguageManager.GetString( "MainForm_Error_Title" );

			MessageBox.Show( message, title, MessageBoxButtons.OK, MessageBoxIcon.Error );
		}

		#region Events
		private void TreeView_AfterSelect( object sender, TreeViewEventArgs e )
		{
			if ( e.Node != null && e.Node.Tag is UserControl )
			{
				if ( _Current is ISettingsPage && !( (ISettingsPage) _Current ).Verify() )
					return;

				_Current.Visible = false;
				_Current = (UserControl) e.Node.Tag;
				_Current.Visible = true;
			}
		}

		private void ButtonDefault_Click( object sender, EventArgs e )
		{
			foreach ( TreeNode node in _TreeView.Nodes )
			{
				if ( node.Tag is ISettingsPage )
					( (ISettingsPage) node.Tag ).Reset();
			}
		}

		private void ButtonSave_Click( object sender, EventArgs e )
		{
			if ( _Current is ISettingsPage && !( (ISettingsPage) _Current ).Verify() )
				return;

			foreach ( TreeNode node in _TreeView.Nodes )
			{
				if ( node.Tag is ISettingsPage )
					( (ISettingsPage) node.Tag ).Save();
			}

			Cursor = Cursors.WaitCursor;
			_Worker.RunWorkerAsync();
		}

		private void Worker_DoWork( object sender, DoWorkEventArgs e )
		{
			Globals.Settings.Save();
		}

		private void Worker_RunWorkerCompleted( object sender, RunWorkerCompletedEventArgs e )
		{
			Cursor = Cursors.Default;

			if ( e.Error != null )
			{
				Globals.Logger.LogException( e.Error );
				ShowError( "SettingsDialog_Error_Saving" );
			}
			else
				Hide();
		}
		#endregion
		#endregion
	}
}
