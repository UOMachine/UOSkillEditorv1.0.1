using System;
using System.IO;
using System.Collections.Generic;

namespace Editor
{
	/// <summary>
	/// Defines client patch result.
	/// </summary>
	public enum PatchResult
	{
		/// <summary>
		/// Patching successful.
		/// </summary>
		Successful,

		/// <summary>
		/// Skill base address not found.
		/// </summary>
		BaseAddressNotFound,

		/// <summary>
		/// Skill count signature not found.
		/// </summary>
		SkillCountNotFound,
	}

	/// <summary>
	/// Provides methods for loading and saving skills.
	/// </summary>
	public class SkillAdapter
	{
		#region Constants
		private const int MAX_SKILL_COUNT = 1024;
		private const int BASE_ADDRESS = 0x950000;
		#endregion

		#region Properties
		private List<Skill> _Skills;

		/// <summary>
		/// Gets list of all skills.
		/// </summary>
		public List<Skill> Skills
		{
			get { return _Skills; }
		}

		private List<SkillGroup> _Groups;

		/// <summary>
		/// Gets list of all groups.
		/// </summary>
		public List<SkillGroup> Groups
		{
			get { return _Groups; }
		}

		/// <summary>
		/// Gets group that represent ungrouped skill.
		/// </summary>
		public SkillGroup Ungrouped
		{
			get
			{
				if ( _Groups.Count == SkillGroup.DEFAULT_GROUP_ID )
					_Groups.Add( new SkillGroup( SkillGroup.DEFAULT_GROUP_ID, SkillGroup.DEFAULT_GROUP_NAME ) );

				return _Groups[ 0 ];
			}
		}
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new instance of SkillLogic.
		/// </summary>
		public SkillAdapter()
		{
			_Skills = new List<Skill>();
			_Groups = new List<SkillGroup>();
			_Groups.Add( new SkillGroup( SkillGroup.DEFAULT_GROUP_ID, SkillGroup.DEFAULT_GROUP_NAME ) );
		}
		#endregion

		#region Methods
		/// <summary>
		/// Clears skills and groups.
		/// </summary>
		public void Clear()
		{
			_Skills.Clear();
			_Groups.Clear();
			_Groups.Add( new SkillGroup( SkillGroup.DEFAULT_GROUP_ID, SkillGroup.DEFAULT_GROUP_NAME ) );
		}

		/// <summary>
		/// Loads skill data from three diferent files.
		/// </summary>
		/// <param name="idx">Skill index file. Used to determines skill start and length.</param>
		/// <param name="mul">Skill data. Used to determine skill name and usability.</param>
		/// <param name="grp">Skill group data. Used to determines skill group data.</param>
		public void Load( string idx, string mul, string grp )
		{
			using ( FileStream idxStream = new FileStream( idx, FileMode.Open, FileAccess.Read, FileShare.ReadWrite ) )
			using ( FileStream mulStream = new FileStream( mul, FileMode.Open, FileAccess.Read, FileShare.ReadWrite ) )
			using ( BinaryReader idxReader = new BinaryReader( idxStream ) )
			using ( BinaryReader mulReader = new BinaryReader( mulStream ) )
			{
				uint start = 0;
				int length = 0;
				int unknown = 0;
				int index = 0;

				while ( start != 0xFFFFFFFF || idxStream.Position < idxStream.Length )
				{
					start = idxReader.ReadUInt32();
					length = idxReader.ReadInt32();
					unknown = idxReader.ReadInt32();

					if ( start != 0xFFFFFFFF )
						_Skills.Add( new Skill( index++, mulReader ) );
				}
			}
			
			using ( FileStream grpStream = new FileStream( grp, FileMode.Open, FileAccess.Read, FileShare.ReadWrite ) )
			using ( BinaryReader grpReader = new BinaryReader( grpStream ) )
			{
				int count = grpReader.ReadInt32();
				int index = 1;

				while ( index < count )
				{
					_Groups.Add( new SkillGroup( index++, grpReader ) );
				}

				Skill skill = null;
				int group = 0;

				for ( int i = 0; i < _Skills.Count; i++ )
				{
					skill = _Skills[ i ];
					group = grpReader.ReadInt32();

					if ( group < 0 || group >= _Groups.Count )
						throw new SkillException( "Invalid group number: {0}!", group );

					skill.Group = _Groups[ group ];
				}
			}
		}

		/// <summary>
		/// Saves skill to three diferent files. Calling this method will replace existing files.
		/// </summary>
		/// <param name="idx">Skill index file. Used to determines skill start and length.</param>
		/// <param name="mul">Skill data. Used to determine skill name and usability.</param>
		/// <param name="grp">Skill group data. Used to determines skill group data.</param>
		public void Save( string idx, string mul, string grp )
		{
			using ( FileStream idxStream = new FileStream( idx, FileMode.Create, FileAccess.Write, FileShare.None ) )
			using ( FileStream mulStream = new FileStream( mul, FileMode.Create, FileAccess.Write, FileShare.None ) )
			using ( BinaryWriter idxWriter = new BinaryWriter( idxStream ) )
			using ( BinaryWriter mulWriter = new BinaryWriter( mulStream ) )
			{
				Skill skill = null;
				int current = 0;
				int length = 0;

				for ( int i = 0; i < _Skills.Count; i++ )
				{
					skill = _Skills[ i ];
					length = skill.Save( mulWriter );

					idxWriter.Write( (int) current );
					idxWriter.Write( (int) length );
					idxWriter.Write( (int) 0 );

					current += length;
				}

				for ( int i = 0; i < MAX_SKILL_COUNT - _Skills.Count; i++ )
				{
					idxWriter.Write( (uint) 0xFFFFFFFF );
					idxWriter.Write( (int) 0 );
					idxWriter.Write( (int) 0 );
				}
			}

			using ( FileStream grpStream = new FileStream( grp, FileMode.Create, FileAccess.Write, FileShare.None ) )
			using ( BinaryWriter grpWriter = new BinaryWriter( grpStream ) )
			{
				grpWriter.Write( (int) _Groups.Count );

				SkillGroup group = null;

				for ( int i = 0; i < _Groups.Count; i++ )
				{
					group = _Groups[ i ];

					if ( group.ID > 0 )
						group.Save( grpWriter );
				}

				Skill skill = null;

				for ( int i = 0; i < _Skills.Count; i++ )
				{
					skill = _Skills[ i ];

					if ( skill.Group == null )
						throw new SkillException( "Missing group for skill: {0}!", skill.ID );

					grpWriter.Write( (int) skill.Group.ID );
				}
			}
		}

		/// <summary>
		/// Patches skill count into the client.
		/// </summary>
		/// <param name="exeSource">Source client.</param>
		/// <param name="exeDestination">Path to store patched client.</param>
		/// <param name="skillCount">Skill count to patch.</param>
		/// <returns>Patch result.</returns>
		public PatchResult PatchClient( string exeSource, string exeDestination, int skillCount )
		{
			byte[] data;

			if ( _Skills.Count > Skill.MAX_SKILL_COUNT )
				throw new SkillException( "Too many skills to patch: {0}", _Skills.Count );

			using ( FileStream stream = new FileStream( exeSource, FileMode.Open, FileAccess.Read, FileShare.ReadWrite ) )
			using ( BinaryReader reader = new BinaryReader( stream ) )
			{
				data = reader.ReadBytes( (int) stream.Length );
			}

			int dataLength = data.Length - Signatures.SkillParametersSignature.Length;
			int oldSkillCount = 0;
			int oldSortedSkillsAddress = 0;

			// Find parameters
			for ( int i = 0; i < dataLength; i++ )
			{
				if ( FoundNeedle( data, i, Signatures.SkillParametersSignature ) )
				{
					byte address0 = data[ i + Signatures.SkillBufferOffset ];
					byte address8 = data[ i + Signatures.SkillBufferOffset + 1 ];
					byte address16 = data[ i + Signatures.SkillBufferOffset + 2 ];
					byte ddress32 = data[ i + Signatures.SkillBufferOffset + 3 ];

					oldSortedSkillsAddress = ( ddress32 << 32 ) | ( address16 << 16 ) | ( address8  << 8 ) | address0;
					oldSkillCount = data[ i + Signatures.SkillCountOffset ];

					break;
				}
			}

			if ( oldSortedSkillsAddress == 0 )
				return PatchResult.BaseAddressNotFound;

			// Calculate new addresses
			SkillAddressInfo buttonInfo = null;
			SkillAddressInfo extButtonInfo = null;
			SkillAddressInfo groupTableInfo = null;
			SkillAddressInfo skillCountInfo = null;
			SkillAddressInfo groupCountInfo = null;
			SkillAddressInfo groupListInfo0 = null;
			SkillAddressInfo groupListInfo1 = null;
			SkillAddressInfo groupListInfo2 = null;
			SkillAddressInfo groupListInfo3 = null;
			SkillAddressInfo groupListInfo4 = null;
			SkillAddressInfo sortedSkillsInfo = null;
			SkillAddressInfo sortedSkillsInfo2 = null;
			SkillAddressInfo unicodeSkillsInfo = null;
			SkillAddressInfo asciiSkillsInfo = null;

			int oldBaseAddress = oldSortedSkillsAddress - SkillGroup.MAX_NAME_LENGTH * SkillGroup.MAX_GROUP_COUNT - 8 - oldSkillCount * 9;
			int newBaseAddress = BASE_ADDRESS;

			if ( oldBaseAddress % 4 > 0 )
				oldBaseAddress -= oldBaseAddress % 4;

			buttonInfo = new SkillAddressInfo( oldBaseAddress, newBaseAddress );
			oldBaseAddress += oldSkillCount + ( 4 - ( oldSkillCount % 4 ) );
			newBaseAddress += skillCount + ( 4 - ( skillCount % 4 ) );
			extButtonInfo = new SkillAddressInfo( oldBaseAddress, newBaseAddress );
			oldBaseAddress += oldSkillCount * 4;
			newBaseAddress += skillCount * 4;
			groupTableInfo = new SkillAddressInfo( oldBaseAddress, newBaseAddress );
			oldBaseAddress += oldSkillCount * 4;
			newBaseAddress += skillCount * 4;
			skillCountInfo = new SkillAddressInfo( oldBaseAddress, newBaseAddress );
			oldBaseAddress += 4;
			newBaseAddress += 4;
			groupCountInfo = new SkillAddressInfo( oldBaseAddress, newBaseAddress );
			oldBaseAddress += 4;
			newBaseAddress += 4;
			groupListInfo0 = new SkillAddressInfo( oldBaseAddress, newBaseAddress );
			groupListInfo1 = new SkillAddressInfo( oldBaseAddress + 4, newBaseAddress + 4 );
			groupListInfo2 = new SkillAddressInfo( oldBaseAddress + 8, newBaseAddress + 8 );
			groupListInfo3 = new SkillAddressInfo( oldBaseAddress + 12, newBaseAddress + 12 );
			groupListInfo4 = new SkillAddressInfo( oldBaseAddress + SkillGroup.MAX_NAME_LENGTH, newBaseAddress + SkillGroup.MAX_NAME_LENGTH );
			oldBaseAddress += SkillGroup.MAX_GROUP_COUNT * SkillGroup.MAX_NAME_LENGTH;
			newBaseAddress += SkillGroup.MAX_GROUP_COUNT * SkillGroup.MAX_NAME_LENGTH;
			sortedSkillsInfo = new SkillAddressInfo( oldBaseAddress, newBaseAddress );
			sortedSkillsInfo2 = new SkillAddressInfo( oldBaseAddress + 1, newBaseAddress + 1 );
			oldBaseAddress += oldSkillCount + ( 4 - ( oldSkillCount % 4 ) );
			newBaseAddress += skillCount + ( 4 - ( skillCount % 4 ) );
			unicodeSkillsInfo = new SkillAddressInfo( oldBaseAddress, newBaseAddress );
			oldBaseAddress += oldSkillCount * 160;
			newBaseAddress += skillCount * 160;
			asciiSkillsInfo = new SkillAddressInfo( oldBaseAddress, newBaseAddress );

			bool found0 = false;
			bool found1 = false;
			bool found2 = false;
			bool found3 = false;
			bool found4 = false;
			bool found5 = false;

			for ( int i = 0; i < dataLength; i++ )
			{
				#region Replace Address
				if ( data[ i ] == 0x05 )
				{
					if ( asciiSkillsInfo.FoundOriginalAddress( data, i + 1 ) )
						asciiSkillsInfo.SaveFixedAddress( data, i + 1 );
				}

				if ( data[ i ] == 0x0F )
				{
					if ( sortedSkillsInfo.FoundOriginalAddress( data, i + 3 ) )
						sortedSkillsInfo.SaveFixedAddress( data, i + 3 );
					else if ( sortedSkillsInfo.FoundOriginalAddress( data, i + 4 ) )
						sortedSkillsInfo.SaveFixedAddress( data, i + 4 );

					if ( sortedSkillsInfo2.FoundOriginalAddress( data, i + 3 ) )
						sortedSkillsInfo2.SaveFixedAddress( data, i + 3 );
				}

				if ( data[ i ] == 0x39 )
				{
					if ( groupTableInfo.FoundOriginalAddress( data, i + 3 ) )
						groupTableInfo.SaveFixedAddress( data, i + 3 );

					if ( skillCountInfo.FoundOriginalAddress( data, i + 2 ) )
						skillCountInfo.SaveFixedAddress( data, i + 2 );

					if ( groupCountInfo.FoundOriginalAddress( data, i + 2 ) )
						groupCountInfo.SaveFixedAddress( data, i + 2 );
				}

				if ( data[ i ] == 0x3B )
				{
					if ( skillCountInfo.FoundOriginalAddress( data, i + 2 ) )
						skillCountInfo.SaveFixedAddress( data, i + 2 );

					if ( groupCountInfo.FoundOriginalAddress( data, i + 2 ) )
						groupCountInfo.SaveFixedAddress( data, i + 2 );
				}

				if ( data[ i ] == 0x66 )
				{
					if ( groupListInfo3.FoundOriginalAddress( data, i + 3 ) )
						groupListInfo3.SaveFixedAddress( data, i + 3 );
				}

				if ( data[ i ] == 0x68 )
				{
					if ( skillCountInfo.FoundOriginalAddress( data, i + 1 ) )
						skillCountInfo.SaveFixedAddress( data, i + 1 );

					if ( groupCountInfo.FoundOriginalAddress( data, i + 1 ) )
						groupCountInfo.SaveFixedAddress( data, i + 1 );

					if ( sortedSkillsInfo.FoundOriginalAddress( data, i + 1 ) )
						sortedSkillsInfo.SaveFixedAddress( data, i + 1 );
				}

				if ( data[ i ] == 0x81 )
				{
					if ( skillCountInfo.FoundOriginalAddress( data, i + 2 ) )
						skillCountInfo.SaveFixedAddress( data, i + 2 );

					if ( asciiSkillsInfo.FoundOriginalAddress( data, i + 2 ) )
						asciiSkillsInfo.SaveFixedAddress( data, i + 2 );
				}

				if ( data[ i ] == 0x83 )
				{
					if ( extButtonInfo.FoundOriginalAddress( data, i + 3 ) )
						extButtonInfo.SaveFixedAddress( data, i + 3 );

					if ( groupTableInfo.FoundOriginalAddress( data, i + 3 ) )
						groupTableInfo.SaveFixedAddress( data, i + 3 );

					if ( skillCountInfo.FoundOriginalAddress( data, i + 2 ) )
						skillCountInfo.SaveFixedAddress( data, i + 2 );

					if ( groupCountInfo.FoundOriginalAddress( data, i + 2 ) )
						groupCountInfo.SaveFixedAddress( data, i + 2 );
				}

				if ( data[ i ] == 0x84 )
				{
					if ( buttonInfo.FoundOriginalAddress( data, i + 2 ) )
						buttonInfo.SaveFixedAddress( data, i + 2 );
				}

				if ( data[ i ] == 0x88 )
				{
					if ( buttonInfo.FoundOriginalAddress( data, i + 2 ) )
						buttonInfo.SaveFixedAddress( data, i + 2 );

					if ( sortedSkillsInfo.FoundOriginalAddress( data, i + 2 ) )
						sortedSkillsInfo.SaveFixedAddress( data, i + 2 );

					if ( sortedSkillsInfo2.FoundOriginalAddress( data, i + 2 ) )
						sortedSkillsInfo2.SaveFixedAddress( data, i + 2 );
				}

				if ( data[ i ] == 0x89 )
				{
					if ( extButtonInfo.FoundOriginalAddress( data, i + 3 ) )
						extButtonInfo.SaveFixedAddress( data, i + 3 );

					if ( groupTableInfo.FoundOriginalAddress( data, i + 3 ) )
						groupTableInfo.SaveFixedAddress( data, i + 3 );

					if ( skillCountInfo.FoundOriginalAddress( data, i + 2 ) )
						skillCountInfo.SaveFixedAddress( data, i + 2 );

					if ( groupCountInfo.FoundOriginalAddress( data, i + 2 ) )
						groupCountInfo.SaveFixedAddress( data, i + 2 );

					if ( groupListInfo0.FoundOriginalAddress( data, i + 2 ) )
						groupListInfo0.SaveFixedAddress( data, i + 2 );

					if ( groupListInfo2.FoundOriginalAddress( data, i + 2 ) )
						groupListInfo2.SaveFixedAddress( data, i + 2 );
				}

				if ( data[ i ] == 0x8A )
				{
					if ( buttonInfo.FoundOriginalAddress( data, i + 2 ) )
						buttonInfo.SaveFixedAddress( data, i + 2 );

					if ( sortedSkillsInfo.FoundOriginalAddress( data, i + 2 ) )
						sortedSkillsInfo.SaveFixedAddress( data, i + 2 );

					if ( sortedSkillsInfo2.FoundOriginalAddress( data, i + 2 ) )
						sortedSkillsInfo2.SaveFixedAddress( data, i + 2 );
				}

				if ( data[ i ] == 0x8B )
				{
					if ( extButtonInfo.FoundOriginalAddress( data, i + 3 ) )
						extButtonInfo.SaveFixedAddress( data, i + 3 );

					if ( groupTableInfo.FoundOriginalAddress( data, i + 3 ) )
						groupTableInfo.SaveFixedAddress( data, i + 3 );

					if ( skillCountInfo.FoundOriginalAddress( data, i + 2 ) )
						skillCountInfo.SaveFixedAddress( data, i + 2 );

					if ( groupCountInfo.FoundOriginalAddress( data, i + 2 ) )
						groupCountInfo.SaveFixedAddress( data, i + 2 );
				}

				if ( data[ i ] == 0x8D )
				{
					if ( buttonInfo.FoundOriginalAddress( data, i + 2 ) )
						buttonInfo.SaveFixedAddress( data, i + 2 );

					if ( groupListInfo0.FoundOriginalAddress( data, i + 3 ) )
						groupListInfo0.SaveFixedAddress( data, i + 3 );

					if ( asciiSkillsInfo.FoundOriginalAddress( data, i + 2 ) )
						asciiSkillsInfo.SaveFixedAddress( data, i + 2 );
				}

				if ( data[ i ] == 0xA3 )
				{
					if ( asciiSkillsInfo.FoundOriginalAddress( data, i + 1 ) )
						asciiSkillsInfo.SaveFixedAddress( data, i + 1 );

					if ( groupListInfo1.FoundOriginalAddress( data, i + 1 ) )
						groupListInfo1.SaveFixedAddress( data, i + 1 );
				}

				if ( data[ i ] == 0xBA )
				{
					if ( asciiSkillsInfo.FoundOriginalAddress( data, i + 1 ) )
						asciiSkillsInfo.SaveFixedAddress( data, i + 1 );
				}

				if ( data[ i ] == 0xBB )
				{
					if ( groupListInfo4.FoundOriginalAddress( data, i + 1 ) )
						groupListInfo4.SaveFixedAddress( data, i + 1 );
				}

				if ( data[ i ] == 0xBE )
				{
					if ( unicodeSkillsInfo.FoundOriginalAddress( data, i + 1 ) )
						unicodeSkillsInfo.SaveFixedAddress( data, i + 1 );
				}

				if ( data[ i ] == 0xBF )
				{
					if ( groupTableInfo.FoundOriginalAddress( data, i + 1 ) )
						groupTableInfo.SaveFixedAddress( data, i + 1 );

					if ( asciiSkillsInfo.FoundOriginalAddress( data, i + 1 ) )
						asciiSkillsInfo.SaveFixedAddress( data, i + 1 );

					if ( groupListInfo4.FoundOriginalAddress( data, i + 1 ) )
						groupListInfo4.SaveFixedAddress( data, i + 1 );
				}

				if ( data[ i ] == 0xC6 )
				{
					if ( buttonInfo.FoundOriginalAddress( data, i + 2 ) )
						buttonInfo.SaveFixedAddress( data, i + 2 );

					if ( asciiSkillsInfo.FoundOriginalAddress( data, i + 3 ) )
						asciiSkillsInfo.SaveFixedAddress( data, i + 3 );

					if ( asciiSkillsInfo.FoundOriginalAddress( data, i + 2 ) )
						asciiSkillsInfo.SaveFixedAddress( data, i + 2 );
				}

				if ( data[ i ] == 0xC7 )
				{
					if ( skillCountInfo.FoundOriginalAddress( data, i + 2 ) )
						skillCountInfo.SaveFixedAddress( data, i + 2 );
				}

				if ( data[ i ] == 0xF6 )
				{
					if ( buttonInfo.FoundOriginalAddress( data, i + 2 ) )
						buttonInfo.SaveFixedAddress( data, i + 2 );
				}
				#endregion

				if ( FoundNeedle( data, i, Signatures.Signature0 ) )
				{
					data[ i ] = (byte) skillCount;
					data[ i + Signatures.SignatureOffset0 ] = (byte) skillCount;
					found0 = true;
				}

				if ( FoundNeedle( data, i, Signatures.Signature1 ) )
				{
					data[ i + Signatures.SignatureOffset1 ] = (byte) skillCount;
					found1 = true;
				}

				if ( FoundNeedle( data, i, Signatures.Signature2 ) )
				{
					data[ i  + Signatures.SignatureOffset2 ] = (byte) skillCount;
					found2 = true;
				}

				if ( FoundNeedle( data, i, Signatures.Signature3 ) )
				{
					data[ i + Signatures.SignatureOffset3 ] = (byte) skillCount;
					found3 = true;
				}

				if ( FoundNeedle( data, i, Signatures.Signature4 ) )
				{
					data[ i + Signatures.SignatureOffset4 ] = (byte) skillCount;
					found4 = true;
				}

				if ( FoundNeedle( data, i, Signatures.Signature5 ) )
				{
					data[ i + Signatures.SignatureOffset5 ] = (byte) skillCount;
					found5 = true;
				}
			}

			if ( found0 && found1 && found2 && found3 && found4 && found5 )
			{
				using ( FileStream stream = new FileStream( exeDestination, FileMode.Create, FileAccess.Write, FileShare.None ) )
				using ( BinaryWriter writer = new BinaryWriter( stream ) )
				{
					writer.Write( data );
				}

				return PatchResult.Successful;
			}

			return PatchResult.SkillCountNotFound;
		}

		private bool FoundNeedle( byte[] hay, int start, byte[] needle )
		{
			int hayPosition = start;
			int needlePosition = 0;
			int toCompare = needle.Length;

			while ( needlePosition < toCompare && ( needle[ needlePosition ] == 0xCC || needle[ needlePosition ] == hay[ hayPosition ] ) )
			{
				hayPosition++;
				needlePosition++;
			}

			return needlePosition == toCompare;
		}
		#endregion
	}
}
