

namespace VirtualBasket.Exceptions
{
	#region Namespace
	using System;
	using System.Globalization;
	using System.Runtime.Serialization;
	#endregion

	/// <summary>
	/// BaseException
	/// </summary> 
	public abstract class BaseException : Exception
	{
		#region Constructors 

		/// <summary>
		/// BaseException
		/// </summary>
		protected BaseException()
		{
		}

		/// <summary>
		/// BaseException
		/// </summary>
		/// <param name="message"></param>
		protected BaseException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// BaseException
		/// </summary>
		/// <param name="message"></param>
		/// <param name="innerException"></param>
		protected BaseException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// BaseException
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected BaseException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}

		#endregion
	}

	/// <summary>
	/// BaseException
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Serializable]
	public class BaseException<T> : BaseException where T : BaseError
	{
		#region Constants and Fields

		private const string ErrorMessageFormat = "[{0}] - {1}";

		private T errorDetail;

		#endregion

		#region Constructors and Destructors

		/// <summary>
		/// BaseException
		/// </summary>
		/// <param name="errorDetail"></param>
		public BaseException(T errorDetail)
			: this(null, errorDetail)
		{
		}

		/// <summary>
		/// BaseException
		/// </summary>
		/// <param name="innerException"></param>
		/// <param name="errorDetailValue"></param>
		public BaseException(Exception innerException, T errorDetailValue)
			: base(null, innerException)
		{
			this.errorDetail = errorDetailValue;
		}

		/// <summary>
		/// BaseException
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		protected BaseException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
			try
			{
				if (info != null)
				{
					info.GetValue("ErrorDetail", typeof(T));
				}
			}
			catch
			{
				// ignore this exception, we did not get any ErrorDetail from serialization info
			}
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// ErrorDetail
		/// </summary>
		public virtual T ErrorDetail
		{
			get
			{
				return this.errorDetail;
			}

			protected set
			{
				this.errorDetail = value;
			}
		}

		/// <summary>
		/// Message
		/// </summary>
		public override string Message
		{
			get
			{
				var currentErrorDetail = this.ErrorDetail;
				return (currentErrorDetail != null)
						   ? (string.IsNullOrWhiteSpace(currentErrorDetail.ErrorCode)
								  ? currentErrorDetail.Description
								  : string.Format(
									  CultureInfo.InvariantCulture,
									  ErrorMessageFormat,
									  currentErrorDetail.ErrorCode,
									  currentErrorDetail.Description))
						   : string.Empty;
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// GetObjectData
		/// </summary>
		/// <param name="info"></param>
		/// <param name="context"></param>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException("info");
			}

			base.GetObjectData(info, context);
			if (this.ErrorDetail != null)
			{
				info.AddValue("ErrorDetail", this.ErrorDetail);
			}
		}

		#endregion
	}
}
