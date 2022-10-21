using Grpc.Core;

namespace CalculateDiscountService.Services;

public class CalculateDiscountAmountService : CalculateDiscountAmount.CalculateDiscountAmountBase
{
    public CalculateDiscountAmountService() { }

    public override Task<CalculateReply> AmountCalculate(CalculateRequest request, ServerCallContext context)
    {
        return Task.FromResult(new CalculateReply { Customerdiscount = ReturnDiscount(request.Customertype) });
    }

    private static double ReturnDiscount(string customerType)
    {
        double discount = 0.0;

        switch (customerType)
        {
            case "GOLD":
                discount = 15.6;
                break;
            case "PLATINUM":
                discount = 20.6;
                break;
            case "DIAMOND":
                discount = 25.6;
                break;
        }

        return discount;
    }
}