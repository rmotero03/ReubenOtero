namespace Clearent
{
    public class Discover : CreditCardBase
    {
        public Discover()
        {
            InterestRate = .01m;
            CreditCardType = CreditCardType.Discover;
        }
    }
}
