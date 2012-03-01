/*
 * Automated conversion
 */


namespace NVecMath
{
	/// <summary>
	/// A 2-element point represented by signed integer x,y
	/// coordinates.
	/// </summary>
	/// <remarks>
	/// A 2-element point represented by signed integer x,y
	/// coordinates.
	/// </remarks>
	/// <since>vecmath 1.4</since>
	[System.Serializable]
	public class Point2i : Tuple2i
	{
		new internal const long serialVersionUID = 9208072376494084954L;

		/// <summary>
		/// Constructs and initializes a Point2i from the specified
		/// x and y coordinates.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes a Point2i from the specified
		/// x and y coordinates.
		/// </remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		public Point2i(int x, int y) : base(x, y)
		{
		}

		/// <summary>Constructs and initializes a Point2i from the array of length 2.</summary>
		/// <remarks>Constructs and initializes a Point2i from the array of length 2.</remarks>
		/// <param name="t">the array of length 2 containing x and y in order.</param>
		public Point2i(int[] t) : base(t)
		{
		}

		/// <summary>Constructs and initializes a Point2i from the specified Tuple2i.</summary>
		/// <remarks>Constructs and initializes a Point2i from the specified Tuple2i.</remarks>
		/// <param name="t1">
		/// the Tuple2i containing the initialization x and y
		/// data.
		/// </param>
		public Point2i(Tuple2i t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a Point2i to (0,0).</summary>
		/// <remarks>Constructs and initializes a Point2i to (0,0).</remarks>
		public Point2i() : base()
		{
		}
	}
}
