using _3D_Printing_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3D_Printing_Service.Utility
{
	public static class SD
	{
		public const string DefaultProductImage = "3dlogo.png";
		public const string ManagerUser = "Manager";
		public const string PrinterUser = "Printer";
		public const string FrontDeskUser = "FrontDesk";
		public const string CustomerEndUser = "Customer";
		public const string ssShoppingCartCount = "ssCartCount";
		public const string ssDiscountCode = "ssDiscountCode";

		public const string StatusSubmitted = "Submitted";
		public const string StatusInProcess = "Being processed";
		public const string StatusReady = "Ready for Pickup";
		public const string StatusCompleted = "Completed";
		public const string StatusCancelled = "Cancelled";

		public const string PaymentStatusPending = "Pending";
		public const string PaymentStatusApproved = "Approved";
		public const string PaymentStatusRejected = "Rejected";

		internal static string ConvertToRawHtml(string description)
		{
			throw new NotImplementedException();
		}

		public static double DiscountedPrice(Discount discountFromDb, double OriginalOrderTotal)
		{
			if (discountFromDb == null)
			{
				return OriginalOrderTotal;
			}
			else
			{
				if (discountFromDb.MinimumAmount > OriginalOrderTotal)
				{
					return OriginalOrderTotal;
				}
				else
				{
					if (Convert.ToInt32(discountFromDb.DiscountType) == (int)Discount.EDiscountType.Dollar)
					{
						//$1 off $100
						return Math.Round(OriginalOrderTotal - discountFromDb.DiscountAmount, 2);
					}
					if (Convert.ToInt32(discountFromDb.DiscountType) == (int)Discount.EDiscountType.Percent)
					{
						return Math.Round(OriginalOrderTotal - (OriginalOrderTotal * discountFromDb.DiscountAmount / 100), 2);
					}

				}
				return OriginalOrderTotal;
			}
			
		}
	}
}
