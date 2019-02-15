using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CoreExample.Models;
using CoreExample.Website.Models;

namespace CoreExample.Website.Extensions
{
    public static class SuperHeroExtensions
    {
        public static IEnumerable<SuperHeroViewModel> ToViewModel(this IEnumerable<SuperHero> model)
        {
            return model.Select(Mapper.Map<SuperHero, SuperHeroViewModel>).ToList();
        }
    }
}