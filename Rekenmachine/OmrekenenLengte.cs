using System;

namespace Rekenmachine
{
    class OmrekenenLengte : Cijfers
    {
        public void VanInch(string naar)
        {
            switch (naar)
            {
                case "Meters":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 0.025400);
                    break;

                case "Voet":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 0.083333);
                    break;

                case "Mijl":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 0.000016);
                    break;

                case "Zeemijl":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 0.000014);
                    break;
            }
        }

        public void VanMeters(string naar)
        {
            switch (naar)
            {
                case "Inch":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 39.37);
                    break;

                case "Voet":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 3.28);
                    break;

                case "Mijl":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 0.000621);
                    break;

                case "Zeemijl":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 0.000540);
                    break;
            }
        }

        public void VanVoet(string naar)
        {
            switch (naar)
            {
                case "Inch":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 12.00);
                    break;

                case "Meters":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 0.304800);
                    break;

                case "Mijl":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 0.000189);
                    break;

                case "Zeemijl":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 0.000165);
                    break;
            }
        }

        public void VanMijl(string naar)
        {
            switch (naar)
            {
                case "Inch":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 63358.27);
                    break;

                case "Meters":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 1609.30);
                    break;

                case "Voet":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 5279.86);
                    break;

                case "Zeemijl":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 0.868952);
                    break;
            }
        }

        public void VanZeemijl(string naar)
        {
            switch (naar)
            {
                case "Inch":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 72913.39);
                    break;

                case "Meters":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 1852.00);
                    break;

                case "Voet":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 6076.12);
                    break;

                case "Mijl":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 1.15);
                    break;
            }
        }
    }
}
