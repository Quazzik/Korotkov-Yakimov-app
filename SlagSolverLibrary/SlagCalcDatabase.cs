using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SlagSolverLibrary
{
    [DataContract]
    public class SlagCalcDatabase
    {
        //[Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int Block_rashet { get; set; }

        [DataMember]
        public int Nomer_rashet { get; set; }

        [DataMember]
        public int Temperature { get; set; }

        [DataMember]
        public int Glinozem { get; set; }

        [DataMember]
        public int K_MgO { get; set; }

        [DataMember]
        public double x { get; set; }

        [DataMember]
        public double y { get; set; }
    }
}
