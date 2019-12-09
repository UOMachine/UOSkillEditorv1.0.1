using System;

namespace Editor
{
	/// <summary>
	/// Client address info.
	/// </summary>
	public class SkillAddressInfo
	{
		#region Properties
		private byte _Address0;
		private byte _Address8;
		private byte _Address16;
		private byte _Address32;

		private int _Address;

		/// <summary>
		/// Original client address.
		/// </summary>
		public int Address
		{
			get { return _Address; }
			set
			{
				_Address = value;

				_Address0 = (byte) ( value & 0xFF );
				_Address8 = (byte) ( ( value & 0xFF00 ) >> 8 );
				_Address16 = (byte) ( ( value & 0xFF0000 ) >> 16 );
				_Address32 = (byte) ( ( value & 0xFF000000 ) >> 32 );
			}
		}

		private byte _FixedAddress0;
		private byte _FixedAddress8;
		private byte _FixedAddress16;
		private byte _FixedAddress32;

		private int _FixedAddress;

		/// <summary>
		/// Fixed client address.
		/// </summary>
		public int FixedAddress
		{
			get { return _FixedAddress; }
			set
			{
				_FixedAddress = value;

				_FixedAddress0 = (byte) ( value & 0xFF );
				_FixedAddress8 = (byte) ( ( value & 0xFF00 ) >> 8 );
				_FixedAddress16 = (byte) ( ( value & 0xFF0000 ) >> 16 );
				_FixedAddress32 = (byte) ( ( value & 0xFF000000 ) >> 32 );
			}
		}

		private int _FixedCount = 0;
		#endregion

		#region Constructors
		/// <summary>
		/// Constructs a new instance of SkillAddressInfo.
		/// </summary>
		/// <param name="address">Address to replace.</param>
		/// <param name="fixedAddress">Address to replace with.</param>
		public SkillAddressInfo( int address, int fixedAddress )
		{
			Address = address;
			FixedAddress = fixedAddress;
		}

		/// <summary>
		/// Constructs new instance of SkillAddressInfo.
		/// </summary>
		/// <param name="data">Data to construct from.</param>
		/// <param name="start">Location within data.</param>
		public SkillAddressInfo( byte[] data, int start )
		{
			_Address0 = data[ start ];
			_Address8 = data[ start + 1 ];
			_Address16 = data[ start + 2 ];
			_Address32 = data[ start + 3 ];
			_Address = ( _Address32 << 32 ) | ( _Address16 << 16 ) | ( _Address8  << 8 ) | _Address0;
		}
		#endregion

		#region Methods
		/// <summary>
		/// Determines whether data at current position is equal to this address.
		/// </summary>
		/// <param name="data">Data to check.</param>
		/// <param name="start">Current position.</param>
		/// <returns>True if data equals this address, false otherwise.</returns>
		public bool FoundOriginalAddress( byte[] data, int start )
		{
			if ( start > 0 &&
					data[ start ] == _Address0 && 
					data[ start + 1 ] == _Address8 && 
					data[ start + 2 ] == _Address16 && 
					data[ start + 3 ] == _Address32 )
				return true;

			return false;
		}

		/// <summary>
		/// Saves fixed address to current position.
		/// </summary>
		/// <param name="data">Data to save to.</param>
		/// <param name="start">Current position.</param>
		public void SaveFixedAddress( byte[] data, int start )
		{
			data[ start ] = _FixedAddress0;
			data[ start + 1 ] = _FixedAddress8;
			data[ start + 2 ] = _FixedAddress16;
			data[ start + 3 ] = _FixedAddress32;

			_FixedCount++;
		}
		#endregion
	}
}
