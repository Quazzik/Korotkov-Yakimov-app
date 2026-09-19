using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class FluxAdditions
    {
        #region Izvestnyak
        public double IzvestnyakCaO {  get; set; }
        public double IzvestnyakSiO2 { get; set; }
        public double IzvestnyakAl2O3 { get; set; }
        public double IzvestnyakMgO { get; set; }
        public double IzvestnyakPMPP => 100 - (IzvestnyakCaO + IzvestnyakSiO2 + IzvestnyakAl2O3 + IzvestnyakMgO);

        #endregion

        #region Dolomyte
        public double DolomyteCaO { get; set; }
        public double DolomyteSiO2 { get; set; }
        public double DolomyteAl2O3 { get; set; }
        public double DolomyteMgO { get; set; }
        public double DolomytePMPP => 100 - (DolomyteCaO + DolomyteSiO2 + DolomyteAl2O3 + DolomyteMgO);

        #endregion
    }
}
