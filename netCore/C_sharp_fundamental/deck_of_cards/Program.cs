using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player one = new Player();
            Player two = new Player();
            deck.Shuffle();
            one.Draw(deck);
            two.Draw(deck);
            one.Draw(deck);
            two.Draw(deck);
            one.Draw(deck);
            two.Draw(deck);
            one.Discard(1);
            two.Discard(5);

        }
    }
}
