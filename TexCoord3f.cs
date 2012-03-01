/*
 * Automated conversion
 */


namespace NVecMath
{
	/// <summary>
	/// A 3 element texture coordinate that is represented by single precision
	/// floating point x,y,z coordinates.
	/// </summary>
	/// <remarks>
	/// A 3 element texture coordinate that is represented by single precision
	/// floating point x,y,z coordinates.
	/// </remarks>
	[System.Serializable]
	public class TexCoord3f : Tuple3f
	{
		new internal const long serialVersionUID = -3517736544731446513L;

		/// <summary>
		/// Constructs and initializes a TexCoord3f from the specified xyz
		/// coordinates.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes a TexCoord3f from the specified xyz
		/// coordinates.
		/// </remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		/// <param name="z">the z coordinate</param>
		public TexCoord3f(float x, float y, float z) : base(x, y, z)
		{
		}

		/// <summary>Constructs and initializes a TexCoord3f from the array of length 3.</summary>
		/// <remarks>Constructs and initializes a TexCoord3f from the array of length 3.</remarks>
		/// <param name="v">the array of length 3 containing xyz in order</param>
		public TexCoord3f(float[] v) : base(v)
		{
		}

		/// <summary>Constructs and initializes a TexCoord3f from the specified TexCoord3f.</summary>
		/// <remarks>Constructs and initializes a TexCoord3f from the specified TexCoord3f.</remarks>
		/// <param name="v1">the TexCoord3f containing the initialization x y z data</param>
		public TexCoord3f(TexCoord3f v1) : base(v1)
		{
		}

		/// <summary>Constructs and initializes a TexCoord3f from the specified Tuple3f.</summary>
		/// <remarks>Constructs and initializes a TexCoord3f from the specified Tuple3f.</remarks>
		/// <param name="t1">the Tuple3f containing the initialization x y z data</param>
		public TexCoord3f(Tuple3f t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a TexCoord3f from the specified Tuple3d.</summary>
		/// <remarks>Constructs and initializes a TexCoord3f from the specified Tuple3d.</remarks>
		/// <param name="t1">the Tuple3d containing the initialization x y z data</param>
		public TexCoord3f(Tuple3d t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a TexCoord3f to (0,0,0).</summary>
		/// <remarks>Constructs and initializes a TexCoord3f to (0,0,0).</remarks>
		public TexCoord3f() : base()
		{
		}
		// Combatible with 1.1
	}
}
