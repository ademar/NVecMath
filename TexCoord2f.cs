/*
 * Automated conversion
 */


namespace NVecMath
{
	/// <summary>
	/// A 2-element vector that is represented by single-precision floating
	/// point x,y coordinates.
	/// </summary>
	/// <remarks>
	/// A 2-element vector that is represented by single-precision floating
	/// point x,y coordinates.
	/// </remarks>
	[System.Serializable]
	public class TexCoord2f : Tuple2f
	{
		new internal const long serialVersionUID = 7998248474800032487L;

		/// <summary>Constructs and initializes a TexCoord2f from the specified xy coordinates.
		/// 	</summary>
		/// <remarks>Constructs and initializes a TexCoord2f from the specified xy coordinates.
		/// 	</remarks>
		/// <param name="x">the x coordinate</param>
		/// <param name="y">the y coordinate</param>
		public TexCoord2f(float x, float y) : base(x, y)
		{
		}

		/// <summary>Constructs and initializes a TexCoord2f from the specified array.</summary>
		/// <remarks>Constructs and initializes a TexCoord2f from the specified array.</remarks>
		/// <param name="v">the array of length 2 containing xy in order</param>
		public TexCoord2f(float[] v) : base(v)
		{
		}

		/// <summary>Constructs and initializes a TexCoord2f from the specified TexCoord2f.</summary>
		/// <remarks>Constructs and initializes a TexCoord2f from the specified TexCoord2f.</remarks>
		/// <param name="v1">the TexCoord2f containing the initialization x y data</param>
		public TexCoord2f(TexCoord2f v1) : base(v1)
		{
		}

		/// <summary>Constructs and initializes a TexCoord2f from the specified Tuple2f.</summary>
		/// <remarks>Constructs and initializes a TexCoord2f from the specified Tuple2f.</remarks>
		/// <param name="t1">the Tuple2f containing the initialization x y data</param>
		public TexCoord2f(Tuple2f t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a TexCoord2f to (0,0).</summary>
		/// <remarks>Constructs and initializes a TexCoord2f to (0,0).</remarks>
		public TexCoord2f() : base()
		{
		}
		// Combatible with 1.1
	}
}
