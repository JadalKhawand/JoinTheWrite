using JoinTheWrite.Data;
using JoinTheWrite.Mappings;
using JoinTheWrite.Services.WritingsService.ChapterServices;
using JoinTheWrite.Services.WritingsService.CommentServices;
using JoinTheWrite.Services.WritingsService.ContributionServices;
using JoinTheWrite.Services.WritingsService.CreationServices;
using JoinTheWrite.Services.WritingsService.VoteServices;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ICreationService, CreationService>();
builder.Services.AddScoped<IChapterService, ChapterService>();
builder.Services.AddScoped<IContributionService, ContributionService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IVoteService, VoteService>();
//builder.Services.AddHostedService<VotingFinalizerService>();



builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddHttpClient();
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
