using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class LabTest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Test Name is required.")]
        [StringLength(100, ErrorMessage = "Test Name cannot be longer than 100 characters.")]
        //[NotAllowedWords(new string[] { "badword", "spam" })]
        public string TestName { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        //[NotAllowedWords(new string[] { "badword", "spam" })]
        public string Description { get; set; }

        //[validCost()]
        public decimal Cost { get; set; }
    }

}
