using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_obsługi_kart_PO_v0_1
{
    class Firm_list
    {
        static private List<Firma> firmy;

        static Firm_list()
        {
            firmy = new List<Firma>();
        }
        ~Firm_list()
        {

        }
        static public void Add_firm(Firma p)
        {
            firmy.Add(p);
        }
        static public void Delete_firm(Firma p0)
        {
            
            foreach (Firma p in firmy)
            { 
                if (p.Get_name() == p0.Get_name()&&p.Get_type() == p0.Get_type())
                {
                    firmy.Remove(p);
                    break;
                }
            }
        }
        static public void Display_firm_list()
        {
            foreach (Firma p in firmy)
            {
                p.Display_Info();
            }
        }
    }
    class Bank_list
    {
        static public List<Bank> banki;

        static Bank_list()
        {
            banki = new List<Bank>();
        }
        ~Bank_list()
        {

        }
        static public void Add_bank(Bank p)
        {
            banki.Add(p);
        }
        static public void Delete_bank(Bank p0)
        {

            foreach (Bank p in banki)
            {
                if (p.Get_name() == p0.Get_name())
                {
                    banki.Remove(p);
                    break;
                }
            }
        }
        static public void Display_bank_list()
        {
            foreach (Bank p in banki)
            {
                p.Display_Info();
            }
        }
    }
}
