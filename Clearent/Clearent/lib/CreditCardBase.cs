namespace Clearent
{
    public interface ICreditCardBase
    {
        decimal InterestRate { get; set; }
        decimal Balance { get; set; }
        decimal InterestCharges { get; set; }
        CreditCardType CreditCardType { get; set; }
    }

    public class CreditCardBase : ICreditCardBase
    {
        public decimal InterestRate { get; set; }
        public decimal Balance { get; set; }
        public decimal InterestCharges { get; set; }
        public CreditCardType CreditCardType { get; set; }
    }
}
