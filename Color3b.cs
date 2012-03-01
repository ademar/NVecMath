/*
 * Automated conversion
 */


using System.Drawing;

namespace NVecMath
{
	/// <summary>A three-byte color value represented by byte x, y, and z values.</summary>
	/// <remarks>
	/// A three-byte color value represented by byte x, y, and z values. The
	/// x, y, and z values represent the red, green, and blue values,
	/// respectively.
	/// <p>
	/// Note that Java defines a byte as a signed integer in the range
	/// [-128, 127]. However, colors are more typically represented by values
	/// in the range [0, 255]. Java 3D recognizes this and for color
	/// treats the bytes as if the range were [0, 255]---in other words, as
	/// if the bytes were unsigned.
	/// <p>
	/// Java 3D assumes that a linear (gamma-corrected) visual is used for
	/// all colors.
	/// </remarks>
	[System.Serializable]
	public class Color3b : Tuple3b
	{
		new internal const long serialVersionUID = 6632576088353444794L;

		/// <summary>Constructs and initializes a Color3b from the specified three values.</summary>
		/// <remarks>Constructs and initializes a Color3b from the specified three values.</remarks>
		/// <param name="c1">the red color value</param>
		/// <param name="c2">the green color value</param>
		/// <param name="c3">the blue color value</param>
		public Color3b(byte c1, byte c2, byte c3) : base(c1, c2, c3)
		{
		}

		/// <summary>Constructs and initializes a Color3b from input array of length 3.</summary>
		/// <remarks>Constructs and initializes a Color3b from input array of length 3.</remarks>
		/// <param name="c">the array of length 3 containing the r,g,b data in order</param>
		public Color3b(byte[] c) : base(c)
		{
		}

		/// <summary>Constructs and initializes a Color3b from the specified Color3b.</summary>
		/// <remarks>Constructs and initializes a Color3b from the specified Color3b.</remarks>
		/// <param name="c1">the Color3b containing the initialization r,g,b data</param>
		public Color3b(Color3b c1) : base(c1)
		{
		}

		/// <summary>Constructs and initializes a Color3b from the specified Tuple3b.</summary>
		/// <remarks>Constructs and initializes a Color3b from the specified Tuple3b.</remarks>
		/// <param name="t1">the Tuple3b containing the initialization r,g,b data</param>
		public Color3b(Tuple3b t1) : base(t1)
		{
		}

		/// <summary>
		/// Constructs and initializes a Color3b from the specified AWT
		/// Color object.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes a Color3b from the specified AWT
		/// Color object.  The alpha value of the AWT color is ignored.
		/// No conversion is done on the color to compensate for
		/// gamma correction.
		/// </remarks>
		/// <param name="color">
		/// the AWT color with which to initialize this
		/// Color3b object
		/// </param>
		/// <since>vecmath 1.2</since>
		public Color3b(Color color) : base(unchecked((byte)color.R), unchecked((byte
			)color.G), unchecked((byte)color.B))
		{
		}

		/// <summary>Constructs and initializes a Color3b to (0,0,0).</summary>
		/// <remarks>Constructs and initializes a Color3b to (0,0,0).</remarks>
		public Color3b() : base()
		{
		}

		// Compatible with 1.1
		/// <summary>
		/// Sets the r,g,b values of this Color3b object to those of the
		/// specified AWT Color object.
		/// </summary>
		/// <remarks>
		/// Sets the r,g,b values of this Color3b object to those of the
		/// specified AWT Color object.
		/// No conversion is done on the color to compensate for
		/// gamma correction.
		/// </remarks>
		/// <param name="color">the AWT color to copy into this Color3b object</param>
		/// <since>vecmath 1.2</since>
		public void Set(Color color)
		{
			x = unchecked((byte)color.R);
			y = unchecked((byte)color.G);
			z = unchecked((byte)color.B);
		}

		/// <summary>
		/// Returns a new AWT color object initialized with the r,g,b
		/// values of this Color3b object.
		/// </summary>
		/// <remarks>
		/// Returns a new AWT color object initialized with the r,g,b
		/// values of this Color3b object.
		/// </remarks>
		/// <returns>a new AWT Color object</returns>
		/// <since>vecmath 1.2</since>
		public Color Get()
		{
			int r = (int)x & unchecked((int)(0xff));
			int g = (int)y & unchecked((int)(0xff));
			int b = (int)z & unchecked((int)(0xff));
			return Color.FromArgb(r, g, b);
		}
	}
}
