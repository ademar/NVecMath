/*
 * Automated conversion
 */
using System;

namespace NVecMath
{
	/// <summary>
	/// Utility vecmath class used when computing the hash code for vecmath
	/// objects containing float or double values.
	/// </summary>
	/// <remarks>
	/// Utility vecmath class used when computing the hash code for vecmath
	/// objects containing float or double values. This fixes Issue 36.
	/// </remarks>
	internal class VecMathUtil
	{
		/// <summary>
		/// Returns the representation of the specified floating-point
		/// value according to the IEEE 754 floating-point "single format"
		/// bit layout, after first mapping -0.0 to 0.0.
		/// </summary>
		/// <remarks>
		/// Returns the representation of the specified floating-point
		/// value according to the IEEE 754 floating-point "single format"
		/// bit layout, after first mapping -0.0 to 0.0. This method is
		/// identical to Float.floatToIntBits(float) except that an integer
		/// value of 0 is returned for a floating-point value of
		/// -0.0f. This is done for the purpose of computing a hash code
		/// that satisfies the contract of hashCode() and equals(). The
		/// equals() method in each vecmath class does a pair-wise "=="
		/// test on each floating-point field in the class (e.g., x, y, and
		/// z for a Tuple3f). Since 0.0f&nbsp;==&nbsp;-0.0f returns true,
		/// we must also return the same hash code for two objects, one of
		/// which has a field with a value of -0.0f and the other of which
		/// has a cooresponding field with a value of 0.0f.
		/// </remarks>
		/// <param name="f">an input floating-point number</param>
		/// <returns>
		/// the integer bits representing that floating-point
		/// number, after first mapping -0.0f to 0.0f
		/// </returns>
		internal static int FloatToIntBits(float f)
		{
			// Check for +0 or -0
			if (f == 0.0f)
			{
				return 0;
			}
			else
			{
				return BitConverter.ToInt32(BitConverter.GetBytes(f), 0);
				//return Sharpen.Runtime.FloatToIntBits(f);
			}
		}

		/// <summary>
		/// Returns the representation of the specified floating-point
		/// value according to the IEEE 754 floating-point "double format"
		/// bit layout, after first mapping -0.0 to 0.0.
		/// </summary>
		/// <remarks>
		/// Returns the representation of the specified floating-point
		/// value according to the IEEE 754 floating-point "double format"
		/// bit layout, after first mapping -0.0 to 0.0. This method is
		/// identical to Double.doubleToLongBits(double) except that an
		/// integer value of 0L is returned for a floating-point value of
		/// -0.0. This is done for the purpose of computing a hash code
		/// that satisfies the contract of hashCode() and equals(). The
		/// equals() method in each vecmath class does a pair-wise "=="
		/// test on each floating-point field in the class (e.g., x, y, and
		/// z for a Tuple3d). Since 0.0&nbsp;==&nbsp;-0.0 returns true, we
		/// must also return the same hash code for two objects, one of
		/// which has a field with a value of -0.0 and the other of which
		/// has a cooresponding field with a value of 0.0.
		/// </remarks>
		/// <param name="d">an input double precision floating-point number</param>
		/// <returns>
		/// the integer bits representing that floating-point
		/// number, after first mapping -0.0f to 0.0f
		/// </returns>
		internal static long DoubleToLongBits(double d)
		{
			// Check for +0 or -0
			if (d == 0.0)
			{
				return 0L;
			}
			else
			{
				return BitConverter.DoubleToInt64Bits(d);
			}
		}

		/// <summary>Do not construct an instance of this class.</summary>
		/// <remarks>Do not construct an instance of this class.</remarks>
		public VecMathUtil()
		{
		}
	}
}
