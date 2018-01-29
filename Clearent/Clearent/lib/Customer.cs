using System.Collections.Generic;

namespace Clearent
{
    public class Customer
    {
        public List<Wallet> Wallets { get; set; }
        public decimal InterestChargesTotal { get; set; }
    }
}
