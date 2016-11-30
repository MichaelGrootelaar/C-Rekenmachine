using System;

namespace Rekenmachine
{
    class OmrekenenVolume : Cijfers
    {
        public void VanMeters(string naar)
        {
            switch (naar)
            {
                case "Liters":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) / 1000);
                    break;


                case "Gallons":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 219.97);
                    break;

            }
        }

        public void VanLiters(string naar)
        {
            switch (naar)
            {
                case "Gallons":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 0.21997);
                    break;

                case "M²":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) * 1000);
                    break;
            }
        }

        public void VanGallons(string naar)
        {
            switch (naar)
            {
                case "Liters":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) / 0.21997);
                    break;

                case "M²":
                    OmrekenGetal = Convert.ToString(Convert.ToDouble(Getal1) / 219.97);
                    break;
            }
        }
    }
}
