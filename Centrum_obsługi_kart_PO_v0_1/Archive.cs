using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Centrum_obsługi_kart_PO_v0_1
{
    class Archive
    {
        
        public static string transakcja_tekst;
        public string Line;
        public string [] Lines;
        public string tekst;
        string szukane_warunki;
        int counter = 0;

        //zmienne przechowujące dane z archiwum
        string data;
        string numer_karty;
        string kwota_tran;
        string card_owner;
        string card_type;
        string bank_name;
        string resault;
        string wpisywany_tekst;
        string warunek;

        //zmienne przechowujące warunki wpisane przez uzytkownika
        string bank_x;
        string numer_karty_x;
        string owner_x;
        string kwota_x;
        string data_x;
        int counter_x = 0;

        //funkcja zapisujące do Archiwum
        static public void Save_to_archive(Card karta, string data, double kwota, string card_owner, string card_type, bool resault)
        {
            transakcja_tekst = data+" "+karta.cardNumber+" "+kwota+" "+card_type+" "+card_owner+" "+karta.bank_name+" "+resault;
            File.AppendAllText("archiwum_transakcji.txt", transakcja_tekst +"\r\n");
            Console.WriteLine("DATA - "+data + " Numer Karty - " + karta.cardNumber + " Kwota - " + kwota + " Typ karty - " + card_type + " Właściciel karty - " + card_owner + " Nazwa Banku - " + karta.bank_name + " Rezultat - " + resault);
        }
        //funkcja przeszukująca archiwum
        public void Search_archive_base()
        {
            Lines = File.ReadAllLines("archiwum_transakcji.txt");
            Console.WriteLine("Przeszukiwanie OR/AND");
            //wpisanie warunku OR/AND
            warunek = Console.ReadLine();
            //wpisanie walorów które chcemy filtrować
            Console.WriteLine("Wpisz szukane walory w formacie BANK NUMERKARTY WŁAŚCICIEL KWOTA DATA jeżeli nie ma warunku wstaw null");
            wpisywany_tekst = Console.ReadLine();
            Split_sentence_into_words(wpisywany_tekst);
            foreach (string line in Lines)
            {
                //countery do dobrego przepisania zmiennych ze stringów
                counter_x = 0;
                counter = 0; 
                Split_into_words(line);
                Split_sentence_into_words(wpisywany_tekst);
                //warunek or
                if (warunek=="OR")
                {
                    if (bank_x==bank_name||numer_karty_x==numer_karty||owner_x==card_owner||kwota_x==kwota_tran||data_x==data)
                    {
                        Console.WriteLine(line);
                    }
                }
                //warunek and
                else if(warunek=="AND")
                { 
                    if (bank_x == bank_name && numer_karty_x == numer_karty && owner_x == card_owner && kwota_x == kwota_tran && data_x == data)
                    {
                        Console.WriteLine(line);
                    }
                }
            }

        }
        //funkcja do wyodrebnienie slow z warunku
        public void Split_sentence_into_words(string sentence)
        {
            string[] words = sentence.Split(' ');
            foreach(var word in words)
            {
                if (counter_x == 0)
                {
                    if(word!="null")
                    {
                        bank_x = word;
                        counter_x++;
                    } 
                    else
                    {
                        bank_x = "null";
                        counter_x++;
                        if(warunek=="AND")
                        { 
                            bank_name = bank_x;
                        }
                    }
                }
                else if (counter_x == 1)
                {
                    if (word != "null")
                    {
                        numer_karty_x = word;
                        counter_x++;
                    }
                    else
                    {
                        numer_karty_x = "null";
                        counter_x++;
                        if (warunek == "AND")
                        {
                            numer_karty = numer_karty_x;
                        }
                    }
                }
                else if (counter_x == 2)
                {
                    if (word != "null")
                    {
                        owner_x = word;
                        counter_x++;
                    }
                    else
                    {
                        owner_x = "null";
                        counter_x++;
                        if (warunek == "AND")
                        {
                            card_owner = owner_x;
                        }
                    }
                }
                else if (counter_x == 3)
                {
                    if (word != "null")
                    {
                        kwota_x = word;
                        counter_x++;
                    }
                    else
                    {
                        kwota_x = "null";
                        counter_x++;
                        if (warunek == "AND")
                        {
                            kwota_tran = kwota_x;
                        } 
                    }
                }
                else if (counter_x == 4)
                {
                    if (word != "null")
                    {
                        data_x = word;
                        counter_x++;
                    }
                    else
                    {
                        data_x = "null";
                        counter_x++;
                        if (warunek == "AND")
                        {
                            data = data_x;
                        } 
                    }
                }
            }
        }
        //funkcja do wyodrebnienia
        private void Split_into_words(string line)
        {
            string[] words = line.Split(' ');

            foreach (var word in words)
            {
                if (counter == 0)
                {
                    data = word;
                    counter++;
                }
                else if (counter == 1)
                {
                    numer_karty = word;
                    counter++;
                }
                else if (counter == 2)
                {
                    kwota_tran = word;
                    counter++;
                }
                else if (counter == 3)
                {
                    card_type = word;
                    counter++;
                }
                else if (counter == 4)
                {
                    card_owner = word;
                    counter++;
                }
                else if (counter == 5)
                {
                    bank_name = word;
                    counter++;
                }
                else if (counter == 6)
                {
                    resault = word;
                    counter++;
                }
            }
        }


    }

}
