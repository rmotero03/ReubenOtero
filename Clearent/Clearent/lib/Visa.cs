namespace Clearent
{
    public class Visa : CreditCardBase
    {
        public Visa()
        {
            InterestRate = .10m;
            CreditCardType = CreditCardType.Visa;
        }
    }
}
