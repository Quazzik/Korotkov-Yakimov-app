using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Console
{
    public class CalcLES (Shihta shihta, FluxAdditions fluxAdditions, Cocksick cocksick, StartEnter startEnter, ZolaOfCocksick zolaOfCocksick)
    {  
        private double FerumMaterial => 0.9 * shihta.TotalSMass * 0.01 + 0.01 * shihta.TotalPercentOfPMPP;
        private double Izvestnyak => fluxAdditions.IzvestnyakPMPP * 0.01;
        private double Dolomyte => fluxAdditions.DolomytePMPP * 0.01;
        private double Cocksick => 0.01 * cocksick.PercentC + 0.01 * cocksick.PercentValotiles + cocksick.PercentSera * 0.001 * 0.9;
        private double FreeMember => Cocksick * cocksick.Weight;
        private double CoefX => -0.01 * shihta.TotalFeOMass * 0.11;
        private double FreeMember2 => (startEnter.FeOinAgl - 0.01 * zolaOfCocksick.Fe * 72d / 56d * cocksick.Weight * cocksick.PercentZola / 100d) * 0.11;
        private double X1 => 1 - FerumMaterial - CoefX;
        private double Y1 => 1 - Izvestnyak;
        private double Sum1 => 100 - startEnter.DolomyteInAgl + FreeMember + FreeMember2 - cocksick.Weight;
        private double X2 => startEnter.osnovnost * shihta.TotalSiO2Mass - shihta.TotalCaOMass;
        private double Y2 => startEnter.osnovnost  * fluxAdditions.IzvestnyakSiO2 - fluxAdditions.IzvestnyakCaO;
        private double Sum2 => -((cocksick.Weight * cocksick.PercentZola / 100 * zolaOfCocksick.SiO2 * startEnter.osnovnost) - (cocksick.Weight * cocksick.PercentZola / 100 * zolaOfCocksick.CaO));

        public double ConsimtionJRM => (Sum2 - Y2 / Y1 * Sum1) / (X2 - Y2 * X1 / Y1);
        public double ConsimitionIzvestyak => (Sum1 - X1 * ConsimtionJRM) / Y1;
    }
}
