using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Centrum_obsługi_kart_PO_v0_1
{
    class Archive
    {
        
        public static string transakcja_tekst;

        static public void Save_to_archive(Card karta, string data, double kwota, string card_owner, string card_type, bool resault)
        {
            transakcja_tekst = data+" "+karta.cardNumber+" "+kwota+" "+card_type+" "+card_owner+" "+karta.bank_name+" "+resault;
            File.AppendAllText("archiwum_transakcji.txt", transakcja_tekst + "\n");
            Console.WriteLine("DATA - "+data + " Numer Karty - " + karta.cardNumber + " Kwota - " + kwota + " Typ karty - " + card_type + " Właściciel karty - " + card_owner + " Nazwa Banku - " + karta.bank_name + " Rezultat - " + resault);
        }
        public void search_archive()
        {


        }
    }
}
