using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_PMdoga
{
    internal class Szakasz
    {
        //Csényeújmajor - Sárvár v.áll.   ;  4,5 ;   0  ;   68
        string utleiras;
        int magassag;
        int ido;
        double hossz;

        public Szakasz(string txtSor)
        {
            var mezok = txtSor.Split(";");
            utleiras = mezok[0];
            ido = Convert.ToInt32(mezok[3]);
            magassag = Convert.ToInt32(mezok[2]);
            hossz = Convert.ToDouble(mezok[1]);
        }

        public string Utleiras { get => utleiras; }
        public int Magassag { get => magassag; }
        public int Ido { get => ido; }
        public double Hossz { get => hossz; }

        public string Nehezseg(double hossz)
        {
            if (hossz <= 5)
            {
                return "könnyű";
            }
            else if (hossz < 10)
            {
                return "közepes";
            }
            else
            {
                return "nehéz";
            }
        }
    }
}
