/*
 * Automated conversion
 */

using System;

namespace NVecMath
{
	/// <summary>
	/// A 4 element point represented by single precision floating point x,y,z,w
	/// coordinates.
	/// </summary>
	/// <remarks>
	/// A 4 element point represented by single precision floating point x,y,z,w
	/// coordinates.
	/// </remarks>
	[System.Serializable]
	public class Point4f : Tuple4f
	{
		new internal const long serialVersionUID = 4643134103185764459L;

		/// <summary>Constructs and initializes a Point4f from the specified xyzw coordinates.
		/// 	</summary>
		/// <remarks>Constructs and initializes a Point4f from the specified xyzw coordinates.
		/// 	</remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		/// <param name="z">the z coordinate</param>
		/// <param name="w">the w coordinate</param>
		public Point4f(float x, float y, float z, float w) : base(x, y, z, w)
		{
		}

		/// <summary>Constructs and initializes a Point4f from the array of length 4.</summary>
		/// <remarks>Constructs and initializes a Point4f from the array of length 4.</remarks>
		/// <param name="p">the array of length 4 containing xyzw in order</param>
		public Point4f(float[] p) : base(p)
		{
		}

		/// <summary>Constructs and initializes a Point4f from the specified Point4f.</summary>
		/// <remarks>Constructs and initializes a Point4f from the specified Point4f.</remarks>
		/// <param name="p1">the Point4f containing the initialization x y z w data</param>
		public Point4f(Point4f p1) : base(p1)
		{
		}

		/// <summary>Constructs and initializes a Point4f from the specified Point4d.</summary>
		/// <remarks>Constructs and initializes a Point4f from the specified Point4d.</remarks>
		/// <param name="p1">the Point4d containing the initialization x y z w data</param>
		public Point4f(Point4d p1) : base(p1)
		{
		}

		/// <summary>Constructs and initializes a Point4f from the specified Tuple4f.</summary>
		/// <remarks>Constructs and initializes a Point4f from the specified Tuple4f.</remarks>
		/// <param name="t1">the Tuple4f containing the initialization x y z w data</param>
		public Point4f(Tuple4f t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a Point4f from the specified Tuple4d.</summary>
		/// <remarks>Constructs and initializes a Point4f from the specified Tuple4d.</remarks>
		/// <param name="t1">the Tuple4d containing the initialization x y z w data</param>
		public Point4f(Tuple4d t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a Point4f from the specified Tuple3f.</summary>
		/// <remarks>
		/// Constructs and initializes a Point4f from the specified Tuple3f.
		/// The x,y,z components of this point are set to the corresponding
		/// components of tuple t1.  The w component of this point
		/// is set to 1.
		/// </remarks>
		/// <param name="t1">the tuple to be copied</param>
		/// <since>vecmath 1.2</since>
		public Point4f(Tuple3f t1) : base(t1.x, t1.y, t1.z, 1.0f)
		{
		}

		/// <summary>Constructs and initializes a Point4f to (0,0,0,0).</summary>
		/// <remarks>Constructs and initializes a Point4f to (0,0,0,0).</remarks>
		public Point4f() : base()
		{
		}

		// Compatible with 1.1
		/// <summary>
		/// Sets the x,y,z components of this point to the corresponding
		/// components of tuple t1.
		/// </summary>
		/// <remarks>
		/// Sets the x,y,z components of this point to the corresponding
		/// components of tuple t1.  The w component of this point
		/// is set to 1.
		/// </remarks>
		/// <param name="t1">the tuple to be copied</param>
		/// <since>vecmath 1.2</since>
		public void Set(Tuple3f t1)
		{
			this.x = t1.x;
			this.y = t1.y;
			this.z = t1.z;
			this.w = 1.0f;
		}

		/// <summary>Computes the square of the distance between this point and point p1.</summary>
		/// <remarks>Computes the square of the distance between this point and point p1.</remarks>
		/// <param name="p1">the other point</param>
		/// <returns>the square of distance between these two points as a float</returns>
		public float DistanceSquared(Point4f p1)
		{
			float dx;
			float dy;
			float dz;
			float dw;
			dx = this.x - p1.x;
			dy = this.y - p1.y;
			dz = this.z - p1.z;
			dw = this.w - p1.w;
			return (dx * dx + dy * dy + dz * dz + dw * dw);
		}

		/// <summary>Computes the distance between this point and point p1.</summary>
		/// <remarks>Computes the distance between this point and point p1.</remarks>
		/// <param name="p1">the other point</param>
		/// <returns>the distance between the two points</returns>
		public float Distance(Point4f p1)
		{
			float dx;
			float dy;
			float dz;
			float dw;
			dx = this.x - p1.x;
			dy = this.y - p1.y;
			dz = this.z - p1.z;
			dw = this.w - p1.w;
			return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz + dw * dw);
		}

		/// <summary>
		/// Computes the L-1 (Manhattan) distance between this point and
		/// point p1.
		/// </summary>
		/// <remarks>
		/// Computes the L-1 (Manhattan) distance between this point and
		/// point p1.  The L-1 distance is equal to:
		/// abs(x1-x2) + abs(y1-y2) + abs(z1-z2) + abs(w1-w2).
		/// </remarks>
		/// <param name="p1">the other point</param>
		/// <returns>the L-1 distance</returns>
		public float DistanceL1(Point4f p1)
		{
			return (Math.Abs(this.x - p1.x) + Math.Abs(this.y - p1.y) + Math.Abs(this.z - p1.
				z) + Math.Abs(this.w - p1.w));
		}

		/// <summary>
		/// Computes the L-infinite distance between this point and
		/// point p1.
		/// </summary>
		/// <remarks>
		/// Computes the L-infinite distance between this point and
		/// point p1.  The L-infinite distance is equal to
		/// MAX[abs(x1-x2), abs(y1-y2), abs(z1-z2), abs(w1-w2)].
		/// </remarks>
		/// <param name="p1">the other point</param>
		/// <returns>the L-infinite distance</returns>
		public float DistanceLinf(Point4f p1)
		{
			float t1;
			float t2;
			t1 = Math.Max(Math.Abs(this.x - p1.x), Math.Abs(this.y - p1.y));
			t2 = Math.Max(Math.Abs(this.z - p1.z), Math.Abs(this.w - p1.w));
			return (Math.Max(t1, t2));
		}

		/// <summary>
		/// Multiplies each of the x,y,z components of the Point4f parameter
		/// by 1/w, places the projected values into this point, and places
		/// a 1 as the w parameter of this point.
		/// </summary>
		/// <remarks>
		/// Multiplies each of the x,y,z components of the Point4f parameter
		/// by 1/w, places the projected values into this point, and places
		/// a 1 as the w parameter of this point.
		/// </remarks>
		/// <param name="p1">the source Point4f, which is not modified</param>
		public void Project(Point4f p1)
		{
			float oneOw;
			oneOw = 1 / p1.w;
			x = p1.x * oneOw;
			y = p1.y * oneOw;
			z = p1.z * oneOw;
			w = 1.0f;
		}
	}
}
