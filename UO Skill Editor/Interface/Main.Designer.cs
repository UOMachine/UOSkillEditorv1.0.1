namespace Editor
{
	partial class Main
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Main ) );
			this._MainMenu = new System.Windows.Forms.MenuStrip();
			this._MenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
			this._MenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
			this._MenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
			this._Separator2 = new System.Windows.Forms.ToolStripSeparator();
			this._MenuItemPatch = new System.Windows.Forms.ToolStripMenuItem();
			this._MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			this._MenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
			this._MenuItemSettings = new System.Windows.Forms.ToolStripMenuItem();
			this._MenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
			this._MenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
			this._Groups = new System.Windows.Forms.TreeView();
			this._SkillContainer = new System.Windows.Forms.Panel();
			this._SkillPanel = new System.Windows.Forms.Panel();
			this._Data = new Editor.FastDataGridView();
			this._ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this._ColumnButton = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this._ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this._ColumnGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this._GroupAdapterBindingSource = new System.Windows.Forms.BindingSource( this.components );
			this._GroupContainer = new System.Windows.Forms.Panel();
			this._GroupPanel = new System.Windows.Forms.Panel();
			this._EditPanel = new System.Windows.Forms.Panel();
			this._TextGroup = new System.Windows.Forms.TextBox();
			this._ButtonRemove = new System.Windows.Forms.Button();
			this._ButtonAddGroup = new System.Windows.Forms.Button();
			this._ToolStrip = new System.Windows.Forms.ToolStrip();
			this._ButtonOpen = new System.Windows.Forms.ToolStripButton();
			this._ButtonSave = new System.Windows.Forms.ToolStripButton();
			this._Separator0 = new System.Windows.Forms.ToolStripSeparator();
			this._ButtonPatch = new System.Windows.Forms.ToolStripButton();
			this._Separator1 = new System.Windows.Forms.ToolStripSeparator();
			this._ButtonAddSkill = new System.Windows.Forms.ToolStripButton();
			this._ButtonRemoveSkill = new System.Windows.Forms.ToolStripButton();
			this._OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
			this._SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this._MainMenu.SuspendLayout();
			this._SkillContainer.SuspendLayout();
			this._SkillPanel.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize) ( this._Data ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize) ( this._GroupAdapterBindingSource ) ).BeginInit();
			this._GroupContainer.SuspendLayout();
			this._GroupPanel.SuspendLayout();
			this._EditPanel.SuspendLayout();
			this._ToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// _MainMenu
			// 
			this._MainMenu.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this._MenuItemFile,
            this._MenuItemEdit,
            this._MenuItemHelp} );
			this._MainMenu.Location = new System.Drawing.Point( 0, 0 );
			this._MainMenu.Name = "_MainMenu";
			this._MainMenu.Size = new System.Drawing.Size( 632, 24 );
			this._MainMenu.TabIndex = 0;
			this._MainMenu.Text = "_Menu";
			// 
			// _MenuItemFile
			// 
			this._MenuItemFile.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this._MenuItemOpen,
            this._MenuItemSave,
            this._Separator2,
            this._MenuItemPatch,
            this._MenuItemExit} );
			this._MenuItemFile.Name = "_MenuItemFile";
			this._MenuItemFile.Size = new System.Drawing.Size( 37, 20 );
			this._MenuItemFile.Text = "File";
			// 
			// _MenuItemOpen
			// 
			this._MenuItemOpen.Image = global::Editor.Properties.Resources.Folder;
			this._MenuItemOpen.Name = "_MenuItemOpen";
			this._MenuItemOpen.Size = new System.Drawing.Size( 104, 22 );
			this._MenuItemOpen.Text = "Open";
			this._MenuItemOpen.Click += new System.EventHandler( this.MenuItemOpen_Click );
			// 
			// _MenuItemSave
			// 
			this._MenuItemSave.Image = global::Editor.Properties.Resources.Disk;
			this._MenuItemSave.Name = "_MenuItemSave";
			this._MenuItemSave.Size = new System.Drawing.Size( 104, 22 );
			this._MenuItemSave.Text = "Save";
			this._MenuItemSave.Click += new System.EventHandler( this.MenuItemSave_Click );
			// 
			// _Separator2
			// 
			this._Separator2.Name = "_Separator2";
			this._Separator2.Size = new System.Drawing.Size( 101, 6 );
			// 
			// _MenuItemPatch
			// 
			this._MenuItemPatch.Image = global::Editor.Properties.Resources.Patch;
			this._MenuItemPatch.Name = "_MenuItemPatch";
			this._MenuItemPatch.Size = new System.Drawing.Size( 104, 22 );
			this._MenuItemPatch.Text = "Patch";
			this._MenuItemPatch.Click += new System.EventHandler( this.MenuItemPatch_Click );
			// 
			// _MenuItemExit
			// 
			this._MenuItemExit.Name = "_MenuItemExit";
			this._MenuItemExit.Size = new System.Drawing.Size( 104, 22 );
			this._MenuItemExit.Text = "Exit";
			this._MenuItemExit.Click += new System.EventHandler( this.MenuItemExit_Click );
			// 
			// _MenuItemEdit
			// 
			this._MenuItemEdit.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this._MenuItemSettings} );
			this._MenuItemEdit.Name = "_MenuItemEdit";
			this._MenuItemEdit.Size = new System.Drawing.Size( 39, 20 );
			this._MenuItemEdit.Text = "Edit";
			// 
			// _MenuItemSettings
			// 
			this._MenuItemSettings.Image = global::Editor.Properties.Resources.Wrench;
			this._MenuItemSettings.Name = "_MenuItemSettings";
			this._MenuItemSettings.Size = new System.Drawing.Size( 116, 22 );
			this._MenuItemSettings.Text = "Settings";
			this._MenuItemSettings.Click += new System.EventHandler( this.MenuItemSettings_Click );
			// 
			// _MenuItemHelp
			// 
			this._MenuItemHelp.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this._MenuItemAbout} );
			this._MenuItemHelp.Name = "_MenuItemHelp";
			this._MenuItemHelp.Size = new System.Drawing.Size( 44, 20 );
			this._MenuItemHelp.Text = "Help";
			// 
			// _MenuItemAbout
			// 
			this._MenuItemAbout.Image = global::Editor.Properties.Resources.Help;
			this._MenuItemAbout.Name = "_MenuItemAbout";
			this._MenuItemAbout.Size = new System.Drawing.Size( 152, 22 );
			this._MenuItemAbout.Text = "About";
			this._MenuItemAbout.Click += new System.EventHandler( this.MenuItemAbout_Click );
			// 
			// _Groups
			// 
			this._Groups.AllowDrop = true;
			this._Groups.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Groups.Dock = System.Windows.Forms.DockStyle.Fill;
			this._Groups.FullRowSelect = true;
			this._Groups.Location = new System.Drawing.Point( 0, 0 );
			this._Groups.Name = "_Groups";
			this._Groups.Size = new System.Drawing.Size( 198, 426 );
			this._Groups.TabIndex = 3;
			this._Groups.ItemDrag += new System.Windows.Forms.ItemDragEventHandler( this.Groups_ItemDrag );
			this._Groups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler( this.Groups_AfterSelect );
			this._Groups.DragDrop += new System.Windows.Forms.DragEventHandler( this.Groups_DragDrop );
			this._Groups.DragEnter += new System.Windows.Forms.DragEventHandler( this.Groups_DragEnter );
			this._Groups.KeyDown += new System.Windows.Forms.KeyEventHandler( this.Groups_KeyDown );
			// 
			// _SkillContainer
			// 
			this._SkillContainer.Controls.Add( this._SkillPanel );
			this._SkillContainer.Controls.Add( this._GroupContainer );
			this._SkillContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this._SkillContainer.Location = new System.Drawing.Point( 0, 47 );
			this._SkillContainer.Name = "_SkillContainer";
			this._SkillContainer.Size = new System.Drawing.Size( 632, 466 );
			this._SkillContainer.TabIndex = 4;
			// 
			// _SkillPanel
			// 
			this._SkillPanel.Controls.Add( this._Data );
			this._SkillPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this._SkillPanel.Location = new System.Drawing.Point( 0, 0 );
			this._SkillPanel.Name = "_SkillPanel";
			this._SkillPanel.Size = new System.Drawing.Size( 432, 466 );
			this._SkillPanel.TabIndex = 4;
			// 
			// _Data
			// 
			this._Data.AllowUserToAddRows = false;
			this._Data.AllowUserToDeleteRows = false;
			this._Data.AllowUserToResizeRows = false;
			this._Data.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this._Data.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this._ColumnID,
            this._ColumnButton,
            this._ColumnName,
            this._ColumnGroup} );
			this._Data.Dock = System.Windows.Forms.DockStyle.Fill;
			this._Data.Location = new System.Drawing.Point( 0, 0 );
			this._Data.Name = "_Data";
			this._Data.RowHeadersVisible = false;
			this._Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this._Data.Size = new System.Drawing.Size( 432, 466 );
			this._Data.TabIndex = 2;
			this._Data.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler( this.Data_CellValidating );
			this._Data.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler( this.Data_CellValueChanged );
			this._Data.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler( this.Data_EditingControlShowing );
			this._Data.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler( this.Data_RowValidated );
			this._Data.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler( this.Data_UserAddedRow );
			this._Data.KeyDown += new System.Windows.Forms.KeyEventHandler( this.Data_KeyDown );
			// 
			// _ColumnID
			// 
			this._ColumnID.HeaderText = "ID";
			this._ColumnID.Name = "_ColumnID";
			this._ColumnID.Width = 50;
			// 
			// _ColumnButton
			// 
			this._ColumnButton.HeaderText = "Button";
			this._ColumnButton.Name = "_ColumnButton";
			this._ColumnButton.Width = 50;
			// 
			// _ColumnName
			// 
			this._ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this._ColumnName.HeaderText = "Name";
			this._ColumnName.Name = "_ColumnName";
			// 
			// _ColumnGroup
			// 
			this._ColumnGroup.DataSource = this._GroupAdapterBindingSource;
			this._ColumnGroup.DisplayMember = "Name";
			this._ColumnGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._ColumnGroup.HeaderText = "Group";
			this._ColumnGroup.Name = "_ColumnGroup";
			this._ColumnGroup.ValueMember = "ID";
			this._ColumnGroup.Width = 150;
			// 
			// _GroupAdapterBindingSource
			// 
			this._GroupAdapterBindingSource.DataMember = "Groups";
			this._GroupAdapterBindingSource.DataSource = typeof( Editor.SkillAdapter );
			// 
			// _GroupContainer
			// 
			this._GroupContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this._GroupContainer.Controls.Add( this._GroupPanel );
			this._GroupContainer.Controls.Add( this._EditPanel );
			this._GroupContainer.Dock = System.Windows.Forms.DockStyle.Right;
			this._GroupContainer.Location = new System.Drawing.Point( 432, 0 );
			this._GroupContainer.Name = "_GroupContainer";
			this._GroupContainer.Size = new System.Drawing.Size( 200, 466 );
			this._GroupContainer.TabIndex = 3;
			// 
			// _GroupPanel
			// 
			this._GroupPanel.Controls.Add( this._Groups );
			this._GroupPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this._GroupPanel.Location = new System.Drawing.Point( 0, 0 );
			this._GroupPanel.Name = "_GroupPanel";
			this._GroupPanel.Size = new System.Drawing.Size( 198, 426 );
			this._GroupPanel.TabIndex = 5;
			// 
			// _EditPanel
			// 
			this._EditPanel.Controls.Add( this._TextGroup );
			this._EditPanel.Controls.Add( this._ButtonRemove );
			this._EditPanel.Controls.Add( this._ButtonAddGroup );
			this._EditPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this._EditPanel.Location = new System.Drawing.Point( 0, 426 );
			this._EditPanel.Name = "_EditPanel";
			this._EditPanel.Size = new System.Drawing.Size( 198, 38 );
			this._EditPanel.TabIndex = 4;
			// 
			// _TextGroup
			// 
			this._TextGroup.Location = new System.Drawing.Point( 5, 9 );
			this._TextGroup.Name = "_TextGroup";
			this._TextGroup.Size = new System.Drawing.Size( 137, 20 );
			this._TextGroup.TabIndex = 2;
			this._TextGroup.TextChanged += new System.EventHandler( this.TextGroup_TextChanged );
			// 
			// _ButtonRemove
			// 
			this._ButtonRemove.Image = global::Editor.Properties.Resources.Minus;
			this._ButtonRemove.Location = new System.Drawing.Point( 170, 6 );
			this._ButtonRemove.Name = "_ButtonRemove";
			this._ButtonRemove.Size = new System.Drawing.Size( 25, 25 );
			this._ButtonRemove.TabIndex = 1;
			this._ButtonRemove.UseVisualStyleBackColor = true;
			this._ButtonRemove.Click += new System.EventHandler( this.ButtonRemoveGroup_Click );
			// 
			// _ButtonAddGroup
			// 
			this._ButtonAddGroup.Image = global::Editor.Properties.Resources.Plus;
			this._ButtonAddGroup.Location = new System.Drawing.Point( 144, 6 );
			this._ButtonAddGroup.Name = "_ButtonAddGroup";
			this._ButtonAddGroup.Size = new System.Drawing.Size( 25, 25 );
			this._ButtonAddGroup.TabIndex = 0;
			this._ButtonAddGroup.UseVisualStyleBackColor = true;
			this._ButtonAddGroup.Click += new System.EventHandler( this.ButtonAddGroup_Click );
			// 
			// _ToolStrip
			// 
			this._ToolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this._ButtonOpen,
            this._ButtonSave,
            this._Separator0,
            this._ButtonPatch,
            this._Separator1,
            this._ButtonAddSkill,
            this._ButtonRemoveSkill} );
			this._ToolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this._ToolStrip.Location = new System.Drawing.Point( 0, 24 );
			this._ToolStrip.Name = "_ToolStrip";
			this._ToolStrip.Size = new System.Drawing.Size( 632, 23 );
			this._ToolStrip.TabIndex = 5;
			// 
			// _ButtonOpen
			// 
			this._ButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._ButtonOpen.Image = global::Editor.Properties.Resources.Folder;
			this._ButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._ButtonOpen.Name = "_ButtonOpen";
			this._ButtonOpen.Size = new System.Drawing.Size( 23, 20 );
			this._ButtonOpen.Click += new System.EventHandler( this.MenuItemOpen_Click );
			// 
			// _ButtonSave
			// 
			this._ButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._ButtonSave.Image = global::Editor.Properties.Resources.Disk;
			this._ButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._ButtonSave.Name = "_ButtonSave";
			this._ButtonSave.Size = new System.Drawing.Size( 23, 20 );
			this._ButtonSave.Click += new System.EventHandler( this.MenuItemSave_Click );
			// 
			// _Separator0
			// 
			this._Separator0.Name = "_Separator0";
			this._Separator0.Size = new System.Drawing.Size( 6, 23 );
			// 
			// _ButtonPatch
			// 
			this._ButtonPatch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._ButtonPatch.Image = global::Editor.Properties.Resources.Patch;
			this._ButtonPatch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._ButtonPatch.Name = "_ButtonPatch";
			this._ButtonPatch.Size = new System.Drawing.Size( 23, 20 );
			this._ButtonPatch.Click += new System.EventHandler( this.MenuItemPatch_Click );
			// 
			// _Separator1
			// 
			this._Separator1.Name = "_Separator1";
			this._Separator1.Size = new System.Drawing.Size( 6, 23 );
			// 
			// _ButtonAddSkill
			// 
			this._ButtonAddSkill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._ButtonAddSkill.Image = global::Editor.Properties.Resources.Plus;
			this._ButtonAddSkill.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._ButtonAddSkill.Name = "_ButtonAddSkill";
			this._ButtonAddSkill.Size = new System.Drawing.Size( 23, 20 );
			this._ButtonAddSkill.Click += new System.EventHandler( this.ButtonAddSkill_Click );
			// 
			// _ButtonRemoveSkill
			// 
			this._ButtonRemoveSkill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this._ButtonRemoveSkill.Image = global::Editor.Properties.Resources.Minus;
			this._ButtonRemoveSkill.ImageTransparentColor = System.Drawing.Color.Magenta;
			this._ButtonRemoveSkill.Name = "_ButtonRemoveSkill";
			this._ButtonRemoveSkill.Size = new System.Drawing.Size( 23, 20 );
			this._ButtonRemoveSkill.Click += new System.EventHandler( this.ButtonRemoveSkill_Click );
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 632, 513 );
			this.Controls.Add( this._SkillContainer );
			this.Controls.Add( this._ToolStrip );
			this.Controls.Add( this._MainMenu );
			this.DoubleBuffered = true;
			this.Icon = ( (System.Drawing.Icon) ( resources.GetObject( "$this.Icon" ) ) );
			this.MainMenuStrip = this._MainMenu;
			this.Name = "Main";
			this.Text = "UO Skill Editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.Main_FormClosing );
			this._MainMenu.ResumeLayout( false );
			this._MainMenu.PerformLayout();
			this._SkillContainer.ResumeLayout( false );
			this._SkillPanel.ResumeLayout( false );
			( (System.ComponentModel.ISupportInitialize) ( this._Data ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize) ( this._GroupAdapterBindingSource ) ).EndInit();
			this._GroupContainer.ResumeLayout( false );
			this._GroupPanel.ResumeLayout( false );
			this._EditPanel.ResumeLayout( false );
			this._EditPanel.PerformLayout();
			this._ToolStrip.ResumeLayout( false );
			this._ToolStrip.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip _MainMenu;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemFile;
		private Editor.FastDataGridView _Data;
		private System.Windows.Forms.TreeView _Groups;
		private System.Windows.Forms.Panel _SkillContainer;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemOpen;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemSave;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemEdit;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemSettings;
		private System.Windows.Forms.Panel _GroupContainer;
		private System.Windows.Forms.Panel _EditPanel;
		private System.Windows.Forms.Panel _GroupPanel;
		private System.Windows.Forms.Button _ButtonRemove;
		private System.Windows.Forms.Button _ButtonAddGroup;
		private System.Windows.Forms.TextBox _TextGroup;
		private System.Windows.Forms.Panel _SkillPanel;
		private System.Windows.Forms.BindingSource _GroupAdapterBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn _ColumnID;
		private System.Windows.Forms.DataGridViewCheckBoxColumn _ColumnButton;
		private System.Windows.Forms.DataGridViewTextBoxColumn _ColumnName;
		private System.Windows.Forms.DataGridViewComboBoxColumn _ColumnGroup;
		private System.Windows.Forms.ToolStrip _ToolStrip;
		private System.Windows.Forms.ToolStripButton _ButtonAddSkill;
		private System.Windows.Forms.ToolStripButton _ButtonRemoveSkill;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemHelp;
		private System.Windows.Forms.ToolStripButton _ButtonOpen;
		private System.Windows.Forms.ToolStripButton _ButtonSave;
		private System.Windows.Forms.ToolStripSeparator _Separator0;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemAbout;
		private System.Windows.Forms.ToolStripSeparator _Separator2;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemPatch;
		private System.Windows.Forms.ToolStripSeparator _Separator1;
		private System.Windows.Forms.ToolStripButton _ButtonPatch;
		private System.Windows.Forms.ToolStripMenuItem _MenuItemExit;
		private System.Windows.Forms.OpenFileDialog _OpenFileDialog;
		private System.Windows.Forms.SaveFileDialog _SaveFileDialog;
	}
}

