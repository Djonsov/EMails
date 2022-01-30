using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationContext>(opt => opt.UseSqlite("Data source=emails.db"));
var emailConfig = builder.Configuration
        .GetSection(MailSettingsOptions.MailSettings)
        .Get<MailSettingsOptions>();
builder.Services.AddSingleton(emailConfig);
builder.Services.AddTransient<IEmailSender, EmailSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
