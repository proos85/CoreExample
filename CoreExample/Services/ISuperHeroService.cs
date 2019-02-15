using System.Collections.Generic;
using CoreExample.Models;

namespace CoreExample.Website.Services
{
    public interface ISuperHeroService
    {
        IEnumerable<SuperHero> GetSuperHeroes();
    }
}