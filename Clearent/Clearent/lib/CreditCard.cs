namespace Clearent
{
    public class CreditCard<T> where T : CreditCardBase
    {
        public T CreditCardType { get; set; }
    }
}
