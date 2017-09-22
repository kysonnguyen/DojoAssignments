using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    public class Card
    {
        public string stringVal;
        public string suit;
        public int val;

        public Card(string in1, string in2, int in3)
        {
            stringVal = in1;
            suit = in2;
            val = in3;
        }
    }

    public class Deck
    {
        public List<Card> cards = new List<Card>();
        public List<Card> full_cards = new List<Card>();
        string[] card_val = new string[] {"Ace", "2", "3", "4","5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};
        string[] card_suit = new string[] {"Clubs", "Spades", "Hearts", "Diamonds"};
        int[] card_num = new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13};
        public Deck(){
            for(int i=0; i<13; i++){
                for(int k=0; k<4; k++){
                    Card card = new Card(card_val[i], card_suit[k], card_num[i]);   
                    cards.Add(card);
                    full_cards.Add(card);
                }
            }
        }

        public Card Deal()
        {
            Card top_card = cards[0];
            cards.RemoveAt(0);
            return top_card;
        }

        public List<Card> Reset()
        {
            cards.Clear();
            cards.AddRange(full_cards);
            return cards;
        }

        public List<Card> Shuffle()
        {
            Random rand = new Random();
            for(int i = 0; i < 200; i++){
                int idx1 = rand.Next(52);
                int idx2 = rand.Next(52);
                Card temp = cards[idx1];
                cards[idx1] = cards[idx2];
                cards[idx2] = temp; 
            }
            // for(int k=0; k<52; k++){
            //     Console.WriteLine(cards[k].stringVal);
            // }

            return cards;
        } 
    }

    public class Player
    {
        public string name;
        public List<Card> hand = new List<Card>();
        public List<Card> Draw(Deck deck)
        {
            Card new_card = deck.Deal();
            hand.Add(new_card);
            Console.WriteLine("Drew: {0} of {1} --- Total in hand: {2}", new_card.stringVal, new_card.suit, hand.Count);
            return hand;
        }
        public Card Discard(int index)
        {   
            int count = hand.Count;
            if(index<count)
            {
                Card discarded = hand[index];
                hand.RemoveAt(index);
            Console.WriteLine("Discarded: {0} of {1} --- Total in hand: {2}", discarded.stringVal, discarded.suit, hand.Count);
                return discarded;
            }
            else
            {
                Console.WriteLine("Please input a real hand position");
                return null;
            } 
        }
    }
}     