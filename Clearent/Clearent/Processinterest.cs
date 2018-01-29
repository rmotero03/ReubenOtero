using System.Collections.Generic;

namespace Clearent
{
    public class ProcessInterest
    {
        public Customer ChargeInterest(Customer customer)
        {
            foreach (var wallet in customer.Wallets)
            {
                var walletCharges = 0.0m;
                foreach (var creditCard in wallet.CreditCards)
                {
                    creditCard.InterestCharges = creditCard.Balance * creditCard.InterestRate;
                    walletCharges += creditCard.InterestCharges;
                }
                wallet.InterestChargesTotal = walletCharges;
                customer.InterestChargesTotal += wallet.InterestChargesTotal;
            }
            return customer;
        }
    }

    public class Customer
    {
        public List<Wallet> Wallets { get; set; }
        public decimal InterestChargesTotal {get; set;}
    }

    public class Wallet
    {
        public List<ICreditCardBase> CreditCards { get; set; }
        public decimal InterestChargesTotal { get; set; }
    }
    
    public class CreditCard<T> where T : CreditCardBase
    {
        public T CreditCardType { get; set; }
    }

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

    public class MasterCard : CreditCardBase
    {
        public MasterCard()
        {
            InterestRate = .05m;
            CreditCardType = CreditCardType.MasterCard;
        }
    }
    public class Visa : CreditCardBase
    {
        public Visa()
        {
            InterestRate = .10m;
            CreditCardType = CreditCardType.Visa;
        }
    }
    public class Discover : CreditCardBase
    {
        public Discover()
        {
            InterestRate = .01m;
            CreditCardType = CreditCardType.Discover;
        }
    }

    public enum CreditCardType { MasterCard, Visa, Discover }
}
