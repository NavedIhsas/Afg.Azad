using Afg.Azad.UnQuery.Contract.Discount.Enum;

namespace Afg.Azad.UnQuery.Contract.Discount
{
    public interface IDiscountQuery
    {
        DiscountUseType UseDiscount(long orderId, string code);
        bool? GetAllUserDiscount(long accountId, long discountCodeId);
    }
}