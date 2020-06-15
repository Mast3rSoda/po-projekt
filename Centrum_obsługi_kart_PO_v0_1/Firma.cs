using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_obsługi_kart_PO_v0_1
{
    class Firma
    {
        public string firm_name; 
        public string firm_type;

        static private List<Klient> klienci_firm;

        public void Input_info(string nazwa,string typ)
        {
            firm_name = nazwa;
            firm_type = typ;
        }
        public virtual void Display_Info()
        {
            Console.WriteLine($"Firm name : {firm_name}");
            Console.WriteLine($"Firm type : {firm_type}");
        }
        public string Get_name()
        {
            return firm_name;
        }
        public string Get_type()
        {
            return firm_type;
        }
        static Firma()
        {
            klienci_firm = new List<Klient>();
        }
        
        static public void Add_klient_to_firm(Klient p0, Firma p)
        {
            klienci_firm.Add(p0);
        }
        static public void Delete_klient_from_firm(Klient p0,Firma p)
        {
            foreach(Klient p1 in klienci_firm)
            {
                if(p1.Get_name()==p0.Get_name())
                {
                    klienci_firm.Remove(p0);
                }
            }
        }
        



    }
    class Firma_store : Firma
    {
        
    } 
    class Firma_service : Firma
    {

    }
    class Firma_shipment : Firma
    {

    }
}
