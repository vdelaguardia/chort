using chort_backend.source.data.entities;

namespace chort_backend.source.data.models.users
{
    public class UserRepository : IRepository<Users>
    {
        ChortDbContext _dbContext;

        public UserRepository(ChortDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Users Get(string id)
        {
            Users? user = _dbContext.Users.Find(id);

            if (user != null)
                return user;
            else
            {
                // throw error
                return null;
            }
        }

        public Users GetUserByEmail(string email)
        {
            Users? user = _dbContext.Users.Find(email);

            if (user != null)
                return user;
            else
            {
                // throw error
                return null;
            }
        }

        public void Post(Users model)
        {
            if (model.Id == null || model.Id == string.Empty) 
                model.Id = Guid.NewGuid().ToString();

            _dbContext.Users.Add(model);
            _dbContext.SaveChanges();
        }

        public void Put(Users model)
        {
            Users current = _dbContext.Users.Find(model.Id);
            if (current != null)
            {
                current.Email = model.Email;

                _dbContext.Users.Update(model);
                _dbContext.SaveChanges();
            }
            else
            {
                //throw error
            }
        }

        public void Delete(string id)
        {
            Users user = _dbContext.Users.Find(id);

            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
            else
            {
                // throw error
            }
        }
    }
}
