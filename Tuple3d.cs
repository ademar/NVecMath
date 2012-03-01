/*
 * Automated conversion
 */

using System;

namespace NVecMath
{
	/// <summary>
	/// A generic 3-element tuple that is represented by double-precision
	/// floating point x,y,z coordinates.
	/// </summary>
	/// <remarks>
	/// A generic 3-element tuple that is represented by double-precision
	/// floating point x,y,z coordinates.
	/// </remarks>
	[System.Serializable]
	public abstract class Tuple3d : ICloneable
	{
		internal const long serialVersionUID = 5542096614926168415L;

		/// <summary>The x coordinate.</summary>
		/// <remarks>The x coordinate.</remarks>
		public double x;

		/// <summary>The y coordinate.</summary>
		/// <remarks>The y coordinate.</remarks>
		public double y;

		/// <summary>The z coordinate.</summary>
		/// <remarks>The z coordinate.</remarks>
		public double z;

		/// <summary>Constructs and initializes a Tuple3d from the specified xyz coordinates.
		/// 	</summary>
		/// <remarks>Constructs and initializes a Tuple3d from the specified xyz coordinates.
		/// 	</remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		/// <param name="z">the z coordinate</param>
		public Tuple3d(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		/// <summary>Constructs and initializes a Tuple3d from the array of length 3.</summary>
		/// <remarks>Constructs and initializes a Tuple3d from the array of length 3.</remarks>
		/// <param name="t">the array of length 3 containing xyz in order</param>
		public Tuple3d(double[] t)
		{
			this.x = t[0];
			this.y = t[1];
			this.z = t[2];
		}

		/// <summary>Constructs and initializes a Tuple3d from the specified Tuple3d.</summary>
		/// <remarks>Constructs and initializes a Tuple3d from the specified Tuple3d.</remarks>
		/// <param name="t1">the Tuple3d containing the initialization x y z data</param>
		public Tuple3d(Tuple3d t1)
		{
			this.x = t1.x;
			this.y = t1.y;
			this.z = t1.z;
		}

		/// <summary>Constructs and initializes a Tuple3d from the specified Tuple3f.</summary>
		/// <remarks>Constructs and initializes a Tuple3d from the specified Tuple3f.</remarks>
		/// <param name="t1">the Tuple3f containing the initialization x y z data</param>
		public Tuple3d(Tuple3f t1)
		{
			this.x = (double)t1.x;
			this.y = (double)t1.y;
			this.z = (double)t1.z;
		}

		/// <summary>Constructs and initializes a Tuple3d to (0,0,0).</summary>
		/// <remarks>Constructs and initializes a Tuple3d to (0,0,0).</remarks>
		public Tuple3d()
		{
			this.x = (double)0.0;
			this.y = (double)0.0;
			this.z = (double)0.0;
		}

		/// <summary>Sets the value of this tuple to the specified xyz coordinates.</summary>
		/// <remarks>Sets the value of this tuple to the specified xyz coordinates.</remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		/// <param name="z">the z coordinate</param>
		public void Set(double x, double y, double z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		/// <summary>
		/// Sets the value of this tuple to the value of the xyz coordinates
		/// located in the array of length 3.
		/// </summary>
		/// <remarks>
		/// Sets the value of this tuple to the value of the xyz coordinates
		/// located in the array of length 3.
		/// </remarks>
		/// <param name="t">the array of length 3 containing xyz in order</param>
		public void Set(double[] t)
		{
			this.x = t[0];
			this.y = t[1];
			this.z = t[2];
		}

		/// <summary>Sets the value of this tuple to the value of tuple t1.</summary>
		/// <remarks>Sets the value of this tuple to the value of tuple t1.</remarks>
		/// <param name="t1">the tuple to be copied</param>
		public void Set(Tuple3d t1)
		{
			this.x = t1.x;
			this.y = t1.y;
			this.z = t1.z;
		}

		/// <summary>Sets the value of this tuple to the value of tuple t1.</summary>
		/// <remarks>Sets the value of this tuple to the value of tuple t1.</remarks>
		/// <param name="t1">the tuple to be copied</param>
		public void Set(Tuple3f t1)
		{
			this.x = (double)t1.x;
			this.y = (double)t1.y;
			this.z = (double)t1.z;
		}

		/// <summary>
		/// Copies the x,y,z coordinates of this tuple into the array t
		/// of length 3.
		/// </summary>
		/// <remarks>
		/// Copies the x,y,z coordinates of this tuple into the array t
		/// of length 3.
		/// </remarks>
		/// <param name="t">the target array</param>
		public void Get(double[] t)
		{
			t[0] = this.x;
			t[1] = this.y;
			t[2] = this.z;
		}

		/// <summary>Copies the x,y,z coordinates of this tuple into the tuple t.</summary>
		/// <remarks>Copies the x,y,z coordinates of this tuple into the tuple t.</remarks>
		/// <param name="t">the Tuple3d object into which the values of this object are copied
		/// 	</param>
		public void Get(Tuple3d t)
		{
			t.x = this.x;
			t.y = this.y;
			t.z = this.z;
		}

		/// <summary>Sets the value of this tuple to the sum of tuples t1 and t2.</summary>
		/// <remarks>Sets the value of this tuple to the sum of tuples t1 and t2.</remarks>
		/// <param name="t1">the first tuple</param>
		/// <param name="t2">the second tuple</param>
		public void Add(Tuple3d t1, Tuple3d t2)
		{
			this.x = t1.x + t2.x;
			this.y = t1.y + t2.y;
			this.z = t1.z + t2.z;
		}

		/// <summary>Sets the value of this tuple to the sum of itself and t1.</summary>
		/// <remarks>Sets the value of this tuple to the sum of itself and t1.</remarks>
		/// <param name="t1">the other tuple</param>
		public void Add(Tuple3d t1)
		{
			this.x += t1.x;
			this.y += t1.y;
			this.z += t1.z;
		}

		/// <summary>
		/// Sets the value of this tuple to the difference of tuples
		/// t1 and t2 (this = t1 - t2).
		/// </summary>
		/// <remarks>
		/// Sets the value of this tuple to the difference of tuples
		/// t1 and t2 (this = t1 - t2).
		/// </remarks>
		/// <param name="t1">the first tuple</param>
		/// <param name="t2">the second tuple</param>
		public void Sub(Tuple3d t1, Tuple3d t2)
		{
			this.x = t1.x - t2.x;
			this.y = t1.y - t2.y;
			this.z = t1.z - t2.z;
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
		public void Sub(Tuple3d t1)
		{
			this.x -= t1.x;
			this.y -= t1.y;
			this.z -= t1.z;
		}

		/// <summary>Sets the value of this tuple to the negation of tuple t1.</summary>
		/// <remarks>Sets the value of this tuple to the negation of tuple t1.</remarks>
		/// <param name="t1">the source tuple</param>
		public void Negate(Tuple3d t1)
		{
			this.x = -t1.x;
			this.y = -t1.y;
			this.z = -t1.z;
		}

		/// <summary>Negates the value of this tuple in place.</summary>
		/// <remarks>Negates the value of this tuple in place.</remarks>
		public void Negate()
		{
			this.x = -this.x;
			this.y = -this.y;
			this.z = -this.z;
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
		public void Scale(double s, Tuple3d t1)
		{
			this.x = s * t1.x;
			this.y = s * t1.y;
			this.z = s * t1.z;
		}

		/// <summary>
		/// Sets the value of this tuple to the scalar multiplication
		/// of itself.
		/// </summary>
		/// <remarks>
		/// Sets the value of this tuple to the scalar multiplication
		/// of itself.
		/// </remarks>
		/// <param name="s">the scalar value</param>
		public void Scale(double s)
		{
			this.x *= s;
			this.y *= s;
			this.z *= s;
		}

		/// <summary>
		/// Sets the value of this tuple to the scalar multiplication
		/// of tuple t1 and then adds tuple t2 (this = s*t1 + t2).
		/// </summary>
		/// <remarks>
		/// Sets the value of this tuple to the scalar multiplication
		/// of tuple t1 and then adds tuple t2 (this = s*t1 + t2).
		/// </remarks>
		/// <param name="s">the scalar value</param>
		/// <param name="t1">the tuple to be multipled</param>
		/// <param name="t2">the tuple to be added</param>
		public void ScaleAdd(double s, Tuple3d t1, Tuple3d t2)
		{
			this.x = s * t1.x + t2.x;
			this.y = s * t1.y + t2.y;
			this.z = s * t1.z + t2.z;
		}

		[System.ObsoleteAttribute(@"Use scaleAdd(double,Tuple3d) instead")]
		public void ScaleAdd(double s, Tuple3f t1)
		{
			ScaleAdd(s, new Point3d(t1));
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
		public void ScaleAdd(double s, Tuple3d t1)
		{
			this.x = s * this.x + t1.x;
			this.y = s * this.y + t1.y;
			this.z = s * this.z + t1.z;
		}

		/// <summary>Returns a string that contains the values of this Tuple3d.</summary>
		/// <remarks>
		/// Returns a string that contains the values of this Tuple3d.
		/// The form is (x,y,z).
		/// </remarks>
		/// <returns>the String representation</returns>
		public override string ToString()
		{
			return "(" + this.x + ", " + this.y + ", " + this.z + ")";
		}

		/// <summary>
		/// Returns a hash code value based on the data values in this
		/// object.
		/// </summary>
		/// <remarks>
		/// Returns a hash code value based on the data values in this
		/// object.  Two different Tuple3d objects with identical data values
		/// (i.e., Tuple3d.equals returns true) will return the same hash
		/// code value.  Two objects with different data members may return the
		/// same hash value, although this is not likely.
		/// </remarks>
		/// <returns>the integer hash code value</returns>
		public override int GetHashCode()
		{
			long bits = 1L;
			bits = 31L * bits + VecMathUtil.DoubleToLongBits(x);
			bits = 31L * bits + VecMathUtil.DoubleToLongBits(y);
			bits = 31L * bits + VecMathUtil.DoubleToLongBits(z);
			return (int)(bits ^ (bits >> 32));
		}

		/// <summary>
		/// Returns true if all of the data members of Tuple3d t1 are
		/// equal to the corresponding data members in this Tuple3d.
		/// </summary>
		/// <remarks>
		/// Returns true if all of the data members of Tuple3d t1 are
		/// equal to the corresponding data members in this Tuple3d.
		/// </remarks>
		/// <param name="t1">the tuple with which the comparison is made</param>
		/// <returns>true or false</returns>
		public virtual bool Equals(Tuple3d t1)
		{
			try
			{
				return (this.x == t1.x && this.y == t1.y && this.z == t1.z);
			}
			catch (ArgumentNullException)
			{
				return false;
			}
		}

		/// <summary>
		/// Returns true if the Object t1 is of type Tuple3d and all of the
		/// data members of t1 are equal to the corresponding data members in
		/// this Tuple3d.
		/// </summary>
		/// <remarks>
		/// Returns true if the Object t1 is of type Tuple3d and all of the
		/// data members of t1 are equal to the corresponding data members in
		/// this Tuple3d.
		/// </remarks>
		/// <param name="t1">the Object with which the comparison is made</param>
		/// <returns>true or false</returns>
		public override bool Equals(object t1)
		{
			try
			{
				Tuple3d t2 = (Tuple3d)t1;
				return (this.x == t2.x && this.y == t2.y && this.z == t2.z);
			}
			catch (InvalidCastException)
			{
				return false;
			}
			catch (ArgumentNullException)
			{
				return false;
			}
		}

		/// <summary>
		/// Returns true if the L-infinite distance between this tuple
		/// and tuple t1 is less than or equal to the epsilon parameter,
		/// otherwise returns false.
		/// </summary>
		/// <remarks>
		/// Returns true if the L-infinite distance between this tuple
		/// and tuple t1 is less than or equal to the epsilon parameter,
		/// otherwise returns false.  The L-infinite
		/// distance is equal to MAX[abs(x1-x2), abs(y1-y2), abs(z1-z2)].
		/// </remarks>
		/// <param name="t1">the tuple to be compared to this tuple</param>
		/// <param name="epsilon">the threshold value</param>
		/// <returns>true or false</returns>
		public virtual bool EpsilonEquals(Tuple3d t1, double epsilon)
		{
			double diff;
			diff = x - t1.x;
			if (double.IsNaN(diff))
			{
				return false;
			}
			if ((diff < 0 ? -diff : diff) > epsilon)
			{
				return false;
			}
			diff = y - t1.y;
			if (double.IsNaN(diff))
			{
				return false;
			}
			if ((diff < 0 ? -diff : diff) > epsilon)
			{
				return false;
			}
			diff = z - t1.z;
			if (double.IsNaN(diff))
			{
				return false;
			}
			if ((diff < 0 ? -diff : diff) > epsilon)
			{
				return false;
			}
			return true;
		}

		[System.ObsoleteAttribute(@"Use clamp(double,double,Tuple3d) instead")]
		public void Clamp(float min, float max, Tuple3d t)
		{
			Clamp((double)min, (double)max, t);
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
		public void Clamp(double min, double max, Tuple3d t)
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
		}

		[System.ObsoleteAttribute(@"Use clampMin(double,Tuple3d) instead")]
		public void ClampMin(float min, Tuple3d t)
		{
			ClampMin((double)min, t);
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
		public void ClampMin(double min, Tuple3d t)
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
		}

		[System.ObsoleteAttribute(@"Use clampMax(double,Tuple3d) instead")]
		public void ClampMax(float max, Tuple3d t)
		{
			ClampMax((double)max, t);
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
		public void ClampMax(double max, Tuple3d t)
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
		public void Absolute(Tuple3d t)
		{
			x = Math.Abs(t.x);
			y = Math.Abs(t.y);
			z = Math.Abs(t.z);
		}

		[System.ObsoleteAttribute(@"Use clamp(double,double) instead")]
		public void Clamp(float min, float max)
		{
			Clamp((double)min, (double)max);
		}

		/// <summary>Clamps this tuple to the range [low, high].</summary>
		/// <remarks>Clamps this tuple to the range [low, high].</remarks>
		/// <param name="min">the lowest value in this tuple after clamping</param>
		/// <param name="max">the highest value in this tuple after clamping</param>
		public void Clamp(double min, double max)
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
		}

		[System.ObsoleteAttribute(@"Use clampMin(double) instead")]
		public void ClampMin(float min)
		{
			ClampMin((double)min);
		}

		/// <summary>Clamps the minimum value of this tuple to the min parameter.</summary>
		/// <remarks>Clamps the minimum value of this tuple to the min parameter.</remarks>
		/// <param name="min">the lowest value in this tuple after clamping</param>
		public void ClampMin(double min)
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
		}

		[System.ObsoleteAttribute(@"Use clampMax(double) instead")]
		public void ClampMax(float max)
		{
			ClampMax((double)max);
		}

		/// <summary>Clamps the maximum value of this tuple to the max parameter.</summary>
		/// <remarks>Clamps the maximum value of this tuple to the max parameter.</remarks>
		/// <param name="max">the highest value in the tuple after clamping</param>
		public void ClampMax(double max)
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
		}

		/// <summary>Sets each component of this tuple to its absolute value.</summary>
		/// <remarks>Sets each component of this tuple to its absolute value.</remarks>
		public void Absolute()
		{
			x = Math.Abs(x);
			y = Math.Abs(y);
			z = Math.Abs(z);
		}

		[System.ObsoleteAttribute(@"Use interpolate(Tuple3d,Tuple3d,double) instead")]
		public void Interpolate(Tuple3d t1, Tuple3d t2, float alpha)
		{
			Interpolate(t1, t2, (double)alpha);
		}

		/// <summary>
		/// Linearly interpolates between tuples t1 and t2 and places the
		/// result into this tuple:  this = (1-alpha)*t1 + alpha*t2.
		/// </summary>
		/// <remarks>
		/// Linearly interpolates between tuples t1 and t2 and places the
		/// result into this tuple:  this = (1-alpha)*t1 + alpha*t2.
		/// </remarks>
		/// <param name="t1">the first tuple</param>
		/// <param name="t2">the second tuple</param>
		/// <param name="alpha">the alpha interpolation parameter</param>
		public void Interpolate(Tuple3d t1, Tuple3d t2, double alpha)
		{
			this.x = (1 - alpha) * t1.x + alpha * t2.x;
			this.y = (1 - alpha) * t1.y + alpha * t2.y;
			this.z = (1 - alpha) * t1.z + alpha * t2.z;
		}

		[System.ObsoleteAttribute(@"Use interpolate(Tuple3d,double) instead")]
		public void Interpolate(Tuple3d t1, float alpha)
		{
			Interpolate(t1, (double)alpha);
		}

		/// <summary>
		/// Linearly interpolates between this tuple and tuple t1 and
		/// places the result into this tuple:  this = (1-alpha)*this + alpha*t1.
		/// </summary>
		/// <remarks>
		/// Linearly interpolates between this tuple and tuple t1 and
		/// places the result into this tuple:  this = (1-alpha)*this + alpha*t1.
		/// </remarks>
		/// <param name="t1">the first tuple</param>
		/// <param name="alpha">the alpha interpolation parameter</param>
		public void Interpolate(Tuple3d t1, double alpha)
		{
			this.x = (1 - alpha) * this.x + alpha * t1.x;
			this.y = (1 - alpha) * this.y + alpha * t1.y;
			this.z = (1 - alpha) * this.z + alpha * t1.z;
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
		public double GetX()
		{
			return x;
		}

		/// <summary>Set the <i>x</i> coordinate.</summary>
		/// <remarks>Set the <i>x</i> coordinate.</remarks>
		/// <param name="x">value to <i>x</i> coordinate.</param>
		/// <since>vecmath 1.5</since>
		public void SetX(double x)
		{
			this.x = x;
		}

		/// <summary>Get the <i>y</i> coordinate.</summary>
		/// <remarks>Get the <i>y</i> coordinate.</remarks>
		/// <returns>the <i>y</i> coordinate.</returns>
		/// <since>vecmath 1.5</since>
		public double GetY()
		{
			return y;
		}

		/// <summary>Set the <i>y</i> coordinate.</summary>
		/// <remarks>Set the <i>y</i> coordinate.</remarks>
		/// <param name="y">value to <i>y</i> coordinate.</param>
		/// <since>vecmath 1.5</since>
		public void SetY(double y)
		{
			this.y = y;
		}

		/// <summary>Get the <i>z</i> coordinate.</summary>
		/// <remarks>Get the <i>z</i> coordinate.</remarks>
		/// <returns>the <i>z</i> coordinate.</returns>
		/// <since>vecmath 1.5</since>
		public double GetZ()
		{
			return z;
		}

		/// <summary>Set the <i>z</i> coordinate.</summary>
		/// <remarks>Set the <i>z</i> coordinate.</remarks>
		/// <param name="z">value to <i>z</i> coordinate.</param>
		/// <since>vecmath 1.5</since>
		public void SetZ(double z)
		{
			this.z = z;
		}
	}
}
