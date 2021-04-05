using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainersDelight.Models
{
    public class ClientWeight
    {
        [Key]
        public int ClientId { get; set; }

        [Column(TypeName="decimal(8, 2)")]
        public decimal WeightInPounds { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfMessurment { get; set; }
    }
}
