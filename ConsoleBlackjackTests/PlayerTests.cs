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
    public class PlayerTests
    {
        [TestMethod()]
        public void PlayerConstructorTest()
        {
            var playerWithoutChips = new Player();
            Assert.AreEqual(0, playerWithoutChips.GetChips());
            var playerWithChips = new Player(1000);
            Assert.AreEqual(1000, playerWithChips.GetChips());
        }

        [TestMethod()]
        public void AddChipsTest()
        {
            var player = new Player(1000);
            player.AddChips(1000);
            Assert.AreEqual(2000, player.GetChips());
        }

        [TestMethod()]
        public void RemoveChipsTest()
        {
            var player = new Player(1000);
            player.RemoveChips(500);
            Assert.AreEqual(500, player.GetChips());
        }

        [TestMethod()]
        public void ReceiveCardTest()
        {
            var player = new Player();
            var card = new Card(0, 5);
            player.ReceiveCard(card);
            // Using the indexer I wrote for Hand
            Assert.AreEqual(card, player.GetHand()[0]);
        }

        [TestMethod()]
        public void GetHandValueTest()
        {
            var player = new Player();
            var card = new Card(0, 5);
            player.ReceiveCard(card);
            Assert.AreEqual(5, player.GetHandValue());
        }
    }
}
