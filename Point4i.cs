/*
 * Automated conversion
 */


namespace NVecMath
{
	/// <summary>
	/// A 4 element point represented by signed integer x,y,z,w
	/// coordinates.
	/// </summary>
	/// <remarks>
	/// A 4 element point represented by signed integer x,y,z,w
	/// coordinates.
	/// </remarks>
	/// <since>vecmath 1.2</since>
	[System.Serializable]
	public class Point4i : Tuple4i
	{
		new internal const long serialVersionUID = 620124780244617983L;

		/// <summary>
		/// Constructs and initializes a Point4i from the specified
		/// x, y, z, and w coordinates.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes a Point4i from the specified
		/// x, y, z, and w coordinates.
		/// </remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		/// <param name="z">the z coordinate</param>
		/// <param name="w">the w coordinate</param>
		public Point4i(int x, int y, int z, int w) : base(x, y, z, w)
		{
		}

		/// <summary>Constructs and initializes a Point4i from the array of length 4.</summary>
		/// <remarks>Constructs and initializes a Point4i from the array of length 4.</remarks>
		/// <param name="t">the array of length 4 containing x, y, z, and w in order.</param>
		public Point4i(int[] t) : base(t)
		{
		}

		/// <summary>Constructs and initializes a Point4i from the specified Tuple4i.</summary>
		/// <remarks>Constructs and initializes a Point4i from the specified Tuple4i.</remarks>
		/// <param name="t1">
		/// the Tuple4i containing the initialization x, y, z,
		/// and w data.
		/// </param>
		public Point4i(Tuple4i t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a Point4i to (0,0,0,0).</summary>
		/// <remarks>Constructs and initializes a Point4i to (0,0,0,0).</remarks>
		public Point4i() : base()
		{
		}
		// Combatible with 1.2
	}
}
