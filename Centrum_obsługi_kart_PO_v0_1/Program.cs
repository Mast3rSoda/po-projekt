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
            int choice = 1;
            do
            {
                Console.WriteLine("1 - dodaj firme");
                Console.WriteLine("2 - usuń firme");
                Console.WriteLine("3 - przeglądaj firmy");
                Console.WriteLine("4 - dodaj bank");
                Console.WriteLine("5 - usuń bank");
                Console.WriteLine("6 - przeglądaj banki");

                Console.WriteLine("0 - exit");
                choice = Convert.ToByte(Console.ReadLine());

                string name;
                string bank_name;
                string firm_type0;
               
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
                }   
                else if (choice == 3)
                {
                    Firm_list.Display_firm_list();
                }
                else if(choice == 4 || choice ==5)
                {
                    Console.WriteLine("Enter bank name");
                    bank_name = Console.ReadLine();
                    Bank p = new Bank();
                    p.Input_info(bank_name);
                    if (choice == 4)
                    {
                        Bank_list.Add_bank(p);
                    }
                    else if (choice == 5)
                    {
                        Bank_list.Delete_bank(p);
                    }
                }
                else if(choice == 6)
                {
                    Bank_list.Display_bank_list();
                }
                else
                {
                    Console.WriteLine("wrong input");
                }

            } while (choice != 0);
        }

       
    }
}
