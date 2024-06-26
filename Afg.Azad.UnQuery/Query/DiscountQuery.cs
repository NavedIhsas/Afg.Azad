using System;
using System.Linq;
using DiscountManagement.Domain.UserDiscountAgg;
using DiscountManagementInfrastructure.EfCore;
using ShopManagement.Domain.OrderAgg;
using Afg.Azad.UnQuery.Contract.Discount;
using Afg.Azad.UnQuery.Contract.Discount.Enum;

namespace Afg.Azad.UnQuery.Query
{
    public class DiscountQuery : IDiscountQuery
    {
        private readonly DiscountContext _context;
        private readonly IOrderRepository _order;

        public DiscountQuery(DiscountContext context, IOrderRepository order)
        {
            _context = context;
            _order = order;
        }

        public DiscountUseType UseDiscount(long orderId, string code)
        {
            var discount = _context.DiscountCodes.SingleOrDefault(x => x.Code == code.Trim());
            if (discount == null) return DiscountUseType.NotFount;

            if (discount.StartDate != null && discount.StartDate > DateTime.Now)
                return DiscountUseType.ExpireDate;

            if (discount.EndDate != null && discount.EndDate <= DateTime.Now)
                return DiscountUseType.ExpireDate;

            if (discount.UseableCount is < 1)
                return DiscountUseType.Finished;

            //find this order
            var order = _order.GetOrderById(orderId);

            if (_context.UserDiscounts.Any(x => x.AccountId == order.AccountId && x.DiscountCodeId == discount.Id))
                return DiscountUseType.UserUsed;

            //Apply Discount
            order.ApplyDiscount(order.Id, order.OrderSum, discount.DiscountRate);
            _order.Update(order);
            _order.SaveChanges();

            //add order and discountCode to userDiscount tbl
            _context.UserDiscounts.Add(new UserDiscount(order.AccountId, discount.Id));

            //decrease from UseableCount
            if (discount.UseableCount != null)
                discount.UseCount(discount.Id, discount.UseableCount);

            _context.DiscountCodes.Update(discount);
            _context.SaveChanges();
            return DiscountUseType.Success;
        }

        public bool? GetAllUserDiscount(long accountId, long discountCodeId)
        {
            var user = _context.UserDiscounts.Any(x =>
                x.AccountId == accountId && x.DiscountCodeId == discountCodeId);
            return user;
        }
    }
}