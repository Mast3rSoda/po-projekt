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
        public List<Card> kolekcja_kart;
        //konstruktor klasy klient
        public Klient(string imie)
        {
            this.imie = imie;
            kolekcja_kart = new List<Card>();
        }
        //funkcja dodająca karta card to kolekcji karta klienta
        public void addCardToCollection(Card card)
        {
            kolekcja_kart.Add(card);
        }
        //funkcja usuwająca karta card z kolekcji kart klienta
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
        //funkcja dodająca karta p3 do klienta na podstawie imienia banku i typu karty
        public void dodajKarte(Card p3,string imie, string bank, string typKarty)
        {
            p3.bank_name = bank;
            p3.cardNumber = p3.Create_cardNumber();
            p3.owner = imie;
            p3.cardType = typKarty;
            Console.WriteLine(p3.bank_name);
            Console.WriteLine(p3.owner);
            Console.WriteLine(p3.cardNumber);
            Console.WriteLine(p3.cardType);
            addCardToCollection(p3);
        }
        //funkcja wyświetlająca karty w kolekcji klienta
        public void przegladajKarty(Card p3)
        {
            foreach(Card card in kolekcja_kart)
            {
                Console.WriteLine(card.bank_name);
                Console.WriteLine(card.owner);
                Console.WriteLine(card.cardNumber);
                Console.WriteLine(card.cardType);
            }
        }
    }
}
