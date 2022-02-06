using chort_backend.source.data;
using chort_backend.source.data.entities;

namespace chort_backend.source.models.scheduledChores
{
    public class ScheduledChoreRepository : IRepository<ScheduledChores>
    {
        ChortDbContext _dbContext;

        public ScheduledChoreRepository(ChortDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ScheduledChores Get(string id)
        {
            ScheduledChores? model = _dbContext.ScheduledChores.Find(id);

            if (model != null)
                return model;
            else
            {
                // throw error
                return null;
            }
        }

        public void Post(ScheduledChores model)
        {
            if (model.Id == null || model.Id == string.Empty)
                model.Id = Guid.NewGuid().ToString();

            _dbContext.ScheduledChores.Add(model);
            _dbContext.SaveChanges();
        }

        public void Put(ScheduledChores model)
        {
            ScheduledChores current = _dbContext.ScheduledChores.Find(model.Id);
            if (current != null)
            {
                _dbContext.ScheduledChores.Update(model);
                _dbContext.SaveChanges();
            }
            else
            {
                //throw error
            }
        }

        public void Delete(string id)
        {
            ScheduledChores model = _dbContext.ScheduledChores.Find(id);

            if (model != null)
            {
                _dbContext.ScheduledChores.Remove(model);
                _dbContext.SaveChanges();
            }
            else
            {
                // throw error
            }
        }
    }
}
