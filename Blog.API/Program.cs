using Blog.Application.Commands.BlogPosts.CreateBlogPost;
using Blog.Application.Commands.BlogPosts.DeleteBlogPost;
using Blog.Application.Commands.BlogPosts.UpdateBlogPost;
using Blog.Application.Commands.Comments.AddComment;
using Blog.Application.Interfaces;
using Blog.Application.Queries;
using Blog.Application.Queries.QueryHandlers;
using Blog.Domain.Entities;
using Blog.Infrastructure.Persistence;
using Blog.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BlogDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<DbContext, BlogDbContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICommandHandler<CreateBlogPostCommand>, CreateBlogPostCommandHandler>();
builder.Services.AddScoped<ICommandHandler<AddCommentCommand>, AddCommentCommandHandler>();
builder.Services.AddScoped<IQueryHandler<GetBlogPostByIdQuery, BlogPost>, GetBlogPostByIdQueryHandler>();
builder.Services.AddScoped<IRepository<BlogPost>, BlogPostRepository>();
builder.Services.AddScoped<ICommandHandler<UpdateBlogPostCommand>, UpdateBlogPostCommandHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteBlogPostCommand>, DeleteBlogPostCommandHandler>();
builder.Services.AddTransient<IValidator<CreateBlogPostCommand>, CreateBlogPostCommandValidator>();


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