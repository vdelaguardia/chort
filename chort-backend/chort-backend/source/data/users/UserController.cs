namespace chort_backend.source.data
{
    public class UserController
    {
        public UserController(WebApplication app)
        {
            app.MapGet("/user/{id}", GetHandler);
        }

        Delegate GetHandler = (HttpContext context) =>
        {

        };
    }
}
