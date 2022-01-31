using chort_backend.source.data.abstractions;
using chort_backend.source.data.entities;

namespace chort_backend.source.models.households
{
    public class HouseholdController : CrudController<Households>
    {
        public HouseholdController(HouseholdRepository repository, WebApplication app)
        {
            if (_repository == null)
                _repository = repository;

            app.MapGet("/households/{id}", GetHandler);
            app.MapPost("/households", PostHandler);
            app.MapPut("/households", PutHandler);
            app.MapDelete("/households/{id}", DeleteHandler);
        }
    }
}
