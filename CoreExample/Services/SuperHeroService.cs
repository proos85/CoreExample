using System.Collections.Generic;
using CoreExample.Models;

namespace CoreExample.Website.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        public IEnumerable<SuperHero> GetSuperHeroes()
        {
            return new List<SuperHero>
            {
                new SuperHero
                {
                    HeroName = "Batman",
                    HeroAge = 50
                },
                new SuperHero
                {
                    HeroName = "Superman",
                    HeroAge = 40
                },
                new SuperHero
                {
                    HeroName = "Spider-man",
                    HeroAge = 18
                }
            };
        }
    }
}