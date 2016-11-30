using System;
using System.Windows.Forms;

namespace Rekenmachine
{
    public partial class Rekenmachine : Form
    {
        private Berekeningen berekeningen;
        private OmrekenenVolume volume;
        private OmrekenenProgrameer programeer;
        private OmrekenenLengte lengte;
        string berekening;
        bool nieuwGetal = false;
        bool doorRekenen = false;
        bool isDoorRekenen = false;
        string getal2;

        public Rekenmachine()
        {
            InitializeComponent();
            berekeningen = new Berekeningen();
            volume = new OmrekenenVolume();
            programeer = new OmrekenenProgrameer();
            lengte = new OmrekenenLengte();
        }

        private void naar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            omrekenen();
        }

        // Omreken functies
        private void Omrekenen_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((string)Omrekenen.SelectedItem)
            {
                case "Lengte":
                    string[] L = new string[] { "Inch", "Meters", "Voet", "Mijl", "Zeemijl" };
                    naar.Items.Clear();
                    naar.Items.Add("Naar");
                    naar.Items.AddRange(L);
                    naar.SelectedIndex = 0;
                    van.Items.Clear();
                    van.Items.Add("Van");
                    van.Items.AddRange(L);
                    van.SelectedIndex = 0;
                    programeerModus(false);
                    break;

                case "Programmeren":
                    string[] P = new string[] { "Decimaal", "Binary", "Octaal", "Hexdecimaal" };
                    naar.Items.Clear();
                    naar.Items.Add("Naar");
                    naar.Items.AddRange(P);
                    naar.SelectedIndex = 0;
                    van.Items.Clear();
                    van.Items.Add("Van");
                    van.Items.AddRange(P);
                    van.SelectedIndex = 0;
                    programeerModus(true);
                    break;

                case "Volume":
                    string[] V = new string[] { "M³", "Liters", "Gallons" };
                    naar.Items.Clear();
                    naar.Items.Add("Naar");
                    naar.Items.AddRange(V);
                    naar.SelectedIndex = 0;
                    van.Items.Clear();
                    van.Items.Add("Van");
                    van.Items.AddRange(V);
                    van.SelectedIndex = 0;
                    programeerModus(false);
                    break;

                default:
                    naar.Items.Clear();
                    naar.Items.Add("Naar");
                    naar.SelectedIndex = 0;
                    van.Items.Clear();
                    van.Items.Add("Van");
                    van.SelectedIndex = 0;

                    // Textbox en omrekengetal op 0
                    omrekenUitkomst.Text = " ";
                    Cijfers.OmrekenGetal = "0";

                    programeerModus(false);
                    enableAll();
                    break;
            }
        }

        // Omreken van/naar
        private void omrekenen()
        {
            if ((string)van.SelectedItem == (string)naar.SelectedItem)
            {
                MessageBox.Show("Van en Naar kunnen niet het zelfde zijn!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                van.SelectedIndex = 0;
                naar.SelectedIndex = 0;
            }

            if ((string)van.SelectedItem != "Van" && (string)naar.SelectedItem != "Naar")
            {
                if (komma.Enabled == true)
                {
                    Cijfers.Getal1 = richTextBox.Text;
                }

                switch ((string)van.SelectedItem)
                {
                    // Lengte omrekeningen
                    case "Inch":
                        if (!ifNumber()) { return; }

                        lengte.VanInch((string)naar.SelectedItem);
                        omrekenUitkomst.Text = Cijfers.OmrekenGetal;
                        programeerModus(false);
                        break;

                    case "Meters":
                        if (!ifNumber()) { return; }

                        lengte.VanMeters((string)naar.SelectedItem);
                        omrekenUitkomst.Text = Cijfers.OmrekenGetal;
                        programeerModus(false);
                        break;

                    case "Voet":
                        if (!ifNumber()) { return; }

                        lengte.VanVoet((string)naar.SelectedItem);
                        omrekenUitkomst.Text = Cijfers.OmrekenGetal;
                        programeerModus(false);
                        break;

                    case "Mijl":
                        if (!ifNumber()) { return; }

                        lengte.VanMijl((string)naar.SelectedItem);
                        omrekenUitkomst.Text = Cijfers.OmrekenGetal;
                        programeerModus(false);
                        break;

                    case "Zeemijl":
                        if (!ifNumber()) { return; }

                        lengte.VanZeemijl((string)naar.SelectedItem);
                        omrekenUitkomst.Text = Cijfers.OmrekenGetal;
                        programeerModus(false);
                        break;

                    // Programeer berekeningen
                    case "Binary":
                        if (!binaryCheck()) { break; }

                        programeer.VanBinary((string)naar.SelectedItem);
                        omrekenUitkomst.Text = Cijfers.OmrekenGetal;
                        programeerModus(true);
                        break;

                    case "Octaal":
                        if (!ifNumber()) { return; }
                        if (!octaalCheck()) { return; }

                        programeer.VanOctaal((string)naar.SelectedItem);
                        omrekenUitkomst.Text = Cijfers.OmrekenGetal;
                        programeerModus(true);
                        break;

                    case "Decimaal":
                        if (!ifNumber()) { return; }
                        if (!decimalCheck()) { return; }

                        programeer.VanDecimaal((string)naar.SelectedItem);
                        omrekenUitkomst.Text = Cijfers.OmrekenGetal;
                        programeerModus(true);
                        break;

                    case "Hexdecimaal":
                        if (!hexCheck()) { break; }

                        programeer.VanHexdecimaal((string)naar.SelectedItem);
                        omrekenUitkomst.Text = Cijfers.OmrekenGetal;
                        programeerModus(true);
                        break;

                    // Volume berekeningen
                    case "M³":
                        if (!ifNumber()) { return; }

                        volume.VanMeters((string)naar.SelectedItem);
                        omrekenUitkomst.Text = Cijfers.OmrekenGetal;
                        programeerModus(false);
                        break;

                    case "Liters":
                        if (!ifNumber()) { return; }

                        volume.VanLiters((string)naar.SelectedItem);
                        omrekenUitkomst.Text = Cijfers.OmrekenGetal;
                        programeerModus(false);
                        break;

                    case "Gallons":
                        if (!ifNumber()) { return; }

                        volume.VanGallons((string)naar.SelectedItem);
                        omrekenUitkomst.Text = Cijfers.OmrekenGetal;
                        programeerModus(false);
                        break;
                }
            }
            else
            {
                if (komma.Enabled == false) { richTextBox.Text = Cijfers.Getal1; }
                Cijfers.OmrekenGetal = "0";

            }
        }
    
        // Progammeer modus.
        private void programeerModus(bool waar)
        {
            if (waar)
            {
                omgekeerde.Text = "A";
                plus.Text = "B";
                min.Text = "C";
                keer.Text = "D";
                delen.Text = "E";
                plusMin.Text = "F";

                omgekeerde.Enabled = true;
                keer.Enabled = true;
                min.Enabled = true;
                delen.Enabled = true;
                plus.Enabled = true;
                plusMin.Enabled = true;
                wortel.Enabled = false;
                procent.Enabled = false;
                vergelijking.Enabled = false;
            } else
            {
                omgekeerde.Text = "1/x";
                plus.Text = "+";
                min.Text = "-";
                keer.Text = "x";
                delen.Text = "÷";
                uitreken.Text = "=";
                plusMin.Text = "±";

                omgekeerde.Enabled = false;
                keer.Enabled = false;
                min.Enabled = false;
                delen.Enabled = false;
                plus.Enabled = false;
                plusMin.Enabled = false;
                wortel.Enabled = false;
                procent.Enabled = false;
                vergelijking.Enabled = false;
            }
        }

        // Functie om door te blijven rekenen.
        private void doorTypen(string number)
        {
            if (richTextBox.Text == "0" || nieuwGetal == true) {
                richTextBox.Text = number;
                nieuwGetal = false;
            } else { richTextBox.Text += number; }
        }

        // Functie voor het kijken als het wel een nummer is.
        private bool ifNumber()
        {
            double result;
            double.TryParse(richTextBox.Text, out result);

            if (richTextBox.Text == "0") { result = 1; }

            if (result == 0)
            {
                MessageBox.Show("Is geen nummer!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTextBox.Text = "0";
                return false;
            } else
            {
                return true;
            }
        }
        
        // Functie voor het kijken welke berekening the vorige was.
        private void vorigeBerekening()
        {
            switch (berekening)
            {
                case "+":
                    berekeningen.Optellen(Convert.ToDouble(richTextBox.Text));
                    break;

                case "-":
                    berekeningen.Aftrekken(Convert.ToDouble(richTextBox.Text));
                    break;

                case "x":
                    berekeningen.Vermenigvuldigen(Convert.ToDouble(richTextBox.Text));
                    break;

                case "÷":
                    berekeningen.Delen(Convert.ToDouble(richTextBox.Text));
                    break;
            }
        }

        // Functie om te kijken als het een binary getal is.
        private bool binaryCheck()
        {
            foreach (char c in richTextBox.Text)
            {
                if (c < '0' || c > '1')
                {
                    MessageBox.Show("Is geen Binary getal!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    van.SelectedIndex = 0;
                    naar.SelectedIndex = 0;
                    Cijfers.Getal1 = "0";
                    richTextBox.Text = Cijfers.Getal1;
                    return false;
                }    
            }

            if (richTextBox.Text.Length > 63) { 
                MessageBox.Show("Binary getal is the groot!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Functie om te kijken als het getal niet te lang is voor decimaal.
        private bool decimalCheck()
        {
            try
            {
                Convert.ToInt64(richTextBox.Text);
            }
            
            catch {
                MessageBox.Show("Decimaal is te groot!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Functie om te kijken als het getal niet te lang is voor octaal.
        private bool octaalCheck()
        {
            try
            {
                Convert.ToInt64(richTextBox.Text, 8);
            }

            catch
            {
                MessageBox.Show("Octaal is te groot!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Functie om te kijken als het een hexdecimaal getal is.
        private bool hexCheck()
        {
            string toegelaten = "0123456789aAbBcCdDeEfF";

            foreach (char c in richTextBox.Text)
            {
                if (!toegelaten.Contains(c.ToString()))
                {
                    MessageBox.Show("Is geen Hexdecimaal!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    van.SelectedIndex = 0;
                    naar.SelectedIndex = 0;
                    return false;
                }
            }
            
            try
            {
                Convert.ToInt64(richTextBox.Text, 16);
            }

            catch
            {
                MessageBox.Show("Hexdecimaal is te groot!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Enable of disable alle knoppen.
        private void enableAll()
        {
            omgekeerde.Enabled = true;
            keer.Enabled = true;
            min.Enabled = true;
            delen.Enabled = true;
            plus.Enabled = true;
            plusMin.Enabled = true;
            wortel.Enabled = true;
            procent.Enabled = true;
            vergelijking.Enabled = true;
        }

        // Nummers
        private void nummer1_Click(object sender, EventArgs e)
        {
            doorTypen("1");
        }

        private void nummer2_Click(object sender, EventArgs e)
        {
            doorTypen("2");
        }

        private void nummer3_Click(object sender, EventArgs e)
        {
            doorTypen("3");
        }

        private void nummer4_Click(object sender, EventArgs e)
        {
            doorTypen("4");
        }

        private void nummer5_Click(object sender, EventArgs e)
        {
            doorTypen("5");
        }

        private void nummer6_Click(object sender, EventArgs e)
        {
            doorTypen("6");
        }

        private void nummer7_Click(object sender, EventArgs e)
        {
            doorTypen("7");
        }

        private void nummer8_Click(object sender, EventArgs e)
        {
            doorTypen("8");
        }

        private void nummer9_Click(object sender, EventArgs e)
        {
            doorTypen("9");
        }

        private void nummer0_Click(object sender, EventArgs e)
        {
            doorTypen("0");
        }

        private void komma_Click(object sender, EventArgs e)
        {
            richTextBox.Text += ",";
        }

        // Wissen
        private void wissen_Click(object sender, EventArgs e)
        {
            richTextBox.Text = "0";
            Cijfers.Getal1 = default(string);
            doorRekenen = false;
            isDoorRekenen = false;
        }

        // Berekeningen
        private void plus_Click(object sender, EventArgs e)
        {
            if (plus.Text == "B")
            {
               doorTypen("B");
               return;
            }

            isDoorRekenen = false;
            nieuwGetal = true;

            if (doorRekenen)
            {
                if (!ifNumber()) { return; }
                
                vorigeBerekening();
                richTextBox.Text = Cijfers.Getal1;
            } else
            {
                if (!ifNumber()) { return; }

                Cijfers.Getal1 = richTextBox.Text;
                richTextBox.Text = "0";
                doorRekenen = true;
            }

            berekening = "+";
        }

        private void min_Click(object sender, EventArgs e)
        {
            if (min.Text == "C")
            {
                doorTypen("C");
                return;
            }

            isDoorRekenen = false;
            nieuwGetal = true;

            if (doorRekenen)
            {
                if (!ifNumber()) { return; }
                
                vorigeBerekening();
                richTextBox.Text = Cijfers.Getal1;
            } else
            {
                if (!ifNumber()) { return; }

                Cijfers.Getal1 = richTextBox.Text;
                richTextBox.Text = "0";
                doorRekenen = true;
            }

            berekening = "-";
        }

        private void keer_Click(object sender, EventArgs e)
        {
            if (keer.Text == "D")
            {
                doorTypen("D");
                return;
            }

            isDoorRekenen = false;
            nieuwGetal = true;

            if (doorRekenen)
            {
                if (!ifNumber()) { return; }
                
                vorigeBerekening();
                richTextBox.Text = Cijfers.Getal1;
            } else
            {
                if (!ifNumber()) { return; }

                Cijfers.Getal1 = richTextBox.Text;
                richTextBox.Text = "0";
                doorRekenen = true;
            }

            berekening = "x";
        }

        private void delen_Click(object sender, EventArgs e)
        {
            if (delen.Text == "E")
            {
                doorTypen("E");
                return;
            }

            isDoorRekenen = false;
            nieuwGetal = true;

            if (doorRekenen)
            {
                if (!ifNumber()) { return; }
                

                if(richTextBox.Text == "0")
                {
                    MessageBox.Show("Je kan niet delen door 0!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cijfers.Getal1 = "0";
                    return;
                }

                vorigeBerekening();
                richTextBox.Text = Cijfers.Getal1;
            } else
            {
                if (!ifNumber()) { return; }

                Cijfers.Getal1 = richTextBox.Text;
                richTextBox.Text = "0";
                doorRekenen = true;
            }

            berekening = "÷";
        }

        private void procent_Click(object sender, EventArgs e)
        {
            nieuwGetal = true;
            doorRekenen = false;

            if (!ifNumber()) { return; }
            
            berekeningen.Procent(Cijfers.Getal1, Convert.ToDouble(richTextBox.Text), berekening);
            richTextBox.Text = Cijfers.Getal1;
        }

        private void wortel_Click(object sender, EventArgs e)
        {
            nieuwGetal = true;
            isDoorRekenen = false;

            if (!ifNumber()) { return; }
            
            berekeningen.Wortel(Convert.ToDouble(richTextBox.Text));
            richTextBox.Text = Cijfers.Getal1;
        }

        private void vergelijking_Click(object sender, EventArgs e)
        {
            nieuwGetal = true;
            isDoorRekenen = false;

            if (!ifNumber()) { return; }
            
            berekeningen.Kwadraat(Convert.ToDouble(richTextBox.Text));
            richTextBox.Text = Cijfers.Getal1;
        }

        private void omgekeerde_Click(object sender, EventArgs e)
        {
            if (omgekeerde.Text == "A")
            {
                doorTypen("A");
                return;
            }

            isDoorRekenen = false;
            nieuwGetal = true;

            if (!ifNumber()) { return; }
            

            if (richTextBox.Text == "0") {
                Cijfers.Getal1 = "0";
            } else {
                berekeningen.Omgekeerde(Convert.ToDouble(richTextBox.Text));
            }

            richTextBox.Text = Cijfers.Getal1;
        }

        private void plusMin_Click(object sender, EventArgs e)
        {
            if (plusMin.Text == "F")
            {
                doorTypen("F");
                return;
            }

            if (!ifNumber()) { return; }
            
            berekeningen.plusMin(Convert.ToDouble(richTextBox.Text));
            richTextBox.Text = Cijfers.Getal1;
        }

        // Uitrekenen
        private void uitreken_Click(object sender, EventArgs e)
        {
            nieuwGetal = true;
            doorRekenen = false;

            if (!isDoorRekenen)
            {
                getal2 = richTextBox.Text;
                isDoorRekenen = true;
            }

            if (procent.Enabled == false)
            {
                omrekenen();
                return;
            }

            if (!ifNumber()) { return; }

            switch (berekening)
            {
                case "+":
                    berekeningen.Optellen(Cijfers.Getal1, Convert.ToDouble(getal2));
                    richTextBox.Text = Cijfers.Getal1;
                    break;

                case "-":
                    berekeningen.Aftrekken(Cijfers.Getal1, Convert.ToDouble(getal2));
                    richTextBox.Text = Cijfers.Getal1;
                    break;

                case "x":
                    berekeningen.Vermenigvuldigen(Cijfers.Getal1, Convert.ToDouble(getal2));
                    richTextBox.Text = Cijfers.Getal1;
                    break;

                case "÷":
                    if (richTextBox.Text == "0")
                    {
                        MessageBox.Show("Je kan niet delen door 0!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Cijfers.Getal1 = "0";
                        break;
                    }

                    berekeningen.Delen(Cijfers.Getal1, Convert.ToDouble(getal2));
                    richTextBox.Text = Cijfers.Getal1;
                    break;
            }
        }
    }
}
