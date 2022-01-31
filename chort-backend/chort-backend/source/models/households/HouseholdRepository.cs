using chort_backend.source.data;
using chort_backend.source.data.entities;

namespace chort_backend.source.models.households
{
    public class HouseholdRepository : IRepository<Households>
    {
        ChortDbContext _dbContext;

        public HouseholdRepository(ChortDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Households Get(string id)
        {
            Households? model = _dbContext.Households.Find(id);

            if (model != null)
                return model;
            else
            {
                // throw error
                return null;
            }
        }

        public void Post(Households model)
        {
            if (model.Id == null || model.Id == string.Empty)
                model.Id = Guid.NewGuid().ToString();

            _dbContext.Households.Add(model);
            _dbContext.SaveChanges();
        }

        public void Put(Households model)
        {
            Households current = _dbContext.Households.Find(model.Id);
            if (current != null)
            {
                _dbContext.Households.Update(model);
                _dbContext.SaveChanges();
            }
            else
            {
                //throw error
            }
        }

        public void Delete(string id)
        {
            Households model = _dbContext.Households.Find(id);

            if (model != null)
            {
                _dbContext.Households.Remove(model);
                _dbContext.SaveChanges();
            }
            else
            {
                // throw error
            }
        }
    }
}
