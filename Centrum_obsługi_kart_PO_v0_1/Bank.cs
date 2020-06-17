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
        //private static int bank_id_helper;
        //private static int bank_counter = 0;
        public List<Klient> klienci;

        public Bank(string bank_name)
        {
            this.bank_name = bank_name;
            klienci = new List<Klient>();
        }
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
        public void Remove_klient(Klient p,Bank p3)
        {
            foreach(Klient p1 in p3.klienci)
            { 
                if (p1.imie==p.imie)
                {
                    klienci.Remove(p);
                    Console.WriteLine("usunięto " + p.imie);
                }
            }
        }
        public void View_all_klients(Bank p1)
        {
            foreach(Klient p in p1.klienci)
            {
                Console.WriteLine(p.imie);
            }
        }
        public void Input_info(string nazwa)
        {
            bank_name = nazwa;
            bank_id = Bank_list.banki.Count;
        }
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
        static public bool Authorize_transaction(Card karta, string data, double kwota, string card_owner, int card_type)
        {
            if(card_type==1||card_type==2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}
