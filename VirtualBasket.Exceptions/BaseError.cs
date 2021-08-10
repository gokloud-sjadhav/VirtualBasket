

namespace VirtualBasket.Exceptions
{
	#region Namespace
	using System.Net;
	using System.Runtime.Serialization;
	#endregion

	[DataContract]
	public class BaseError
	{
		#region Public Properties

		[DataMember]
		public HttpStatusCode Code { get; set; }

		[DataMember]
		public string ErrorCode { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public Category Category { get; set; }

		[DataMember]
		public Severity Severity { get; set; }

		#endregion
	}

	/// <summary>
	/// Category
	/// </summary>
	public enum Category
	{
		ApplicationLevel,
	}

	/// <summary>
	/// Severity
	/// </summary>
	public enum Severity
	{
		Extreme,
		High,
		Medium,
		Low,
		InformationOnly
	}
}
