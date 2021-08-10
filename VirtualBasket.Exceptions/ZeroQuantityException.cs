

namespace VirtualBasket.Exceptions
{
	#region Namespace
	using System;
	using System.Net;
	#endregion

	/// <summary>
	/// ZeroQuantityException
	/// </summary>
	public class ZeroQuantityException : BaseException<BaseError>
	{
		#region Constructors 

		/// <summary>
		/// ZeroQuantityException
		/// </summary>
		/// <param name="message"></param>
		/// <param name="statusCode"></param>
		/// <param name="severity"></param>
		/// <param name="category"></param>
		public ZeroQuantityException(string message, HttpStatusCode statusCode, Severity severity, Category category)
			: this(message, statusCode, null, severity, category)
		{
		}

		/// <summary>
		/// ZeroQuantityException
		/// </summary>
		/// <param name="message"></param>
		/// <param name="statusCode"></param>
		/// <param name="innerException"></param>
		/// <param name="severity"></param>
		/// <param name="category"></param>
		public ZeroQuantityException(string message, HttpStatusCode statusCode, Exception innerException, Severity severity, Category category)
			: base(innerException, new BaseError { Code = statusCode, Description = message, Severity = severity, Category = category })
		{
		}

		/// <summary>
		/// ZeroQuantityException
		/// </summary>
		/// <param name="message"></param>
		public ZeroQuantityException(string message)
			: this(message, string.Empty, null)
		{
		}

		/// <summary>
		/// ZeroQuantityException
		/// </summary>
		/// <param name="message"></param>
		/// <param name="errorCode"></param>
		/// <param name="innerException"></param>
		public ZeroQuantityException(string message, string errorCode, Exception innerException)
			: base(innerException, new BaseError { Description = message, ErrorCode = errorCode, Code = HttpStatusCode.Conflict })
		{
		}
		#endregion
	}
}
