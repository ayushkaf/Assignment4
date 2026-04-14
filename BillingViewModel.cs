public class BillingViewModel
{
    public double CalculateDiscount(double totalCost, bool isReseller)
    {
        if (isReseller)
            return totalCost * 0.20;

        return 0;
    }
}