namespace Editor
{
	partial class AboutDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( AboutDialog ) );
			this._Logo = new System.Windows.Forms.PictureBox();
			this._LabelTitle = new System.Windows.Forms.Label();
			this._Panel = new System.Windows.Forms.Panel();
			this._LabelVersion = new System.Windows.Forms.Label();
			this._ButtonOK = new System.Windows.Forms.Button();
			this._LabelCopyright = new System.Windows.Forms.Label();
			this._LabelSubtitle = new System.Windows.Forms.Label();
			this._LabelDescription = new System.Windows.Forms.LinkLabel();
			( (System.ComponentModel.ISupportInitialize) ( this._Logo ) ).BeginInit();
			this._Panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// _Logo
			// 
			this._Logo.Image = global::Editor.Properties.Resources.Ultima;
			this._Logo.Location = new System.Drawing.Point( 3, 3 );
			this._Logo.Name = "_Logo";
			this._Logo.Size = new System.Drawing.Size( 80, 80 );
			this._Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this._Logo.TabIndex = 0;
			this._Logo.TabStop = false;
			// 
			// _LabelTitle
			// 
			this._LabelTitle.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left ) 
            | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._LabelTitle.AutoSize = true;
			this._LabelTitle.Font = new System.Drawing.Font( "Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 238 ) ) );
			this._LabelTitle.ForeColor = System.Drawing.SystemColors.Control;
			this._LabelTitle.Location = new System.Drawing.Point( 89, 31 );
			this._LabelTitle.Name = "_LabelTitle";
			this._LabelTitle.Size = new System.Drawing.Size( 153, 25 );
			this._LabelTitle.TabIndex = 1;
			this._LabelTitle.Text = "UO Skill Editor";
			this._LabelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _Panel
			// 
			this._Panel.BackColor = System.Drawing.Color.DimGray;
			this._Panel.Controls.Add( this._LabelVersion );
			this._Panel.Controls.Add( this._LabelTitle );
			this._Panel.Controls.Add( this._Logo );
			this._Panel.Dock = System.Windows.Forms.DockStyle.Top;
			this._Panel.Location = new System.Drawing.Point( 0, 0 );
			this._Panel.Name = "_Panel";
			this._Panel.Size = new System.Drawing.Size( 384, 86 );
			this._Panel.TabIndex = 3;
			// 
			// _LabelVersion
			// 
			this._LabelVersion.AutoSize = true;
			this._LabelVersion.ForeColor = System.Drawing.SystemColors.Control;
			this._LabelVersion.Location = new System.Drawing.Point( 91, 56 );
			this._LabelVersion.Name = "_LabelVersion";
			this._LabelVersion.Size = new System.Drawing.Size( 40, 13 );
			this._LabelVersion.TabIndex = 2;
			this._LabelVersion.Text = "1.0.0.0";
			// 
			// _ButtonOK
			// 
			this._ButtonOK.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._ButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this._ButtonOK.Location = new System.Drawing.Point( 297, 149 );
			this._ButtonOK.Name = "_ButtonOK";
			this._ButtonOK.Size = new System.Drawing.Size( 75, 23 );
			this._ButtonOK.TabIndex = 4;
			this._ButtonOK.Text = "OK";
			this._ButtonOK.UseVisualStyleBackColor = true;
			// 
			// _LabelCopyright
			// 
			this._LabelCopyright.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._LabelCopyright.AutoSize = true;
			this._LabelCopyright.Location = new System.Drawing.Point( 154, 154 );
			this._LabelCopyright.Name = "_LabelCopyright";
			this._LabelCopyright.Size = new System.Drawing.Size( 137, 13 );
			this._LabelCopyright.TabIndex = 5;
			this._LabelCopyright.Text = "Copyright 2010 by Malganis";
			// 
			// _LabelSubtitle
			// 
			this._LabelSubtitle.AutoSize = true;
			this._LabelSubtitle.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 238 ) ) );
			this._LabelSubtitle.Location = new System.Drawing.Point( 12, 91 );
			this._LabelSubtitle.Margin = new System.Windows.Forms.Padding( 3, 5, 3, 0 );
			this._LabelSubtitle.Name = "_LabelSubtitle";
			this._LabelSubtitle.Size = new System.Drawing.Size( 90, 13 );
			this._LabelSubtitle.TabIndex = 6;
			this._LabelSubtitle.Text = "UO Skill Editor";
			// 
			// _LabelDescription
			// 
			this._LabelDescription.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom ) 
            | System.Windows.Forms.AnchorStyles.Left ) 
            | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._LabelDescription.LinkArea = new System.Windows.Forms.LinkArea( 77, 55 );
			this._LabelDescription.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this._LabelDescription.LinkColor = System.Drawing.Color.FromArgb( ( (int) ( ( (byte) ( 192 ) ) ) ), ( (int) ( ( (byte) ( 64 ) ) ) ), ( (int) ( ( (byte) ( 0 ) ) ) ) );
			this._LabelDescription.Location = new System.Drawing.Point( 13, 108 );
			this._LabelDescription.Name = "_LabelDescription";
			this._LabelDescription.Size = new System.Drawing.Size( 359, 38 );
			this._LabelDescription.TabIndex = 7;
			this._LabelDescription.TabStop = true;
			this._LabelDescription.Text = "This program is used for editing Ultima Online skills. Check for updates on: http" +
    "://code.google.com/p/mondains-legacy/downloads/list.";
			this._LabelDescription.UseCompatibleTextRendering = true;
			this._LabelDescription.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler( this.LabelDescription_LinkClicked );
			// 
			// AboutDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 384, 184 );
			this.Controls.Add( this._LabelDescription );
			this.Controls.Add( this._LabelSubtitle );
			this.Controls.Add( this._LabelCopyright );
			this.Controls.Add( this._ButtonOK );
			this.Controls.Add( this._Panel );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "About";
			( (System.ComponentModel.ISupportInitialize) ( this._Logo ) ).EndInit();
			this._Panel.ResumeLayout( false );
			this._Panel.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox _Logo;
		private System.Windows.Forms.Label _LabelTitle;
		private System.Windows.Forms.Panel _Panel;
		private System.Windows.Forms.Button _ButtonOK;
		private System.Windows.Forms.Label _LabelVersion;
		private System.Windows.Forms.Label _LabelCopyright;
		private System.Windows.Forms.Label _LabelSubtitle;
		private System.Windows.Forms.LinkLabel _LabelDescription;

	}
}