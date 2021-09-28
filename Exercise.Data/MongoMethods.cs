using Exercise.Domain;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Data
{
    public class MongoMethods
    {
        private static SuperHeroDbContext _context;

        public static void Init(SuperHeroDbContext context)
        {
            _context = context;
        }

        public static string AddOneSuperHero(string superHeroName)
        {
            var newSuperHero = new SuperHero { Name = superHeroName };
            _context.SuperHeroes.InsertOne(newSuperHero);
            return newSuperHero.Id;
        }

        public static void AddOneSuperHero(SuperHero hero)
        {
            _context.SuperHeroes.InsertOne(hero);
        }

        public static List<string> GetAllSuperHeroNames()
        {
            return _context.SuperHeroes.AsQueryable()
                .Select(s => s.Name)
                .ToList();
        }
        
        public static SuperHero GetSuperHero(string superHeroId)
        {
            var superHeroResult = _context.SuperHeroes.Find(s => s.Id == superHeroId)
                .ToList()
                .FirstOrDefault();

            if(superHeroResult is not { } superHero)
            {
                return null;
            }

            var realIdentityResult = _context.RealIdentities.Find(ri => ri.HeroId == superHeroId)
                .ToList()
                .FirstOrDefault();

            if (realIdentityResult is not { } realIdentity)
            {
                return superHero;
            }

            superHero.RealIdentity = realIdentity;
            return superHero;

        }

        public static void UpdateSuperHeroSetRealIdentity(string heroId, string realName)
        {
            var superhero = _context.SuperHeroes.Find(s => s.Id == heroId)
                .ToList()
                .FirstOrDefault();

            if(superhero.Id is not { } heroId)
            {
                return;
            }

            superhero.RealIdentity.RealName = realName;

        }
    }
}
