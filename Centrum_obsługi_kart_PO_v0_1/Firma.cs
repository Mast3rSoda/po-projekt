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
        //1-store 2-service 3-shipment
        public string firm_type;

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
    }
    class Firma_store : Firma
    {
        public override void Display_Info()
        {
            Console.WriteLine($"Firm name : {firm_name}");
            Console.WriteLine($"Firm type : {firm_type}");
            Console.WriteLine($"This firm belongs to firm_store class");
        }
    } 
    class Firma_service : Firma
    {

    }
    class Firma_shipment : Firma
    {

    }
}
