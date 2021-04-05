using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrainersDelight.Models
{
    public class TrainerNotes
    {
        [Key]
        public int TrianerId { get; set; }

        [ForeignKey("ClientID")]
        public int ClientId { get; set; }


        public string NotesOnClient { get; set; }
    }
}
