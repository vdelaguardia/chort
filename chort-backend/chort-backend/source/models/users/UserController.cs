using chort_backend.source.data.abstractions;
using chort_backend.source.data.entities;
using chort_backend.source.utilities;
using Newtonsoft.Json;

namespace chort_backend.source.data.models.users
{
    public class UserController : CrudController<Users>
    {
        protected static new UserRepository _repository;
        public UserController(UserRepository repository, WebApplication app)
        {
            if (_repository == null)
                _repository = repository;

            app.MapGet("/users/{id}", GetHandler);
            app.MapGet("/users/email/{email}", GetUserByEmailHandler);
            app.MapPost("/users", PostHandler);
            app.MapPut("/users", PutHandler);
            app.MapDelete("/users/{id}", DeleteHandler);
        }

        protected Delegate GetUserByEmailHandler = (HttpContext context, string email) =>
        {
            Users model = _repository.GetUserByEmail(email);
            string body = JsonConvert.SerializeObject(model);
            return context.Response.WriteAsync(body);
        };
    }
}
