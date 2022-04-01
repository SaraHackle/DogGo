using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogGo.Models.ViewModels
{
    public class WalkerFormViewModel
    {
        public Walker Walker { get; set; }
        public List<Neighborhood> Neighborhoods { get; set; }
    }
}
