using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_obsługi_kart_PO_v0_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //resetujemy plik archiwum_transakcji.txt
            File.WriteAllText("archiwum_transakcji.txt", "");
            int choice;
            do
            {
                //menu - wybor
                Console.WriteLine("1 - dodaj firme");
                Console.WriteLine("2 - usuń firme");
                Console.WriteLine("3 - przeglądaj firmy");
                Console.WriteLine("4 - dodaj bank");
                Console.WriteLine("5 - usuń bank");
                Console.WriteLine("6 - przeglądaj banki");
                Console.WriteLine("7 - dodaj klienta do banku");
                Console.WriteLine("8 - usuń klienta z banku");
                Console.WriteLine("9 - przeglądaj klientow banku");
                Console.WriteLine("10 - dodaj karte do klienta");
                Console.WriteLine("11 - przegladaj karty klienta");
                Console.WriteLine("12 - manualne dodawanie transakcji");
                Console.WriteLine("13 - przeszukaj baze danych");
                Console.WriteLine("0 - exit");
                choice = Convert.ToByte(Console.ReadLine());
                //zmienne
                string firm_name;
                string bank_name;
                string firm_type0;
                string nazwa_banku1;
                string nazwa_klienta1;
                string nazwa_firmy1;
                string typ_firmy; 
                double kwota_transakcji;
                //dodaj/usun firme
                if (choice == 1 || choice == 2)
                {
                    Console.WriteLine("Enter firm name");
                    firm_name = Console.ReadLine();
                    Console.WriteLine("Enter firm type store/service/shipment");
                    firm_type0 = Console.ReadLine();
                    //dodaj/usun firme-sklep
                    if (firm_type0 == "store")
                    {
                        Firma_store p = new Firma_store(firm_name, firm_type0);
                        if (choice == 1)
                        {
                            Firm_list.Add_firm_store(p);
                        }
                        else if (choice == 2)
                            Firm_list.Delete_firm_store(p);
                    }
                    //dodaj/usun firme-serwis
                    else if (firm_type0 == "service")
                    {
                        Firma_service p = new Firma_service(firm_name, firm_type0); 
                        if (choice == 1)
                        {
                            Firm_list.Add_firm_service(p);
                        }
                        else if (choice == 2)
                        {
                            Firm_list.Delete_firm_service(p);
                        }
                    }
                    //dodaj/usun firme-transportowa
                    else if (firm_type0 == "shipment")
                    {
                        Firma_shipment p = new Firma_shipment(firm_name, firm_type0);
                        if (choice == 1)
                        {
                            Firm_list.Add_firm_shipment(p);
                        }
                        else if (choice == 2)
                        {
                            Firm_list.Delete_firm_shipment(p);
                        }
                    }
                    Console.Clear();
                }
                //wyswietl liste firm
                else if (choice == 3)
                {
                    Firm_list.Display_firm_list();
                }
                //dodaj/usun bank
                else if (choice == 4 || choice == 5)
                {
                    Console.WriteLine("Enter bank name");
                    bank_name = Console.ReadLine();
                    Bank p = new Bank(bank_name);
                    //dodaj bank
                    if (choice == 4)
                    {
                        Bank_list.Add_bank(p);
                    }
                    //usun bank
                    else if (choice == 5)
                    {
                        Bank_list.Delete_bank(p);
                    }
                    Console.Clear();
                }
                //wyswietl liste bankow
                else if (choice == 6)
                {
                    Bank_list.Display_bank_list();
                }
                //dodaj klienta do banku
                else if (choice == 7)
                {
                    Console.WriteLine("Podaj nazwe banku");
                    Console.WriteLine("Podaj nazwisko klienta banku");
                    nazwa_banku1 = Console.ReadLine();
                    nazwa_klienta1 = Console.ReadLine();
                    Klient p = new Klient(nazwa_klienta1);
                    Bank p0 = new Bank(nazwa_banku1);
                    foreach (Bank p1 in Bank_list.banki)
                    {
                        if (p1.bank_name == p0.bank_name)
                        {
                            p1.klienci.Add(p);
                        }
                    }
                    Console.Clear();
                }
                //usun klienta z banku
                else if (choice == 8)
                {
                    Console.WriteLine("podaj nazwe banku");
                    Console.WriteLine("podaj nazwe klienta");
                    nazwa_banku1 = Console.ReadLine();
                    nazwa_klienta1 = Console.ReadLine();
                    Klient p = new Klient(nazwa_klienta1);
                    Bank p0 = new Bank(nazwa_banku1);
                    foreach (Bank p1 in Bank_list.banki)
                    {
                        if (p1.bank_name == p0.bank_name)
                        {
                            p1.Remove_klient_form_bank(p, p1);
                        }
                    }
                    Console.Clear();
                }
                //wypisz liste klientow banku
                else if (choice == 9)
                {
                    Console.WriteLine("podaj nazwe banku");
                    nazwa_banku1 = Console.ReadLine();
                    Bank p0 = new Bank(nazwa_banku1);
                    Console.Clear();
                    foreach (Bank p1 in Bank_list.banki)
                    {
                        if (p1.bank_name == p0.bank_name)
                        {
                            p1.View_all_klients(p1);
                        }
                    }
                }
                //dodaj karte do klienta banku
                else if (choice == 10)
                {
                    string typKarty;
                    Console.WriteLine("podaj nazwe banku");
                    Console.WriteLine("podaj nazwe klienta");
                    Console.WriteLine("podaj typ karty (atm, deb, cred)");
                    nazwa_banku1 = Console.ReadLine();
                    nazwa_klienta1 = Console.ReadLine();
                    typKarty = Console.ReadLine();
                    Klient p = new Klient(nazwa_klienta1);
                    Bank p0 = new Bank(nazwa_banku1);
                    Console.Clear();
                    foreach (Bank p1 in Bank_list.banki)
                    {
                        if (p1.bank_name == p0.bank_name)
                        {
                            p1.findClient(p, p1, typKarty);
                        }
                    }
                }
                //wypisywanie kart
                else if (choice == 11)
                {
                    Console.WriteLine("podaj nazwe banku");
                    Console.WriteLine("podaj nazwe klienta");
                    nazwa_banku1 = Console.ReadLine();
                    nazwa_klienta1 = Console.ReadLine();
                    Klient p = new Klient(nazwa_klienta1);
                    Bank p0 = new Bank(nazwa_banku1);
                    Console.Clear();
                    foreach (Bank p1 in Bank_list.banki)
                    {
                        if (p1.bank_name == p0.bank_name)
                        {
                            p1.checkCards(p, p1);
                        }
                    }

                }
                //wykonanie transakcji
                else if (choice == 12)
                {
                    Console.WriteLine("podaj nazwe firmy");
                    Console.WriteLine("podaj typ firmy");
                    Console.WriteLine("podaj numer karty");
                    Console.WriteLine("podaj kwote");
                    long numer_karty;
                    nazwa_firmy1 = Console.ReadLine();
                    typ_firmy = Console.ReadLine();
                    numer_karty = Convert.ToInt64(Console.ReadLine());
                    kwota_transakcji = Convert.ToDouble(Console.ReadLine());
                    Firma p = new Firma(nazwa_firmy1, typ_firmy);
                    Card karta_y1 = new Card();
                    foreach (Bank bank_x1 in Bank_list.banki)
                    {                   
                        foreach (Klient klient_x1 in bank_x1.klienci)
                        {
                            foreach (Card karta_x1 in klient_x1.kolekcja_kart)
                            {
                                if (karta_x1.cardNumber == numer_karty)
                                {
                                    karta_y1.bank_name = karta_x1.bank_name;
                                    karta_y1.cardNumber = karta_x1.cardNumber;
                                    karta_y1.cardType = karta_x1.cardType;
                                    karta_y1.owner = karta_x1.owner;
                                    break;
                                }
                            }
                        }
                    }
                    //wysyla zadanie autoryzacji dla firmy-sklepu
                    if (typ_firmy == "store")
                    {
                        foreach (Firma_store firma_sklep in Firm_list.firmy_stores)
                        {
                            if (firma_sklep.firm_name == p.firm_name)
                            {
                                firma_sklep.Require_authorization(karta_y1, kwota_transakcji);
                            }
                        }
                    }
                    //wysyla zadanie autoryzacji dla firmy-serwisu
                    else if (typ_firmy == "service")
                    {
                        foreach (Firma_service firma_service in Firm_list.firmy_services)
                        {
                            if (firma_service.firm_name == p.firm_name)
                            {
                                firma_service.Require_authorization(karta_y1, kwota_transakcji);
                            }
                        }

                    }
                    //wysyla zadanie autoryzacji dla firmy-transportowej
                    else if (typ_firmy == "shipment")
                    {
                        foreach (Firma_shipment firma_shipment in Firm_list.firmy_shipment)
                        {
                            if (firma_shipment.firm_name == p.firm_name)
                            {
                                firma_shipment.Require_authorization(karta_y1, kwota_transakcji);
                            }
                        }
                    }
                }
                //przeszukiwanie archiwum
                else if (choice == 13)
                {
                    Archive p = new Archive();
                    p.Search_archive_base();
                }
                else
                {
                    Console.WriteLine("wrong input");
                }
            } while (choice != 0);
        }   
    }
}
