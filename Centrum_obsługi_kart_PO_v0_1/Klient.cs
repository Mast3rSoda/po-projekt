using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_obsługi_kart_PO_v0_1
{
    class Klient
    {
        public string imie;
        private List<Card> kolekcja_kart;

        public Klient(string imie)
        {
            this.imie = imie;
            kolekcja_kart = new List<Card>();
        }

        public void addCardToCollection(Card card)
        {
            kolekcja_kart.Add(card);
        }

        public void removeFromCollection(Card card)
        {
            foreach (Card card1 in kolekcja_kart)
            {
                if (card1.getCardNumber() == card.getCardNumber())
                {
                    kolekcja_kart.Remove(card1);
                    break;
                }
            }
        }
        public string Get_name()
        {
            return imie;
        }
    }
}
