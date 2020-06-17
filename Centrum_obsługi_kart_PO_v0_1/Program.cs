using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_obsługi_kart_PO_v0_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("1 - dodaj firme");
                Console.WriteLine("2 - usuń firme");
                Console.WriteLine("3 - przeglądaj firmy");
                Console.WriteLine("4 - dodaj bank");
                Console.WriteLine("5 - usuń bank");
                Console.WriteLine("6 - przeglądaj banki");
                Console.WriteLine("7 - dodaj klienta do banku");
                Console.WriteLine("8 - usuń klienta z banku");
                Console.WriteLine("9 - przeglądaj klientow banku");
                Console.WriteLine("x - manualne dodawanie transakcji");


                Console.WriteLine("0 - exit");
                choice = Convert.ToByte(Console.ReadLine());

                string name;
                string bank_name;
                string firm_type0;
                string nazwa_banku1;
                string nazwa_klienta1;
                

                if (choice == 1 || choice == 2)
                {
                    Console.WriteLine("Enter firm name");
                    name = Console.ReadLine();
                    Console.WriteLine("Enter firm type store/service/shipment");
                    firm_type0 = Console.ReadLine();
                    if(firm_type0 =="store")
                    {
                        Firma_store p = new Firma_store();
                        p.Input_info(name, firm_type0);
                        if(choice == 1)
                        {
                            Firm_list.Add_firm_store(p);
                        }  
                        else if (choice == 2)
                        {
                            Firm_list.Delete_firm_store(p);
                        }
                    }
                    else if(firm_type0 == "service")
                    {
                        Firma_service p = new Firma_service();

                        p.Input_info(name, firm_type0);
                        if (choice == 1)
                        {
                            Firm_list.Add_firm_service(p);
                        }  
                        else if(choice == 2)
                        {
                            Firm_list.Delete_firm_service(p);
                        }
                    }
                    else if(firm_type0 == "shipment")
                    {
                        Firma_shipment p = new Firma_shipment();
                        p.Input_info(name, firm_type0);
                        if (choice == 1)
                        {
                            Firm_list.Add_firm_shipment(p);
                        }   
                        else if(choice == 2)
                        {
                            Firm_list.Delete_firm_shipment(p);
                        }
                    }

                    /*if (choice == 1)
                    {
                        Firm_list.Add_firm(p);
                        if (firm_type0 == "store")
                        {
                            Firm_list.Add_firm_store(p);
                        }
                        else if (firm_type0 == "service")
                        {
                            Firm_list.Add_firm_service(p);
                        }
                        else if (firm_type0 == "shipment")
                        {

                        }
                    }*/
                    /*if(choice == 2)
                    {        
                        Firm_list.Delete_firm(p);
                    }*/
                    Console.Clear();
                }   
                else if (choice == 3)
                {
                    Firm_list.Display_firm_list();
                }
                else if(choice == 4 || choice ==5)
                {
                    Console.WriteLine("Enter bank name");
                    bank_name = Console.ReadLine();
                    Bank p = new Bank(bank_name);  
                    if (choice == 4)
                    {
                        Bank_list.Add_bank(p);
                    }
                    else if (choice == 5)
                    {
                        Bank_list.Delete_bank(p);
                    }
                    Console.Clear();
                }
                else if(choice == 6)
                {
                    Bank_list.Display_bank_list();
                }
                else if(choice == 7)
                {
                    Console.WriteLine("Podaj nazwe banku");
                    Console.WriteLine("Podaj imie/nazwisko klienta banku");
                    
                    
                    nazwa_banku1=Console.ReadLine();
                    nazwa_klienta1=Console.ReadLine();
                    Klient p = new Klient(nazwa_klienta1);
                    Bank p0 = new Bank(nazwa_banku1);
                    foreach(Bank p1 in Bank_list.banki)
                    {
                        if(p1.bank_name==p0.bank_name)
                        {
                            //Bank_list.Add_klient_to_bank(p, p0); 
                            p1.klienci.Add(p);
                        }
                    }
                    
                }
                else if(choice == 8)
                {
                    Console.WriteLine("podaj nazwe banku");
                    Console.WriteLine("podaj nazwe klienta");
                    nazwa_banku1 = Console.ReadLine();
                    nazwa_klienta1 = Console.ReadLine();
                    Klient p = new Klient(nazwa_klienta1);
                    foreach(Bank p1 in Bank_list.banki)
                    {
                        if(p1.bank_name==nazwa_banku1)
                        {     
                            
                            Bank_list.Remove_klient_form_bank(p, p1);
                        }
                    }
                    
                }
                else if(choice == 9)
                {
                    Console.WriteLine("podaj nazwe banku");
                    nazwa_banku1 = Console.ReadLine();
                    Bank p0 = new Bank(nazwa_banku1);
                    foreach (Bank p1 in Bank_list.banki)
                    {
                        if (p1.bank_name == p0.bank_name)
                        {
                            Console.WriteLine("siema");
                            p1.View_all_klients(p1);
                        }
                    }

                }
                else if(choice == 100)
                {
                    Console.WriteLine("");

                }
                else
                {
                    Console.WriteLine("wrong input");
                }
                

            } while (choice != 0);
        }

       
    }
}
