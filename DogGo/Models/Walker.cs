using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models
{
    public class Walker
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Hmmm... You should really add a Name...")]
        [MaxLength(35)]
        public string Name { get; set; }

        [DisplayName("Neighborhood Id")]
        public int NeighborhoodId { get; set; }
        [Required(ErrorMessage = "Please add a profile photo.")]
        public string ImageUrl { get; set; }
        public Neighborhood Neighborhood { get; set; }
    }
}
