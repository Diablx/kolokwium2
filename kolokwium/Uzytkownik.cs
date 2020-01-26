using System;
using System.Collections.Generic;
using System.Text;

namespace kolokwium
{
    public class Uzytkownik
    {
        private string Login { get; set; }
        private string Haslo { get; set; }
        private DateTime DataUtworzenia { get; set; }
        private int IloscPostow { get; set; }
    }
}
