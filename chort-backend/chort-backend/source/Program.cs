using chort_backend.source.data.entities;
using chort_backend.source.data.models.users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

ChortDbContext context = new ChortDbContext();

UserRepository userRepository = new UserRepository(context);
UserController userController = new UserController(userRepository, app);

app.Run();
