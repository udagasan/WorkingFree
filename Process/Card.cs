using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process
{
    /// <summary>
    /// Card
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Suites
        /// </summary>
        public enum Suites
        {
            /// <summary>
            /// The diamonds
            /// </summary>
            Diamonds,
            /// <summary>
            /// The clubs
            /// </summary>
            Clubs,
            /// <summary>
            /// The hearts
            /// </summary>
            Hearts,
            /// <summary>
            /// The spades
            /// </summary>
            Spades
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value
        {
            get;
            set;
        }

    
        public Suites Suite
        {
            get;
            set;
        }

        public string NamedValue
        {
            get
            {
                string name = string.Empty;
                switch (Value)
                {
                    case (14):
                        name = "Ace";
                        break;
                    case (13):
                        name = "King";
                        break;
                    case (12):
                        name = "Queen";
                        break;
                    case (11):
                        name = "Jack";
                        break;
                    default:
                        name = Value.ToString();
                        break;
                }

                return name;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return NamedValue + " of  " + Suite.ToString();
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="Value">The value.</param>
        /// <param name="Suite">The suite.</param>
        public Card(int Value, Suites Suite)
        {
            this.Value = Value;
            this.Suite = Suite;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class Deck
    {
        /// <summary>
        /// The cards
        /// </summary>
        public List<Card> Cards = new List<Card>();
        /// <summary>
        /// Fills the deck.
        /// </summary>
        public void FillDeck()
        {

            for (int i = 0; i < 52; i++)
            {
                Card.Suites suite = (Card.Suites)(Math.Floor((decimal)i / 13));
                int val = i % 13 + 2;
                Cards.Add(new Card(val, suite));
            }
        }

        /// <summary>
        /// Prints the deck.
        /// </summary>
        public void PrintDeck()
        {
            foreach (Card card in this.Cards)
            {
                Console.WriteLine(card.Name);
            }
        }
    }
}
