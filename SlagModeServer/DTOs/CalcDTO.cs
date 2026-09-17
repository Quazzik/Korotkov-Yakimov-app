using SlagModeServer.entities.NewStructure;

namespace SlagModeServer.DTOs
{
    public class CalcDTO
    {
        public VariantsParameter parameters { get; set; } //Создать одноименные DTO только с нужными полями. В дальнейшем нужно будет конвертировать в VariantsParameter DTO

        public List<VariantCharges> Charges { get; set; } //Создать одноименные DTO только с нужными полями
    }
}
