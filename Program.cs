using BlogAPI.BLL.Services.Abstract;
using BlogAPI.BLL.Services.Implementations;
using BlogAPI.DAL.Repositories.Abstract;
using BlogAPI.DAL.Repositories.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPostsRepository, PostsRepository>();

builder.Services.AddScoped<IPostService, PostService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
