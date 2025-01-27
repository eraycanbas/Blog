using Blog.Application.Commands.BlogPosts.CreateBlogPost;
using Blog.Application.Interfaces;
using Blog.Infrastructure.Persistence;
using Blog.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DbContext, BlogDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMediator, Mediator>();

builder.Services.AddScoped<IValidator<CreateBlogPostCommand>, CreateBlogPostCommandValidator>();
builder.Services.AddScoped<IRequestHandler<CreateBlogPostCommand, int>, CreateBlogPostCommandHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();