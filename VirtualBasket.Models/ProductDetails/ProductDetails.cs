/*
 Filename:	ProductDetails.cs
 Author:	Shrikant Jadhav
 Initial Implementation:	08/10/2021
 Change History
 #	Name				Date			Remarks
 1:	Shrikant J.			08/10/2021		Product item related details are mentioned in product details class
*/

namespace VirtualBasket.Models.ProductDetails
{
	#region Namespace
	using System;
    using VirtualBasket.Models.Common;
    #endregion

    /// <summary>
    /// ProductDetails
    /// </summary>
    public class ProductDetails : ResultStatus
	{
		#region Properties 
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
		public double DiscountAmount { get; set; }
		#endregion
	}
}
