/*
 * Automated conversion
 */

using System;

namespace NVecMath
{
	/// <summary>
	/// A 2 element point that is represented by single precision floating
	/// point x,y coordinates.
	/// </summary>
	/// <remarks>
	/// A 2 element point that is represented by single precision floating
	/// point x,y coordinates.
	/// </remarks>
	[System.Serializable]
	public class Point2f : Tuple2f
	{
		new internal const long serialVersionUID = -4801347926528714435L;

		/// <summary>Constructs and initializes a Point2f from the specified xy coordinates.</summary>
		/// <remarks>Constructs and initializes a Point2f from the specified xy coordinates.</remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		public Point2f(float x, float y) : base(x, y)
		{
		}

		/// <summary>Constructs and initializes a Point2f from the specified array.</summary>
		/// <remarks>Constructs and initializes a Point2f from the specified array.</remarks>
		/// <param name="p">the array of length 2 containing xy in order</param>
		public Point2f(float[] p) : base(p)
		{
		}

		/// <summary>Constructs and initializes a Point2f from the specified Point2f.</summary>
		/// <remarks>Constructs and initializes a Point2f from the specified Point2f.</remarks>
		/// <param name="p1">the Point2f containing the initialization x y data</param>
		public Point2f(Point2f p1) : base(p1)
		{
		}

		/// <summary>Constructs and initializes a Point2f from the specified Point2d.</summary>
		/// <remarks>Constructs and initializes a Point2f from the specified Point2d.</remarks>
		/// <param name="p1">the Point2d containing the initialization x y z data</param>
		public Point2f(Point2d p1) : base(p1)
		{
		}

		/// <summary>Constructs and initializes a Point2f from the specified Tuple2d.</summary>
		/// <remarks>Constructs and initializes a Point2f from the specified Tuple2d.</remarks>
		/// <param name="t1">the Tuple2d containing the initialization x y z data</param>
		public Point2f(Tuple2d t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a Point2f from the specified Tuple2f.</summary>
		/// <remarks>Constructs and initializes a Point2f from the specified Tuple2f.</remarks>
		/// <param name="t1">the Tuple2f containing the initialization x y data</param>
		public Point2f(Tuple2f t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a Point2f to (0,0).</summary>
		/// <remarks>Constructs and initializes a Point2f to (0,0).</remarks>
		public Point2f() : base()
		{
		}

		// Compatible with 1.1
		/// <summary>Computes the square of the distance between this point and point p1.</summary>
		/// <remarks>Computes the square of the distance between this point and point p1.</remarks>
		/// <param name="p1">the other point</param>
		public float DistanceSquared(Point2f p1)
		{
			float dx;
			float dy;
			dx = this.x - p1.x;
			dy = this.y - p1.y;
			return dx * dx + dy * dy;
		}

		/// <summary>Computes the distance between this point and point p1.</summary>
		/// <remarks>Computes the distance between this point and point p1.</remarks>
		/// <param name="p1">the other point</param>
		public float Distance(Point2f p1)
		{
			float dx;
			float dy;
			dx = this.x - p1.x;
			dy = this.y - p1.y;
			return (float)Math.Sqrt(dx * dx + dy * dy);
		}

		/// <summary>
		/// Computes the L-1 (Manhattan) distance between this point and
		/// point p1.
		/// </summary>
		/// <remarks>
		/// Computes the L-1 (Manhattan) distance between this point and
		/// point p1.  The L-1 distance is equal to abs(x1-x2) + abs(y1-y2).
		/// </remarks>
		/// <param name="p1">the other point</param>
		public float DistanceL1(Point2f p1)
		{
			return (Math.Abs(this.x - p1.x) + Math.Abs(this.y - p1.y));
		}

		/// <summary>
		/// Computes the L-infinite distance between this point and
		/// point p1.
		/// </summary>
		/// <remarks>
		/// Computes the L-infinite distance between this point and
		/// point p1.  The L-infinite distance is equal to
		/// MAX[abs(x1-x2), abs(y1-y2)].
		/// </remarks>
		/// <param name="p1">the other point</param>
		public float DistanceLinf(Point2f p1)
		{
			return (Math.Max(Math.Abs(this.x - p1.x), Math.Abs(this.y - p1.y)));
		}
	}
}
