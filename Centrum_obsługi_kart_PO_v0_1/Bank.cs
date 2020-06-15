using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centrum_obsługi_kart_PO_v0_1
{
    class Bank
    {
        private string bank_name;
        private int bank_id=0;

        public void Input_info(string nazwa)
        {
            bank_name = nazwa;
            bank_id = Bank_list.banki.Count;
        }
        public void Display_Info()
        {
            Console.WriteLine($"Bank name : {bank_name}");
            Console.WriteLine($"Bank id : {bank_id}");
        }
        public string Get_name()
        {
            return bank_name;
        }
        public int Get_id()
        {
            return bank_id;
        }
    }
}
