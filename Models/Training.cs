using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace application_api.Models
{
    public class Training
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TrainingID { get; set; }
        [Required(ErrorMessage = "Training name is required")]
        public string TrainingName { get; set; }
        [Required(ErrorMessage = "Training date is required")]
        public DateTime TrainingDate { get; set; }
        [Required(ErrorMessage = "Course code is required")]
        public string TrainingVenue { get; set; }
        [Required(ErrorMessage = "Course code is required")]
        public int NoOfSeatLeft { get; set; }
        [Required(ErrorMessage = "Course code is required")]
        public double TrainingCost { get; set; }
        [Required(ErrorMessage = "Course code is required")]
        public DateTime ClosingDate { get; set; }
    }
}
