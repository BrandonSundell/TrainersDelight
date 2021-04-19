using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TrainersDelight.Models
{
    public class Trainer
    {
        [Key]
        public int TrainerId { get; set; }

        [MaxLength(20, ErrorMessage = "Name can only be 20 characters!")]
        public string FirstName { get; set; }

        [MaxLength(20, ErrorMessage = "Name can only be 20 characters!")]
        public string LastName { get; set; }

        [MaxLength(20, ErrorMessage = "Name can only be 20 characters!")]
        public string MiddleName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Phone { get; set; }

        public DateTime DateOfBirth { get; set; }
        

    }
}
