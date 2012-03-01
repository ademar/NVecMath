/*
 * Automated conversion
 */

using System;

namespace NVecMath
{
	/// <summary>
	/// Indicates that an operation cannot be completed properly because
	/// of a mismatch in the sizes of object attributes.
	/// </summary>
	/// <remarks>
	/// Indicates that an operation cannot be completed properly because
	/// of a mismatch in the sizes of object attributes.
	/// </remarks>
	[System.Serializable]
	public class MismatchedSizeException : Exception
	{
		/// <summary>Create the exception object with default values.</summary>
		/// <remarks>Create the exception object with default values.</remarks>
		public MismatchedSizeException()
		{
		}

		/// <summary>Create the exception object that outputs a message.</summary>
		/// <remarks>Create the exception object that outputs a message.</remarks>
		/// <param name="str">the message string to be output.</param>
		public MismatchedSizeException(string str) : base(str)
		{
		}
	}
}
