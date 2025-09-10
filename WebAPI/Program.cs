using Infrastructure.Data;
using Infrastructure.Interfaces;
using Infrastructure.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IClapService, ClapService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<DataContext>();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(s=>s.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
}



app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
app.Run();

