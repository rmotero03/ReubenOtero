using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Clearent
{
    [TestFixture]
    public class ProcessInterestTests
    {
        private ProcessInterest processInterest;

        [SetUp]
        public void SetUp()
        {
            processInterest = new ProcessInterest();
        }

        [Test]
        public void OnePerson_OneWallet_ThreeCreditCards()
        {
            //arrange
            var customer = Get_Test_One_Scenario();

            //act
            var process_customer = processInterest.ChargeInterest(customer);
           
            //assert
            Assert.NotNull(process_customer);
            Assert.AreEqual(5, process_customer.Wallets
                                            .First().CreditCards
                                            .FirstOrDefault(c => c.CreditCardType == CreditCardType.MasterCard)
                                            .InterestCharges);
            Assert.AreEqual(10, process_customer.Wallets
                                            .First().CreditCards
                                            .FirstOrDefault(c => c.CreditCardType == CreditCardType.Visa)
                                            .InterestCharges);
            Assert.AreEqual(1, process_customer.Wallets
                                            .First().CreditCards
                                            .FirstOrDefault(c => c.CreditCardType == CreditCardType.Discover)
                                            .InterestCharges);
            Assert.AreEqual(16, process_customer.InterestChargesTotal);
        }

        [Test]
        public void OnePerson_TwoWallets()
        {
            //arrange
            var customer = Get_Test_Two_Scenario();

            //act
            var process_customer = processInterest.ChargeInterest(customer);

            //assert
            Assert.NotNull(process_customer);
            Assert.AreEqual(5, process_customer.Wallets
                                                .SelectMany(w => w.CreditCards)
                                                .FirstOrDefault(c => c.CreditCardType == CreditCardType.MasterCard)
                                                .InterestCharges);
            Assert.AreEqual(10, process_customer.Wallets.SelectMany(w => w.CreditCards)
                                                .FirstOrDefault(c => c.CreditCardType == CreditCardType.Visa)
                                                .InterestCharges);
            Assert.AreEqual(1, process_customer.Wallets.SelectMany(w => w.CreditCards)
                                                .FirstOrDefault(c => c.CreditCardType == CreditCardType.Discover)
                                                .InterestCharges);
            Assert.AreEqual(16, process_customer.InterestChargesTotal);
        }

        [Test]
        public void TwoPersons_EachOneWallet()
        {
            //arrange
            var customer1 = Get_Test_Three_Scenario();
            var customer2 = Get_Test_Three_Scenario();

            //act
            var process_customer1 = processInterest.ChargeInterest(customer1);
            var process_customer2 = processInterest.ChargeInterest(customer2);

            //assert
            Assert.NotNull(process_customer1);
            Assert.NotNull(process_customer2);

            Assert.AreEqual(5, process_customer1.Wallets
                                                .SelectMany(w => w.CreditCards)
                                                .FirstOrDefault(c => c.CreditCardType == CreditCardType.MasterCard)
                                                .InterestCharges);
            Assert.AreEqual(10, process_customer1.Wallets.SelectMany(w => w.CreditCards)
                                                .FirstOrDefault(c => c.CreditCardType == CreditCardType.Visa)
                                                .InterestCharges);

            Assert.AreEqual(5, process_customer2.Wallets
                                                .SelectMany(w => w.CreditCards)
                                                .FirstOrDefault(c => c.CreditCardType == CreditCardType.MasterCard)
                                                .InterestCharges);
            Assert.AreEqual(10, process_customer2.Wallets.SelectMany(w => w.CreditCards)
                                                .FirstOrDefault(c => c.CreditCardType == CreditCardType.Visa)
                                                .InterestCharges);

            Assert.AreEqual(15, process_customer1.InterestChargesTotal);
            Assert.AreEqual(15, process_customer2.InterestChargesTotal);

        }

        public Customer Get_Test_One_Scenario()
        {
            var wallet = getNewWallet();
           
            wallet.CreditCards.Add(getMasterCard(100));
            wallet.CreditCards.Add(getVisa(100));
            wallet.CreditCards.Add(GetDiscover(100));

            var customer = new Customer
            {
                Wallets = new List<Wallet> { wallet}
            };

            return customer;
        }

        public Customer Get_Test_Two_Scenario()
        {
            var wallet1 = getNewWallet();

            wallet1.CreditCards.Add(getVisa(100));
            wallet1.CreditCards.Add(GetDiscover(100));

            var wallet2 = getNewWallet();
            wallet2.CreditCards.Add(getMasterCard(100));

            var customer = new Customer
            {
                Wallets = new List<Wallet> { wallet1, wallet2 }
            };

            return customer;
        }

        public Customer Get_Test_Three_Scenario()
        {
            var wallet = getNewWallet();

            wallet.CreditCards.Add(getMasterCard(100));
            wallet.CreditCards.Add(getVisa(100));

            var customer = new Customer
            {
                Wallets = new List<Wallet> { wallet }
            };

            return customer;
        }

        public Wallet getNewWallet()
        {
            return new Wallet
            {
                CreditCards = new List<ICreditCardBase>()
            };
        }
        public MasterCard getMasterCard(int balance)
        {
            return new MasterCard
            {
                Balance = balance
            };
        }

        public Visa getVisa(int balance)
        {
            return new Visa
            {
                Balance = balance
            };
        }

        public Discover GetDiscover(int balance)
        {
            return new Discover
            {
                Balance = balance
            };
        }
    }
}
