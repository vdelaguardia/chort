using chort_backend.source.data;
using chort_backend.source.data.entities;

namespace chort_backend.source.models.choreEvents
{
    public class ChoreEventRepository : IRepository<ChoreEvents>
    {
        ChortDbContext _dbContext;

        public ChoreEventRepository(ChortDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ChoreEvents Get(string id)
        {
            ChoreEvents? choreEvent = _dbContext.ChoreEvents.Find(id);

            if (choreEvent != null)
                return choreEvent;
            else
            {
                // throw error
                return null;
            }
        }

        public void Post(ChoreEvents model)
        {
            if (model.Id == null || model.Id == string.Empty)
                model.Id = Guid.NewGuid().ToString();

            _dbContext.ChoreEvents.Add(model);
            _dbContext.SaveChanges();
        }

        public void Put(ChoreEvents model)
        {
            ChoreEvents current = _dbContext.ChoreEvents.Find(model.Id);
            if (current != null)
            {
                _dbContext.ChoreEvents.Update(model);
                _dbContext.SaveChanges();
            }
            else
            {
                //throw error
            }
        }

        public void Delete(string id)
        {
            ChoreEvents model = _dbContext.ChoreEvents.Find(id);

            if (model != null)
            {
                _dbContext.ChoreEvents.Remove(model);
                _dbContext.SaveChanges();
            }
            else
            {
                // throw error
            }
        }
    }
}
