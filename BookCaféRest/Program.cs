var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", 
        builder => builder.AllowAnyOrigin().
        AllowAnyHeader().
        AllowAnyMethod()
    );
    options.AddPolicy("OnlyGetDelete", 
        builder => builder.AllowAnyOrigin().
        AllowAnyHeader().
        WithMethods("Get", "Delete")
    );
}

);


var app = builder.Build();




// WHAT SERVICES ARE BEING USED **
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.UseCors("OnlyGetDelete");

app.MapControllers();

app.Run();
