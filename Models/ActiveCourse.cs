using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace application_api.Models
{
    public class ActiveCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }
        [Required(ErrorMessage = "Course code is required")]
        public string CourseCode { get; set; }
        [Required(ErrorMessage = "Course name is required")]
        public string CourseName { get; set; }
        [Required(ErrorMessage = "Course description is required")]
        public string CourseDescription { get; set; }
        [Required(ErrorMessage = "Course venue is required")]
        public string TrainingVenueSelected { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public bool isTrainingFreeOrPaid { get; set; }
    }
}
