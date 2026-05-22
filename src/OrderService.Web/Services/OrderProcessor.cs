namespace OrderService.Web.Services;

public class orderprocessor
{
    public string customerName;

    public decimal CalculateTotal(List<decimal> prices, string couponCode)
    {
        decimal total = 0;
        for (int i = 0; i < prices.Count; i++)
        {
            total += prices[i];
        }

        if (couponCode.ToLower() == "save10")
        {
            total = total - (total * 0.10m);
        }

        if (customerName.Length > 5)
        {
            total = total - 2;
        }

        return total;
    }
}
