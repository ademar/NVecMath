/*
 * Automated conversion
 */

using System;

namespace NVecMath
{
	/// <summary>A four byte tuple.</summary>
	/// <remarks>
	/// A four byte tuple.  Note that Java defines a byte as a signed integer
	/// in the range [-128, 127]. However, colors are more typically
	/// represented by values in the range [0, 255]. Java 3D recognizes this
	/// and, in those cases where Tuple4b is used to represent color, treats
	/// the bytes as if the range were [0, 255]---in other words, as if the
	/// bytes were unsigned.
	/// Values greater than 127 can be assigned to a byte variable using a
	/// type cast.  For example:
	/// <ul>byteVariable = (byte) intValue; // intValue can be &gt; 127</ul>
	/// If intValue is greater than 127, then byteVariable will be negative.  The
	/// correct value will be extracted when it is used (by masking off the upper
	/// bits).
	/// </remarks>
	[System.Serializable]
	public abstract class Tuple4b : ICloneable
	{
		internal const long serialVersionUID = -8226727741811898211L;

		/// <summary>The first value.</summary>
		/// <remarks>The first value.</remarks>
		public byte x;

		/// <summary>The second value.</summary>
		/// <remarks>The second value.</remarks>
		public byte y;

		/// <summary>The third value.</summary>
		/// <remarks>The third value.</remarks>
		public byte z;

		/// <summary>The fourth value.</summary>
		/// <remarks>The fourth value.</remarks>
		public byte w;

		/// <summary>Constructs and initializes a Tuple4b from the specified four values.</summary>
		/// <remarks>Constructs and initializes a Tuple4b from the specified four values.</remarks>
		/// <param name="b1">the first value</param>
		/// <param name="b2">the second value</param>
		/// <param name="b3">the third value</param>
		/// <param name="b4">the fourth value</param>
		public Tuple4b(byte b1, byte b2, byte b3, byte b4)
		{
			this.x = b1;
			this.y = b2;
			this.z = b3;
			this.w = b4;
		}

		/// <summary>Constructs and initializes a Tuple4b from the array of length 4.</summary>
		/// <remarks>Constructs and initializes a Tuple4b from the array of length 4.</remarks>
		/// <param name="t">the array of length 4 containing b1 b2 b3 b4 in order</param>
		public Tuple4b(byte[] t)
		{
			this.x = t[0];
			this.y = t[1];
			this.z = t[2];
			this.w = t[3];
		}

		/// <summary>Constructs and initializes a Tuple4b from the specified Tuple4b.</summary>
		/// <remarks>Constructs and initializes a Tuple4b from the specified Tuple4b.</remarks>
		/// <param name="t1">the Tuple4b containing the initialization x y z w data</param>
		public Tuple4b(Tuple4b t1)
		{
			this.x = t1.x;
			this.y = t1.y;
			this.z = t1.z;
			this.w = t1.w;
		}

		/// <summary>Constructs and initializes a Tuple4b to (0,0,0,0).</summary>
		/// <remarks>Constructs and initializes a Tuple4b to (0,0,0,0).</remarks>
		public Tuple4b()
		{
			this.x = unchecked((byte)0);
			this.y = unchecked((byte)0);
			this.z = unchecked((byte)0);
			this.w = unchecked((byte)0);
		}

		/// <summary>Returns a string that contains the values of this Tuple4b.</summary>
		/// <remarks>Returns a string that contains the values of this Tuple4b.</remarks>
		/// <returns>the String representation</returns>
		public override string ToString()
		{
			return ("(" + ((int)this.x & unchecked((int)(0xff))) + ", " + ((int)this.y & unchecked(
				(int)(0xff))) + ", " + ((int)this.z & unchecked((int)(0xff))) + ", " + ((int)this
				.w & unchecked((int)(0xff))) + ")");
		}

		/// <summary>
		/// Places the value of the x,y,z,w components of this Tuple4b
		/// into the array of length 4.
		/// </summary>
		/// <remarks>
		/// Places the value of the x,y,z,w components of this Tuple4b
		/// into the array of length 4.
		/// </remarks>
		/// <param name="b">array of length 4 into which the values are placed</param>
		public void Get(byte[] b)
		{
			b[0] = this.x;
			b[1] = this.y;
			b[2] = this.z;
			b[3] = this.w;
		}

		/// <summary>
		/// Places the value of the x,y,z,w components of this
		/// Tuple4b into the tuple t1.
		/// </summary>
		/// <remarks>
		/// Places the value of the x,y,z,w components of this
		/// Tuple4b into the tuple t1.
		/// </remarks>
		/// <param name="t1">tuple into which the values are placed</param>
		public void Get(Tuple4b t1)
		{
			t1.x = this.x;
			t1.y = this.y;
			t1.z = this.z;
			t1.w = this.w;
		}

		/// <summary>
		/// Sets the value of the data members of this tuple to the value
		/// of the argument tuple t1.
		/// </summary>
		/// <remarks>
		/// Sets the value of the data members of this tuple to the value
		/// of the argument tuple t1.
		/// </remarks>
		/// <param name="t1">the source tuple</param>
		public void Set(Tuple4b t1)
		{
			this.x = t1.x;
			this.y = t1.y;
			this.z = t1.z;
			this.w = t1.w;
		}

		/// <summary>
		/// Sets the value of the data members of this tuple to the value
		/// of the array b of length 4.
		/// </summary>
		/// <remarks>
		/// Sets the value of the data members of this tuple to the value
		/// of the array b of length 4.
		/// </remarks>
		/// <param name="b">the source array of length 4</param>
		public void Set(byte[] b)
		{
			this.x = b[0];
			this.y = b[1];
			this.z = b[2];
			this.w = b[3];
		}

		/// <summary>
		/// Returns true if all of the data members of tuple t1 are equal to
		/// the corresponding data members in this tuple.
		/// </summary>
		/// <remarks>
		/// Returns true if all of the data members of tuple t1 are equal to
		/// the corresponding data members in this tuple.
		/// </remarks>
		/// <param name="t1">the tuple with which the comparison is made</param>
		public virtual bool Equals(Tuple4b t1)
		{
			try
			{
				return (this.x == t1.x && this.y == t1.y && this.z == t1.z && this.w == t1.w);
			}
			catch (ArgumentNullException)
			{
				return false;
			}
		}

		/// <summary>
		/// Returns true if the Object t1 is of type Tuple4b and all of the
		/// data members of t1 are equal to the corresponding data members in
		/// this Tuple4b.
		/// </summary>
		/// <remarks>
		/// Returns true if the Object t1 is of type Tuple4b and all of the
		/// data members of t1 are equal to the corresponding data members in
		/// this Tuple4b.
		/// </remarks>
		/// <param name="t1">the object with which the comparison is made</param>
		public override bool Equals(object t1)
		{
			try
			{
				Tuple4b t2 = (Tuple4b)t1;
				return (this.x == t2.x && this.y == t2.y && this.z == t2.z && this.w == t2.w);
			}
			catch (ArgumentNullException)
			{
				return false;
			}
			catch (InvalidCastException)
			{
				return false;
			}
		}

		/// <summary>
		/// Returns a hash code value based on the data values in this
		/// object.
		/// </summary>
		/// <remarks>
		/// Returns a hash code value based on the data values in this
		/// object.  Two different Tuple4b objects with identical data values
		/// (i.e., Tuple4b.equals returns true) will return the same hash
		/// code value.  Two objects with different data members may return the
		/// same hash value, although this is not likely.
		/// </remarks>
		/// <returns>the integer hash code value</returns>
		public override int GetHashCode()
		{
			return ((((int)x & unchecked((int)(0xff))) << 0) | (((int)y & unchecked((int)(0xff
				))) << 8) | (((int)z & unchecked((int)(0xff))) << 16) | (((int)w & unchecked((int
				)(0xff))) << 24));
		}

		/// <summary>Creates a new object of the same class as this object.</summary>
		/// <remarks>Creates a new object of the same class as this object.</remarks>
		/// <returns>a clone of this instance.</returns>
		/// <exception>
		/// OutOfMemoryError
		/// if there is not enough memory.
		/// </exception>
		/// <seealso cref="System.ICloneable">System.ICloneable</seealso>
		/// <since>vecmath 1.3</since>
		public virtual object Clone()
		{
			// Since there are no arrays we can just use Object.clone()
			return base.MemberwiseClone();
		}

		// this shouldn't happen, since we are Cloneable
		/// <summary>Get <i>x</i>, the first value.</summary>
		/// <remarks>Get <i>x</i>, the first value.</remarks>
		/// <returns>Returns <i>x</i>, the first value.</returns>
		/// <since>vecmath 1.5</since>
		public byte GetX()
		{
			return x;
		}

		/// <summary>Set <i>x</i>,  the first value.</summary>
		/// <remarks>Set <i>x</i>,  the first value.</remarks>
		/// <param name="x">the first value.</param>
		/// <since>vecmath 1.5</since>
		public void SetX(byte x)
		{
			this.x = x;
		}

		/// <summary>Get <i>y</i>, the second value.</summary>
		/// <remarks>Get <i>y</i>, the second value.</remarks>
		/// <returns>Returns <i>y</i>, the second value.</returns>
		/// <since>vecmath 1.5</since>
		public byte GetY()
		{
			return y;
		}

		/// <summary>Set <i>y</i>, the second value.</summary>
		/// <remarks>Set <i>y</i>, the second value.</remarks>
		/// <param name="y">the second value.</param>
		/// <since>vecmath 1.5</since>
		public void SetY(byte y)
		{
			this.y = y;
		}

		/// <summary>Get <i>z</i>, the third value.</summary>
		/// <remarks>Get <i>z</i>, the third value.</remarks>
		/// <returns>Returns <i>z</i>, the third value.</returns>
		/// <since>vecmath 1.5</since>
		public byte GetZ()
		{
			return z;
		}

		/// <summary>Set <i>z</i>,  the third value.</summary>
		/// <remarks>Set <i>z</i>,  the third value.</remarks>
		/// <param name="z">the third value.</param>
		/// <since>vecmath 1.5</since>
		public void SetZ(byte z)
		{
			this.z = z;
		}

		/// <summary>Get <i>w</i>, the fourth value.</summary>
		/// <remarks>Get <i>w</i>, the fourth value.</remarks>
		/// <returns>Returns <i>w</i> - the fourth value.</returns>
		/// <since>vecmath 1.5</since>
		public byte GetW()
		{
			return w;
		}

		/// <summary>Set <i>w</i>, the fourth value.</summary>
		/// <remarks>Set <i>w</i>, the fourth value.</remarks>
		/// <param name="w">the fourth value.</param>
		/// <since>vecmath 1.5</since>
		public void SetW(byte w)
		{
			this.w = w;
		}
	}
}
