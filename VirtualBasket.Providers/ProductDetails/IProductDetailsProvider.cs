/*
 Filename:	IProductDetailsProvider.cs
 Author:	Shrikant Jadhav
 Initial Implementation:	08/10/2021
 Change History
 #	Name				Date			Remarks
 1:	Shrikant J.			08/10/2021		Created interface for product 
*/

namespace VirtualBasket.Providers.ProductDetails
{
	#region Namespace
	using System;
	using System.Collections.Generic;
	using VirtualBasket.Models.ProductDetails;
	#endregion

	/// <summary>
	/// IProductDetailsProvider
	/// </summary>
	public interface IProductDetailsProvider
	{
		#region Method Declaration		

		/// <summary>
		/// addProductItem
		/// </summary>
		/// <param name="_productDetails"></param>
		/// <returns></returns>
		ProductDetails addProductItem(ProductDetails _productDetails);
		 
		/// <summary>
		/// getAllProductItems
		/// </summary>
		/// <returns></returns>
		List<ProductDetails> getAllProductItems();

		/// <summary>
		/// getTotalAmount
		/// </summary>
		/// <returns></returns>
		double getTotalAmount();

		/// <summary>
		/// getTotalDiscountAmount
		/// </summary>
		/// <param name="_productName"></param>
		/// <param name="_discountAmount"></param>
		/// <returns></returns>
		double getTotalDiscountAmount(string _productName, double _discountAmount);
		 
		/// <summary>
		/// clearCartItems
		/// </summary>
		void clearCartItems();

		#endregion
	}
}
