using System;

namespace Rekenmachine
{
    class OmrekenenProgrameer : Cijfers
    {   
        public void VanBinary(string naar)
        {
            long Binary = Convert.ToInt64(Getal1, 2);

            switch (naar)
            {
                case "Octaal":
                    OmrekenGetal = Convert.ToString(Binary, 8);
                    break;

                case "Decimaal":
                    OmrekenGetal = Binary.ToString();
                    break;

                case "Hexdecimaal":
                    OmrekenGetal = Convert.ToString(Binary, 16).ToUpper();
                    break;
            }
        }

        public void VanOctaal(string naar)
        {
            long Octaal = Convert.ToInt64(Getal1, 8);

            switch (naar)
            {
                case "Decimaal":
                    OmrekenGetal = Octaal.ToString();
                    break;

                case "Binary":
                    OmrekenGetal = Convert.ToString(Octaal, 2);
                    break;

                case "Hexdecimaal":
                    OmrekenGetal = Convert.ToString(Octaal, 16).ToUpper();
                    break;
            }
        }

        public void VanDecimaal(string naar)
        {
            switch (naar)
            {
                case "Octaal":
                    OmrekenGetal = Convert.ToString(Convert.ToInt64(Getal1), 8);
                    break;

                case "Binary":
                    OmrekenGetal = Convert.ToString(Convert.ToInt64(Getal1), 2);
                    break;

                case "Hexdecimaal":
                    OmrekenGetal = Convert.ToString(Convert.ToInt64(Getal1), 16).ToUpper();
                    break;
            }
        }

        public void VanHexdecimaal(string naar)
        {
            long Hex = Convert.ToInt64(Getal1, 16);

            switch (naar)
            {
                case "Decimaal":
                    OmrekenGetal = Hex.ToString();
                    break;

                case "Octaal":
                    OmrekenGetal = Convert.ToString(Hex, 8);
                    break;

                case "Binary":
                    OmrekenGetal = Convert.ToString(Hex, 2);
                    break;
            }
        }
    }
}
