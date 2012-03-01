/*
 * Automated conversion
 */

using System;

namespace NVecMath
{
	/// <summary>Indicates that inverse of a matrix can not be computed.</summary>
	/// <remarks>Indicates that inverse of a matrix can not be computed.</remarks>
	[System.Serializable]
	public class SingularMatrixException : Exception
	{
		/// <summary>Create the exception object with default values.</summary>
		/// <remarks>Create the exception object with default values.</remarks>
		public SingularMatrixException()
		{
		}

		/// <summary>Create the exception object that outputs message.</summary>
		/// <remarks>Create the exception object that outputs message.</remarks>
		/// <param name="str">the message string to be output.</param>
		public SingularMatrixException(string str) : base(str)
		{
		}
	}
}
