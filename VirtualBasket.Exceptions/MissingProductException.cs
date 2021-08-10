

namespace VirtualBasket.Exceptions
{
	#region Namespace
	using System;
	using System.Net;
	#endregion

	/// <summary>
	/// MissingProductException
	/// </summary>
	public class MissingProductException : BaseException<BaseError>
	{
		#region Constructors 

		/// <summary>
		/// MissingProductException
		/// </summary>
		/// <param name="message"></param>
		/// <param name="statusCode"></param>
		/// <param name="severity"></param>
		/// <param name="category"></param>
		public MissingProductException(string message, HttpStatusCode statusCode, Severity severity, Category category)
			: this(message, statusCode, null, severity, category)
		{
		}

		/// <summary>
		/// MissingProductException
		/// </summary>
		/// <param name="message"></param>
		/// <param name="statusCode"></param>
		/// <param name="innerException"></param>
		/// <param name="severity"></param>
		/// <param name="category"></param>
		public MissingProductException(string message, HttpStatusCode statusCode, Exception innerException, Severity severity, Category category)
			: base(innerException, new BaseError { Code = statusCode, Description = message, Severity = severity, Category = category })
		{
		}

		/// <summary>
		/// MissingProductException
		/// </summary>
		/// <param name="message"></param>
		public MissingProductException(string message)
			: this(message, string.Empty, null)
		{
		}

		/// <summary>
		/// MissingProductException
		/// </summary>
		/// <param name="message"></param>
		/// <param name="errorCode"></param>
		/// <param name="innerException"></param>
		public MissingProductException(string message, string errorCode, Exception innerException)
			: base(innerException, new BaseError { Description = message, ErrorCode = errorCode, Code = HttpStatusCode.Conflict })
		{
		}
		#endregion
	}
}
