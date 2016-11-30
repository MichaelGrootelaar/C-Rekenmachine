using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rekenmachine
{
    class Berekeningen : Cijfers
    {
        // Standaard berekeningen
        public void Optellen(double getal2)
        {
            Getal1 = Convert.ToString(Convert.ToDouble(Getal1) + getal2);
   
        }

        public void Optellen(string getal1, double getal2)
        {
            Getal1 = Convert.ToString(Convert.ToDouble(getal1) + getal2);

        }

        public void Aftrekken(double getal2)
        {
            Getal1 = Convert.ToString(Convert.ToDouble(Getal1) - getal2);
        }

        public void Aftrekken(string getal1, double getal2)
        {
            Getal1 = Convert.ToString(Convert.ToDouble(getal1) - getal2);
        }

        public void Vermenigvuldigen(double getal2)
        {
            Getal1 = Convert.ToString(Convert.ToDouble(Getal1) * getal2);
        }

        public void Vermenigvuldigen(string getal1, double getal2)
        {
            Getal1 = Convert.ToString(Convert.ToDouble(getal1) * getal2);
        }

        public void Delen(double getal2)
        {
            Getal1 = Convert.ToString(Convert.ToDouble(Getal1) / getal2);
        }

        public void Delen(string getal1, double getal2)
        {
            Getal1 = Convert.ToString(Convert.ToDouble(getal1) / getal2);
        }

        // Berekeningen
        public void Wortel(double getal2)
        {
            Getal1 = Convert.ToString(Math.Sqrt(getal2));
        }

        public void Kwadraat(double getal2)
        {
            Getal1 = Convert.ToString(getal2 * getal2);
        }

        public void Procent(string getal1, double getal2, string breuk)
        {
            double g1 = Convert.ToDouble(getal1);

            switch (breuk) {
                case "x":
                    Getal1 = Convert.ToString(g1 / 100 * getal2);
                    break;

                case "÷":
                    Getal1 = Convert.ToString(g1 / getal2 * 100);
                    break;

                case "+":
                    Getal1 = Convert.ToString(g1 + g1 / 100 * getal2);
                    break;

                case "-":
                    Getal1 = Convert.ToString(g1 - g1 / 100 * getal2);
                    break;
            }
          
        }

        public void Omgekeerde(double getal2)
        {
            Getal1 = Convert.ToString(1 / getal2);
        }

        public void plusMin(double getal2)
        {
            if (getal2 > 0)
            {
                Getal1 = Convert.ToString(Math.Abs(getal2) * -1);
            }
            else
            {
                Getal1 = Convert.ToString(Math.Abs(getal2));
            }
        }
    }
}
