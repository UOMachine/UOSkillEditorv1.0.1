using System;
using System.IO;
using System.Text;

namespace Editor
{
	/// <summary>
	/// Describes UO skill.
	/// </summary>
	public class Skill
	{
		#region Constants
		/// <summary>
		/// Maximum skill count.
		/// </summary>
		public const int MAX_SKILL_COUNT = 0xFF;
		#endregion

		#region Properties
		private int _ID;

		/// <summary>
		/// Determines skill ID.
		/// </summary>
		public int ID
		{
			get { return _ID; }
			set { _ID = value; }
		}

		private bool _Button;

		/// <summary>
		/// Determines whether skill has button next to the name.
		/// </summary>
		public bool Button
		{
			get { return _Button; }
			set { _Button = value; }
		}

		private string _Name;

		/// <summary>
		/// Determines skill name.
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		private SkillGroup _Group;

		/// <summary>
		/// Determines to which group this skill belongs.
		/// </summary>
		public SkillGroup Group
		{
			get { return _Group; }
			set { _Group = value; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new instance of Skill.
		/// </summary>
		/// <param name="id">Id of the skill.</param>
		public Skill( int id )
		{
			_ID = id;
			_Button = false;
			_Name = String.Empty;
			_Group = null;
		}

		/// <summary>
		/// Constructs a new instance of Skill.
		/// </summary>
		/// <param name="id">Id of the skill.</param>
		/// <param name="reader">Stream used to read data.</param>
		public Skill( int id, BinaryReader reader )
		{
			_ID = id;
			_Button = reader.ReadBoolean();
			_Name = String.Empty;

			char c;

			while ( ( c = reader.ReadChar() ) != 0 )
				_Name += c;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Saves skill to a file represented as BinaryWriter.
		/// </summary>
		/// <param name="writer">Writer used to save skill.</param>
		/// <returns>Skill data length in bytes.</returns>
		public int Save( BinaryWriter writer )
		{
			writer.Write( _Button );

			for ( int i = 0; i < _Name.Length; i++ )
				writer.Write( _Name[ i ] );

			writer.Write( (byte) 0 );

			return _Name.Length + 2;
		}
		#endregion
	}
}
