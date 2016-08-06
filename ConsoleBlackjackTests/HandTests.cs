using ConsoleBlackjack;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack.Tests
{
    [TestClass()]
    public class HandTests
    {
        [TestMethod()]
        public void HandConstructorTest()
        {
            Hand testHand = new Hand();
            Assert.AreEqual(testHand.Value, 0);
        }

        [TestMethod]
        public void AddCardToHandTest()
        {
            Hand testHand = new Hand();
            Card testCard = new Card(0, 10); // Ten of Spades
            testHand.AddCardToHand(testCard);
            Assert.AreEqual(10, testHand.Value);
        }

        [TestMethod]
        public void HandValueTest()
        {
            Hand testHand = new Hand();
            Card tenOfSpades = new Card(0, 10);
            testHand.AddCardToHand(tenOfSpades);
            Card threeOfClubs = new Card(3, 3);
            testHand.AddCardToHand(threeOfClubs);
            Card sevenOfDiamonds = new Card(2, 7);
            testHand.AddCardToHand(sevenOfDiamonds);
            Assert.AreEqual(20, testHand.Value);
        }

        [TestMethod]
        public void CardsInHandTest()
        {
            Hand testHand = new Hand();
            Card tenOfSpades = new Card(0, 10);
            testHand.AddCardToHand(tenOfSpades);
            Card threeOfClubs = new Card(3, 3);
            testHand.AddCardToHand(threeOfClubs);
            Card sevenOfDiamonds = new Card(2, 7);
            testHand.AddCardToHand(sevenOfDiamonds);
            Assert.AreEqual(tenOfSpades, testHand[0]);
            Assert.AreEqual(threeOfClubs, testHand[1]);
            Assert.AreEqual(sevenOfDiamonds, testHand[2]);
            // Testing IEnumerable implementation
            foreach (Card c in testHand)
            {
                Console.WriteLine(c.ToString());
            }
        }

        // Check the ace high logic required to get blackjack
        [TestMethod]
        public void BlackjackTest()
        {
            Hand testHand = new Hand();
            Card aceOfSpades = new Card(0, 1);
            testHand.AddCardToHand(aceOfSpades);
            Card kingOfSpades = new Card(0, 13);
            testHand.AddCardToHand(kingOfSpades);
            Assert.AreEqual(21, testHand.Value);
        }
    }
}
