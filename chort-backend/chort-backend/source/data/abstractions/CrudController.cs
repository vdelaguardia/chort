using chort_backend.source.utilities;
using Newtonsoft.Json;

namespace chort_backend.source.data.abstractions
{
    public class CrudController<T>
    {
        protected static IRepository<T> _repository;

        protected Delegate GetHandler = (HttpContext context, string id) =>
        {
            T model = _repository.Get(id);
            string body = JsonConvert.SerializeObject(model);
            return context.Response.WriteAsync(body);
        };

        protected Delegate PostHandler = async (HttpContext context) =>
        {
            string body = await context.Json();
            T model = JsonConvert.DeserializeObject<T>(body);
            _repository.Post(model);
        };

        protected Delegate PutHandler = async (HttpContext context) =>
        {
            string body = await context.Json();
            T model = JsonConvert.DeserializeObject<T>(body);
            _repository.Put(model);
        };

        protected Delegate DeleteHandler = async (HttpContext context, string id) =>
        {
            _repository.Delete(id);
        };
    }
}
