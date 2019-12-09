namespace Editor
{
	partial class GeneralPage
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._TextLanguage = new System.Windows.Forms.ComboBox();
			this._LabelCurrentLangauge = new System.Windows.Forms.Label();
			this._LabelLanguage = new System.Windows.Forms.Label();
			this._OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this._FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// _TextLanguage
			// 
			this._TextLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._TextLanguage.FormattingEnabled = true;
			this._TextLanguage.Location = new System.Drawing.Point( 166, 32 );
			this._TextLanguage.Name = "_TextLanguage";
			this._TextLanguage.Size = new System.Drawing.Size( 121, 21 );
			this._TextLanguage.TabIndex = 5;
			// 
			// _LabelCurrentLangauge
			// 
			this._LabelCurrentLangauge.Location = new System.Drawing.Point( 8, 31 );
			this._LabelCurrentLangauge.Margin = new System.Windows.Forms.Padding( 5 );
			this._LabelCurrentLangauge.Name = "_LabelCurrentLangauge";
			this._LabelCurrentLangauge.Size = new System.Drawing.Size( 150, 20 );
			this._LabelCurrentLangauge.TabIndex = 4;
			this._LabelCurrentLangauge.Text = "Current language:";
			this._LabelCurrentLangauge.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// _LabelLanguage
			// 
			this._LabelLanguage.AutoSize = true;
			this._LabelLanguage.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
			this._LabelLanguage.Location = new System.Drawing.Point( 5, 10 );
			this._LabelLanguage.Margin = new System.Windows.Forms.Padding( 5, 10, 5, 3 );
			this._LabelLanguage.Name = "_LabelLanguage";
			this._LabelLanguage.Size = new System.Drawing.Size( 63, 13 );
			this._LabelLanguage.TabIndex = 3;
			this._LabelLanguage.Text = "Language";
			this._LabelLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// GeneralPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add( this._TextLanguage );
			this.Controls.Add( this._LabelCurrentLangauge );
			this.Controls.Add( this._LabelLanguage );
			this.Name = "GeneralPage";
			this.Size = new System.Drawing.Size( 538, 310 );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox _TextLanguage;
		private System.Windows.Forms.Label _LabelCurrentLangauge;
		private System.Windows.Forms.Label _LabelLanguage;
		private System.Windows.Forms.OpenFileDialog _OpenFileDialog;
		private System.Windows.Forms.FolderBrowserDialog _FolderBrowserDialog;
	}
}
