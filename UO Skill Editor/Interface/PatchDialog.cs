using System;
using System.IO;
using System.Windows.Forms;

namespace Editor
{
	/// <summary>
	/// Patch dialog.
	/// </summary>
	public partial class PatchDialog : Form
	{
		#region Properties
		/// <summary>
		/// Gets path to the client to patch.
		/// </summary>
		public string ClientSource
		{
			get { return _TextFrom.Text; }
		}

		/// <summary>
		/// Gets path where patched client will be saved.
		/// </summary>
		public string ClientDestination
		{
			get { return _TextTo.Text; }
		}

		private int _SkillCount;

		/// <summary>
		/// Gets or sets skill count.
		/// </summary>
		public int SkillCount
		{
			get
			{
				byte count = 0;

				if ( Byte.TryParse( _TextCount.Text, out count ) )
					return count;

				return -1;
			}
			set
			{
				_SkillCount = value;
				_TextCount.Text = _SkillCount.ToString();
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new instnace of patchDialog.
		/// </summary>
		public PatchDialog()
		{
			InitializeComponent();
			Initialize();
		}
		#endregion

		#region Methods
		private void Initialize()
		{
			Tag = Globals.LanguageManager.GetString( "PatchDialog_Title" );

			_LabelFrom.Text = Globals.LanguageManager.GetString( "PatchDialog_Label_From" );
			_LabelTo.Text = Globals.LanguageManager.GetString( "PatchDialog_Label_To" );
			_LabelCount.Text = Globals.LanguageManager.GetString( "PatchDialog_Label_Count" );
			_CheckCount.Text = Globals.LanguageManager.GetString( "PatchDialog_Check_Count" );

			_ButtonCancel.Text = Globals.LanguageManager.GetString( "PatchDialog_Button_Cancel" );
			_ButtonConfirm.Text = Globals.LanguageManager.GetString( "PatchDialog_Button_Confirm" );

			_OpenFileDialog.Title = Globals.LanguageManager.GetString( "PatchDialog_OpenFile_Title" );
			_SaveFileDialog.Title = Globals.LanguageManager.GetString( "PatchDialog_SaveFile_Title" );

			_TextFrom.Text = Globals.Settings.DefaultExePath;
			_TextTo.Text = GetPatchedFileName( _TextFrom.Text );
		}

		private void ShowError( string key, params object[] args )
		{
			string message = Globals.LanguageManager.GetString( key, args );
			string title = Globals.LanguageManager.GetString( "MainForm_Error_Title" );

			MessageBox.Show( message, title, MessageBoxButtons.OK, MessageBoxIcon.Error );
		}

		private string GetPatchedFileName( string path )
		{
			string folder = Path.GetDirectoryName( path );
			string fileName = Path.GetFileNameWithoutExtension( path );
			string ext = Path.GetExtension( path );

			return String.Format( "{0}.patched{1}", Path.Combine( folder, fileName ), ext );
		}

		#region Events
		private void ButtonOpenFrom_Click( object sender, EventArgs e )
		{
			_OpenFileDialog.FileName = _TextFrom.Text;

			if ( _OpenFileDialog.ShowDialog() == DialogResult.OK )
			{
				_TextFrom.Text = _OpenFileDialog.FileName;
				_TextTo.Text = GetPatchedFileName( _TextFrom.Text );
			}
		}

		private void ButtonOpenTo_Click( object sender, EventArgs e )
		{
			_SaveFileDialog.FileName = _TextTo.Text;

			if ( _SaveFileDialog.ShowDialog() == DialogResult.OK )
				_TextTo.Text = _SaveFileDialog.FileName;
		}

		private void ButtonConfirm_Click( object sender, EventArgs e )
		{
			if ( !File.Exists( _TextFrom.Text ) )
			{
				ShowError( "MainForm_Error_FileNotFound", _TextFrom.Text );
			}
			else if ( !Directory.Exists( Path.GetDirectoryName( _TextTo.Text ) ) )
			{
				ShowError( "MainForm_Error_FolderNotFound", _TextFrom.Text );
			}
			else if ( String.IsNullOrEmpty( Path.GetFileName( _TextTo.Text ) ) )
			{
				ShowError( "MainForm_Error_InvalidPath" );
			}
			else if ( SkillCount < 0 || SkillCount > Byte.MaxValue )
			{
				ShowError( "MainForm_Error_InvalidSkillCount" );
			}
			else
			{
				DialogResult = DialogResult.OK;
			}
		}

		private void CheckCount_CheckedChanged( object sender, EventArgs e )
		{
			if ( _CheckCount.Checked )
			{
				_TextCount.Text = _SkillCount.ToString();
				_TextCount.ReadOnly = true;
			}
			else
			{
				_TextCount.ReadOnly = false;
			}
		}

		private void CheckDefault_CheckedChanged( object sender, EventArgs e )
		{
			if ( _CheckDefault.Checked )
			{
				_TextFrom.Text = Globals.Settings.DefaultExePath;
				_TextTo.Text = GetPatchedFileName( _TextFrom.Text );
				_TextFrom.ReadOnly = true;
				_ButtonOpenFrom.Enabled = false;
			}
			else
			{
				_TextFrom.ReadOnly = false;
				_ButtonOpenFrom.Enabled = true;
			}
		}
		#endregion
		#endregion
	}
}
