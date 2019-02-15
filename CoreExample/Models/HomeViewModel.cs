using System.Collections.Generic;

namespace CoreExample.Website.Models
{
    public class HomeViewModel
    {
        public IEnumerable<SuperHeroViewModel> SuperHeros { get; set; } = new List<SuperHeroViewModel>();
    }
}