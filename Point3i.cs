/*
 * Automated conversion
 */

namespace NVecMath
{
	/// <summary>
	/// A 3 element point represented by signed integer x,y,z
	/// coordinates.
	/// </summary>
	/// <remarks>
	/// A 3 element point represented by signed integer x,y,z
	/// coordinates.
	/// </remarks>
	/// <since>vecmath 1.2</since>
	[System.Serializable]
	public class Point3i : Tuple3i
	{
		new internal const long serialVersionUID = 6149289077348153921L;

		/// <summary>
		/// Constructs and initializes a Point3i from the specified
		/// x, y, and z coordinates.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes a Point3i from the specified
		/// x, y, and z coordinates.
		/// </remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		/// <param name="z">the z coordinate</param>
		public Point3i(int x, int y, int z) : base(x, y, z)
		{
		}

		/// <summary>Constructs and initializes a Point3i from the array of length 3.</summary>
		/// <remarks>Constructs and initializes a Point3i from the array of length 3.</remarks>
		/// <param name="t">the array of length 3 containing x, y, and z in order.</param>
		public Point3i(int[] t) : base(t)
		{
		}

		/// <summary>Constructs and initializes a Point3i from the specified Tuple3i.</summary>
		/// <remarks>Constructs and initializes a Point3i from the specified Tuple3i.</remarks>
		/// <param name="t1">
		/// the Tuple3i containing the initialization x, y, and z
		/// data.
		/// </param>
		public Point3i(Tuple3i t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a Point3i to (0,0,0).</summary>
		/// <remarks>Constructs and initializes a Point3i to (0,0,0).</remarks>
		public Point3i() : base()
		{
		}
		// Compatible with 1.2
	}
}
