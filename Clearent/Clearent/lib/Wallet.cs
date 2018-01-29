using System.Collections.Generic;

namespace Clearent
{
    public class Wallet
    {
        public List<ICreditCardBase> CreditCards { get; set; }
        public decimal InterestChargesTotal { get; set; }
    }
}
