

namespace VirtualBasket.Models.Common
{
	#region Namespace
	using System;
	using System.Collections.Generic;
	using System.Text;
	using static VirtualBasket.Models.Common.CommonEnum;
	#endregion

	/// <summary>
	/// ResultStatus
	/// </summary>
	public class ResultStatus
	{
		#region Constructor

		/// <summary>
		/// ResultStatus
		/// </summary>
		public ResultStatus()
		{
			Status = PageStatus.None;
		}

		#endregion

		#region Public Properties

		public PageStatus Status { get; set; }
		public string ErrorMsg { get; set; }
		public string SuccessMsg { get; set; }

		#endregion
	}
}
