using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;

namespace Editor
{
	/// <summary>
	/// Displays data in a customizable double buffered grid.
	/// </summary>
	[Designer( "System.Windows.Forms.Design.ControlDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" )]
	[ToolboxItemFilter( "System.Windows.Forms" )]
	[DesignerSerializer( "System.Windows.Forms.Design.ControlCodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" )]
	public class FastDataGridView : DataGridView
	{
		/// <summary>
		/// Constructs a new instance of FastDataGridView.
		/// </summary>
		public FastDataGridView() : base()
		{
			DoubleBuffered = true;
		}
	}
}
