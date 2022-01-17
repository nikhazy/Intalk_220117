using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intalk_220117.Data
{
    public class ApplicationDbService
    {
        private readonly ApplicationDbContext _db;

        public ApplicationDbService(ApplicationDbContext db)
        {
            _db = db;
            _db.Database.EnsureCreated();
        }


        public List<Ember> GetAllEmber()
        {
            var emberList = _db.Emberek.ToList();
            return emberList;
        }

        public void AddOrUpdateEmber(Ember ember)
        {
            if (ember.Id == 0)
            {
                _db.Emberek.Add(ember);
            }
            else
            {
                _db.Emberek.Update(ember);
            }
            _db.SaveChanges();
        }


        public bool DeleteEmber(int id)
        {
            var part = _db.Emberek.FirstOrDefault(x => x.Id == id);
            if (_db.Kapcsolotabla.Where(x => x.EmberId == id || x.ApjaId == id || x.AnyjaId == id).Count() == 0)
            {
                _db.Emberek.Remove(part);
                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Ember> GetAllUnusedEmber()
        {
            List<Kapcsolat> kapcsolatok = _db.Kapcsolotabla.ToList();
            List<Ember> emberek = _db.Emberek.ToList();
            List<Ember> result = new List<Ember>();
            foreach (var ember in emberek)
            {
                if(kapcsolatok.Where(x=>x.EmberId == ember.Id).Count() == 0)
                {
                    result.Add(ember);
                }
            }
            return result;
        }

        public void AddKapcsolat(Kapcsolat kapcsolat)
        {
            _db.Kapcsolotabla.Add(kapcsolat);
            _db.SaveChanges();
        }
    }
}
