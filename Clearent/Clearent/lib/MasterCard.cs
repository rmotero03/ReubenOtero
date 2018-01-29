namespace Clearent
{
    public class MasterCard : CreditCardBase
    {
        public MasterCard()
        {
            InterestRate = .05m;
            CreditCardType = CreditCardType.MasterCard;
        }
    }
}
