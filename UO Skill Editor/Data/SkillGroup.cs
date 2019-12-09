using System;
using System.IO;

namespace Editor
{
	/// <summary>
	/// Skill group.
	/// </summary>
	public class SkillGroup
	{
		#region Constants
		/// <summary>
		/// Maximum group name length.
		/// </summary>
		public const int MAX_NAME_LENGTH = 0x11;

		/// <summary>
		/// Maximum group count.
		/// </summary>
		public const int MAX_GROUP_COUNT = 12;

		/// <summary>
		/// Default group id.
		/// </summary>
		public const int DEFAULT_GROUP_ID = 0;

		/// <summary>
		/// Default group name.
		/// </summary>
		public const string DEFAULT_GROUP_NAME = "Miscellaneous";
		#endregion

		#region Properties
		private int _ID;

		/// <summary>
		/// ID of the group.
		/// </summary>
		public int ID
		{
			get { return _ID; }
		}

		private string _Name;

		/// <summary>
		/// Group name.
		/// </summary>
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new instance of SkillGroup.
		/// </summary>
		/// <param name="id">Id of the group/</param>
		/// <param name="reader">Stream used to read data.</param>
		public SkillGroup( int id, BinaryReader reader )
		{
			_ID = id;
			_Name = String.Empty;

			char[] name = reader.ReadChars( MAX_NAME_LENGTH );
			int i = 0;
			char c;

			while ( i < name.Length && ( c = name[ i++ ] ) != 0 )
				_Name += c;
		}

		/// <summary>
		/// Constructs a new instance of SkillGroup.
		/// </summary>
		/// <param name="id">Id of the group.</param>
		/// <param name="name">Name of the gourp.</param>
		public SkillGroup( int id, string name )
		{
			_ID = id;
			_Name = name;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Saves skill group to a file represented as BinaryWriter.
		/// </summary>
		/// <param name="writer">Writer used to save skill group.</param>
		public void Save( BinaryWriter writer )
		{
			if ( _Name.Length > MAX_NAME_LENGTH )
				throw new SkillException( "Invalid skill group name length: {0}", _Name.Length );

			for ( int i = 0; i < _Name.Length; i++ )
				writer.Write( _Name[ i ] );

			for ( int i = 0; i < MAX_NAME_LENGTH - _Name.Length; i++ )
				writer.Write( (byte) 0 );
		}

		/// <summary>
		/// Returns a string that represents the current skill group.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return _Name;
		}
		#endregion
	}
}
