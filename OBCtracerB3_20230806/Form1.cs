using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace OBCtracerB3_20230806
{
    public partial class Form1 : Form
    {
        string primaData;
        string oraHousing,oraTrafCLC, oraTrafDC, oraLV, oraCapaP, oraCapaN, oraMicroIO, oraMicroC,  oraPower, oraFilter,oraBC, oraTC;

        

        bool f0,f1, f2, f3, f4, f5, f6, f7, f8, f9,f10,f11=false;//fanion pentru modificarea orei in xml in caz ca pcb-ul a fost scant deja



        // bool p0,p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11 = false;//fanion pentru schibarea pozei

        Utilitati utix = new Utilitati();
        public Form1()
        {
            InitializeComponent();
            this.MouseClick += mouseClick;
            btnSave.Enabled = false;
            btnExit.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtNrProdus.Text == "")
            {
                MessageBox.Show("Trebuie introdus un produs");
            }
            else
            {
                btnSave.Enabled=true;
                btnExit.Enabled = true;
                Utilitati uti = new Utilitati();
                if (File.Exists(uti.CautFisier() + "Produse\\" + txtNrProdus.Text.ToString() + "_OBC.xml"))
                {
                    XElement xElement = XElement.Load(uti.CautFisier() + "Produse\\" + txtNrProdus.Text.ToString() + "_OBC.xml");
                    primaData = (string)xElement.Element("DataAsamblare");

                    if (xElement.Element("Altele").Element("Housing").Value.Length >= 1)
                    {
                        f0 = true;
                        uti.Housing = (string)xElement.Element("Altele").Element("Housing");
                        oraHousing = (string)xElement.Element("oraAsamblare").Element("oraHousing");
                        txtH.Text = uti.Housing;
                        txtH.BackColor = Color.LightGreen;
                        txtH.ReadOnly = true;

                    }

                    if (xElement.Element("Altele").Element("TrafCLC").Value.Length >= 1)
                    {
                        f1 = true;
                        uti.TrafCLC = (string)xElement.Element("Altele").Element("TrafCLC");
                        oraTrafCLC = (string)xElement.Element("oraAsamblare").Element("oraTrafCLC");
                        txtTLLC.Text = uti.TrafCLC;
                        txtTLLC.BackColor = Color.LightGreen;
                        txtTLLC.ReadOnly = true;

                    }
                    if (xElement.Element("Altele").Element("TrafDC").Value.Length > 1)
                    {
                        f2 = true;
                        uti.TrafDC = (string)xElement.Element("Altele").Element("TrafDC");
                        oraTrafDC = (string)xElement.Element("oraAsamblare").Element("oraTrafDC");
                        txtTDCDC.Text = uti.TrafDC;
                        txtTDCDC.BackColor = Color.LightGreen;
                        txtTDCDC.ReadOnly = true;

                    }
                    if (xElement.Element("PCBs").Element("LV").Value.Length > 1)
                    {
                        f3 = true;
                        uti.LV = (string)xElement.Element("PCBs").Element("LV");
                        oraLV = (string)xElement.Element("oraAsamblare").Element("oraLV");
                        txtLV.Text = uti.LV;
                        txtLV.BackColor = Color.LightGreen;
                        txtLV.ReadOnly = true;
                    }
                    if (xElement.Element("PCBs").Element("CapaP").Value.Length > 1)
                    {
                        f4 = true;
                        uti.CapaP = (string)xElement.Element("PCBs").Element("CapaP");
                        oraCapaP = (string)xElement.Element("oraAsamblare").Element("oraCapaP");
                        txtPC.Text = uti.CapaP;
                        txtPC.BackColor = Color.LightGreen;
                        txtPC.ReadOnly = true;
                    }
                    if (xElement.Element("PCBs").Element("CapaN").Value.Length >= 1)
                    {
                        f5 = true;
                        uti.CapaN = (string)xElement.Element("PCBs").Element("CapaN");
                        oraCapaN = (string)xElement.Element("oraAsamblare").Element("oraCapaN");
                        txtNC.Text = uti.CapaN;
                        txtNC.BackColor = Color.LightGreen;
                        txtNC.ReadOnly = true;

                    }
                    if (xElement.Element("PCBs").Element("MicroIO").Value.Length >= 1)
                    {
                        f6 = true;
                        uti.MicroIO = (string)xElement.Element("PCBs").Element("MicroIO");
                        oraMicroIO = (string)xElement.Element("oraAsamblare").Element("oraMicroIO");
                        txtMIO.Text = uti.MicroIO;
                        txtMIO.BackColor = Color.LightGreen;
                        txtMIO.ReadOnly = true;

                    }
                    if (xElement.Element("PCBs").Element("MicroC").Value.Length > 1)
                    {
                        f7 = true;
                        uti.MicroC = (string)xElement.Element("PCBs").Element("MicroC");
                        oraMicroC = (string)xElement.Element("oraAsamblare").Element("oraMicroC");
                        txtMC.Text = uti.MicroC;
                        txtMC.BackColor = Color.LightGreen;
                        txtMC.ReadOnly = true;

                    }
                    if (xElement.Element("PCBs").Element("Power").Value.Length > 1)
                    {
                        f8 = true;
                        uti.Power = (string)xElement.Element("PCBs").Element("Power");
                        oraPower = (string)xElement.Element("oraAsamblare").Element("oraPower");
                        txtPower.Text = uti.Power;
                        txtPower.BackColor = Color.LightGreen;
                        txtPower.ReadOnly = true;

                    }

                    if (xElement.Element("PCBs").Element("Filter").Value.Length > 1)
                    {
                        f9 = true;
                        uti.Filter = (string)xElement.Element("PCBs").Element("Filter");
                        oraFilter = (string)xElement.Element("oraAsamblare").Element("oraFilter");
                        txtFilter.Text = uti.Filter;
                        txtFilter.BackColor = Color.LightGreen;
                        txtFilter.ReadOnly = true;
                    }
                    if (xElement.Element("Altele").Element("BC").Value.Length > 1)
                    {
                        f10 = true;
                        uti.BC = (string)xElement.Element("PCBs").Element("BC");
                        oraBC = (string)xElement.Element("oraAsamblare").Element("oraBC");
                        txtBC.Text = uti.BC;
                        txtBC.BackColor = Color.LightGreen;
                        txtBC.ReadOnly = true;

                    }

                    if (xElement.Element("Altele").Element("TC").Value.Length > 1)
                    {
                        f11 = true;
                        uti.TC = (string)xElement.Element("PCBs").Element("TC");
                        oraTC = (string)xElement.Element("oraAsamblare").Element("oraTC");
                        txtTC.Text = uti.TC;
                        txtTC.BackColor = Color.LightGreen;
                        txtTC.ReadOnly = true;
                    }


                }
                else
                {
                    primaData = uti.ReturnezData(1);
                }
            }
        }

        private void txtH_TextChanged(object sender, EventArgs e)
        {

            if (f0 == false)
            {
                System.Threading.Thread.Sleep(100);
                if (f0 == false)
                {
                    oraHousing = DateTime.Now.ToString("dd.MM.yyyy@HH:mm:ss", CultureInfo.InvariantCulture);
                    utix.oraHousing= oraHousing.ToString();
                }
            }
        }
        private void txtTLLC_TextChanged(object sender, EventArgs e)
        {
            if (f1 == false)
            {
                System.Threading.Thread.Sleep(100);
                if (f1 == false)
                {
                    oraTrafCLC = DateTime.Now.ToString("dd.MM.yyyy@HH:mm:ss", CultureInfo.InvariantCulture);
                    utix.oraTrafCLC = oraTrafCLC.ToString();
                }
            }
        }
        private void txtTDCDC_TextChanged(object sender, EventArgs e)
        {
            if (f2 == false)
            {
                System.Threading.Thread.Sleep(100);
                if (f2 == false)
                {
                    oraTrafDC = DateTime.Now.ToString("dd.MM.yyyy@HH:mm:ss", CultureInfo.InvariantCulture);
                    utix.oraTrafDC = oraTrafDC.ToString();
                }
            }
        }
        private void txtLV_TextChanged(object sender, EventArgs e)
        {
            if (f3 == false)
            {
                System.Threading.Thread.Sleep(100);
                if (f3 == false)
                {
                    oraLV = DateTime.Now.ToString("dd.MM.yyyy@HH:mm:ss", CultureInfo.InvariantCulture);
                    utix.oraLV= oraLV.ToString();
                }
            }
        }
        private void txtPC_TextChanged(object sender, EventArgs e)
        {
            if (f4 == false)
            {
                System.Threading.Thread.Sleep(100);
                if (f4 == false)
                {
                    oraCapaP = DateTime.Now.ToString("dd.MM.yyyy@HH:mm:ss", CultureInfo.InvariantCulture);
                    utix.oraCapaP = oraCapaP.ToString();
                }
            }
        }

        private void txtNC_TextChanged(object sender, EventArgs e)
        {
            if (f5 == false)
            {
                System.Threading.Thread.Sleep(100);
                if (f5 == false)
                {
                    oraCapaN= DateTime.Now.ToString("dd.MM.yyyy@HH:mm:ss", CultureInfo.InvariantCulture);
                    utix.oraCapaN = oraCapaN.ToString();
                }
            }
        }
        private void txtMIO_TextChanged(object sender, EventArgs e)
        {
            if (f6 == false)
            {
                System.Threading.Thread.Sleep(100);
                if (f6 == false)
                {
                    oraMicroIO = DateTime.Now.ToString("dd.MM.yyyy@HH:mm:ss", CultureInfo.InvariantCulture);
                    utix.oraMicroIO = oraMicroIO.ToString();
                }
            }
        }

        private void txtMC_TextChanged(object sender, EventArgs e)
        {
            if (f7 == false)
            {
                System.Threading.Thread.Sleep(100);
                if (f7 == false)
                {
                    oraMicroC = DateTime.Now.ToString("dd.MM.yyyy@HH:mm:ss", CultureInfo.InvariantCulture);
                    utix.oraMicroC = oraMicroC.ToString();
                }
            }
        }

        private void txtPower_TextChanged(object sender, EventArgs e)
        {
            if (f8 == false)
            {
                System.Threading.Thread.Sleep(100);
                if (f8 == false)
                {
                    oraPower = DateTime.Now.ToString("dd.MM.yyyy@HH:mm:ss", CultureInfo.InvariantCulture);
                    utix.oraPower = oraPower.ToString();
                }
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            if (f9 == false)
            {
                System.Threading.Thread.Sleep(100);
                if (f9 == false)
                {
                    oraFilter = DateTime.Now.ToString("dd.MM.yyyy@HH:mm:ss", CultureInfo.InvariantCulture);
                    utix.oraFilter = oraFilter.ToString();
                }
            }
        }

        private void txtBC_TextChanged(object sender, EventArgs e)
        {
            if (f10 == false)
            {
                System.Threading.Thread.Sleep(100);
                if (f10 == false)
                {
                    oraBC = DateTime.Now.ToString("dd.MM.yyyy@HH:mm:ss", CultureInfo.InvariantCulture);
                    utix.oraBC = oraBC.ToString();
                }
            }
        }

        private void txtTC_TextChanged(object sender, EventArgs e)
        {
            if (f11 == false)
            {
                System.Threading.Thread.Sleep(100);
                if (f11 == false)
                {
                    oraTC = DateTime.Now.ToString("dd.MM.yyyy@HH:mm:ss", CultureInfo.InvariantCulture);
                    utix.oraTC = oraTC.ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBC == null)
            {
                txtBC.Text = "s";
            }
            Utilitati uti4 = new Utilitati(int.Parse(txtNrProdus.Text), primaData, Environment.UserName, txtH.Text, 
                txtTLLC.Text, txtTDCDC.Text, txtLV.Text, txtPC.Text, txtNC.Text, txtMIO.Text, txtMC.Text, txtPower.Text, 
                txtFilter.Text, "bc", txtTC.Text, oraHousing, oraTrafCLC, oraTrafDC, oraLV, oraCapaP, oraCapaN, 
                oraMicroIO, oraMicroC, oraPower, oraFilter, oraBC, oraTC);
            MessageBox.Show("bc"+uti4.BC);
            uti4.CreezFisier();
            Application.Restart();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sigur inchizi aplicatia? \nFara slavare", "Esti pe cale sa inchizi aplicatia...", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                // Process.Start("shutdown", "/s /t 0");
                //do something else
            }
        }

        private void DisplayNameOfActiveControl()
        {
            label13.Text = this.ActiveControl.Name;


            switch (label13.Text)
            {

                case "txtH":
                    ShowImage(1);
                    break;
                case "txtTLLC":
                    ShowImage(2);
                    break;
                case "txtTDCDC":
                    ShowImage(3);
                    break;
                case "txtLV":
                    ShowImage(4);
                    break;
                case "txtPC":
                    ShowImage(5);
                    break;
                case "txtNC":
                    ShowImage(6);
                    break;
                case "txtMIO":
                    ShowImage(7);
                    break;
                case "txtMC":
                    ShowImage(8);
                    break;
                case "txtPower":
                    ShowImage(9);
                    break;
                case "txtFilter":
                    ShowImage(10);
                    break;
                case "txtBC":
                    ShowImage(11);
                    break;
                case "txtTC":
                    ShowImage(12);
                    break;


                default:
                    ShowImage(1);
                    break;
            }




        }

        private void ShowImage(int nr)
        {
            Utilitati ou2 = new Utilitati();
            Image image = Image.FromFile(ou2.CautFisier() + "\\resurse\\" + nr + ".png");
            pb1.Image = image;



        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool baseResult = base.ProcessCmdKey(ref msg, keyData);

            if (keyData == Keys.Tab)
            {
                label13.Text = this.ActiveControl.Name;

                switch (label13.Text)
                {

                    case "txtH":
                        ShowImage(2);
                        break;
                    case "txtTLLC":
                        ShowImage(3);
                        break;
                    case "txtTDCDC":
                        ShowImage(4);
                        break;
                    case "txtLV":
                        ShowImage(5);
                        break;
                    case "txtPC":
                        ShowImage(6);
                        break;
                    case "txtNC":
                        ShowImage(7);
                        break;
                    case "txtMIO":
                        ShowImage(8);
                        break;
                    case "txtMC":
                        ShowImage(9);
                        break;
                    case "txtPower":
                        ShowImage(10);
                        break;
                    case "txtFilter":
                        ShowImage(11);
                        break;
                    case "txtBC":
                        ShowImage(12);
                        break;
                    case "txtTC":
                        ShowImage(12);
                        break;


                    default:
                        ShowImage(1);
                        break;
                }

                return baseResult; ;
            }
            return baseResult;
        }



        private void mouseClick(object sender, MouseEventArgs e)
        {
            DisplayNameOfActiveControl();
        }






    }
}
