using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlagSolverLibrary
{
    public class SlagSolverData
    {
        public double CaO { get; set; }

        public double SiO2 { get; set; }

        public double Al2O3 { get; set; }

        public double MgO { get; set; }

        public double K_b { get; set; }
        public double K_a { get; set; }

        public double Osnovnost1 
        { 
            get
            {
                return (CaO / SiO2);
            }
        }

        public double Osnovnost2
        {
            get
            {
                return ((CaO + MgO) / SiO2);
            }
        }

        public double Osnovnost3
        {
            get
            {
                return ((CaO + MgO) / (SiO2 + Al2O3));
            }
        }

        public double Viscosity_1350 
        { 
            get
            {
                return Math.Pow(10, Math.Pow(10, K_a + K_b * 1350));
            }
        }

        public double Viscosity_1400
        {
            get
            {
                return Math.Pow(10, Math.Pow(10, K_a + K_b * 1400));
            }
        }

        public double Viscosity_1450
        {
            get
            {
                return Math.Pow(10, Math.Pow(10, K_a + K_b * 1450));
            }
        }

        public double Viscosity_1500
        {
            get
            {
                return Math.Pow(10, Math.Pow(10, K_a + K_b * 1500));
            }
        }

        public double Viscosity_1550
        {
            get
            {
                return Math.Pow(10, Math.Pow(10, K_a + K_b * 1550));
            }
        }

        public double Temp_7_puaz
        {
            get
            {
                return (K_a - Math.Log10(Math.Log10(7))) / (-1 * K_b);
            }
        }
                
        public double Temp_25_puaz 
        { 
            get 
            { 
                return (K_a - Math.Log10(Math.Log10(25))) / (-1 * K_b); 
            } 
        }

        public double Gradient_7_25 
        { 
            get
            { 
                return (25 - 7) / (Temp_7_puaz - Temp_25_puaz); 
            }
        }

        public double Gradient_1400_1500
        {
            get
            {
                return (Viscosity_1400 - Viscosity_1500) / 100d;
            }
        }

        public double CaO_In3
        {
            get
            {
                return CaO * 100 / (CaO + SiO2 + Al2O3);
            }
        }

        public double SiO2_In3
        {
            get
            {
                return SiO2 * 100 / (CaO + SiO2 + Al2O3);
            }
        }

        public double Al2O3_In3
        {
            get
            {
                return Al2O3 * 100 / (CaO + SiO2 + Al2O3);
            }
        }

        public double OsnovnostKulikovAlfa
        {
            get
            {
                return (1.84 * SiO2 - 0.9 * CaO) / (SiO2 + 0.9 * MgO);
            }
        }

        public double OsnovnostKulikov
        {
            get
            {
                return (CaO + OsnovnostKulikovAlfa * MgO) / (SiO2 + 0.6 * Al2O3 * ((CaO + OsnovnostKulikovAlfa * MgO) / SiO2 - 1.19));
            }
        }

        public SlagSolverData(double CaO, double SiO2, double Al2O3, double MgO, double K_b, double K_a)
        {
            this.CaO = CaO;
            this.SiO2 = SiO2;
            this.Al2O3 = Al2O3;
            this.MgO = MgO;
            this.K_b = K_b;
            this.K_a = K_a;
        }
    }
}
