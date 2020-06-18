using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_obsługi_kart_PO_v0_1
{
    class Card
    {
        static public List<long> CardsList = new List<long>();
        public string cardType;
        public string bank_name;
        public string owner;
        public long cardNumber;
        
        public string Get_bankName()
        {
            return bank_name;
        }
        public string Get_cardType()
        {
            return cardType;
        }
        //funkcja generujaca 16cyfrowy numer karty
        public long Create_cardNumber()
        {
            Random rng = new Random();
        RLoop:
            for (int i = 0; i < 4; i++)
            {
                if (i == 0) cardNumber = rng.Next(1000, 9999);
                else cardNumber = (cardNumber * 10000) + rng.Next(1000, 9999);
            }
            if (CardsList.Find(x => x == cardNumber) == cardNumber) goto RLoop;
            else
            {
                CardsList.Add(cardNumber);
                return cardNumber;
            }
        }
        public long getCardNumber()
        {
            return cardNumber;
        }
    }
}

