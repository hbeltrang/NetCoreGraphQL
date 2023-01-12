using Microsoft.EntityFrameworkCore;
using WebApiGraphQL.DBContext;
using WebApiGraphQL.Querys;
using WebApiGraphQL.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//DB SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDbInitializer, DbInitializer>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//GraphQL
//builder.Services.AddGraphQLServer().AddQueryType<ProductQuery>().AddProjections().AddFiltering().AddSorting();
builder.Services.AddGraphQLServer().RegisterDbContext<ApplicationDbContext>(DbContextKind.Pooled)
    .AddQueryType<ProductQuery>().AddProjections().AddFiltering().AddSorting();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//DataSeeding();

app.UseAuthorization();

app.MapControllers();

//GraphQL
app.MapGraphQL("/graphql");

app.Run();

//HB
void DataSeeding()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}
