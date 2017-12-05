namespace TablePerHierarchyWithConventions
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string Text { get; set; }
        public double Amount { get; set; }
    }

    public class CashPayment : Payment { }

    public class CreditcardPayment : Payment
    {
        public string CreditcardNumber { get; set; }
    }
}
