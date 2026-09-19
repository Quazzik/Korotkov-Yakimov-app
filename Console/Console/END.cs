using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class END 
    {
        public double ReportComponentOfShihta {  get; set; }
        public double ReportPercentOfFe { get; set; }
        public double ReportFe => ReportComponentOfShihta * ReportPercentOfFe / 100;
        public double ReportPercentOfS { get; set; }
        public double ReportS => ReportComponentOfShihta * ReportPercentOfS / 100;
        public double ReportPercentOfP { get; set; }
        public double ReportP => ReportComponentOfShihta * ReportPercentOfP / 100;
        public double ReportPercentOfFeO { get; set; }
        public double ReportFeO => ReportComponentOfShihta * ReportPercentOfFeO / 100;
        public double ReportPercentOfCaO { get; set; }
        public double ReportCaO => ReportComponentOfShihta * ReportPercentOfCaO / 100;
        public double ReportPercentOfSiO2 { get; set; }
        public double ReportSiO2 => ReportComponentOfShihta * ReportPercentOfSiO2 / 100;
        public double ReportPercentOfAl2O3 { get; set; }
        public double ReportAl2O3 => ReportComponentOfShihta * ReportPercentOfAl2O3 / 100;
        public double ReportPercentOfMgO { get; set; }
        public double ReportMgO => ReportComponentOfShihta * ReportPercentOfMgO / 100;
        public double ReportPercentOfMnO { get; set; }
        public double ReportMnO => ReportComponentOfShihta * ReportPercentOfMnO / 100;
        public double ReportPercentOfTiO2 { get; set; }
        public double ReportTiO2 => ReportComponentOfShihta * ReportPercentOfTiO2 / 100;
        public double ReportPercentOfZn { get; set; }
        public double ReportZn => ReportComponentOfShihta * ReportPercentOfZn / 100;
        public double ReportPercentOfPMPP { get; set; }
        public double ReportPMPP => ReportComponentOfShihta * ReportPercentOfPMPP / 100;

    }
}
