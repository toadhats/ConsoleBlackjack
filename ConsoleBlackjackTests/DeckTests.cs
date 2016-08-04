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
    public class DeckTests
    {
        [TestMethod()]
        public void DeckConstructorTest()
        {
            var testDeck = new Deck();
            Assert.AreEqual(testDeck.CountRemainingCards(), 52);
        }

        [TestMethod()]
        public void DrawCardTest()
        {
            var testDeck = new Deck();
            for (var i = 0; i < 52; i++)
            {
                Assert.AreEqual(testDeck.CountRemainingCards(), 52 - i);
                var card = testDeck.DrawCard();
                Console.WriteLine(card.ToString());
            }
        }

        // This test is totally redundant. I know HOW to write unit tests, but not when (or when not
        // to) lol
        [TestMethod()]
        public void CountRemainingCardsTest()
        {
            var testDeck = new Deck();
            Assert.AreEqual(testDeck.CountRemainingCards(), 52);
        }

        [TestMethod()]
        public void CreateCardsTest()
        {
            List<Card> testCards = Deck.CreateCards();
            Assert.AreEqual(testCards.Count, 52);
            foreach (var card in testCards)
            {
                Console.WriteLine(card.ToString());
            }
        }

        // I could try and show statistically that the shuffling is sufficiently random, but that
        // seems like overkill for a little blackjack exercise - lets just ensure the function is
        // robust and set it up so I can eyeball it.
        [TestMethod()]
        public void ShuffleCardsTest()
        {
            List<Card> testCards = Deck.CreateCards();
            // We can't compare to this to check shuffling because shuffling is destructive, need to
            // make a copy

            // 100 test shuffles
            for (var i = 0; i < 100; ++i)
            {
                Console.WriteLine("\n*** ROUND {0} ***\n", i);
                var previous = new List<Card>(testCards); // Must CLONE the list, otherwise it's just a reference, also we're going to empty and reuse it
                Stack<Card> shuffledCards = Deck.ShuffleCards(testCards);
                Assert.AreEqual(shuffledCards.Count, 52); // Make sure we haven't lost any cards...
                int index = 0;
                while (shuffledCards.Count > 0)
                {
                    var card = shuffledCards.Pop();
                    Console.WriteLine(card.ToString());
                    if (card.Equals(previous.ElementAt(index)))
                    {
                        Console.WriteLine("-- {0} did not move after shuffling --", card.ToString());
                    }
                    testCards.Add(card); // Putting the card into a new pack to reshuffle next time.
                    index++;
                }
            }
        }
    }
}
