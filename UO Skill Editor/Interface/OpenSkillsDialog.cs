using System;
using System.IO;
using System.Windows.Forms;
using System.ComponentModel;

namespace Editor
{
	/// <summary>
	/// Prompts the user to open skill files.
	/// </summary>
	public partial class OpenSkillsDialog : Form
	{
		#region Properties
		/// <summary>
		/// Gets or sets skills.idx path.
		/// </summary>
		public string SkillsIdx
		{
			get { return _TextIdx.Text; }
			set { _TextIdx.Text = value; }
		}

		/// <summary>
		/// Gets or sets skills.mul path.
		/// </summary>
		public string SkillsMul
		{
			get { return _TextMul.Text; }
			set { _TextMul.Text = value; }
		}

		/// <summary>
		/// Gets or sets skillgrp.mul path.
		/// </summary>
		public string SkillsGrp
		{
			get { return _TextGrp.Text; }
			set { _TextGrp.Text = value; }
		}

		/// <summary>
		/// Determine wheter to store paths in settings file.
		/// </summary>
		public bool UseAsDefault
		{
			get { return _TextDefault.Checked; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new instance of OpenSkillsDialog.
		/// </summary>
		public OpenSkillsDialog()
		{
			InitializeComponent();
			Initialize();
		}
		#endregion

		#region Methods
		private void Initialize()
		{
			Text = Globals.LanguageManager.GetString( "SaveSkillsDialog_Title" );

			_LabelIdx.Text = Globals.LanguageManager.GetString( "SaveSkillsDialog_SkillsIdx" );
			_LabelMul.Text = Globals.LanguageManager.GetString( "SaveSkillsDialog_SkillsMul" );
			_LabelGrp.Text = Globals.LanguageManager.GetString( "SaveSkillsDialog_GroupsMul" );
			_LabelDefault.Text = Globals.LanguageManager.GetString( "SaveSkillsDialog_UseDefault" );
			_LabelOpenAll.Text = Globals.LanguageManager.GetString( "SaveSkillsDialog_LoadFromFolder" );
			_ButtonCancel.Text = Globals.LanguageManager.GetString( "SaveSkillsDialog_Button_Cancel" );
			_ButtonConfirm.Text = Globals.LanguageManager.GetString( "SaveSkillsDialog_Button_Confirm" );

			Toggle();
		}

		private void Toggle()
		{
			_TextIdx.ReadOnly = _TextDefault.Checked;
			_TextMul.ReadOnly = _TextDefault.Checked;
			_TextGrp.ReadOnly = _TextDefault.Checked;

			if ( _TextDefault.Checked )
			{
				_TextIdx.Text = Globals.Settings.DefaultSkillIndexes;
				_TextMul.Text = Globals.Settings.DefaultSkillData;
				_TextGrp.Text = Globals.Settings.DefaultSkillGroups;
			}

			_ButtonOpenIdx.Enabled = !_TextDefault.Checked;
			_ButtonOpenMul.Enabled = !_TextDefault.Checked;
			_ButtonOpenGrp.Enabled = !_TextDefault.Checked;
			_ButtonOpenAll.Enabled = !_TextDefault.Checked;
		}

		private void ShowError( string key, params object[] args )
		{
			string message = Globals.LanguageManager.GetString( key, args );
			string title = Globals.LanguageManager.GetString( "MainForm_Error_Title" );

			MessageBox.Show( message, title, MessageBoxButtons.OK, MessageBoxIcon.Error );
		}

		#region Events
		private void TextDefault_Changed( object sender, EventArgs e )
		{
			Toggle();
		}

		private void ButtonOpenIdx_Click( object sender, EventArgs e )
		{
			_OpenFileDialog.Filter = "Skill indexes|skills.idx";
			_OpenFileDialog.FileName = _TextIdx.Text;

			if ( _OpenFileDialog.ShowDialog() == DialogResult.OK )
				_TextIdx.Text = _OpenFileDialog.FileName;
		}

		private void ButtonOpenMul_Click( object sender, EventArgs e )
		{
			_OpenFileDialog.Filter = "Skill data|skills.mul";
			_OpenFileDialog.FileName = _TextMul.Text;

			if ( _OpenFileDialog.ShowDialog() == DialogResult.OK )
				_TextMul.Text = _OpenFileDialog.FileName;
		}

		private void ButtonOpenGrp_Click( object sender, EventArgs e )
		{
			_OpenFileDialog.Filter = "Skill groups|skillgrp.mul";
			_OpenFileDialog.FileName = _TextGrp.Text;

			if ( _OpenFileDialog.ShowDialog() == DialogResult.OK )
				_TextGrp.Text = _OpenFileDialog.FileName;
		}

		private void ButtonOpenAll_Click( object sender, EventArgs e )
		{
			if ( _FolderBrowserDialog.ShowDialog() == DialogResult.OK )
			{
				_TextIdx.Text = Path.Combine( _FolderBrowserDialog.SelectedPath, "skills.idx" );
				_TextMul.Text = Path.Combine( _FolderBrowserDialog.SelectedPath, "skills.mul" );
				_TextGrp.Text = Path.Combine( _FolderBrowserDialog.SelectedPath, "skillgrp.mul" );
			}
		}

		private void ButtonConfirm_Click( object sender, EventArgs e )
		{
			if ( !File.Exists( _TextIdx.Text ) )
			{
				ShowError( "MainForm_Error_FileNotFound", _TextIdx.Text );
			}
			else if ( !File.Exists( _TextMul.Text ) )
			{
				ShowError( "MainForm_Error_FileNotFound", _TextMul.Text );
			}
			else if ( !File.Exists( _TextGrp.Text ) )
			{
				ShowError( "MainForm_Error_FileNotFound", _TextGrp.Text );
			}
			else
			{
				DialogResult = DialogResult.OK;
			}
		}
		#endregion
		#endregion
	}
}
