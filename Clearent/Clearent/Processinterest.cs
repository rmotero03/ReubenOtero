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
}
