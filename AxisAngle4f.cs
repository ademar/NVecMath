/*
 * Automated conversion
 */

using System;

namespace NVecMath
{
	/// <summary>
	/// A four-element axis angle represented by single-precision floating point
	/// x,y,z,angle components.
	/// </summary>
	/// <remarks>
	/// A four-element axis angle represented by single-precision floating point
	/// x,y,z,angle components.  An axis angle is a rotation of angle (radians)
	/// about the vector (x,y,z).
	/// </remarks>
	[System.Serializable]
	public class AxisAngle4f : ICloneable
	{
		internal const long serialVersionUID = -163246355858070601L;

		/// <summary>The x coordinate.</summary>
		/// <remarks>The x coordinate.</remarks>
		public float x;

		/// <summary>The y coordinate.</summary>
		/// <remarks>The y coordinate.</remarks>
		public float y;

		/// <summary>The z coordinate.</summary>
		/// <remarks>The z coordinate.</remarks>
		public float z;

		/// <summary>The angle of rotation in radians.</summary>
		/// <remarks>The angle of rotation in radians.</remarks>
		public float angle;

		internal const double Eps = 0.000001;

		/// <summary>Constructs and initializes a AxisAngle4f from the specified xyzw coordinates.
		/// 	</summary>
		/// <remarks>Constructs and initializes a AxisAngle4f from the specified xyzw coordinates.
		/// 	</remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		/// <param name="z">the z coordinate</param>
		/// <param name="angle">the angle of rotation in radians</param>
		public AxisAngle4f(float x, float y, float z, float angle)
		{
			// Compatible with 1.1
			this.x = x;
			this.y = y;
			this.z = z;
			this.angle = angle;
		}

		/// <summary>Constructs and initializes an AxisAngle4f from the array of length 4.</summary>
		/// <remarks>Constructs and initializes an AxisAngle4f from the array of length 4.</remarks>
		/// <param name="a">the array of length 4 containing x,y,z,angle in order</param>
		public AxisAngle4f(float[] a)
		{
			this.x = a[0];
			this.y = a[1];
			this.z = a[2];
			this.angle = a[3];
		}

		/// <summary>
		/// Constructs and initializes an AxisAngle4f from the specified
		/// AxisAngle4f.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes an AxisAngle4f from the specified
		/// AxisAngle4f.
		/// </remarks>
		/// <param name="a1">the AxisAngle4f containing the initialization x y z angle data</param>
		public AxisAngle4f(AxisAngle4f a1)
		{
			this.x = a1.x;
			this.y = a1.y;
			this.z = a1.z;
			this.angle = a1.angle;
		}

		/// <summary>Constructs and initializes an AxisAngle4f from the specified AxisAngle4d.
		/// 	</summary>
		/// <remarks>Constructs and initializes an AxisAngle4f from the specified AxisAngle4d.
		/// 	</remarks>
		/// <param name="a1">the AxisAngle4d containing the initialization x y z angle data</param>
		public AxisAngle4f(AxisAngle4d a1)
		{
			this.x = (float)a1.x;
			this.y = (float)a1.y;
			this.z = (float)a1.z;
			this.angle = (float)a1.angle;
		}

		/// <summary>
		/// Constructs and initializes an AxisAngle4f from the specified
		/// axis and angle.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes an AxisAngle4f from the specified
		/// axis and angle.
		/// </remarks>
		/// <param name="axis">the axis</param>
		/// <param name="angle">the angle of rotation in radians</param>
		/// <since>vecmath 1.2</since>
		public AxisAngle4f(Vector3f axis, float angle)
		{
			this.x = axis.x;
			this.y = axis.y;
			this.z = axis.z;
			this.angle = angle;
		}

		/// <summary>Constructs and initializes an AxisAngle4f to (0,0,1,0).</summary>
		/// <remarks>Constructs and initializes an AxisAngle4f to (0,0,1,0).</remarks>
		public AxisAngle4f()
		{
			this.x = 0.0f;
			this.y = 0.0f;
			this.z = 1.0f;
			this.angle = 0.0f;
		}

		/// <summary>Sets the value of this axis-angle to the specified x,y,z,angle.</summary>
		/// <remarks>Sets the value of this axis-angle to the specified x,y,z,angle.</remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		/// <param name="z">the z coordinate</param>
		/// <param name="angle">the angle of rotation in radians</param>
		public void Set(float x, float y, float z, float angle)
		{
			this.x = x;
			this.y = y;
			this.z = z;
			this.angle = angle;
		}

		/// <summary>
		/// Sets the value of this axis-angle to the specified values in the
		/// array of length 4.
		/// </summary>
		/// <remarks>
		/// Sets the value of this axis-angle to the specified values in the
		/// array of length 4.
		/// </remarks>
		/// <param name="a">the array of length 4 containing x,y,z,angle in order</param>
		public void Set(float[] a)
		{
			this.x = a[0];
			this.y = a[1];
			this.z = a[2];
			this.angle = a[3];
		}

		/// <summary>Sets the value of this axis-angle to the value of axis-angle a1.</summary>
		/// <remarks>Sets the value of this axis-angle to the value of axis-angle a1.</remarks>
		/// <param name="a1">the axis-angle to be copied</param>
		public void Set(AxisAngle4f a1)
		{
			this.x = a1.x;
			this.y = a1.y;
			this.z = a1.z;
			this.angle = a1.angle;
		}

		/// <summary>Sets the value of this axis-angle to the value of axis-angle a1.</summary>
		/// <remarks>Sets the value of this axis-angle to the value of axis-angle a1.</remarks>
		/// <param name="a1">the axis-angle to be copied</param>
		public void Set(AxisAngle4d a1)
		{
			this.x = (float)a1.x;
			this.y = (float)a1.y;
			this.z = (float)a1.z;
			this.angle = (float)a1.angle;
		}

		/// <summary>
		/// Sets the value of this AxisAngle4f to the specified
		/// axis and angle.
		/// </summary>
		/// <remarks>
		/// Sets the value of this AxisAngle4f to the specified
		/// axis and angle.
		/// </remarks>
		/// <param name="axis">the axis</param>
		/// <param name="angle">the angle of rotation in radians</param>
		/// <since>vecmath 1.2</since>
		public void Set(Vector3f axis, float angle)
		{
			this.x = axis.x;
			this.y = axis.y;
			this.z = axis.z;
			this.angle = angle;
		}

		/// <summary>Copies the value of this axis-angle into the array a.</summary>
		/// <remarks>Copies the value of this axis-angle into the array a.</remarks>
		/// <param name="a">the array</param>
		public void Get(float[] a)
		{
			a[0] = this.x;
			a[1] = this.y;
			a[2] = this.z;
			a[3] = this.angle;
		}

		/// <summary>
		/// Sets the value of this axis-angle to the rotational equivalent
		/// of the passed quaternion.
		/// </summary>
		/// <remarks>
		/// Sets the value of this axis-angle to the rotational equivalent
		/// of the passed quaternion.
		/// If the specified quaternion has no rotational component, the value
		/// of this AxisAngle4f is set to an angle of 0 about an axis of (0,1,0).
		/// </remarks>
		/// <param name="q1">the Quat4f</param>
		public void Set(Quat4f q1)
		{
			double mag = q1.x * q1.x + q1.y * q1.y + q1.z * q1.z;
			if (mag > Eps)
			{
				mag = Math.Sqrt(mag);
				double invMag = 1.0 / mag;
				x = (float)(q1.x * invMag);
				y = (float)(q1.y * invMag);
				z = (float)(q1.z * invMag);
				angle = (float)(2.0 * Math.Atan2(mag, q1.w));
			}
			else
			{
				x = 0.0f;
				y = 1.0f;
				z = 0.0f;
				angle = 0.0f;
			}
		}

		/// <summary>
		/// Sets the value of this axis-angle to the rotational equivalent
		/// of the passed quaternion.
		/// </summary>
		/// <remarks>
		/// Sets the value of this axis-angle to the rotational equivalent
		/// of the passed quaternion.
		/// If the specified quaternion has no rotational component, the value
		/// of this AxisAngle4f is set to an angle of 0 about an axis of (0,1,0).
		/// </remarks>
		/// <param name="q1">the Quat4d</param>
		public void Set(Quat4d q1)
		{
			double mag = q1.x * q1.x + q1.y * q1.y + q1.z * q1.z;
			if (mag > Eps)
			{
				mag = Math.Sqrt(mag);
				double invMag = 1.0 / mag;
				x = (float)(q1.x * invMag);
				y = (float)(q1.y * invMag);
				z = (float)(q1.z * invMag);
				angle = (float)(2.0 * Math.Atan2(mag, q1.w));
			}
			else
			{
				x = 0.0f;
				y = 1.0f;
				z = 0.0f;
				angle = 0.0f;
			}
		}

		/// <summary>
		/// Sets the value of this axis-angle to the rotational component of
		/// the passed matrix.
		/// </summary>
		/// <remarks>
		/// Sets the value of this axis-angle to the rotational component of
		/// the passed matrix.
		/// If the specified matrix has no rotational component, the value
		/// of this AxisAngle4f is set to an angle of 0 about an axis of (0,1,0).
		/// </remarks>
		/// <param name="m1">the matrix4f</param>
		public void Set(Matrix4f m1)
		{
			Matrix3f m3f = new Matrix3f();
			m1.Get(m3f);
			x = m3f.m21 - m3f.m12;
			y = m3f.m02 - m3f.m20;
			z = m3f.m10 - m3f.m01;
			double mag = x * x + y * y + z * z;
			if (mag > Eps)
			{
				mag = Math.Sqrt(mag);
				double sin = 0.5 * mag;
				double cos = 0.5 * (m3f.m00 + m3f.m11 + m3f.m22 - 1.0);
				angle = (float)Math.Atan2(sin, cos);
				double invMag = 1.0 / mag;
				x = (float)(x * invMag);
				y = (float)(y * invMag);
				z = (float)(z * invMag);
			}
			else
			{
				x = 0.0f;
				y = 1.0f;
				z = 0.0f;
				angle = 0.0f;
			}
		}

		/// <summary>
		/// Sets the value of this axis-angle to the rotational component of
		/// the passed matrix.
		/// </summary>
		/// <remarks>
		/// Sets the value of this axis-angle to the rotational component of
		/// the passed matrix.
		/// If the specified matrix has no rotational component, the value
		/// of this AxisAngle4f is set to an angle of 0 about an axis of (0,1,0).
		/// </remarks>
		/// <param name="m1">the matrix4d</param>
		public void Set(Matrix4d m1)
		{
			Matrix3d m3d = new Matrix3d();
			m1.Get(m3d);
			x = (float)(m3d.m21 - m3d.m12);
			y = (float)(m3d.m02 - m3d.m20);
			z = (float)(m3d.m10 - m3d.m01);
			double mag = x * x + y * y + z * z;
			if (mag > Eps)
			{
				mag = Math.Sqrt(mag);
				double sin = 0.5 * mag;
				double cos = 0.5 * (m3d.m00 + m3d.m11 + m3d.m22 - 1.0);
				angle = (float)Math.Atan2(sin, cos);
				double invMag = 1.0 / mag;
				x = (float)(x * invMag);
				y = (float)(y * invMag);
				z = (float)(z * invMag);
			}
			else
			{
				x = 0.0f;
				y = 1.0f;
				z = 0.0f;
				angle = 0.0f;
			}
		}

		/// <summary>
		/// Sets the value of this axis-angle to the rotational component of
		/// the passed matrix.
		/// </summary>
		/// <remarks>
		/// Sets the value of this axis-angle to the rotational component of
		/// the passed matrix.
		/// If the specified matrix has no rotational component, the value
		/// of this AxisAngle4f is set to an angle of 0 about an axis of (0,1,0).
		/// </remarks>
		/// <param name="m1">the matrix3f</param>
		public void Set(Matrix3f m1)
		{
			x = (float)(m1.m21 - m1.m12);
			y = (float)(m1.m02 - m1.m20);
			z = (float)(m1.m10 - m1.m01);
			double mag = x * x + y * y + z * z;
			if (mag > Eps)
			{
				mag = Math.Sqrt(mag);
				double sin = 0.5 * mag;
				double cos = 0.5 * (m1.m00 + m1.m11 + m1.m22 - 1.0);
				angle = (float)Math.Atan2(sin, cos);
				double invMag = 1.0 / mag;
				x = (float)(x * invMag);
				y = (float)(y * invMag);
				z = (float)(z * invMag);
			}
			else
			{
				x = 0.0f;
				y = 1.0f;
				z = 0.0f;
				angle = 0.0f;
			}
		}

		/// <summary>
		/// Sets the value of this axis-angle to the rotational component of
		/// the passed matrix.
		/// </summary>
		/// <remarks>
		/// Sets the value of this axis-angle to the rotational component of
		/// the passed matrix.
		/// If the specified matrix has no rotational component, the value
		/// of this AxisAngle4f is set to an angle of 0 about an axis of (0,1,0).
		/// </remarks>
		/// <param name="m1">the matrix3d</param>
		public void Set(Matrix3d m1)
		{
			x = (float)(m1.m21 - m1.m12);
			y = (float)(m1.m02 - m1.m20);
			z = (float)(m1.m10 - m1.m01);
			double mag = x * x + y * y + z * z;
			if (mag > Eps)
			{
				mag = Math.Sqrt(mag);
				double sin = 0.5 * mag;
				double cos = 0.5 * (m1.m00 + m1.m11 + m1.m22 - 1.0);
				angle = (float)Math.Atan2(sin, cos);
				double invMag = 1.0 / mag;
				x = (float)(x * invMag);
				y = (float)(y * invMag);
				z = (float)(z * invMag);
			}
			else
			{
				x = 0.0f;
				y = 1.0f;
				z = 0.0f;
				angle = 0.0f;
			}
		}

		/// <summary>Returns a string that contains the values of this AxisAngle4f.</summary>
		/// <remarks>
		/// Returns a string that contains the values of this AxisAngle4f.
		/// The form is (x,y,z,angle).
		/// </remarks>
		/// <returns>the String representation</returns>
		public override string ToString()
		{
			return "(" + this.x + ", " + this.y + ", " + this.z + ", " + this.angle + ")";
		}

		/// <summary>
		/// Returns true if all of the data members of AxisAngle4f a1 are
		/// equal to the corresponding data members in this AxisAngle4f.
		/// </summary>
		/// <remarks>
		/// Returns true if all of the data members of AxisAngle4f a1 are
		/// equal to the corresponding data members in this AxisAngle4f.
		/// </remarks>
		/// <param name="a1">the axis-angle with which the comparison is made</param>
		/// <returns>true or false</returns>
		public virtual bool Equals(AxisAngle4f a1)
		{
			try
			{
				return (this.x == a1.x && this.y == a1.y && this.z == a1.z && this.angle == a1.angle
					);
			}
			catch (ArgumentNullException)
			{
				return false;
			}
		}

		/// <summary>
		/// Returns true if the Object o1 is of type AxisAngle4f and all of the
		/// data members of o1 are equal to the corresponding data members in
		/// this AxisAngle4f.
		/// </summary>
		/// <remarks>
		/// Returns true if the Object o1 is of type AxisAngle4f and all of the
		/// data members of o1 are equal to the corresponding data members in
		/// this AxisAngle4f.
		/// </remarks>
		/// <param name="o1">the object with which the comparison is made</param>
		/// <returns>true or false</returns>
		public override bool Equals(object o1)
		{
			try
			{
				AxisAngle4f a2 = (AxisAngle4f)o1;
				return (this.x == a2.x && this.y == a2.y && this.z == a2.z && this.angle == a2.angle
					);
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
		/// Returns true if the L-infinite distance between this axis-angle
		/// and axis-angle a1 is less than or equal to the epsilon parameter,
		/// otherwise returns false.
		/// </summary>
		/// <remarks>
		/// Returns true if the L-infinite distance between this axis-angle
		/// and axis-angle a1 is less than or equal to the epsilon parameter,
		/// otherwise returns false.  The L-infinite
		/// distance is equal to
		/// MAX[abs(x1-x2), abs(y1-y2), abs(z1-z2), abs(angle1-angle2)].
		/// </remarks>
		/// <param name="a1">the axis-angle to be compared to this axis-angle</param>
		/// <param name="epsilon">the threshold value</param>
		public virtual bool EpsilonEquals(AxisAngle4f a1, float epsilon)
		{
			float diff;
			diff = x - a1.x;
			if ((diff < 0 ? -diff : diff) > epsilon)
			{
				return false;
			}
			diff = y - a1.y;
			if ((diff < 0 ? -diff : diff) > epsilon)
			{
				return false;
			}
			diff = z - a1.z;
			if ((diff < 0 ? -diff : diff) > epsilon)
			{
				return false;
			}
			diff = angle - a1.angle;
			if ((diff < 0 ? -diff : diff) > epsilon)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// Returns a hash code value based on the data values in this
		/// object.
		/// </summary>
		/// <remarks>
		/// Returns a hash code value based on the data values in this
		/// object.  Two different AxisAngle4f objects with identical data values
		/// (i.e., AxisAngle4f.equals returns true) will return the same hash
		/// code value.  Two objects with different data members may return the
		/// same hash value, although this is not likely.
		/// </remarks>
		/// <returns>the integer hash code value</returns>
		public override int GetHashCode()
		{
			long bits = 1L;
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(x);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(y);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(z);
			bits = 31L * bits + (long)VecMathUtil.FloatToIntBits(angle);
			return (int)(bits ^ (bits >> 32));
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
			//return base.Clone();
			return base.MemberwiseClone();
		}

		// this shouldn't happen, since we are Cloneable
		/// <summary>
		/// Get the axis angle, in radians.<br />
		/// An axis angle is a rotation angle about the vector (x,y,z).
		/// </summary>
		/// <remarks>
		/// Get the axis angle, in radians.<br />
		/// An axis angle is a rotation angle about the vector (x,y,z).
		/// </remarks>
		/// <returns>Returns the angle, in radians.</returns>
		/// <since>vecmath 1.5</since>
		public float GetAngle()
		{
			return angle;
		}

		/// <summary>
		/// Set the axis angle, in radians.<br />
		/// An axis angle is a rotation angle about the vector (x,y,z).
		/// </summary>
		/// <remarks>
		/// Set the axis angle, in radians.<br />
		/// An axis angle is a rotation angle about the vector (x,y,z).
		/// </remarks>
		/// <param name="angle">The angle to set, in radians.</param>
		/// <since>vecmath 1.5</since>
		public void SetAngle(float angle)
		{
			this.angle = angle;
		}

		/// <summary>Get value of <i>x</i> coordinate.</summary>
		/// <remarks>Get value of <i>x</i> coordinate.</remarks>
		/// <returns>the <i>x</i> coordinate.</returns>
		/// <since>vecmath 1.5</since>
		public float GetX()
		{
			return x;
		}

		/// <summary>Set a new value for <i>x</i> coordinate.</summary>
		/// <remarks>Set a new value for <i>x</i> coordinate.</remarks>
		/// <param name="x">the <i>x</i> coordinate.</param>
		/// <since>vecmath 1.5</since>
		public void SetX(float x)
		{
			this.x = x;
		}

		/// <summary>Get value of <i>y</i> coordinate.</summary>
		/// <remarks>Get value of <i>y</i> coordinate.</remarks>
		/// <returns>the <i>y</i> coordinate</returns>
		/// <since>vecmath 1.5</since>
		public float GetY()
		{
			return y;
		}

		/// <summary>Set a new value for <i>y</i> coordinate.</summary>
		/// <remarks>Set a new value for <i>y</i> coordinate.</remarks>
		/// <param name="y">the <i>y</i> coordinate.</param>
		/// <since>vecmath 1.5</since>
		public void SetY(float y)
		{
			this.y = y;
		}

		/// <summary>Get  value of <i>z</i> coordinate.</summary>
		/// <remarks>Get  value of <i>z</i> coordinate.</remarks>
		/// <returns>the <i>z</i> coordinate.</returns>
		/// <since>vecmath 1.5</since>
		public float GetZ()
		{
			return z;
		}

		/// <summary>Set a new value for <i>z</i> coordinate.</summary>
		/// <remarks>Set a new value for <i>z</i> coordinate.</remarks>
		/// <param name="z">the <i>z</i> coordinate.</param>
		/// <since>vecmath 1.5</since>
		public void SetZ(float z)
		{
			this.z = z;
		}
	}
}
