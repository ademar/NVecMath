/*
 * Automated conversion
 */

using System;
using System.Drawing;

namespace NVecMath
{
	/// <summary>
	/// A four-element color represented by single precision floating point
	/// x, y, z, and w values.
	/// </summary>
	/// <remarks>
	/// A four-element color represented by single precision floating point
	/// x, y, z, and w values.  The x, y, z, and w values represent the red,
	/// blue, green, and alpha color values, respectively. Color and alpha
	/// components should be in the range [0.0, 1.0].
	/// <p>
	/// Java 3D assumes that a linear (gamma-corrected) visual is used for
	/// all colors.
	/// </remarks>
	[System.Serializable]
	public class Color4f : Tuple4f
	{
		new internal const long serialVersionUID = 8577680141580006740L;

		/// <summary>
		/// Constructs and initializes a Color4f from the specified xyzw
		/// coordinates.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes a Color4f from the specified xyzw
		/// coordinates.
		/// </remarks>
		/// <param name="x">the red color value</param>
		/// <param name="y">the green color value</param>
		/// <param name="z">the blue color value</param>
		/// <param name="w">the alpha value</param>
		public Color4f(float x, float y, float z, float w) : base(x, y, z, w)
		{
		}

		/// <summary>Constructs and initializes a Color4f from the array of length 4.</summary>
		/// <remarks>Constructs and initializes a Color4f from the array of length 4.</remarks>
		/// <param name="c">the array of length 4 containing r,g,b,a in order</param>
		public Color4f(float[] c) : base(c)
		{
		}

		/// <summary>Constructs and initializes a Color4f from the specified Color4f.</summary>
		/// <remarks>Constructs and initializes a Color4f from the specified Color4f.</remarks>
		/// <param name="c1">the Color4f containing the initialization r,g,b,a data</param>
		public Color4f(Color4f c1) : base(c1)
		{
		}

		/// <summary>Constructs and initializes a Color4f from the specified Tuple4f.</summary>
		/// <remarks>Constructs and initializes a Color4f from the specified Tuple4f.</remarks>
		/// <param name="t1">the Tuple4f containing the initialization r,g,b,a data</param>
		public Color4f(Tuple4f t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a Color4f from the specified Tuple4d.</summary>
		/// <remarks>Constructs and initializes a Color4f from the specified Tuple4d.</remarks>
		/// <param name="t1">the Tuple4d containing the initialization r,g,b,a data</param>
		public Color4f(Tuple4d t1) : base(t1)
		{
		}

		/// <summary>
		/// Constructs and initializes a Color4f from the specified AWT
		/// Color object.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes a Color4f from the specified AWT
		/// Color object.
		/// No conversion is done on the color to compensate for
		/// gamma correction.
		/// </remarks>
		/// <param name="color">
		/// the AWT color with which to initialize this
		/// Color4f object
		/// </param>
		/// <since>vecmath 1.2</since>
		public Color4f(Color color) : base((float)color.R / 255.0f, (float)color.G / 255.0f, (float)color.B / 255.0f, (float)color.A / 255.0f)
		{
		}

		/// <summary>Constructs and initializes a Color4f to (0.0, 0.0, 0.0, 0.0).</summary>
		/// <remarks>Constructs and initializes a Color4f to (0.0, 0.0, 0.0, 0.0).</remarks>
		public Color4f() : base()
		{
		}

		// Compatible with 1.1
		/// <summary>
		/// Sets the r,g,b,a values of this Color4f object to those of the
		/// specified AWT Color object.
		/// </summary>
		/// <remarks>
		/// Sets the r,g,b,a values of this Color4f object to those of the
		/// specified AWT Color object.
		/// No conversion is done on the color to compensate for
		/// gamma correction.
		/// </remarks>
		/// <param name="color">the AWT color to copy into this Color4f object</param>
		/// <since>vecmath 1.2</since>
		public void Set(Color color)
		{
			x = (float)color.R / 255.0f;
			y = (float)color.G / 255.0f;
			z = (float)color.B / 255.0f;
			w = (float)color.A / 255.0f;
		}

		/// <summary>
		/// Returns a new AWT color object initialized with the r,g,b,a
		/// values of this Color4f object.
		/// </summary>
		/// <remarks>
		/// Returns a new AWT color object initialized with the r,g,b,a
		/// values of this Color4f object.
		/// </remarks>
		/// <returns>a new AWT Color object</returns>
		/// <since>vecmath 1.2</since>
		public Color Get()
		{
			int r = (int)Math.Round(x * 255.0f);
			int g = (int)Math.Round(y * 255.0f);
			int b = (int)Math.Round(z * 255.0f);
			int a = (int)Math.Round(w * 255.0f);
			return Color.FromArgb(r, g, b, a);
		}
	}
}
