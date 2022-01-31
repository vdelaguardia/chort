using chort_backend.source.data.abstractions;
using chort_backend.source.data.entities;
using chort_backend.source.utilities;
using Newtonsoft.Json;

namespace chort_backend.source.models.scheduledChores
{
    public class ScheduledChoreController : CrudController<ScheduledChores>
    {
        public ScheduledChoreController(ScheduledChoreRepository repository, WebApplication app)
        {
            if (_repository == null)
                _repository = repository;

            app.MapGet("/scheduledChores/{id}", GetHandler);
            app.MapPost("/scheduledChores", PostHandler);
            app.MapPut("/scheduledChores", PutHandler);
            app.MapDelete("/scheduledChores/{id}", DeleteHandler);
        }
    }
}
