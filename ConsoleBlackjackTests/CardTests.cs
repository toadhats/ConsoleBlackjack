﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ConsoleBlackjack.Tests
{
    [TestClass()]
    public class CardTests
    {
        [TestMethod()]
        public void CardConstructorTest()
        {
            Card aceOfSpades = new Card(0, 1);
            Console.WriteLine(aceOfSpades.ToString());
            Assert.IsInstanceOfType(aceOfSpades, typeof(Card));
        }

        [TestMethod()]
        public void GetValueTest()
        {
            Card aceOfSpades = new Card(0, 1);
            Console.WriteLine(aceOfSpades.ToString());
            Console.WriteLine("Value of card = {0}", aceOfSpades.Value);
            Assert.AreEqual(aceOfSpades.Value, 1);

            Card tenOfDiamonds = new Card(2, 10);
            Console.WriteLine(tenOfDiamonds.ToString());
            Console.WriteLine("Value of card = {0}", tenOfDiamonds.Value);
            Assert.AreEqual(tenOfDiamonds.Value, 10);

            Card kingOfHearts = new Card(1, 13);
            Console.WriteLine(kingOfHearts.ToString());
            Console.WriteLine("Value of card = {0}", kingOfHearts.Value);
            Assert.AreEqual(kingOfHearts.Value, 10);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Card jackOfClubs = new Card(3, 11);
            Assert.AreEqual(jackOfClubs.ToString(), "Jack of Clubs");
        }
    }
}
