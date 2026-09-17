namespace SlagModeServer.DTOs
{
    public class OldParametersDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string VariantName { get; set; }

        public string DateVariant { get; set; }

        public string BFName { get; set; }

        public InputCastIronForCalc Iron { get; set; }

        public InputSlagForCalc Slag { get; set; }

        //public double SlagCaO { get; set; }

        //public double SlagSiO2 { get; set; }

        //public double SlagTiO2 { get; set; }

        public InputCokeForCalcs Coke { get; set; }

        /*
        public double CokeConsumption { get; set; }

        public double CokeS { get; set; }

        public double CokeAsh { get; set; }

        public double CokeAshCaO { get; set; }

        public double CokeAshSiO2 { get; set; }

        public double CokeAshAl2O3 { get; set; }

        public double CokeAshMgO { get; set; }
        */

        public List<ChargesDTO> Components { get; set; }
    }
}
