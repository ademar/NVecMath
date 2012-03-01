/*
 * Automated conversion
 */

using System.Drawing;

namespace NVecMath
{
	/// <summary>A four-byte color value represented by byte x, y, z, and w values.</summary>
	/// <remarks>
	/// A four-byte color value represented by byte x, y, z, and w values.
	/// The x, y, z, and w values represent the red, green, blue, and alpha
	/// values, respectively.
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
	public class Color4b : Tuple4b
	{
		new internal const long serialVersionUID = -105080578052502155L;

		/// <summary>Constructs and initializes a Color4b from the four specified values.</summary>
		/// <remarks>Constructs and initializes a Color4b from the four specified values.</remarks>
		/// <param name="b1">the red color value</param>
		/// <param name="b2">the green color value</param>
		/// <param name="b3">the blue color value</param>
		/// <param name="b4">the alpha value</param>
		public Color4b(byte b1, byte b2, byte b3, byte b4) : base(b1, b2, b3, b4)
		{
		}

		/// <summary>Constructs and initializes a Color4b from the array of length 4.</summary>
		/// <remarks>Constructs and initializes a Color4b from the array of length 4.</remarks>
		/// <param name="c">the array of length 4 containing r, g, b, and alpha in order</param>
		public Color4b(byte[] c) : base(c)
		{
		}

		/// <summary>Constructs and initializes a Color4b from the specified Color4b.</summary>
		/// <remarks>Constructs and initializes a Color4b from the specified Color4b.</remarks>
		/// <param name="c1">
		/// the Color4b containing the initialization r,g,b,a
		/// data
		/// </param>
		public Color4b(Color4b c1) : base(c1)
		{
		}

		/// <summary>Constructs and initializes a Color4b from the specified Tuple4b.</summary>
		/// <remarks>Constructs and initializes a Color4b from the specified Tuple4b.</remarks>
		/// <param name="t1">
		/// the Tuple4b containing the initialization r,g,b,a
		/// data
		/// </param>
		public Color4b(Tuple4b t1) : base(t1)
		{
		}

		/// <summary>
		/// Constructs and initializes a Color4b from the specified AWT
		/// Color object.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes a Color4b from the specified AWT
		/// Color object.
		/// No conversion is done on the color to compensate for
		/// gamma correction.
		/// </remarks>
		/// <param name="color">
		/// the AWT color with which to initialize this
		/// Color4b object
		/// </param>
		/// <since>vecmath 1.2</since>
		public Color4b(Color color) : base(unchecked((byte)color.R), unchecked((byte
			)color.G), unchecked((byte)color.B), unchecked((byte)color.A))
		{
		}

		/// <summary>Constructs and initializes a Color4b to (0,0,0,0).</summary>
		/// <remarks>Constructs and initializes a Color4b to (0,0,0,0).</remarks>
		public Color4b() : base()
		{
		}

		// Compatible with 1.1
		/// <summary>
		/// Sets the r,g,b,a values of this Color4b object to those of the
		/// specified AWT Color object.
		/// </summary>
		/// <remarks>
		/// Sets the r,g,b,a values of this Color4b object to those of the
		/// specified AWT Color object.
		/// No conversion is done on the color to compensate for
		/// gamma correction.
		/// </remarks>
		/// <param name="color">the AWT color to copy into this Color4b object</param>
		/// <since>vecmath 1.2</since>
		public void Set(Color color)
		{
			x = unchecked((byte)color.R);
			y = unchecked((byte)color.G);
			z = unchecked((byte)color.B);
			w = unchecked((byte)color.A);
		}

		/// <summary>
		/// Returns a new AWT color object initialized with the r,g,b,a
		/// values of this Color4b object.
		/// </summary>
		/// <remarks>
		/// Returns a new AWT color object initialized with the r,g,b,a
		/// values of this Color4b object.
		/// </remarks>
		/// <returns>a new AWT Color object</returns>
		/// <since>vecmath 1.2</since>
		public Color Get()
		{
			int r = (int)x & unchecked((int)(0xff));
			int g = (int)y & unchecked((int)(0xff));
			int b = (int)z & unchecked((int)(0xff));
			int a = (int)w & unchecked((int)(0xff));
			return Color.FromArgb(r, g, b, a);
		}
	}
}
