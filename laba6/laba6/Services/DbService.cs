using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;
using laba6.Models;

namespace laba6.Services
{
    public class DbService
    {
        private ApplicationContext _db;

        public DbService(ApplicationContext context)
        {
            _db = context;
        }

        public List<PrepareFuels> ListPriceClass()
        {
            //IQueryable<PriceFuels> priceFuels = from type in _db.TypeGSMs
            //                                    join price in _db.Prices
            //                                    on type.Id equals price.TypeGSMId
            //                                    select new PriceFuels(type.subject, price.Cost, price.Date, type.Id);
            //return priceFuels.ToList();
            IQueryable<PrepareFuels> fuels = from ClassType in _db.ClassTypes
                                             select new PrepareFuels(ClassType.Id, ClassType.Name);
            return fuels.ToList();
        }

        public List<Class> FindPriceClassById(int id)
        {
            //IQueryable<PriceFuels> priceFuels = from type in _db.TypeGSMs
            //                                    join price in _db.Prices
            //                                    on type.Id equals price.TypeGSMId
            //                                    where type.Id == id
            //                                    select new PriceFuels(type.subject, price.Cost, price.Date, type.Id);
            //return priceFuels.First();
            var Classes = _db.Classes.Where((Class) => Class.ClassTypeId == id);
            return Classes.ToList();
        }

        public void DeletePriceClass(int id)
        {
            //var fuel = _db.TypeGSMs.First((type) => type.Id == id);
            //_db.TypeGSMs.Remove(fuel);
            //_db.SaveChanges();
            var Classes = _db.Classes.Where((Class) => Class.ClassTypeId == id);
            foreach(var Class in Classes) _db.Classes.Remove(Class);
            _db.SaveChanges();
        }

        public void UpdatePriceClass(int id, UpdateModel priceFuels)
        {
            var Classes = _db.Classes.Where((Class) => Class.ClassTypeId == id);
            foreach (var Class in Classes)
            {
                Class.ClassTypeId = priceFuels.ClassTypeId;
                Class.ClassLead = priceFuels.ClassLead;
                _db.Classes.Update(Class);
            }
            _db.SaveChanges();
            //var fuel = _db.TypeGSMs.First((type) => type.Id == id);
            //var prices = _db.Prices.First((price) => price.TypeGSMId == id);

            //fuel.subject = priceFuels.Type;
            //prices.Cost = priceFuels.Price;

            //_db.TypeGSMs.Update(fuel);
            //_db.Prices.Update(prices);
            //_db.SaveChanges();
        }

        public void PostPriceClass(PriceBody value)
        {
            Class Class = new Class();
           
            Class.Date = new DateTime();
            Class.ClassTypeId = value.id;
            _db.Classes.Add(Class);
            _db.SaveChanges();
        }
    }
}
