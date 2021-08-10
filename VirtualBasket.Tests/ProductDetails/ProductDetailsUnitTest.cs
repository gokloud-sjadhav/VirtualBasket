/*
 Filename:	ProductDetailsUnitTest.cs
 Author:	Shrikant Jadhav
 Initial Implementation:	08/10/2021
 Change History
 #	Name				Date			Remarks
 1:	Shrikant J.			08/10/2021		Created ProductDetailsUnitTest class and also created test methods to perform shopping cart related operations
*/

namespace VirtualBasket.Tests.ProductDetails
{
	#region Namespace
	using System;
	using System.Collections.Generic;
	using System.Text;
	using VirtualBasket.Models.ProductDetails;
	using VirtualBasket.Providers.ProductDetails;
	using Xunit;
	#endregion

	/// <summary>
	/// ProductDetailsUnitTest
	/// </summary>
	public class ProductDetailsUnitTest
	{
		#region Properties
		private IProductDetailsProvider _productDetailsProvider = null;
		#endregion

		#region Construsture

		/// <summary>
		/// ProductDetailsUnitTest
		/// </summary>
		public ProductDetailsUnitTest()
		{
			_productDetailsProvider = new ProductDetailsProvider();
		}

		#endregion

		#region Test Methods 

		/// <summary>
		/// addProductItemTest
		/// </summary>
		/// </summary>
		[Fact]
		public void addProductItemTest()
		{
			_productDetailsProvider.addProductItem(new ProductDetails() { ProductId = 1, ProductName = "apples", Quantity = 10, Price = 180.00 });
			var _expectedCount = 1;
			var _totalCount = _productDetailsProvider.getAllProductItems().Count;
			Assert.Equal(_expectedCount, _totalCount);
		}

		/// <summary>
		/// getTotalAmountTest
		/// </summary>
		[Fact]
		public void getTotalAmountTest()
		{
			var _expectedAmount = 500.00;

			_productDetailsProvider.addProductItem(new ProductDetails() { ProductId = 2, ProductName = "oranges", Quantity = 4, Price = 200.00 });
			_productDetailsProvider.addProductItem(new ProductDetails() { ProductId = 3, ProductName = "banana", Quantity = 5, Price = 300.00 });

			var _totalPrice = _productDetailsProvider.getTotalAmount();

			Assert.Equal(_totalPrice, _expectedAmount);
		}

		/// <summary>
		/// getTotalDiscountTest
		/// </summary>
		[Fact]
		public void getTotalDiscountTest()
		{
			var _expectedAmount = 500;

			_productDetailsProvider.addProductItem(new ProductDetails() { ProductId = 2, ProductName = "apples", Quantity = 4, Price = 200.00 });
			_productDetailsProvider.addProductItem(new ProductDetails() { ProductId = 3, ProductName = "oranges", Quantity = 5, Price = 300.00 });

			var _totalDiscountAmount = _productDetailsProvider.getTotalDiscountAmount("apples", 20.3);

			Assert.Equal(_expectedAmount, _totalDiscountAmount);
		}

		/// <summary>
		/// getAllProductItemsTest
		/// </summary>
		[Fact]
		public void getAllProductItemsTest()
		{
			List<ProductDetails> _products = _productDetailsProvider.getAllProductItems();
			Assert.NotNull(_products);
		}

		/// <summary>
		/// clearCartItemsTest
		/// </summary>
		[Fact]
		public void clearCartItemsTest()
		{
			_productDetailsProvider.clearCartItems();
			Assert.True(true);
		}

		#endregion
	}
}
