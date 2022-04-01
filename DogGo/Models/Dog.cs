using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models
{
    public class Dog
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Hmmm... You should really add a Name...")]
        [MaxLength(35)]
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }

        [Required(ErrorMessage = "Please Enter the Breed of your dog")]
        [MaxLength(35)]
        public string Breed { get; set; }
        public string Notes { get; set; }
        public string ImageUrl { get; set; }

    }
}
