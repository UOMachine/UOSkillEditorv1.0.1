namespace Editor
{
	partial class OpenSkillsDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( OpenSkillsDialog ) );
			this._Container = new System.Windows.Forms.GroupBox();
			this._LabelDefault = new System.Windows.Forms.Label();
			this._TextDefault = new System.Windows.Forms.CheckBox();
			this._LabelOpenAll = new System.Windows.Forms.Label();
			this._TextGrp = new System.Windows.Forms.TextBox();
			this._LabelGrp = new System.Windows.Forms.Label();
			this._TextMul = new System.Windows.Forms.TextBox();
			this._LabelMul = new System.Windows.Forms.Label();
			this._TextIdx = new System.Windows.Forms.TextBox();
			this._LabelIdx = new System.Windows.Forms.Label();
			this._OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this._FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this._ButtonCancel = new System.Windows.Forms.Button();
			this._ButtonConfirm = new System.Windows.Forms.Button();
			this._ButtonOpenAll = new System.Windows.Forms.Button();
			this._ButtonOpenGrp = new System.Windows.Forms.Button();
			this._ButtonOpenMul = new System.Windows.Forms.Button();
			this._ButtonOpenIdx = new System.Windows.Forms.Button();
			this._Container.SuspendLayout();
			this.SuspendLayout();
			// 
			// _Container
			// 
			this._Container.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom ) 
            | System.Windows.Forms.AnchorStyles.Left ) 
            | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._Container.Controls.Add( this._LabelDefault );
			this._Container.Controls.Add( this._TextDefault );
			this._Container.Controls.Add( this._LabelOpenAll );
			this._Container.Controls.Add( this._ButtonOpenAll );
			this._Container.Controls.Add( this._ButtonOpenGrp );
			this._Container.Controls.Add( this._TextGrp );
			this._Container.Controls.Add( this._LabelGrp );
			this._Container.Controls.Add( this._ButtonOpenMul );
			this._Container.Controls.Add( this._TextMul );
			this._Container.Controls.Add( this._LabelMul );
			this._Container.Controls.Add( this._ButtonOpenIdx );
			this._Container.Controls.Add( this._TextIdx );
			this._Container.Controls.Add( this._LabelIdx );
			this._Container.Location = new System.Drawing.Point( 12, 12 );
			this._Container.Name = "_Container";
			this._Container.Size = new System.Drawing.Size( 470, 126 );
			this._Container.TabIndex = 0;
			this._Container.TabStop = false;
			// 
			// _LabelDefault
			// 
			this._LabelDefault.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ( (byte) ( 238 ) ) );
			this._LabelDefault.Location = new System.Drawing.Point( 6, 94 );
			this._LabelDefault.Name = "_LabelDefault";
			this._LabelDefault.Size = new System.Drawing.Size( 100, 23 );
			this._LabelDefault.TabIndex = 12;
			this._LabelDefault.Text = "Use default paths:";
			this._LabelDefault.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// _TextDefault
			// 
			this._TextDefault.AutoSize = true;
			this._TextDefault.Checked = true;
			this._TextDefault.CheckState = System.Windows.Forms.CheckState.Checked;
			this._TextDefault.Location = new System.Drawing.Point( 112, 99 );
			this._TextDefault.Name = "_TextDefault";
			this._TextDefault.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._TextDefault.Size = new System.Drawing.Size( 15, 14 );
			this._TextDefault.TabIndex = 11;
			this._TextDefault.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this._TextDefault.UseVisualStyleBackColor = true;
			this._TextDefault.CheckedChanged += new System.EventHandler( this.TextDefault_Changed );
			// 
			// _LabelOpenAll
			// 
			this._LabelOpenAll.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._LabelOpenAll.Location = new System.Drawing.Point( 278, 94 );
			this._LabelOpenAll.Name = "_LabelOpenAll";
			this._LabelOpenAll.Size = new System.Drawing.Size( 155, 23 );
			this._LabelOpenAll.TabIndex = 10;
			this._LabelOpenAll.Text = "Load from folder";
			this._LabelOpenAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// _TextGrp
			// 
			this._TextGrp.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left ) 
            | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._TextGrp.Location = new System.Drawing.Point( 112, 70 );
			this._TextGrp.Name = "_TextGrp";
			this._TextGrp.Size = new System.Drawing.Size( 321, 20 );
			this._TextGrp.TabIndex = 7;
			// 
			// _LabelGrp
			// 
			this._LabelGrp.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 238 ) ) );
			this._LabelGrp.Location = new System.Drawing.Point( 6, 68 );
			this._LabelGrp.Name = "_LabelGrp";
			this._LabelGrp.Size = new System.Drawing.Size( 100, 23 );
			this._LabelGrp.TabIndex = 6;
			this._LabelGrp.Text = "skillgrp.mul:";
			this._LabelGrp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// _TextMul
			// 
			this._TextMul.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left ) 
            | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._TextMul.Location = new System.Drawing.Point( 112, 44 );
			this._TextMul.Name = "_TextMul";
			this._TextMul.Size = new System.Drawing.Size( 321, 20 );
			this._TextMul.TabIndex = 4;
			// 
			// _LabelMul
			// 
			this._LabelMul.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 238 ) ) );
			this._LabelMul.Location = new System.Drawing.Point( 6, 42 );
			this._LabelMul.Name = "_LabelMul";
			this._LabelMul.Size = new System.Drawing.Size( 100, 23 );
			this._LabelMul.TabIndex = 3;
			this._LabelMul.Text = "skills.mul:";
			this._LabelMul.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// _TextIdx
			// 
			this._TextIdx.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left ) 
            | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._TextIdx.Location = new System.Drawing.Point( 112, 18 );
			this._TextIdx.Name = "_TextIdx";
			this._TextIdx.Size = new System.Drawing.Size( 321, 20 );
			this._TextIdx.TabIndex = 1;
			// 
			// _LabelIdx
			// 
			this._LabelIdx.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 238 ) ) );
			this._LabelIdx.Location = new System.Drawing.Point( 6, 16 );
			this._LabelIdx.Name = "_LabelIdx";
			this._LabelIdx.Size = new System.Drawing.Size( 100, 23 );
			this._LabelIdx.TabIndex = 0;
			this._LabelIdx.Text = "skills.idx:";
			this._LabelIdx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// _OpenFileDialog
			// 
			this._OpenFileDialog.CheckFileExists = false;
			this._OpenFileDialog.Filter = "Skill index|skills.idx|Skill data|skills.mul|Skill groups|skillgrp.mul";
			// 
			// _FolderBrowserDialog
			// 
			this._FolderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
			// 
			// _ButtonCancel
			// 
			this._ButtonCancel.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._ButtonCancel.Image = global::Editor.Properties.Resources.Cross;
			this._ButtonCancel.Location = new System.Drawing.Point( 326, 144 );
			this._ButtonCancel.Name = "_ButtonCancel";
			this._ButtonCancel.Size = new System.Drawing.Size( 75, 25 );
			this._ButtonCancel.TabIndex = 2;
			this._ButtonCancel.Text = "Cancel";
			this._ButtonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this._ButtonCancel.UseVisualStyleBackColor = true;
			// 
			// _ButtonConfirm
			// 
			this._ButtonConfirm.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._ButtonConfirm.Image = global::Editor.Properties.Resources.Tick;
			this._ButtonConfirm.Location = new System.Drawing.Point( 407, 144 );
			this._ButtonConfirm.Name = "_ButtonConfirm";
			this._ButtonConfirm.Size = new System.Drawing.Size( 75, 25 );
			this._ButtonConfirm.TabIndex = 1;
			this._ButtonConfirm.Text = "Confirm";
			this._ButtonConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this._ButtonConfirm.UseVisualStyleBackColor = true;
			this._ButtonConfirm.Click += new System.EventHandler( this.ButtonConfirm_Click );
			// 
			// _ButtonOpenAll
			// 
			this._ButtonOpenAll.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._ButtonOpenAll.Image = global::Editor.Properties.Resources.Folder;
			this._ButtonOpenAll.Location = new System.Drawing.Point( 439, 93 );
			this._ButtonOpenAll.Name = "_ButtonOpenAll";
			this._ButtonOpenAll.Size = new System.Drawing.Size( 25, 25 );
			this._ButtonOpenAll.TabIndex = 9;
			this._ButtonOpenAll.UseVisualStyleBackColor = true;
			this._ButtonOpenAll.Click += new System.EventHandler( this.ButtonOpenAll_Click );
			// 
			// _ButtonOpenGrp
			// 
			this._ButtonOpenGrp.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._ButtonOpenGrp.Image = global::Editor.Properties.Resources.Folder;
			this._ButtonOpenGrp.Location = new System.Drawing.Point( 439, 67 );
			this._ButtonOpenGrp.Name = "_ButtonOpenGrp";
			this._ButtonOpenGrp.Size = new System.Drawing.Size( 25, 25 );
			this._ButtonOpenGrp.TabIndex = 8;
			this._ButtonOpenGrp.UseVisualStyleBackColor = true;
			this._ButtonOpenGrp.Click += new System.EventHandler( this.ButtonOpenGrp_Click );
			// 
			// _ButtonOpenMul
			// 
			this._ButtonOpenMul.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._ButtonOpenMul.Image = global::Editor.Properties.Resources.Folder;
			this._ButtonOpenMul.Location = new System.Drawing.Point( 439, 41 );
			this._ButtonOpenMul.Name = "_ButtonOpenMul";
			this._ButtonOpenMul.Size = new System.Drawing.Size( 25, 25 );
			this._ButtonOpenMul.TabIndex = 5;
			this._ButtonOpenMul.UseVisualStyleBackColor = true;
			this._ButtonOpenMul.Click += new System.EventHandler( this.ButtonOpenMul_Click );
			// 
			// _ButtonOpenIdx
			// 
			this._ButtonOpenIdx.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._ButtonOpenIdx.Image = global::Editor.Properties.Resources.Folder;
			this._ButtonOpenIdx.Location = new System.Drawing.Point( 439, 15 );
			this._ButtonOpenIdx.Name = "_ButtonOpenIdx";
			this._ButtonOpenIdx.Size = new System.Drawing.Size( 25, 25 );
			this._ButtonOpenIdx.TabIndex = 2;
			this._ButtonOpenIdx.UseVisualStyleBackColor = true;
			this._ButtonOpenIdx.Click += new System.EventHandler( this.ButtonOpenIdx_Click );
			// 
			// OpenSkillsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 494, 181 );
			this.Controls.Add( this._ButtonCancel );
			this.Controls.Add( this._ButtonConfirm );
			this.Controls.Add( this._Container );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OpenSkillsDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Open Skills";
			this._Container.ResumeLayout( false );
			this._Container.PerformLayout();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.GroupBox _Container;
		private System.Windows.Forms.Button _ButtonConfirm;
		private System.Windows.Forms.Button _ButtonCancel;
		private System.Windows.Forms.Button _ButtonOpenIdx;
		private System.Windows.Forms.TextBox _TextIdx;
		private System.Windows.Forms.Label _LabelIdx;
		private System.Windows.Forms.Button _ButtonOpenGrp;
		private System.Windows.Forms.TextBox _TextGrp;
		private System.Windows.Forms.Label _LabelGrp;
		private System.Windows.Forms.Button _ButtonOpenMul;
		private System.Windows.Forms.TextBox _TextMul;
		private System.Windows.Forms.Label _LabelMul;
		private System.Windows.Forms.Label _LabelOpenAll;
		private System.Windows.Forms.Button _ButtonOpenAll;
		private System.Windows.Forms.OpenFileDialog _OpenFileDialog;
		private System.Windows.Forms.FolderBrowserDialog _FolderBrowserDialog;
		private System.Windows.Forms.Label _LabelDefault;
		private System.Windows.Forms.CheckBox _TextDefault;

	}
}