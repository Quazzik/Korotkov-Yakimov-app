using UBFBaseLibrary;

namespace SlagModeServer.DTOs
{
    public class InputKal
    {
        //public InputCokeForCalcs CokeParameters { get; set; }

        public InputCokeForCalcs Coke { get; set; }

        public InputCastIronForCalc Iron { get; set; }

        public InputSlagForCalc Slag { get; set; }

        //public InputSlagForCalc SlagParameters { get; set; }

        public List<InputChargeComponentsForCalc> Components { get; set; }
    }
}
