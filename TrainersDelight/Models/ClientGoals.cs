using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainersDelight.Models
{
    public class ClientGoals
    {
        [Key]
        public int ClientId { get; set; }

        public string Goals { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateOfMessurment { get; set; }
    }
}
