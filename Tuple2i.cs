/*
 * Automated conversion
 */

using System;

namespace NVecMath
{
	/// <summary>
	/// A 2-element tuple represented by signed integer x,y
	/// coordinates.
	/// </summary>
	/// <remarks>
	/// A 2-element tuple represented by signed integer x,y
	/// coordinates.
	/// </remarks>
	/// <since>vecmath 1.4</since>
	[System.Serializable]
	public abstract class Tuple2i : ICloneable
	{
		internal const long serialVersionUID = -3555701650170169638L;

		/// <summary>The x coordinate.</summary>
		/// <remarks>The x coordinate.</remarks>
		public int x;

		/// <summary>The y coordinate.</summary>
		/// <remarks>The y coordinate.</remarks>
		public int y;

		/// <summary>
		/// Constructs and initializes a Tuple2i from the specified
		/// x and y coordinates.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes a Tuple2i from the specified
		/// x and y coordinates.
		/// </remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		public Tuple2i(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		/// <summary>Constructs and initializes a Tuple2i from the array of length 2.</summary>
		/// <remarks>Constructs and initializes a Tuple2i from the array of length 2.</remarks>
		/// <param name="t">the array of length 2 containing x and y in order.</param>
		public Tuple2i(int[] t)
		{
			this.x = t[0];
			this.y = t[1];
		}

		/// <summary>Constructs and initializes a Tuple2i from the specified Tuple2i.</summary>
		/// <remarks>Constructs and initializes a Tuple2i from the specified Tuple2i.</remarks>
		/// <param name="t1">
		/// the Tuple2i containing the initialization x and y
		/// data.
		/// </param>
		public Tuple2i(Tuple2i t1)
		{
			this.x = t1.x;
			this.y = t1.y;
		}

		/// <summary>Constructs and initializes a Tuple2i to (0,0).</summary>
		/// <remarks>Constructs and initializes a Tuple2i to (0,0).</remarks>
		public Tuple2i()
		{
			this.x = 0;
			this.y = 0;
		}

		/// <summary>
		/// Sets the value of this tuple to the specified x and y
		/// coordinates.
		/// </summary>
		/// <remarks>
		/// Sets the value of this tuple to the specified x and y
		/// coordinates.
		/// </remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		public void Set(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		/// <summary>
		/// Sets the value of this tuple to the specified coordinates in the
		/// array of length 2.
		/// </summary>
		/// <remarks>
		/// Sets the value of this tuple to the specified coordinates in the
		/// array of length 2.
		/// </remarks>
		/// <param name="t">the array of length 2 containing x and y in order.</param>
		public void Set(int[] t)
		{
			this.x = t[0];
			this.y = t[1];
		}

		/// <summary>Sets the value of this tuple to the value of tuple t1.</summary>
		/// <remarks>Sets the value of this tuple to the value of tuple t1.</remarks>
		/// <param name="t1">the tuple to be copied</param>
		public void Set(Tuple2i t1)
		{
			this.x = t1.x;
			this.y = t1.y;
		}

		/// <summary>Copies the values of this tuple into the array t.</summary>
		/// <remarks>Copies the values of this tuple into the array t.</remarks>
		/// <param name="t">is the array</param>
		public void Get(int[] t)
		{
			t[0] = this.x;
			t[1] = this.y;
		}

		/// <summary>Copies the values of this tuple into the tuple t.</summary>
		/// <remarks>Copies the values of this tuple into the tuple t.</remarks>
		/// <param name="t">is the target tuple</param>
		public void Get(Tuple2i t)
		{
			t.x = this.x;
			t.y = this.y;
		}

		/// <summary>Sets the value of this tuple to the sum of tuples t1 and t2.</summary>
		/// <remarks>Sets the value of this tuple to the sum of tuples t1 and t2.</remarks>
		/// <param name="t1">the first tuple</param>
		/// <param name="t2">the second tuple</param>
		public void Add(Tuple2i t1, Tuple2i t2)
		{
			this.x = t1.x + t2.x;
			this.y = t1.y + t2.y;
		}

		/// <summary>Sets the value of this tuple to the sum of itself and t1.</summary>
		/// <remarks>Sets the value of this tuple to the sum of itself and t1.</remarks>
		/// <param name="t1">the other tuple</param>
		public void Add(Tuple2i t1)
		{
			this.x += t1.x;
			this.y += t1.y;
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
		public void Sub(Tuple2i t1, Tuple2i t2)
		{
			this.x = t1.x - t2.x;
			this.y = t1.y - t2.y;
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
		public void Sub(Tuple2i t1)
		{
			this.x -= t1.x;
			this.y -= t1.y;
		}

		/// <summary>Sets the value of this tuple to the negation of tuple t1.</summary>
		/// <remarks>Sets the value of this tuple to the negation of tuple t1.</remarks>
		/// <param name="t1">the source tuple</param>
		public void Negate(Tuple2i t1)
		{
			this.x = -t1.x;
			this.y = -t1.y;
		}

		/// <summary>Negates the value of this tuple in place.</summary>
		/// <remarks>Negates the value of this tuple in place.</remarks>
		public void Negate()
		{
			this.x = -this.x;
			this.y = -this.y;
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
		public void Scale(int s, Tuple2i t1)
		{
			this.x = s * t1.x;
			this.y = s * t1.y;
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
		public void ScaleAdd(int s, Tuple2i t1, Tuple2i t2)
		{
			this.x = s * t1.x + t2.x;
			this.y = s * t1.y + t2.y;
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
		public void ScaleAdd(int s, Tuple2i t1)
		{
			this.x = s * this.x + t1.x;
			this.y = s * this.y + t1.y;
		}

		/// <summary>Returns a string that contains the values of this Tuple2i.</summary>
		/// <remarks>
		/// Returns a string that contains the values of this Tuple2i.
		/// The form is (x,y).
		/// </remarks>
		/// <returns>the String representation</returns>
		public override string ToString()
		{
			return "(" + this.x + ", " + this.y + ")";
		}

		/// <summary>
		/// Returns true if the Object t1 is of type Tuple2i and all of the
		/// data members of t1 are equal to the corresponding data members in
		/// this Tuple2i.
		/// </summary>
		/// <remarks>
		/// Returns true if the Object t1 is of type Tuple2i and all of the
		/// data members of t1 are equal to the corresponding data members in
		/// this Tuple2i.
		/// </remarks>
		/// <param name="t1">the object with which the comparison is made</param>
		public override bool Equals(object t1)
		{
			try
			{
				Tuple2i t2 = (Tuple2i)t1;
				return (this.x == t2.x && this.y == t2.y);
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
		/// object.  Two different Tuple2i objects with identical data values
		/// (i.e., Tuple2i.equals returns true) will return the same hash
		/// code value.  Two objects with different data members may return the
		/// same hash value, although this is not likely.
		/// </remarks>
		/// <returns>the integer hash code value</returns>
		public override int GetHashCode()
		{
			long bits = 1L;
			bits = 31L * bits + (long)x;
			bits = 31L * bits + (long)y;
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
		public void Clamp(int min, int max, Tuple2i t)
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
		public void ClampMin(int min, Tuple2i t)
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
		public void ClampMax(int max, Tuple2i t)
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
		public void Absolute(Tuple2i t)
		{
			x = Math.Abs(t.x);
			y = Math.Abs(t.y);
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
		}

		/// <summary>Sets each component of this tuple to its absolute value.</summary>
		/// <remarks>Sets each component of this tuple to its absolute value.</remarks>
		public void Absolute()
		{
			x = Math.Abs(x);
			y = Math.Abs(y);
		}

		/// <summary>Creates a new object of the same class as this object.</summary>
		/// <remarks>Creates a new object of the same class as this object.</remarks>
		/// <returns>a clone of this instance.</returns>
		/// <exception>
		/// OutOfMemoryError
		/// if there is not enough memory.
		/// </exception>
		/// <seealso cref="System.ICloneable">System.ICloneable</seealso>
		public virtual object Clone()
		{
			// Since there are no arrays we can just use Object.clone()
			return base.MemberwiseClone();
		}

		// this shouldn't happen, since we are Cloneable
		/// <summary>Get the <i>x</i> coordinate.</summary>
		/// <remarks>Get the <i>x</i> coordinate.</remarks>
		/// <returns>the x coordinate.</returns>
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
	}
}
