using Google.OrTools.LinearSolver;
using System.Runtime.Serialization.Json;
using System.Text;

namespace SlagSolverLibrary
{
    public class SlagSolver
    {
        public double CaO { get; set; }
        public double SiO2 { get; set; }
        public double Al2O3 { get; set; }
        public double MgO { get; set; }

        public double K_b { get; set; }
        public double K_a { get; set; }

        public List<SlagCalcDatabase> dat;

        public SlagSolverData Solve<T>(T CaO, T SiO2, T Al2O3, T MgO)
        {
            double.TryParse(CaO.ToString(), out double _CaO);
            double.TryParse(SiO2.ToString(), out double _SiO2);
            double.TryParse(Al2O3.ToString(), out double _Al2O3);
            double.TryParse(MgO.ToString(), out double _MgO);

            return Solve(_CaO, _SiO2, _Al2O3, _MgO);
        }

        public SlagSolverData Solve(double CaO, double SiO2, double Al2O3, double MgO)
        {
            this.CaO = CaO;
            this.SiO2 = SiO2;
            this.Al2O3 = Al2O3;
            this.MgO = MgO;

            var componentSum = CaO + SiO2 + Al2O3 + MgO;

            if (componentSum != 100)
            {
                CaO = CaO / componentSum * 100;
                SiO2 = SiO2 / componentSum * 100;
                Al2O3 = Al2O3 / componentSum * 100;
                MgO = MgO / componentSum * 100;
            }

            double Osnovnost1 = (CaO / SiO2);

            List<SlagCalcDatabase>[] list = new List<SlagCalcDatabase>[6];

            double[] znach_y = new double[5];
            double[] znach_y2 = new double[7];
            double[] k_Al2O3 = new double[4] { 0, 12, 5, 15 };
            double[] vyz = new double[2];

            for (int block_ras = 1; block_ras < 7; block_ras++)
            {
                double[,] data_ras = new double[3, 7];

                int[] k_MgO = new int[5] { 0, 5, 10, 15, 20 };

                for (int nomer_ras = 1; nomer_ras < 5; nomer_ras++)
                {
                    int i = 0;

                    list[nomer_ras] = dat.Where(parametr => (parametr.Block_rashet == block_ras) && (parametr.Nomer_rashet == nomer_ras)).ToList();

                    list[nomer_ras].ForEach(znach => { data_ras[0, i] = znach.x; data_ras[1, i] = znach.y; i++; });

                    Solver solver = Solver.CreateSolver("GLOP");

                    Variable a1 = solver.MakeNumVar(double.NegativeInfinity, double.PositiveInfinity, "a");
                    Variable b1 = solver.MakeNumVar(double.NegativeInfinity, double.PositiveInfinity, "b");
                    Variable c1 = solver.MakeNumVar(double.NegativeInfinity, double.PositiveInfinity, "c");
                    Variable d1 = solver.MakeNumVar(double.NegativeInfinity, double.PositiveInfinity, "d");
                    Variable e1 = solver.MakeNumVar(double.NegativeInfinity, double.PositiveInfinity, "e");
                    Variable f1 = solver.MakeNumVar(double.NegativeInfinity, double.PositiveInfinity, "f");

                    solver.Add(data_ras[1, 0] == (Math.Pow(data_ras[0, 0], 5) * a1 + Math.Pow(data_ras[0, 0], 4) * b1 + Math.Pow(data_ras[0, 0], 3) * c1 + Math.Pow(data_ras[0, 0], 2) * d1 + data_ras[0, 0] * e1 + f1));
                    solver.Add(data_ras[1, 1] == (Math.Pow(data_ras[0, 1], 5) * a1 + Math.Pow(data_ras[0, 1], 4) * b1 + Math.Pow(data_ras[0, 1], 3) * c1 + Math.Pow(data_ras[0, 1], 2) * d1 + data_ras[0, 1] * e1 + f1));
                    solver.Add(data_ras[1, 2] == (Math.Pow(data_ras[0, 2], 5) * a1 + Math.Pow(data_ras[0, 2], 4) * b1 + Math.Pow(data_ras[0, 2], 3) * c1 + Math.Pow(data_ras[0, 2], 2) * d1 + data_ras[0, 2] * e1 + f1));
                    solver.Add(data_ras[1, 3] == (Math.Pow(data_ras[0, 3], 5) * a1 + Math.Pow(data_ras[0, 3], 4) * b1 + Math.Pow(data_ras[0, 3], 3) * c1 + Math.Pow(data_ras[0, 3], 2) * d1 + data_ras[0, 3] * e1 + f1));
                    solver.Add(data_ras[1, 4] == (Math.Pow(data_ras[0, 4], 5) * a1 + Math.Pow(data_ras[0, 4], 4) * b1 + Math.Pow(data_ras[0, 4], 3) * c1 + Math.Pow(data_ras[0, 4], 2) * d1 + data_ras[0, 4] * e1 + f1));
                    solver.Add(data_ras[1, 5] == (Math.Pow(data_ras[0, 5], 5) * a1 + Math.Pow(data_ras[0, 5], 4) * b1 + Math.Pow(data_ras[0, 5], 3) * c1 + Math.Pow(data_ras[0, 5], 2) * d1 + data_ras[0, 5] * e1 + f1));

                    Solver.ResultStatus resultStatus = solver.Solve();

                    //Console.WriteLine(a1.SolutionValue());
                    znach_y[nomer_ras] = (a1.SolutionValue() * Math.Pow(Osnovnost1, 5)) + (b1.SolutionValue() * Math.Pow(Osnovnost1, 4)) + (c1.SolutionValue() * Math.Pow(Osnovnost1, 3)) + (d1.SolutionValue() * Math.Pow(Osnovnost1, 2)) + (e1.SolutionValue() * Osnovnost1) + f1.SolutionValue();
                }

                Solver solver2 = Solver.CreateSolver("GLOP");

                Variable a = solver2.MakeNumVar(double.NegativeInfinity, double.PositiveInfinity, "a");
                Variable b = solver2.MakeNumVar(double.NegativeInfinity, double.PositiveInfinity, "b");
                Variable c = solver2.MakeNumVar(double.NegativeInfinity, double.PositiveInfinity, "c");
                Variable d = solver2.MakeNumVar(double.NegativeInfinity, double.PositiveInfinity, "d");

                solver2.Add(znach_y[1] == (Math.Pow(k_MgO[1], 3) * a + Math.Pow(k_MgO[1], 2) * b + k_MgO[1] * c + d));
                solver2.Add(znach_y[2] == (Math.Pow(k_MgO[2], 3) * a + Math.Pow(k_MgO[2], 2) * b + k_MgO[2] * c + d));
                solver2.Add(znach_y[3] == (Math.Pow(k_MgO[3], 3) * a + Math.Pow(k_MgO[3], 2) * b + k_MgO[3] * c + d));
                solver2.Add(znach_y[4] == (Math.Pow(k_MgO[4], 3) * a + Math.Pow(k_MgO[4], 2) * b + k_MgO[4] * c + d));

                Solver.ResultStatus resultStatus2 = solver2.Solve();

                znach_y2[block_ras] = (a.SolutionValue() * Math.Pow(MgO, 3)) + (b.SolutionValue() * Math.Pow(MgO, 2)) + (c.SolutionValue() * MgO) + d.SolutionValue();
            }

            int key = 0;

            for (int ident = 1; ident < 7; ident += 3)
            {
                Solver solver_end = Solver.CreateSolver("GLOP");

                Variable end_a = solver_end.MakeNumVar(double.NegativeInfinity, double.PositiveInfinity, "a");
                Variable end_b = solver_end.MakeNumVar(double.NegativeInfinity, double.PositiveInfinity, "b");
                Variable end_c = solver_end.MakeNumVar(double.NegativeInfinity, double.PositiveInfinity, "c");

                solver_end.Add(znach_y2[ident] == (Math.Pow(k_Al2O3[1], 2) * end_a + k_Al2O3[1] * end_b + end_c));
                solver_end.Add(znach_y2[ident + 1] == (Math.Pow(k_Al2O3[2], 2) * end_a + k_Al2O3[2] * end_b + end_c));
                solver_end.Add(znach_y2[ident + 2] == (Math.Pow(k_Al2O3[3], 2) * end_a + k_Al2O3[3] * end_b + end_c));

                Solver.ResultStatus resultStatus2 = solver_end.Solve();

                //Console.Write(end_a.SolutionValue());
                vyz[key] = (end_a.SolutionValue() * Math.Pow(Al2O3, 2)) + (end_b.SolutionValue() * Al2O3) + end_c.SolutionValue();
                key++;
            }

            K_b = (-0.01) * (Math.Log10(Math.Log10(vyz[0])) - Math.Log10(Math.Log10(vyz[1])));
            K_a = Math.Log10(Math.Log10(vyz[1])) - 1500 * K_b;

            return new SlagSolverData(this.CaO, this.SiO2, this.Al2O3, this.MgO, K_b, K_a);
        }

        public SlagSolver()
        {
            //List<SlagCalcDatabase> jsonDatabase = new List<SlagCalcDatabase>();

            byte[] byteArray = Encoding.UTF8.GetBytes(Resources.JsonDatabaseString);
            MemoryStream stream = new MemoryStream(byteArray);

            DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(List<SlagCalcDatabase>));
            List<SlagCalcDatabase> jsonDatabase = (List<SlagCalcDatabase>)jsonFormatter.ReadObject(stream);

            dat = jsonDatabase;
        }
    }
}
