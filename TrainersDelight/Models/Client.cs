using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainersDelight.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [ForeignKey("TrainerID")]
        public int TrainerId { get; set; }

        [MaxLength(20, ErrorMessage ="Name can only be 20 characters!")]
        public string FirstName { get; set; }

        [MaxLength(20, ErrorMessage = "Name can only be 20 characters!")]
        public string LastName { get; set; }

        [MaxLength(20, ErrorMessage = "Name can only be 20 characters!")]
        public string MiddleName { get; set; }
        public int Height { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        
        public string Phone { get; set; }


        public DateTime DateOfBirth { get; set; }
    }
}
