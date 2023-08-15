using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace OBCtracerB3_20230806
{
    internal class Utilitati
    {
        public int NrProdus { get; set; }
        public string DataAsamblare { get; set; }
        public string StatieAsamblare { get; set; }

        public string Housing { get; set; }
        public string TrafCLC { get; set; }
        public string TrafDC { get; set; }
        public string LV { get; set; }
        public string CapaP { get; set; }
        public string CapaN { get; set; }
        public string MicroIO { get; set; }
        public string MicroC { get; set; }
        public string Power { get; set; }
        public string Filter { get; set; }
        public string BC { get; set; }
        public string TC { get; set; }




        public string oraHousing { get; set; }
        public string oraTrafCLC { get; set; }
        public string oraTrafDC { get; set; }
        public string oraLV { get; set; }
        public string oraCapaP { get; set; }
        public string oraCapaN { get; set; }
        public string oraMicroIO { get; set; }
        public string oraMicroC { get; set; }
        public string oraPower { get; set; }
        public string oraFilter { get; set; }
        public string oraBC { get; set; }
        public string oraTC { get; set; }



        public Utilitati(int nrProdus, string dataAsamblare, string statieAsamblare, string housing, string trafCLC, string trafDC, string lV, string capaP, string capaN, string microIO, string microC, string power, string filter, string bC, string tC, string oraHousing, string oraTrafCLC, string oraTrafDC, string oraLV, string oraCapaP, string oraCapaN, string oraMicroIO, string oraMicroC, string oraPower, string oraFilter, string oraBC, string oraTC)
        {
            NrProdus = nrProdus;
            DataAsamblare = dataAsamblare;
            StatieAsamblare = statieAsamblare;
            Housing = housing;
            TrafCLC = trafCLC;
            TrafDC = trafDC;
            LV = lV;
            CapaP = capaP;
            CapaN = capaN;
            MicroIO = microIO;
            MicroC = microC;
            Power = power;
            Filter = filter;
            BC = bC;
            TC = tC;
            this.oraHousing = oraHousing;
            this.oraTrafCLC = oraTrafCLC;
            this.oraTrafDC = oraTrafDC;
            this.oraLV = oraLV;
            this.oraCapaP = oraCapaP;
            this.oraCapaN = oraCapaN;
            this.oraMicroIO = oraMicroIO;
            this.oraMicroC = oraMicroC;
            this.oraPower = oraPower;
            this.oraFilter = oraFilter;
            this.oraBC = oraBC;
            this.oraTC = oraTC;
        }

        public Utilitati()
        {

        }

        public string ReturnezData(int n)
        {
            string datac;
            switch (n)
            {
                case 1:
                    datac = DateTime.Now.ToString("dd.MM.yyyy@HH:mm", CultureInfo.InvariantCulture);
                    return datac;
                    break;
                case 2:
                    datac = DateTime.Now.ToString("HH:mm", CultureInfo.InvariantCulture);
                    return datac;
                    break;
                default:
                    datac = DateTime.Now.ToString("dd.MM.yyyy@HH:mm", CultureInfo.InvariantCulture);
                    return datac;
                    break;
            }
        }

        public string CautFisier()
        {
            string dir;
            dir = AppDomain.CurrentDomain.BaseDirectory;
            return dir;
        }

        public void IncartDocument()
        {
            XElement xElement = XElement.Load(CautFisier() + "Produse\\" + NrProdus + "_OBC.xml");
        }
        public void CreezFisier()
        {
            if (!Directory.Exists(CautFisier() + "Produse"))
            {
                Directory.CreateDirectory(CautFisier() + "Produse");
            }
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");
            settings.CloseOutput = true;
            settings.OmitXmlDeclaration = true;
            XmlWriter writer = XmlWriter.Create(CautFisier() + "Produse\\" + NrProdus + "_OBC.xml", settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("DetaliiProdus_" + NrProdus.ToString()+"_OBC_B3_11kW");
            writer.WriteElementString("NumarProdus", NrProdus.ToString());
            writer.WriteElementString("DataAsamblare", DataAsamblare.ToString());
            writer.WriteElementString("StatieAsamblare", Environment.UserName.ToString()+"_YCT");

            writer.WriteStartElement("PCBs");
            writer.WriteElementString("LV_Iso", LV.ToString());
            writer.WriteElementString("Positive_Capacitor", CapaP.ToString());
            writer.WriteElementString("Negative_Capacitor", CapaN.ToString());
            writer.WriteElementString("Micro_IO", MicroIO.ToString());
            writer.WriteElementString("Micro_Ctr", MicroC.ToString());
            writer.WriteElementString("Power", Power.ToString());
            writer.WriteElementString("Filter", Filter.ToString());
            writer.WriteEndElement();

           writer.WriteStartElement("Altele");
            writer.WriteElementString("Housing", Housing.ToString());
            //writer.WriteElementString("Bottom cover","bc");//BC.ToString());
          // writer.WriteElementString("Top cover", TC.ToString());
            writer.WriteElementString("Traf_CLLLC", TrafCLC.ToString());
           writer.WriteElementString("Traf_DCDC", TrafDC.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("oraAsamblare");
            writer.WriteElementString("oraHousing", oraHousing.ToString());
            writer.WriteElementString("oraTraf_CLLLC", oraTrafCLC.ToString());
           writer.WriteElementString("oraTraf_DCDC", oraTrafDC.ToString());
            writer.WriteElementString("oraLV_Iso", oraLV.ToString());
            writer.WriteElementString("oraPositive_Capacitor", oraCapaP.ToString());
            writer.WriteElementString("oraNegative_Capacitor", oraCapaN.ToString());
            writer.WriteElementString("oraMicro_IO", oraMicroIO.ToString());
            writer.WriteElementString("oraMicro_Ctr", oraMicroC.ToString());
            writer.WriteElementString("oraPower", oraPower.ToString());
            writer.WriteElementString("oraFilter", oraFilter.ToString());
            //writer.WriteElementString("oraBottom cover", oraBC.ToString());
           //writer.WriteElementString("oraTop cover", oraTC.ToString());
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();

        }

    }
}
