namespace Editor
{
	partial class SettingsDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( SettingsDialog ) );
			this._ButtonReset = new System.Windows.Forms.Button();
			this._SplitMenu = new System.Windows.Forms.SplitContainer();
			this._TreeView = new System.Windows.Forms.TreeView();
			this._SplitContent = new System.Windows.Forms.SplitContainer();
			this._ButtonCancel = new System.Windows.Forms.Button();
			this._ButtonSave = new System.Windows.Forms.Button();
			this._Worker = new System.ComponentModel.BackgroundWorker();
			this._SplitMenu.Panel1.SuspendLayout();
			this._SplitMenu.Panel2.SuspendLayout();
			this._SplitMenu.SuspendLayout();
			this._SplitContent.Panel2.SuspendLayout();
			this._SplitContent.SuspendLayout();
			this.SuspendLayout();
			// 
			// _ButtonReset
			// 
			this._ButtonReset.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
			this._ButtonReset.Image = global::Editor.Properties.Resources.Reset;
			this._ButtonReset.Location = new System.Drawing.Point( 9, 13 );
			this._ButtonReset.Name = "_ButtonReset";
			this._ButtonReset.Size = new System.Drawing.Size( 75, 25 );
			this._ButtonReset.TabIndex = 2;
			this._ButtonReset.Text = "Reset";
			this._ButtonReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this._ButtonReset.UseVisualStyleBackColor = true;
			this._ButtonReset.Click += new System.EventHandler( this.ButtonDefault_Click );
			// 
			// _SplitMenu
			// 
			this._SplitMenu.Dock = System.Windows.Forms.DockStyle.Fill;
			this._SplitMenu.IsSplitterFixed = true;
			this._SplitMenu.Location = new System.Drawing.Point( 0, 0 );
			this._SplitMenu.Name = "_SplitMenu";
			// 
			// _SplitMenu.Panel1
			// 
			this._SplitMenu.Panel1.Controls.Add( this._TreeView );
			// 
			// _SplitMenu.Panel2
			// 
			this._SplitMenu.Panel2.Controls.Add( this._SplitContent );
			this._SplitMenu.Size = new System.Drawing.Size( 594, 293 );
			this._SplitMenu.SplitterDistance = 198;
			this._SplitMenu.TabIndex = 1;
			// 
			// _TreeView
			// 
			this._TreeView.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom ) 
            | System.Windows.Forms.AnchorStyles.Left ) 
            | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._TreeView.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte) ( 0 ) ) );
			this._TreeView.ItemHeight = 18;
			this._TreeView.Location = new System.Drawing.Point( 12, 12 );
			this._TreeView.Name = "_TreeView";
			this._TreeView.Size = new System.Drawing.Size( 183, 269 );
			this._TreeView.TabIndex = 0;
			// 
			// _SplitContent
			// 
			this._SplitContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this._SplitContent.IsSplitterFixed = true;
			this._SplitContent.Location = new System.Drawing.Point( 0, 0 );
			this._SplitContent.Name = "_SplitContent";
			this._SplitContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// _SplitContent.Panel2
			// 
			this._SplitContent.Panel2.Controls.Add( this._ButtonReset );
			this._SplitContent.Panel2.Controls.Add( this._ButtonCancel );
			this._SplitContent.Panel2.Controls.Add( this._ButtonSave );
			this._SplitContent.Size = new System.Drawing.Size( 392, 293 );
			this._SplitContent.SplitterDistance = 239;
			this._SplitContent.TabIndex = 0;
			// 
			// _ButtonCancel
			// 
			this._ButtonCancel.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._ButtonCancel.Image = global::Editor.Properties.Resources.Cross;
			this._ButtonCancel.Location = new System.Drawing.Point( 224, 13 );
			this._ButtonCancel.Name = "_ButtonCancel";
			this._ButtonCancel.Size = new System.Drawing.Size( 75, 25 );
			this._ButtonCancel.TabIndex = 1;
			this._ButtonCancel.Text = "Cancel";
			this._ButtonCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this._ButtonCancel.UseVisualStyleBackColor = true;
			// 
			// _ButtonSave
			// 
			this._ButtonSave.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this._ButtonSave.Image = global::Editor.Properties.Resources.Disk;
			this._ButtonSave.Location = new System.Drawing.Point( 305, 13 );
			this._ButtonSave.Name = "_ButtonSave";
			this._ButtonSave.Size = new System.Drawing.Size( 75, 25 );
			this._ButtonSave.TabIndex = 0;
			this._ButtonSave.Text = "Save";
			this._ButtonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this._ButtonSave.UseVisualStyleBackColor = true;
			this._ButtonSave.Click += new System.EventHandler( this.ButtonSave_Click );
			// 
			// _Worker
			// 
			this._Worker.DoWork += new System.ComponentModel.DoWorkEventHandler( this.Worker_DoWork );
			this._Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler( this.Worker_RunWorkerCompleted );
			// 
			// SettingsDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 594, 293 );
			this.Controls.Add( this._SplitMenu );
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SettingsDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SettingsDialog";
			this._SplitMenu.Panel1.ResumeLayout( false );
			this._SplitMenu.Panel2.ResumeLayout( false );
			this._SplitMenu.ResumeLayout( false );
			this._SplitContent.Panel2.ResumeLayout( false );
			this._SplitContent.ResumeLayout( false );
			this.ResumeLayout( false );

		}

		#endregion

		private System.Windows.Forms.Button _ButtonReset;
		private System.Windows.Forms.SplitContainer _SplitMenu;
		private System.Windows.Forms.TreeView _TreeView;
		private System.Windows.Forms.SplitContainer _SplitContent;
		private System.Windows.Forms.Button _ButtonCancel;
		private System.Windows.Forms.Button _ButtonSave;
		private System.ComponentModel.BackgroundWorker _Worker;
	}
}