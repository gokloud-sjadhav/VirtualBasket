/*
 Filename:	ProductDetailsProvider.cs
 Author:	Shrikant Jadhav
 Initial Implementation:	08/10/2021
 Change History
 #	Name				Date			Remarks
 1:	Shrikant J.			08/10/2021		Shopping cart business rules related operation in product provider class 
*/

namespace VirtualBasket.Providers.ProductDetails
{
	#region Namespace
	using System;
	using System.Collections.Generic;
	using VirtualBasket.Models.ProductDetails;
	using System.Linq;
	using VirtualBasket.Exceptions;
	#endregion

	/// <summary>
	/// ProductDetailsProvider
	/// </summary>
	public class ProductDetailsProvider : IProductDetailsProvider
	{
		#region Properties
		private List<ProductDetails> _shoppingCart = null;
		#endregion

		#region Constructure

		/// <summary>
		/// ProductDetailsProvider
		/// </summary>
		public ProductDetailsProvider()
		{
			_shoppingCart = new List<ProductDetails>();
		}

		#endregion

		#region Methods 

		/// <summary>
		/// Add product details object into shopping cart collection
		/// </summary>
		/// <param name="_productDetails">Passing product details object and it contains product item details while adding into collection object</param>
		/// <returns></returns>
		public ProductDetails addProductItem(ProductDetails _productDetails)
		{
			if (null == _productDetails)
				throw new MissingProductException("Missing product details exception.");
			if (0 == _productDetails.Quantity)
				throw new ZeroQuantityException("Zero quantity exception.");

			_shoppingCart.Add(_productDetails);


			return _productDetails;
		}

		/// <summary>
		/// Get all product cart items 
		/// </summary>
		/// <returns></returns>
		public List<ProductDetails> getAllProductItems()
		{
			return _shoppingCart;
		}

		/// <summary>
		/// calculate total price of given collection
		/// </summary> 
		public double getTotalAmount()
		{
			var totalPrice = _shoppingCart.Sum(m => m.Price);
			return totalPrice;
		}

		/// <summary>
		/// clearCartItems
		/// </summary>
		public void clearCartItems()
		{
			_shoppingCart = new List<ProductDetails>();
		}

		/// <summary>
		/// getTotalDiscountAmount
		/// </summary>
		/// <param name="_productName"></param>
		/// <param name="_discountAmount"></param>
		/// <returns></returns>
		public double getTotalDiscountAmount(string _productName, double _discountAmount)
		{
			var _finalAmount = 0.00;
			if (_productName == "apples")
			{
				var _totalPrice = _shoppingCart.Where(m => m.ProductName == _productName).Sum(m => m.Price * m.Quantity);
				_finalAmount = _totalPrice - _discountAmount;
			}
			return _finalAmount;
		}

		#endregion
	}
}
