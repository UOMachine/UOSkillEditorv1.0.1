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
	/// Main form dialog.
	/// </summary>
	public partial class Main : Form
	{
		#region Properties
		private AboutDialog _About;
		private OpenSkillsDialog _OpenSkills;
		private SaveSkillsDialog _SaveSkills;
		private SettingsDialog _Settings;
		private PatchDialog _Patch;
		private SkillAdapter _Adapter;

		private bool _Modified;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new instance of Main.
		/// </summary>
		public Main()
		{
			InitializeComponent();
			Initialize();
		}
		#endregion

		#region Methods
		private void Initialize()
		{
			_About = new AboutDialog();
			_OpenSkills = new OpenSkillsDialog();
			_SaveSkills = new SaveSkillsDialog();
			_Settings = new SettingsDialog();
			_Patch = new PatchDialog();
			_Adapter = new SkillAdapter();

			_Modified = false;

			Text = Globals.LanguageManager.GetString( "MainForm_Title" );
			_MenuItemFile.Text = Globals.LanguageManager.GetString( "MainForm_Menu_File" );
			_MenuItemOpen.Text = Globals.LanguageManager.GetString( "MainForm_Menu_File_Open" );
			_MenuItemSave.Text = Globals.LanguageManager.GetString( "MainForm_Menu_File_Save" );
			_MenuItemPatch.Text = Globals.LanguageManager.GetString( "MainForm_Menu_File_Patch" );
			_MenuItemExit.Text = Globals.LanguageManager.GetString( "MainForm_Menu_File_Exit" );
			_MenuItemEdit.Text = Globals.LanguageManager.GetString( "MainForm_Menu_Edit" );
			_MenuItemSettings.Text = Globals.LanguageManager.GetString( "MainForm_Menu_Edit_Settings" );
			_MenuItemHelp.Text = Globals.LanguageManager.GetString( "MainForm_Menu_Help" );
			_MenuItemAbout.Text = Globals.LanguageManager.GetString( "MainForm_Menu_Help_About" );

			_ColumnID.HeaderText = Globals.LanguageManager.GetString( "MainForm_SkillColumn_ID" );
			_ColumnButton.HeaderText = Globals.LanguageManager.GetString( "MainForm_SkillColumn_Button" );
			_ColumnName.HeaderText = Globals.LanguageManager.GetString( "MainForm_SkillColumn_Name" );
			_ColumnGroup.HeaderText = Globals.LanguageManager.GetString( "MainForm_SkillColumn_Group" );

			_GroupAdapterBindingSource.DataSource = _Adapter;
		}

		private void SortGroupSkills()
		{
			for ( int i = 0; i < _Groups.Nodes.Count; i++ )
			{
				TreeNode node = _Groups.Nodes[ i ];

				if ( node.Tag is SkillGroup )
				{
					int index = node.Nodes.Count - 1;

					while ( index >= 0 )
					{
						TreeNode best = node.Nodes[ index ];
						int bestIndex = -1;

						for ( int j = index - 1; j >= 0; j-- )
						{
							TreeNode child = node.Nodes[ j ];

							if ( String.Compare( best.Text, child.Text ) < 0 )
							{
								best = child;
								bestIndex = j;
							}
						}

						if ( best != node.Nodes[ index ] )
						{
							TreeNode temp = node.Nodes[ index ];

							temp.Remove();
							node.Nodes.Insert( bestIndex, temp );

							best.Remove();
							node.Nodes.Insert( index, best );
						}

						index--;
					}
				}
			}
		}

		private DialogResult ShowOptions( string key, params object[] args )
		{
			string title = Globals.LanguageManager.GetString( "MainForm_Prompt_Title" );
			string message = Globals.LanguageManager.GetString( key, args );

			return MessageBox.Show( message, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question );
		}

		private DialogResult ShowPrompt( string key, params object[] args )
		{
			string title = Globals.LanguageManager.GetString( "MainForm_Prompt_Title" );
			string message = Globals.LanguageManager.GetString( key, args );

			return MessageBox.Show( message, title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question );
		}

		private void ShowError( string key, params object[] args )
		{
			string message = Globals.LanguageManager.GetString( key, args );
			string title = Globals.LanguageManager.GetString( "MainForm_Error_Title" );

			MessageBox.Show( message, title, MessageBoxButtons.OK, MessageBoxIcon.Error );
		}

		private void ShowMessage( string key, params object[] args )
		{
			string message = Globals.LanguageManager.GetString( key, args );
			string title = Globals.LanguageManager.GetString( "MainForm_Message_Title" );

			MessageBox.Show( message, title, MessageBoxButtons.OK, MessageBoxIcon.Information );
		}

		private void Open( string idx, string mul, string grp )
		{
			_Adapter.Clear();
			_Adapter.Load( idx, mul, grp );

			_Data.Rows.Clear();
			_Groups.Nodes.Clear();

			foreach ( Skill skill in _Adapter.Skills )
			{
				int row = _Data.Rows.Add( skill.ID, skill.Button, skill.Name, skill.Group.ID );

				_Data.Rows[ row ].Tag = skill;
			}

			TreeNode node = null;
			TreeNode subnode = null;

			foreach ( SkillGroup group in _Adapter.Groups )
			{
				node = new TreeNode( group.Name );
				node.Tag = group;

				foreach ( Skill skill in _Adapter.Skills )
				{
					if ( skill.Group == group )
					{
						subnode = new TreeNode( skill.Name );
						subnode.Tag = skill;

						node.Nodes.Add( subnode );
					}
				}

				_Groups.Nodes.Add( node );
			}

			SortGroupSkills();

			_Modified = false;
		}

		private void DeleteSeletedSkills()
		{
			DataGridViewSelectedRowCollection selected = _Data.SelectedRows;

			if ( selected.Count > 0 )
			{
				_Modified = true;

				for ( int j = selected.Count - 1; j >= 0; j-- )
				{
					Skill skill = (Skill) selected[ j ].Tag;

					for ( int i = _Data.RowCount - 1; i >= 0; i-- )
					{
						Skill rowSkill = (Skill) _Data.Rows[ i ].Tag;

						if ( rowSkill.ID == skill.ID )
						{
							_Data.Rows.RemoveAt( i );
							break;
						}
					}
					
					for ( int i = 0; i < _Groups.Nodes.Count; i++ )
					{
						TreeNode node = _Groups.Nodes[ i ];

						foreach ( TreeNode child in node.Nodes )
						{
							if ( skill.ID == ( (Skill) child.Tag ).ID )
								child.Remove();
						}
					}

					_Adapter.Skills.Remove( skill );
				}
			}
		}

		private void DeleteSelectedGroup()
		{
			TreeNode node = _Groups.SelectedNode;

			if ( node != null && node.Tag is SkillGroup )
			{
				SkillGroup group = (SkillGroup) node.Tag;

				node.Remove();
				_Modified = true;

				for ( int i = 0; i < _Data.Rows.Count; i++ )
				{
					DataGridViewCell cell = _Data[ 3, i ];

					if ( cell.Value is int )
					{
						int groupID = (int) cell.Value;

						if ( groupID == group.ID )
							cell.Value = 0;
					}
				}

				_Adapter.Groups.Remove( group );
			}
		}

		private void AddNewGroup()
		{
			SkillGroup group = new SkillGroup( _Adapter.Groups.Count, "New Group" );
			TreeNode node = new TreeNode( group.Name );
			node.Tag = group;

			bool added = false;

			for ( int i = 0; i < _Groups.Nodes.Count && !added; i++ )
			{
				if ( _Groups.Nodes[ i ].Tag is Skill )
				{
					_Groups.Nodes.Insert( i, node );
					added = true;
				}
			}

			if ( !added )
				_Groups.Nodes.Add( node );

			_Adapter.Groups.Add( group );
			_Modified = true;
		}

		private void AddNewSkill()
		{
			Skill skill = new Skill( _Adapter.Skills.Count );
			skill.Group = _Adapter.Ungrouped;
			skill.Name = "New Skill";

			_Adapter.Skills.Add( skill );

			_Data.Rows.Add( skill.ID, skill.Button, skill.Name, skill.Group.ID );
			_Data.Rows[ _Data.RowCount - 1 ].Tag = skill;

			TreeNode node = new TreeNode( skill.Name );
			node.Tag = skill;
			_Groups.Nodes.Add( node );

			SortGroupSkills();
		}

		private void MoveSkill( Skill skill, SkillGroup group )
		{
			TreeNode source = null;
			TreeNode destination = null;

			for ( int i = 0; i < _Groups.Nodes.Count; i++ )
			{
				TreeNode node = _Groups.Nodes[ i ];
				SkillGroup tagGroup = (SkillGroup) node.Tag;

				if ( tagGroup == group )
					destination = node;

				for ( int j = 0; j < node.Nodes.Count; j++ )
				{
					TreeNode subnode = node.Nodes[ j ];
					Skill tagSkill = (Skill) subnode.Tag;

					if ( tagSkill == skill )
						source = subnode;
				}
			}

			if ( source != null )
			{
				TreeNode clone = (TreeNode) source.Clone();

				if ( destination != null )
					destination.Nodes.Add( clone );
				else
					_Groups.Nodes.Add( clone );

				source.Remove();

				for ( int i = 0; i < _Data.Rows.Count; i++ )
				{
					DataGridViewRow row = _Data.Rows[ i ];
					Skill tagSkill = (Skill) row.Tag;

					if ( skill == tagSkill )
					{
						row.Cells[ 3 ].Value = group.ID;
						break;
					}
				}

				skill.Group = group;
				_Modified = true;
			}

			SortGroupSkills();
		}

		#region Events
		private void MenuItemAbout_Click( object sender, EventArgs e )
		{
			_About.ShowDialog();
		}

		private void MenuItemPatch_Click( object sender, EventArgs e )
		{
			_Patch.SkillCount = _Adapter.Skills.Count;

			if ( _Patch.ShowDialog() == DialogResult.OK )
			{
				Cursor = Cursors.WaitCursor;

				try
				{
					PatchResult result = _Adapter.PatchClient( _Patch.ClientSource, _Patch.ClientDestination, _Patch.SkillCount );
					Cursor = Cursors.Default;

					if ( result == PatchResult.BaseAddressNotFound )
					{
						ShowError( "MainForm_Error_MissingBaseAddress" );
					}
					else if ( result == PatchResult.SkillCountNotFound )
					{
						ShowError( "MainForm_Error_MissingSkillCount" );
					}
					else
					{
						ShowMessage( "MainForm_Message_PatchingSuccessful" );
					}
				}
				catch ( Exception ex )
				{
					Cursor = Cursors.Default;
					Globals.Logger.LogException( ex );
					ShowError( "MainForm_Error_Patching" );
				}
			}
		}

		private void MenuItemExit_Click( object sender, EventArgs e )
		{
			Close();
		}

		private void ButtonAddGroup_Click( object sender, EventArgs e )
		{
			try
			{
				if ( _Adapter.Groups.Count < SkillGroup.MAX_GROUP_COUNT )
					AddNewGroup();
				else
					ShowError( "MainForm_Error_OverGroupCap" );
			}
			catch ( Exception ex )
			{
				Globals.Logger.LogException( ex );
				ShowError( "MainForm_Error_AddingGroup" );
			}
		}

		private void ButtonRemoveGroup_Click( object sender, EventArgs e )
		{
			if ( _Groups.SelectedNode != null && _Groups.SelectedNode.Tag is SkillGroup )
			{
				DialogResult result = ShowPrompt( "MainForm_Prompt_Delete" );

				if ( result == DialogResult.OK )
				{
					try
					{
						DeleteSelectedGroup();
					}
					catch ( Exception ex )
					{
						Globals.Logger.LogException( ex );
						ShowError( "MainForm_Error_DeletingItems" );
					}
				}
			}
		}

		private void ButtonAddSkill_Click( object sender, EventArgs e )
		{
			try
			{
				if ( _Adapter.Skills.Count < Byte.MaxValue )
					AddNewSkill();
				else
					ShowError( "MainForm_Error_OverSkillCap" );
			}
			catch ( Exception ex )
			{
				Globals.Logger.LogException( ex );
				ShowError( "MainForm_Error_AddingSkill" );
			}
		}

		private void ButtonRemoveSkill_Click( object sender, EventArgs e )
		{
			if ( _Data.SelectedRows.Count > 0 )
			{
				DialogResult result = ShowPrompt( "MainForm_Prompt_Delete" );

				if ( result == DialogResult.OK )
				{
					try
					{
						DeleteSeletedSkills();
					}
					catch ( Exception ex )
					{
						Globals.Logger.LogException( ex );
						ShowError( "MainForm_Error_DeletingItems" );
					}
				}
			}
		}

		private void Data_KeyDown( object sender, KeyEventArgs e )
		{
			if ( e.KeyCode == Keys.Delete && ShowPrompt( "MainForm_Prompt_Delete" ) == DialogResult.OK )
			{
				try
				{
					DeleteSeletedSkills();
				}
				catch ( Exception ex )
				{
					Globals.Logger.LogException( ex );
					ShowError( "MainForm_Error_DeletingItems" );
				}
			}
		}

		private void MenuItemOpen_Click( object sender, EventArgs e )
		{
			if ( _Modified )
			{
				DialogResult result = ShowOptions( "MainForm_Prompt_Changes" );

				if ( result == DialogResult.Yes )
				{
					_MenuItemSave.PerformClick();
				}
				else if ( result == DialogResult.Cancel )
					return;
			}

			if ( _OpenSkills.ShowDialog() == DialogResult.OK )
			{
				try
				{
					Cursor = Cursors.WaitCursor;
					Open( _OpenSkills.SkillsIdx, _OpenSkills.SkillsMul, _OpenSkills.SkillsGrp );

					_SaveSkills.SkillsIdx = _OpenSkills.SkillsIdx;
					_SaveSkills.SkillsMul = _OpenSkills.SkillsMul;
					_SaveSkills.SkillsGrp = _OpenSkills.SkillsGrp;

					Cursor = Cursors.Default;
				}
				catch ( Exception ex )
				{
					Cursor = Cursors.Default;
					Globals.Logger.LogException( ex );
					ShowError( "MainForm_Error_Loading" );
				}
			}
		}

		private void MenuItemSave_Click( object sender, EventArgs e )
		{
			if ( _SaveSkills.ShowDialog() == DialogResult.OK )
			{
				try
				{
					_Adapter.Save( _SaveSkills.SkillsIdx, _SaveSkills.SkillsMul, _SaveSkills.SkillsGrp );

					_Modified = false;
				}
				catch ( Exception ex )
				{
					Globals.Logger.LogException( ex );
					ShowError( "MainForm_Error_Saving" );
				}
			}
		}

		private void MenuItemSettings_Click( object sender, EventArgs e )
		{
			_Settings.ShowDialog();
		}

		private void Groups_ItemDrag( object sender, ItemDragEventArgs e )
		{
			TreeNode node = e.Item as TreeNode;

			if ( node != null && node.Tag is Skill )
				DoDragDrop( e.Item, DragDropEffects.Move );
		}

		private void Groups_DragEnter( object sender, DragEventArgs e )
		{
			TreeNode node = e.Data.GetData( "System.Windows.Forms.TreeNode" ) as TreeNode;

			if ( node != null && node.Tag is Skill )
				e.Effect = DragDropEffects.Move;
			else
				e.Effect = DragDropEffects.None;
		}

		private void Groups_DragDrop( object sender, DragEventArgs e )
		{
			TreeNode node = e.Data.GetData( "System.Windows.Forms.TreeNode" ) as TreeNode;

			if ( node != null && node.Tag is Skill )
			{
				try
				{
					Point pt = _Groups.PointToClient( new Point( e.X, e.Y ) );
					TreeNode destination = _Groups.GetNodeAt( pt );

					if ( destination != null && destination.Tag is Skill )
						destination = destination.Parent;

					SkillGroup group = _Adapter.Groups[ 0 ];

					if ( destination != null && destination.Tag is SkillGroup )
						group = (SkillGroup) destination.Tag;

					MoveSkill( (Skill) node.Tag, group );
				}
				catch ( Exception ex )
				{
					Globals.Logger.LogException( ex );
					ShowError( "MainForm_Error_MovingSkill" );
				}
			}
		}

		private void Groups_AfterSelect( object sender, TreeViewEventArgs e )
		{
			TreeNode node = _Groups.SelectedNode;

			if ( node != null && node.Tag is Skill )
				node = node.Parent;

			if ( node != null && node.Tag is SkillGroup )
			{
				SkillGroup group = (SkillGroup) node.Tag;

				_TextGroup.Tag = node;
				_TextGroup.Text = node.Text;

				_TextGroup.ReadOnly = group.ID == SkillGroup.DEFAULT_GROUP_ID;
			}
			else
			{
				_TextGroup.Tag = null;
				_TextGroup.Text = String.Empty;
				_TextGroup.ReadOnly = false;
			}
		}

		private void Groups_KeyDown( object sender, KeyEventArgs e )
		{
			if ( e.KeyCode == Keys.Delete && ShowPrompt( "MainForm_Prompt_Delete" ) == DialogResult.OK )
			{
				try
				{
					TreeNode node = _Groups.SelectedNode;

					if ( node.Tag is SkillGroup )
					{
						SkillGroup group = (SkillGroup) node.Tag;

						if ( group.ID != SkillGroup.DEFAULT_GROUP_ID )
							DeleteSelectedGroup();
						else
							ShowError( "MainForm_Error_CantDeleteDefaultGroup" );
					}
				}
				catch ( Exception ex )
				{
					Globals.Logger.LogException( ex );
					ShowError( "MainForm_Error_DeletingItems" );
				}
			}
		}

		private void TextGroup_TextChanged( object sender, EventArgs e )
		{
			TreeNode node = _TextGroup.Tag as TreeNode;

			if ( node != null && node.Tag is SkillGroup )
			{
				SkillGroup group = (SkillGroup) node.Tag;

				group.Name = _TextGroup.Text;
				node.Text = _TextGroup.Text;
			}
		}

		private void Data_EditingControlShowing( object sender, DataGridViewEditingControlShowingEventArgs e )
		{
			ComboBox combo = e.Control as ComboBox;

			if ( combo != null )
			{
				combo.SelectedIndexChanged -= new EventHandler( ComboBox_SelectedIndexChanged );
				combo.SelectedIndexChanged += new EventHandler( ComboBox_SelectedIndexChanged );
			}
		}

		private void ComboBox_SelectedIndexChanged( object sender, EventArgs e )
		{
			DataGridViewComboBoxEditingControl control = sender as DataGridViewComboBoxEditingControl;

			if ( control != null && control.EditingControlValueChanged )
			{
				DataGridViewCell cell = _Data[ 3, control.EditingControlRowIndex ];

				for ( int i = 0; i < _Adapter.Groups.Count; i++ )
				{
					SkillGroup group = _Adapter.Groups[ i ];

					if ( group.ID == (int) cell.Value )
						MoveSkill( (Skill) cell.OwningRow.Tag, group );
				}
			}
		}

		private void Main_FormClosing( object sender, FormClosingEventArgs e )
		{
			if ( _Modified )
			{
				DialogResult result = ShowOptions( "MainForm_Prompt_Changes" );

				if ( result == DialogResult.Yes )
				{
					_MenuItemSave.PerformClick();
				}
				else if ( result == DialogResult.Cancel )
					e.Cancel = true;
			}
		}

		private void Data_UserAddedRow( object sender, DataGridViewRowEventArgs e )
		{
			try
			{
				DataGridViewRow row = e.Row;
				int id = 0;

				if ( _Adapter.Skills.Count > 0 )
					id = _Adapter.Skills[ _Adapter.Skills.Count - 1 ].ID;

				Skill skill = new Skill( id );

				row.Cells[ 0 ].Value = id;
				row.Tag = skill;
			}
			catch ( Exception ex )
			{
				Globals.Logger.LogException( ex );
				ShowError( "MainForm_Error_AddingSkill" );
			}
		}

		private void Data_CellValidating( object sender, DataGridViewCellValidatingEventArgs e )
		{
			if ( e.ColumnIndex == _ColumnID.Index )
			{
				string value = e.FormattedValue.ToString();
				byte id = 0;

				if ( Byte.TryParse( value, out id ) )
				{
					Skill rowSkill = (Skill) _Data.Rows[ e.RowIndex ].Tag;

					if ( id >= _Adapter.Skills.Count )
					{
						ShowError( "MainForm_Error_OverSkillCount" );
						e.Cancel = true;
						return;
					}

					foreach ( Skill skill in _Adapter.Skills )
					{
						if ( skill.ID != rowSkill.ID && skill.ID == id )
						{
							ShowError( "MainForm_Error_DuplicateSkillID", id, skill.Name );
							e.Cancel = true;
							return;
						}
					}
				}
				else
				{
					ShowError( "MainForm_Error_InvalidSkillID" );
					e.Cancel = true;
					return;
				}
			}
		}

		private void Data_RowValidated( object sender, DataGridViewCellEventArgs e )
		{
			DataGridViewRow row = _Data.Rows[ e.RowIndex ];
			Skill skill = (Skill) row.Tag;

			int id = Int32.Parse( row.Cells[ _ColumnID.Index ].Value.ToString() );
			bool button = Boolean.Parse( row.Cells[ _ColumnButton.Index ].Value.ToString() );
			string name = row.Cells[ _ColumnName.Index ].Value.ToString();
			int groupID = Int32.Parse( row.Cells[ _ColumnGroup.Index ].Value.ToString() );

			skill.ID = id;
			skill.Button = button;
			skill.Name = name;

			for ( int i = 0; i < _Adapter.Groups.Count; i++ )
			{
				SkillGroup group = _Adapter.Groups[ i ];

				if ( group.ID == groupID )
				{
					skill.Group = group;
					break;
				}
			}
		}

		private void Data_CellValueChanged( object sender, DataGridViewCellEventArgs e )
		{
			if ( e.RowIndex >= 0 && e.RowIndex < _Data.RowCount )
			{
				_Modified = true;

				DataGridViewRow row = _Data.Rows[ e.RowIndex ];
				DataGridViewCell cell = row.Cells[ e.ColumnIndex ];
				Skill skill = (Skill) row.Tag;

				if ( e.ColumnIndex == _ColumnGroup.Index )
				{
					int groupID = Int32.Parse( cell.Value.ToString() );

					for ( int i = 0; i < _Adapter.Groups.Count; i++ )
					{
						SkillGroup group = _Adapter.Groups[ i ];

						if ( group.ID == groupID )
						{
							MoveSkill( (Skill) cell.OwningRow.Tag, group );
						}
					}
				}
				else if ( e.ColumnIndex == _ColumnName.Index )
				{
					string name = cell.Value.ToString();

					foreach ( TreeNode node in _Groups.Nodes )
					{
						if ( node.Tag is SkillGroup )
						{
							foreach ( TreeNode child in node.Nodes )
							{
								if ( skill.ID == ( (Skill) child.Tag ).ID )
								{
									child.Text = name;
									SortGroupSkills();
									return;
								}
							}
						}
						else if ( node.Tag is Skill )
						{
							if ( skill.ID == ( (Skill) node.Tag ).ID )
							{
								node.Text = name;
								SortGroupSkills();
								return;
							}
						}
					}
				}
			}
		}
		#endregion
		#endregion
	}
}
