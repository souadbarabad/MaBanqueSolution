using BanqueLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BanqueLogic.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        private const string DefaultOwner = "souad_barabad";
        private BankAccount compte;
        private int defaultInitialBalance;

        [TestInitialize]
        public void Setup()
        {
            defaultInitialBalance = 2500;
            compte = new BankAccount(DefaultOwner, defaultInitialBalance);
        }

        [TestMethod]
        public void Tester_Cas_Ideal_Debit() {
            int debitAmount = 1000;
            int expectedBalance = defaultInitialBalance - debitAmount;
            compte.Debit(debitAmount);
            Assert.AreEqual(expectedBalance, compte.Balance);
        }

        [TestMethod]
        public void Tester_Cas_Ideal_Credit() {
            int debitAmount = 500;
            int expectedBalance = defaultInitialBalance + debitAmount;
            compte.Credit(debitAmount);
            Assert.AreEqual(expectedBalance, compte.Balance);
        }


        [TestMethod]
        public void Debit_Solde_Insuffisants_Leve_Exception() {
            Assert.ThrowsException<InvalidOperationException>(() => { compte.Debit(5000); });
        }

        [TestMethod]
        public void Debit_Montant_Negative_Leve_Exception() {
            Assert.ThrowsException<InvalidOperationException>(() => { compte.Debit(-100); });
        }

        [TestMethod]
        public void Credit_Montant_Negatif_Leve_Exception() {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { compte.Credit(-200); });
        }
    }
}

