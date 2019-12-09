namespace Editor
{
	partial class PatchDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( PatchDialog ) );
			this._ButtonCancel = new System.Windows.Forms.Button();
			this._ButtonConfirm = new System.Windows.Forms.Button();
			this._Container = new System.Windows.Forms.GroupBox();
			this._CheckDefault = new System.Windows.Forms.CheckBox();
			this._CheckCount = new System.Windows.Forms.CheckBox();
			this._LabelCount = new System.Windows.Forms.Label();
			this._TextCount = new System.Windows.Forms.TextBox();
			this._ButtonOpenTo = new System.Windows.Forms.Button();
			this._TextTo = new System.Windows.Forms.TextBox();
			this._LabelTo = new System.Windows.Forms.Label();
			this._ButtonOpenFrom = new System.Windows.Forms.Button();
			this._TextFrom = new System.Windows.Forms.TextBox();
			this._LabelFrom = new System.Windows.Forms.Label();
			this._OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this._SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this._Container.SuspendLayout();
			this.SuspendLayout();
			// 
			// _ButtonCancel
			// 
			this._ButtonCancel.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._ButtonCancel.Image = global::Editor.Properties.Resources.Cross;
			this._ButtonCancel.Location = new System.Drawing.Point( 266, 187 );
			this._ButtonCancel.Name = "_ButtonCancel";
			this._ButtonCancel.Size = new System.Drawing.Size( 75, 25 );
			this._ButtonCancel.TabIndex = 5;
			this._ButtonCancel.Text = "Cancel";
			this._ButtonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this._ButtonCancel.UseVisualStyleBackColor = true;
			// 
			// _ButtonConfirm
			// 
			this._ButtonConfirm.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._ButtonConfirm.Image = global::Editor.Properties.Resources.Tick;
			this._ButtonConfirm.Location = new System.Drawing.Point( 347, 187 );
			this._ButtonConfirm.Name = "_ButtonConfirm";
			this._ButtonConfirm.Size = new System.Drawing.Size( 75, 25 );
			this._ButtonConfirm.TabIndex = 4;
			this._ButtonConfirm.Text = "Confirm";
			this._ButtonConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this._ButtonConfirm.UseVisualStyleBackColor = true;
			this._ButtonConfirm.Click += new System.EventHandler( this.ButtonConfirm_Click );
			// 
			// _Container
			// 
			this._Container.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom ) 
            | System.Windows.Forms.AnchorStyles.Left ) 
            | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._Container.Controls.Add( this._CheckDefault );
			this._Container.Controls.Add( this._CheckCount );
			this._Container.Controls.Add( this._LabelCount );
			this._Container.Controls.Add( this._TextCount );
			this._Container.Controls.Add( this._ButtonOpenTo );
			this._Container.Controls.Add( this._TextTo );
			this._Container.Controls.Add( this._LabelTo );
			this._Container.Controls.Add( this._ButtonOpenFrom );
			this._Container.Controls.Add( this._TextFrom );
			this._Container.Controls.Add( this._LabelFrom );
			this._Container.Location = new System.Drawing.Point( 12, 12 );
			this._Container.Name = "_Container";
			this._Container.Size = new System.Drawing.Size( 410, 169 );
			this._Container.TabIndex = 3;
			this._Container.TabStop = false;
			// 
			// _CheckDefault
			// 
			this._CheckDefault.AutoSize = true;
			this._CheckDefault.Checked = true;
			this._CheckDefault.CheckState = System.Windows.Forms.CheckState.Checked;
			this._CheckDefault.Location = new System.Drawing.Point( 120, 20 );
			this._CheckDefault.Name = "_CheckDefault";
			this._CheckDefault.Size = new System.Drawing.Size( 126, 17 );
			this._CheckDefault.TabIndex = 9;
			this._CheckDefault.Text = "use default client.exe";
			this._CheckDefault.UseVisualStyleBackColor = true;
			this._CheckDefault.CheckedChanged += new System.EventHandler( this.CheckDefault_CheckedChanged );
			// 
			// _CheckCount
			// 
			this._CheckCount.AutoSize = true;
			this._CheckCount.Checked = true;
			this._CheckCount.CheckState = System.Windows.Forms.CheckState.Checked;
			this._CheckCount.Location = new System.Drawing.Point( 91, 118 );
			this._CheckCount.Name = "_CheckCount";
			this._CheckCount.Size = new System.Drawing.Size( 110, 17 );
			this._CheckCount.TabIndex = 8;
			this._CheckCount.Text = "use from skills.mul";
			this._CheckCount.UseVisualStyleBackColor = true;
			this._CheckCount.CheckedChanged += new System.EventHandler( this.CheckCount_CheckedChanged );
			// 
			// _LabelCount
			// 
			this._LabelCount.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 238 ) ) );
			this._LabelCount.Location = new System.Drawing.Point( 6, 114 );
			this._LabelCount.Name = "_LabelCount";
			this._LabelCount.Size = new System.Drawing.Size( 79, 23 );
			this._LabelCount.TabIndex = 7;
			this._LabelCount.Text = "Skill count:";
			this._LabelCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _TextCount
			// 
			this._TextCount.Location = new System.Drawing.Point( 6, 140 );
			this._TextCount.Name = "_TextCount";
			this._TextCount.ReadOnly = true;
			this._TextCount.Size = new System.Drawing.Size( 100, 20 );
			this._TextCount.TabIndex = 6;
			// 
			// _ButtonOpenTo
			// 
			this._ButtonOpenTo.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._ButtonOpenTo.Image = global::Editor.Properties.Resources.Folder;
			this._ButtonOpenTo.Location = new System.Drawing.Point( 379, 88 );
			this._ButtonOpenTo.Name = "_ButtonOpenTo";
			this._ButtonOpenTo.Size = new System.Drawing.Size( 25, 25 );
			this._ButtonOpenTo.TabIndex = 5;
			this._ButtonOpenTo.UseVisualStyleBackColor = true;
			this._ButtonOpenTo.Click += new System.EventHandler( this.ButtonOpenTo_Click );
			// 
			// _TextTo
			// 
			this._TextTo.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left ) 
            | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._TextTo.Location = new System.Drawing.Point( 6, 91 );
			this._TextTo.Name = "_TextTo";
			this._TextTo.Size = new System.Drawing.Size( 367, 20 );
			this._TextTo.TabIndex = 4;
			// 
			// _LabelTo
			// 
			this._LabelTo.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left ) 
            | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._LabelTo.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 238 ) ) );
			this._LabelTo.Location = new System.Drawing.Point( 6, 65 );
			this._LabelTo.Name = "_LabelTo";
			this._LabelTo.Size = new System.Drawing.Size( 363, 23 );
			this._LabelTo.TabIndex = 3;
			this._LabelTo.Text = "Save patched client to:";
			this._LabelTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _ButtonOpenFrom
			// 
			this._ButtonOpenFrom.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._ButtonOpenFrom.Enabled = false;
			this._ButtonOpenFrom.Image = global::Editor.Properties.Resources.Folder;
			this._ButtonOpenFrom.Location = new System.Drawing.Point( 379, 39 );
			this._ButtonOpenFrom.Name = "_ButtonOpenFrom";
			this._ButtonOpenFrom.Size = new System.Drawing.Size( 25, 25 );
			this._ButtonOpenFrom.TabIndex = 2;
			this._ButtonOpenFrom.UseVisualStyleBackColor = true;
			this._ButtonOpenFrom.Click += new System.EventHandler( this.ButtonOpenFrom_Click );
			// 
			// _TextFrom
			// 
			this._TextFrom.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left ) 
            | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._TextFrom.Location = new System.Drawing.Point( 6, 42 );
			this._TextFrom.Name = "_TextFrom";
			this._TextFrom.ReadOnly = true;
			this._TextFrom.Size = new System.Drawing.Size( 367, 20 );
			this._TextFrom.TabIndex = 1;
			// 
			// _LabelFrom
			// 
			this._LabelFrom.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left ) 
            | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._LabelFrom.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 238 ) ) );
			this._LabelFrom.Location = new System.Drawing.Point( 6, 16 );
			this._LabelFrom.Name = "_LabelFrom";
			this._LabelFrom.Size = new System.Drawing.Size( 139, 23 );
			this._LabelFrom.TabIndex = 0;
			this._LabelFrom.Text = "Load client from:";
			this._LabelFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _OpenFileDialog
			// 
			this._OpenFileDialog.Filter = "Exe Files|*.exe";
			// 
			// _SaveFileDialog
			// 
			this._SaveFileDialog.Filter = "Exe Files|*.exe";
			// 
			// PatchDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 436, 221 );
			this.Controls.Add( this._ButtonCancel );
			this.Controls.Add( this._ButtonConfirm );
			this.Controls.Add( this._Container );
			this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
			this.Name = "PatchDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Patch Skill Count";
			this._Container.ResumeLayout( false );
			this._Container.PerformLayout();
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Button _ButtonCancel;
		private System.Windows.Forms.Button _ButtonConfirm;
		private System.Windows.Forms.GroupBox _Container;
		private System.Windows.Forms.Button _ButtonOpenTo;
		private System.Windows.Forms.TextBox _TextTo;
		private System.Windows.Forms.Label _LabelTo;
		private System.Windows.Forms.Button _ButtonOpenFrom;
		private System.Windows.Forms.TextBox _TextFrom;
		private System.Windows.Forms.Label _LabelFrom;
		private System.Windows.Forms.OpenFileDialog _OpenFileDialog;
		private System.Windows.Forms.SaveFileDialog _SaveFileDialog;
		private System.Windows.Forms.Label _LabelCount;
		private System.Windows.Forms.TextBox _TextCount;
		private System.Windows.Forms.CheckBox _CheckCount;
		private System.Windows.Forms.CheckBox _CheckDefault;
	}
}