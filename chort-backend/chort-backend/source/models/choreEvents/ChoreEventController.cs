using chort_backend.source.data.abstractions;
using chort_backend.source.data.entities;
using chort_backend.source.utilities;
using Newtonsoft.Json;

namespace chort_backend.source.models.choreEvents
{
    public class ChoreEventController : CrudController<ChoreEvents>
    {
        public ChoreEventController(ChoreEventRepository repository, WebApplication app)
        {
            if (_repository == null)
                _repository = repository;

            app.MapGet("/choreEvents/{id}", GetHandler);
            app.MapPost("/choreEvents", PostHandler);
            app.MapPut("/choreEvents", PutHandler);
            app.MapDelete("/choreEvents/{id}", DeleteHandler);
        }
    }
}
