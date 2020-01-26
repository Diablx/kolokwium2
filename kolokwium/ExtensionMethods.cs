using System;
using System.Collections.Generic;
using System.Text;

namespace kolokwium
{
    public class ExtensionMethods
    {
        public static string Rodo(string getLastName)
        {
            string temp = "";
            for (int i = 0; i < getLastName.Length; i++)
            {

                if (i == 0)
                {
                    string a = getLastName.Substring(i, 1).ToString();
                    temp += a;
                }
                else
                {
                    string b = "*";
                    temp += b;
                }
            }
            return temp;
        }
    }
}
