using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_obsługi_kart_PO_v0_1
{
    class Bank
    {
        public string bank_name;
        private int bank_id = 0;
        public List<Klient> klienci;
        //konstruktor klasy bank
        public Bank(string bank_name)
        {
            this.bank_name = bank_name;
            klienci = new List<Klient>();
        }
        //funkcja dodajaca klianta p do banku p0
        public void Add_klient(Klient p,Bank p0)
        {
            foreach (Bank p1 in Bank_list.banki)
            {
                if(p1.bank_name==p0.bank_name)
                {
                    klienci.Add(p);
                }
            }
        }
        //funkcja usuwajace klienta x z banku p1
        public void Remove_klient_form_bank(Klient x, Bank p1)
        {
            foreach (Klient p in p1.klienci)
            {
                if(p.imie==x.imie)
                {
                    p1.klienci.Remove(p);
                    break;
                }
            }
        }
        //funkcja wyswietlajace imiona klientow banku p1
        public void View_all_klients(Bank p1)
        {
            foreach(Klient p in p1.klienci)
            {
                Console.WriteLine(p.imie);
            }
        }
        //funkcja do przypisania wartosci banku
        public void Input_info(string nazwa)
        {
            bank_name = nazwa;
            bank_id = Bank_list.banki.Count;
        }
        //funkcja wyswietlajaca dane banku
        public void Display_Info()
        {
            Console.WriteLine($"Bank name : {bank_name}");
            Console.WriteLine($"Bank id : {bank_id}");
        }
        public string Get_name()
        {
            return bank_name;
        }
        public int Get_id()
        {
            return bank_id;
        }
        //funkcja autoryzujaca transakcje na podstawie typu karty
        static public bool Authorize_transaction(Card karta, string data, double kwota, string card_owner, string card_type)
        {
            if(card_type=="deb"||card_type=="cred")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //funkcja dodajace karta card to klienta p
        public void findClient(Klient p2, Bank p1, string typKarty)
        {
            foreach(Klient p in p1.klienci)
                if(p.imie == p2.imie)
                {
                    Card card = new Card();
                    p.dodajKarte(card,p.imie,p1.bank_name, typKarty);
                }
        }
        //funkcja wyswietlajaca karty klienta p2 ktory jest klientem banku p1
        public void checkCards(Klient p2, Bank p1)
        {
            foreach(Klient p in p1.klienci)
                if(p.imie == p2.imie)
                {
                    Card card = new Card();
                    p.przegladajKarty(card);
                }
        }
    }

}
