/*
 * Automated conversion
 */


namespace NVecMath
{
	/// <summary>
	/// A 4 element texture coordinate that is represented by single precision
	/// floating point x,y,z,w coordinates.
	/// </summary>
	/// <remarks>
	/// A 4 element texture coordinate that is represented by single precision
	/// floating point x,y,z,w coordinates.
	/// </remarks>
	/// <since>vecmath 1.3</since>
	[System.Serializable]
	public class TexCoord4f : Tuple4f
	{
		new internal const long serialVersionUID = -3517736544731446513L;

		/// <summary>
		/// Constructs and initializes a TexCoord4f from the specified xyzw
		/// coordinates.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes a TexCoord4f from the specified xyzw
		/// coordinates.
		/// </remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		/// <param name="z">the z coordinate</param>
		/// <param name="w">the w coordinate</param>
		public TexCoord4f(float x, float y, float z, float w) : base(x, y, z, w)
		{
		}

		/// <summary>Constructs and initializes a TexCoord4f from the array of length 4.</summary>
		/// <remarks>Constructs and initializes a TexCoord4f from the array of length 4.</remarks>
		/// <param name="v">the array of length w containing xyzw in order</param>
		public TexCoord4f(float[] v) : base(v)
		{
		}

		/// <summary>Constructs and initializes a TexCoord4f from the specified TexCoord4f.</summary>
		/// <remarks>Constructs and initializes a TexCoord4f from the specified TexCoord4f.</remarks>
		/// <param name="v1">the TexCoord4f containing the initialization x y z w data</param>
		public TexCoord4f(TexCoord4f v1) : base(v1)
		{
		}

		/// <summary>Constructs and initializes a TexCoord4f from the specified Tuple4f.</summary>
		/// <remarks>Constructs and initializes a TexCoord4f from the specified Tuple4f.</remarks>
		/// <param name="t1">the Tuple4f containing the initialization x y z w data</param>
		public TexCoord4f(Tuple4f t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a TexCoord4f from the specified Tuple4d.</summary>
		/// <remarks>Constructs and initializes a TexCoord4f from the specified Tuple4d.</remarks>
		/// <param name="t1">the Tuple4d containing the initialization x y z w data</param>
		public TexCoord4f(Tuple4d t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a TexCoord4f to (0,0,0,0).</summary>
		/// <remarks>Constructs and initializes a TexCoord4f to (0,0,0,0).</remarks>
		public TexCoord4f() : base()
		{
		}
		// Combatible with 1.1
	}
}
