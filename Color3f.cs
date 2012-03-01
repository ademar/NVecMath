/*
 * Automated conversion
 */

using System;
using System.Drawing;

namespace NVecMath
{
	/// <summary>
	/// A three-element color value represented by single precision floating
	/// point x,y,z values.
	/// </summary>
	/// <remarks>
	/// A three-element color value represented by single precision floating
	/// point x,y,z values.  The x,y,z values represent the red, green, and
	/// blue color values, respectively. Color components should be in the
	/// range of [0.0, 1.0].
	/// <p>
	/// Java 3D assumes that a linear (gamma-corrected) visual is used for
	/// all colors.
	/// </remarks>
	[System.Serializable]
	public class Color3f : Tuple3f
	{
		new internal const long serialVersionUID = -1861792981817493659L;

		/// <summary>Constructs and initializes a Color3f from the three xyz values.</summary>
		/// <remarks>Constructs and initializes a Color3f from the three xyz values.</remarks>
		/// <param name="x">the red color value</param>
		/// <param name="y">the green color value</param>
		/// <param name="z">the blue color value</param>
		public Color3f(float x, float y, float z) : base(x, y, z)
		{
		}

		/// <summary>Constructs and initializes a Color3f from the array of length 3.</summary>
		/// <remarks>Constructs and initializes a Color3f from the array of length 3.</remarks>
		/// <param name="v">the array of length 3 containing xyz in order</param>
		public Color3f(float[] v) : base(v)
		{
		}

		/// <summary>Constructs and initializes a Color3f from the specified Color3f.</summary>
		/// <remarks>Constructs and initializes a Color3f from the specified Color3f.</remarks>
		/// <param name="v1">the Color3f containing the initialization x y z data</param>
		public Color3f(Color3f v1) : base(v1)
		{
		}

		/// <summary>Constructs and initializes a Color3f from the specified Tuple3f.</summary>
		/// <remarks>Constructs and initializes a Color3f from the specified Tuple3f.</remarks>
		/// <param name="t1">the Tuple3f containing the initialization x y z data</param>
		public Color3f(Tuple3f t1) : base(t1)
		{
		}

		/// <summary>Constructs and initializes a Color3f from the specified Tuple3d.</summary>
		/// <remarks>Constructs and initializes a Color3f from the specified Tuple3d.</remarks>
		/// <param name="t1">the Tuple3d containing the initialization x y z data</param>
		public Color3f(Tuple3d t1) : base(t1)
		{
		}

		/// <summary>
		/// Constructs and initializes a Color3f from the specified AWT
		/// Color object.
		/// </summary>
		/// <remarks>
		/// Constructs and initializes a Color3f from the specified AWT
		/// Color object.  The alpha value of the AWT color is ignored.
		/// No conversion is done on the color to compensate for
		/// gamma correction.
		/// </remarks>
		/// <param name="color">
		/// the AWT color with which to initialize this
		/// Color3f object
		/// </param>
		/// <since>vecmath 1.2</since>
		public Color3f(Color color) : base((float)color.R / 255.0f, (float)color.G / 255.0f, (float)color.B / 255.0f)
		{
		}

		/// <summary>Constructs and initializes a Color3f to (0.0, 0.0, 0.0).</summary>
		/// <remarks>Constructs and initializes a Color3f to (0.0, 0.0, 0.0).</remarks>
		public Color3f() : base()
		{
		}

		// Compatible with 1.1
		/// <summary>
		/// Sets the r,g,b values of this Color3f object to those of the
		/// specified AWT Color object.
		/// </summary>
		/// <remarks>
		/// Sets the r,g,b values of this Color3f object to those of the
		/// specified AWT Color object.
		/// No conversion is done on the color to compensate for
		/// gamma correction.
		/// </remarks>
		/// <param name="color">the AWT color to copy into this Color3f object</param>
		/// <since>vecmath 1.2</since>
		public void Set(Color color)
		{
			x = (float)color.R / 255.0f;
			y = (float)color.G / 255.0f;
			z = (float)color.B / 255.0f;
		}

		/// <summary>
		/// Returns a new AWT color object initialized with the r,g,b
		/// values of this Color3f object.
		/// </summary>
		/// <remarks>
		/// Returns a new AWT color object initialized with the r,g,b
		/// values of this Color3f object.
		/// </remarks>
		/// <returns>a new AWT Color object</returns>
		/// <since>vecmath 1.2</since>
		public Color Get()
		{
			int r = (int)Math.Round(x * 255.0f);
			int g = (int)Math.Round(y * 255.0f);
			int b = (int)Math.Round(z * 255.0f);
			return Color.FromArgb(r, g, b);
		}
	}
}
