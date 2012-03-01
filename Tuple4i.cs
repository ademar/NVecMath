/*
 * Automated conversion
 */

using System;

namespace NVecMath
{
	/// <summary>
	/// A 4-element tuple represented by signed integer x,y,z,w
	/// coordinates.
	/// </summary>
	/// <remarks>
	/// A 4-element tuple represented by signed integer x,y,z,w
	/// coordinates.
	/// </remarks>
	/// <since>vecmath 1.2</since>
	[System.Serializable]
	public abstract class Tuple4i : ICloneable
	{
		internal const long serialVersionUID = 8064614250942616720L;

		/// <summary>The x coordinate.</summary>
		/// <remarks>The x coordinate.</remarks>
		public int x;

		/// <summary>The y coordinate.</summary>
		/// <remarks>The y coordinate.</remarks>
		public int y;

		/// <summary>The z coordinate.</summary>
		/// <remarks>The z coordinate.</remarks>
		public int z;

		/// <summary>The w coordinate.</summary>
		/// <remarks>The w coordinate.</remarks>
		public int w;

		/// <summary>
		/// Constructs and initializes a Tuple4i from the specified
		/// x, y, z, and w coordinates.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes a Tuple4i from the specified
		/// x, y, z, and w coordinates.
		/// </remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		/// <param name="z">the z coordinate</param>
		/// <param name="w">the w coordinate</param>
		public Tuple4i(int x, int y, int z, int w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		/// <summary>Constructs and initializes a Tuple4i from the array of length 4.</summary>
		/// <remarks>Constructs and initializes a Tuple4i from the array of length 4.</remarks>
		/// <param name="t">the array of length 4 containing x, y, z, and w in order.</param>
		public Tuple4i(int[] t)
		{
			this.x = t[0];
			this.y = t[1];
			this.z = t[2];
			this.w = t[3];
		}

		/// <summary>Constructs and initializes a Tuple4i from the specified Tuple4i.</summary>
		/// <remarks>Constructs and initializes a Tuple4i from the specified Tuple4i.</remarks>
		/// <param name="t1">
		/// the Tuple4i containing the initialization x, y, z,
		/// and w data.
		/// </param>
		public Tuple4i(Tuple4i t1)
		{
			this.x = t1.x;
			this.y = t1.y;
			this.z = t1.z;
			this.w = t1.w;
		}

		/// <summary>Constructs and initializes a Tuple4i to (0,0,0,0).</summary>
		/// <remarks>Constructs and initializes a Tuple4i to (0,0,0,0).</remarks>
		public Tuple4i()
		{
			this.x = 0;
			this.y = 0;
			this.z = 0;
			this.w = 0;
		}

		/// <summary>
		/// Sets the value of this tuple to the specified x, y, z, and w
		/// coordinates.
		/// </summary>
		/// <remarks>
		/// Sets the value of this tuple to the specified x, y, z, and w
		/// coordinates.
		/// </remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		/// <param name="z">the z coordinate</param>
		/// <param name="w">the w coordinate</param>
		public void Set(int x, int y, int z, int w)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.w = w;
		}

		/// <summary>
		/// Sets the value of this tuple to the specified coordinates in the
		/// array of length 4.
		/// </summary>
		/// <remarks>
		/// Sets the value of this tuple to the specified coordinates in the
		/// array of length 4.
		/// </remarks>
		/// <param name="t">the array of length 4 containing x, y, z, and w in order.</param>
		public void Set(int[] t)
		{
			this.x = t[0];
			this.y = t[1];
			this.z = t[2];
			this.w = t[3];
		}

		/// <summary>Sets the value of this tuple to the value of tuple t1.</summary>
		/// <remarks>Sets the value of this tuple to the value of tuple t1.</remarks>
		/// <param name="t1">the tuple to be copied</param>
		public void Set(Tuple4i t1)
		{
			this.x = t1.x;
			this.y = t1.y;
			this.z = t1.z;
			this.w = t1.w;
		}

		/// <summary>Copies the values of this tuple into the array t.</summary>
		/// <remarks>Copies the values of this tuple into the array t.</remarks>
		/// <param name="t">the array</param>
		public void Get(int[] t)
		{
			t[0] = this.x;
			t[1] = this.y;
			t[2] = this.z;
			t[3] = this.w;
		}

		/// <summary>Copies the values of this tuple into the tuple t.</summary>
		/// <remarks>Copies the values of this tuple into the tuple t.</remarks>
		/// <param name="t">the target tuple</param>
		public void Get(Tuple4i t)
		{
			t.x = this.x;
			t.y = this.y;
			t.z = this.z;
			t.w = this.w;
		}

		/// <summary>Sets the value of this tuple to the sum of tuples t1 and t2.</summary>
		/// <remarks>Sets the value of this tuple to the sum of tuples t1 and t2.</remarks>
		/// <param name="t1">the first tuple</param>
		/// <param name="t2">the second tuple</param>
		public void Add(Tuple4i t1, Tuple4i t2)
		{
			this.x = t1.x + t2.x;
			this.y = t1.y + t2.y;
			this.z = t1.z + t2.z;
			this.w = t1.w + t2.w;
		}

		/// <summary>Sets the value of this tuple to the sum of itself and t1.</summary>
		/// <remarks>Sets the value of this tuple to the sum of itself and t1.</remarks>
		/// <param name="t1">the other tuple</param>
		public void Add(Tuple4i t1)
		{
			this.x += t1.x;
			this.y += t1.y;
			this.z += t1.z;
			this.w += t1.w;
		}

		/// <summary>
		/// Sets the value of this tuple to the difference
		/// of tuples t1 and t2 (this = t1 - t2).
		/// </summary>
		/// <remarks>
		/// Sets the value of this tuple to the difference
		/// of tuples t1 and t2 (this = t1 - t2).
		/// </remarks>
		/// <param name="t1">the first tuple</param>
		/// <param name="t2">the second tuple</param>
		public void Sub(Tuple4i t1, Tuple4i t2)
		{
			this.x = t1.x - t2.x;
			this.y = t1.y - t2.y;
			this.z = t1.z - t2.z;
			this.w = t1.w - t2.w;
		}

		/// <summary>
		/// Sets the value of this tuple to the difference
		/// of itself and t1 (this = this - t1).
		/// </summary>
		/// <remarks>
		/// Sets the value of this tuple to the difference
		/// of itself and t1 (this = this - t1).
		/// </remarks>
		/// <param name="t1">the other tuple</param>
		public void Sub(Tuple4i t1)
		{
			this.x -= t1.x;
			this.y -= t1.y;
			this.z -= t1.z;
			this.w -= t1.w;
		}

		/// <summary>Sets the value of this tuple to the negation of tuple t1.</summary>
		/// <remarks>Sets the value of this tuple to the negation of tuple t1.</remarks>
		/// <param name="t1">the source tuple</param>
		public void Negate(Tuple4i t1)
		{
			this.x = -t1.x;
			this.y = -t1.y;
			this.z = -t1.z;
			this.w = -t1.w;
		}

		/// <summary>Negates the value of this tuple in place.</summary>
		/// <remarks>Negates the value of this tuple in place.</remarks>
		public void Negate()
		{
			this.x = -this.x;
			this.y = -this.y;
			this.z = -this.z;
			this.w = -this.w;
		}

		/// <summary>
		/// Sets the value of this tuple to the scalar multiplication
		/// of tuple t1.
		/// </summary>
		/// <remarks>
		/// Sets the value of this tuple to the scalar multiplication
		/// of tuple t1.
		/// </remarks>
		/// <param name="s">the scalar value</param>
		/// <param name="t1">the source tuple</param>
		public void Scale(int s, Tuple4i t1)
		{
			this.x = s * t1.x;
			this.y = s * t1.y;
			this.z = s * t1.z;
			this.w = s * t1.w;
		}

		/// <summary>
		/// Sets the value of this tuple to the scalar multiplication
		/// of the scale factor with this.
		/// </summary>
		/// <remarks>
		/// Sets the value of this tuple to the scalar multiplication
		/// of the scale factor with this.
		/// </remarks>
		/// <param name="s">the scalar value</param>
		public void Scale(int s)
		{
			this.x *= s;
			this.y *= s;
			this.z *= s;
			this.w *= s;
		}

		/// <summary>
		/// Sets the value of this tuple to the scalar multiplication
		/// of tuple t1 plus tuple t2 (this = s*t1 + t2).
		/// </summary>
		/// <remarks>
		/// Sets the value of this tuple to the scalar multiplication
		/// of tuple t1 plus tuple t2 (this = s*t1 + t2).
		/// </remarks>
		/// <param name="s">the scalar value</param>
		/// <param name="t1">the tuple to be multipled</param>
		/// <param name="t2">the tuple to be added</param>
		public void ScaleAdd(int s, Tuple4i t1, Tuple4i t2)
		{
			this.x = s * t1.x + t2.x;
			this.y = s * t1.y + t2.y;
			this.z = s * t1.z + t2.z;
			this.w = s * t1.w + t2.w;
		}

		/// <summary>
		/// Sets the value of this tuple to the scalar multiplication
		/// of itself and then adds tuple t1 (this = s*this + t1).
		/// </summary>
		/// <remarks>
		/// Sets the value of this tuple to the scalar multiplication
		/// of itself and then adds tuple t1 (this = s*this + t1).
		/// </remarks>
		/// <param name="s">the scalar value</param>
		/// <param name="t1">the tuple to be added</param>
		public void ScaleAdd(int s, Tuple4i t1)
		{
			this.x = s * this.x + t1.x;
			this.y = s * this.y + t1.y;
			this.z = s * this.z + t1.z;
			this.w = s * this.w + t1.w;
		}

		/// <summary>Returns a string that contains the values of this Tuple4i.</summary>
		/// <remarks>
		/// Returns a string that contains the values of this Tuple4i.
		/// The form is (x,y,z,w).
		/// </remarks>
		/// <returns>the String representation</returns>
		public override string ToString()
		{
			return "(" + this.x + ", " + this.y + ", " + this.z + ", " + this.w + ")";
		}

		/// <summary>
		/// Returns true if the Object t1 is of type Tuple4i and all of the
		/// data members of t1 are equal to the corresponding data members in
		/// this Tuple4i.
		/// </summary>
		/// <remarks>
		/// Returns true if the Object t1 is of type Tuple4i and all of the
		/// data members of t1 are equal to the corresponding data members in
		/// this Tuple4i.
		/// </remarks>
		/// <param name="t1">the object with which the comparison is made</param>
		/// <returns>true or false</returns>
		public override bool Equals(object t1)
		{
			try
			{
				Tuple4i t2 = (Tuple4i)t1;
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
		/// object.  Two different Tuple4i objects with identical data values
		/// (i.e., Tuple4i.equals returns true) will return the same hash
		/// code value.  Two objects with different data members may return the
		/// same hash value, although this is not likely.
		/// </remarks>
		/// <returns>the integer hash code value</returns>
		public override int GetHashCode()
		{
			long bits = 1L;
			bits = 31L * bits + (long)x;
			bits = 31L * bits + (long)y;
			bits = 31L * bits + (long)z;
			bits = 31L * bits + (long)w;
			return (int)(bits ^ (bits >> 32));
		}

		/// <summary>
		/// Clamps the tuple parameter to the range [low, high] and
		/// places the values into this tuple.
		/// </summary>
		/// <remarks>
		/// Clamps the tuple parameter to the range [low, high] and
		/// places the values into this tuple.
		/// </remarks>
		/// <param name="min">the lowest value in the tuple after clamping</param>
		/// <param name="max">the highest value in the tuple after clamping</param>
		/// <param name="t">the source tuple, which will not be modified</param>
		public void Clamp(int min, int max, Tuple4i t)
		{
			if (t.x > max)
			{
				x = max;
			}
			else
			{
				if (t.x < min)
				{
					x = min;
				}
				else
				{
					x = t.x;
				}
			}
			if (t.y > max)
			{
				y = max;
			}
			else
			{
				if (t.y < min)
				{
					y = min;
				}
				else
				{
					y = t.y;
				}
			}
			if (t.z > max)
			{
				z = max;
			}
			else
			{
				if (t.z < min)
				{
					z = min;
				}
				else
				{
					z = t.z;
				}
			}
			if (t.w > max)
			{
				w = max;
			}
			else
			{
				if (t.w < min)
				{
					w = min;
				}
				else
				{
					w = t.w;
				}
			}
		}

		/// <summary>
		/// Clamps the minimum value of the tuple parameter to the min
		/// parameter and places the values into this tuple.
		/// </summary>
		/// <remarks>
		/// Clamps the minimum value of the tuple parameter to the min
		/// parameter and places the values into this tuple.
		/// </remarks>
		/// <param name="min">the lowest value in the tuple after clamping</param>
		/// <param name="t">the source tuple, which will not be modified</param>
		public void ClampMin(int min, Tuple4i t)
		{
			if (t.x < min)
			{
				x = min;
			}
			else
			{
				x = t.x;
			}
			if (t.y < min)
			{
				y = min;
			}
			else
			{
				y = t.y;
			}
			if (t.z < min)
			{
				z = min;
			}
			else
			{
				z = t.z;
			}
			if (t.w < min)
			{
				w = min;
			}
			else
			{
				w = t.w;
			}
		}

		/// <summary>
		/// Clamps the maximum value of the tuple parameter to the max
		/// parameter and places the values into this tuple.
		/// </summary>
		/// <remarks>
		/// Clamps the maximum value of the tuple parameter to the max
		/// parameter and places the values into this tuple.
		/// </remarks>
		/// <param name="max">the highest value in the tuple after clamping</param>
		/// <param name="t">the source tuple, which will not be modified</param>
		public void ClampMax(int max, Tuple4i t)
		{
			if (t.x > max)
			{
				x = max;
			}
			else
			{
				x = t.x;
			}
			if (t.y > max)
			{
				y = max;
			}
			else
			{
				y = t.y;
			}
			if (t.z > max)
			{
				z = max;
			}
			else
			{
				z = t.z;
			}
			if (t.w > max)
			{
				w = max;
			}
			else
			{
				w = t.z;
			}
		}

		/// <summary>
		/// Sets each component of the tuple parameter to its absolute
		/// value and places the modified values into this tuple.
		/// </summary>
		/// <remarks>
		/// Sets each component of the tuple parameter to its absolute
		/// value and places the modified values into this tuple.
		/// </remarks>
		/// <param name="t">the source tuple, which will not be modified</param>
		public void Absolute(Tuple4i t)
		{
			x = Math.Abs(t.x);
			y = Math.Abs(t.y);
			z = Math.Abs(t.z);
			w = Math.Abs(t.w);
		}

		/// <summary>Clamps this tuple to the range [low, high].</summary>
		/// <remarks>Clamps this tuple to the range [low, high].</remarks>
		/// <param name="min">the lowest value in this tuple after clamping</param>
		/// <param name="max">the highest value in this tuple after clamping</param>
		public void Clamp(int min, int max)
		{
			if (x > max)
			{
				x = max;
			}
			else
			{
				if (x < min)
				{
					x = min;
				}
			}
			if (y > max)
			{
				y = max;
			}
			else
			{
				if (y < min)
				{
					y = min;
				}
			}
			if (z > max)
			{
				z = max;
			}
			else
			{
				if (z < min)
				{
					z = min;
				}
			}
			if (w > max)
			{
				w = max;
			}
			else
			{
				if (w < min)
				{
					w = min;
				}
			}
		}

		/// <summary>Clamps the minimum value of this tuple to the min parameter.</summary>
		/// <remarks>Clamps the minimum value of this tuple to the min parameter.</remarks>
		/// <param name="min">the lowest value in this tuple after clamping</param>
		public void ClampMin(int min)
		{
			if (x < min)
			{
				x = min;
			}
			if (y < min)
			{
				y = min;
			}
			if (z < min)
			{
				z = min;
			}
			if (w < min)
			{
				w = min;
			}
		}

		/// <summary>Clamps the maximum value of this tuple to the max parameter.</summary>
		/// <remarks>Clamps the maximum value of this tuple to the max parameter.</remarks>
		/// <param name="max">the highest value in the tuple after clamping</param>
		public void ClampMax(int max)
		{
			if (x > max)
			{
				x = max;
			}
			if (y > max)
			{
				y = max;
			}
			if (z > max)
			{
				z = max;
			}
			if (w > max)
			{
				w = max;
			}
		}

		/// <summary>Sets each component of this tuple to its absolute value.</summary>
		/// <remarks>Sets each component of this tuple to its absolute value.</remarks>
		public void Absolute()
		{
			x = Math.Abs(x);
			y = Math.Abs(y);
			z = Math.Abs(z);
			w = Math.Abs(w);
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
		/// <summary>Get the <i>x</i> coordinate.</summary>
		/// <remarks>Get the <i>x</i> coordinate.</remarks>
		/// <returns>the <i>x</i> coordinate.</returns>
		/// <since>vecmath 1.5</since>
		public int GetX()
		{
			return x;
		}

		/// <summary>Set the <i>x</i> coordinate.</summary>
		/// <remarks>Set the <i>x</i> coordinate.</remarks>
		/// <param name="x">value to <i>x</i> coordinate.</param>
		/// <since>vecmath 1.5</since>
		public void SetX(int x)
		{
			this.x = x;
		}

		/// <summary>Get the <i>y</i> coordinate.</summary>
		/// <remarks>Get the <i>y</i> coordinate.</remarks>
		/// <returns>the <i>y</i> coordinate.</returns>
		/// <since>vecmath 1.5</since>
		public int GetY()
		{
			return y;
		}

		/// <summary>Set the <i>y</i> coordinate.</summary>
		/// <remarks>Set the <i>y</i> coordinate.</remarks>
		/// <param name="y">value to <i>y</i> coordinate.</param>
		/// <since>vecmath 1.5</since>
		public void SetY(int y)
		{
			this.y = y;
		}

		/// <summary>Get the <i>z</i> coordinate.</summary>
		/// <remarks>Get the <i>z</i> coordinate.</remarks>
		/// <returns>the <i>z</i> coordinate.</returns>
		/// <since>vecmath 1.5</since>
		public int GetZ()
		{
			return z;
		}

		/// <summary>Set the <i>z</i> coordinate.</summary>
		/// <remarks>Set the <i>z</i> coordinate.</remarks>
		/// <param name="z">value to <i>z</i> coordinate.</param>
		/// <since>vecmath 1.5</since>
		public void SetZ(int z)
		{
			this.z = z;
		}

		/// <summary>Get the <i>w</i> coordinate.</summary>
		/// <remarks>Get the <i>w</i> coordinate.</remarks>
		/// <returns>the  <i>w</i> coordinate.</returns>
		/// <since>vecmath 1.5</since>
		public int GetW()
		{
			return w;
		}

		/// <summary>Set the <i>w</i> coordinate.</summary>
		/// <remarks>Set the <i>w</i> coordinate.</remarks>
		/// <param name="w">value to <i>w</i> coordinate.</param>
		/// <since>vecmath 1.5</since>
		public void SetW(int w)
		{
			this.w = w;
		}
	}
}
