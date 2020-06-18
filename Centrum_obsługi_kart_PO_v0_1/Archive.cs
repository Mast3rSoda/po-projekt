using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_obsługi_kart_PO_v0_1
{
    class Archive
    {
        private const string File_Name = "archiwum_transakcji.txt";
        public static string transakcja_tekst;
        static public void Save_to_archive(Card karta, string data, double kwota, string card_owner, string card_type, bool resault)
        {
            transakcja_tekst = data+" "+karta.cardNumber+" "+kwota+" "+card_type+" "+card_owner+" "+karta.bank_name+" "+resault;
            System.IO.File.WriteAllText("archiwum_transakcji.txt", transakcja_tekst);
            Console.WriteLine("DATA - "+data + " Numer Karty - " + karta.cardNumber + " Kwota - " + kwota + " Typ karty - " + card_type + " Właściciel karty - " + card_owner + " Nazwa Banku - " + karta.bank_name + " Rezultat - " + resault);
        }
    }
}
