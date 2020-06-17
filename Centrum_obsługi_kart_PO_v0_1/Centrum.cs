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
        static private List<Firma_store> firmy_stores;
        static private List<Firma_service> firmy_services;
        static private List<Firma_shipment> firmy_shipment;

        static Firm_list()
        {
            firmy = new List<Firma>();
            firmy_stores = new List<Firma_store>();
            firmy_services = new List<Firma_service>();
            firmy_shipment = new List<Firma_shipment>();
        }
        ~Firm_list()
        {

        }
        static public void Add_firm(Firma p)
        {
            firmy.Add(p);
        }
        static public void Add_firm_store(Firma_store p)
        {
            firmy_stores.Add(p);
        }
        static public void Add_firm_service(Firma_service p)
        {
            firmy_services.Add(p);
        }
        static public void Add_firm_shipment(Firma_shipment p)
        {
            firmy_shipment.Add(p);
        }
        static public void Delete_firm_store(Firma_store p0)
        {
            foreach (Firma_store p in firmy_stores)
            { 
                if (p.Get_name() == p0.Get_name()&&p.Get_type() == p0.Get_type())
                {
                    firmy_stores.Remove(p);
                    break;
                }
            }
        }
        static public void Delete_firm_service(Firma_service p0)
        {
            foreach (Firma_service p in firmy_services)
            {
                if (p.Get_name() == p0.Get_name() && p.Get_type() == p0.Get_type())
                {
                    firmy_services.Remove(p);
                    break;
                }
            }
        }

        static public void Delete_firm_shipment(Firma p0)
        {
            foreach (Firma_shipment p in firmy_shipment)
            {
                if (p.Get_name() == p0.Get_name() && p.Get_type() == p0.Get_type())
                {
                    firmy_shipment.Remove(p);
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
            foreach (Firma_store p in firmy_stores)
            {
                p.Display_Info();
            }
            foreach (Firma_service p in firmy_services)
            {
                p.Display_Info();
            }
            foreach (Firma_shipment p in firmy_shipment)
            {
                p.Display_Info();
            }
        }
    }
    class Bank_list
    {
        //siema
        static public List<Bank> banki;
        static Bank_list()
        {
            banki = new List<Bank>();
        }
        static public void Add_klient_to_bank(Klient p,Bank p0)
        {   
                    p0.Add_klient(p,p0);
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
    class Centrum
    { 
        static public void Get_authorization(Card karta,string data,double kwota,string card_owner,int card_type)
        {
            Archive.Save_to_archive(karta, data, kwota, card_owner, card_type, Bank.Authorize_transaction(karta,data,kwota,card_owner,card_type));
            
        }
     

    }
}
