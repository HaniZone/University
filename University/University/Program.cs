using Airport.Api.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using University.Application.Services;
using University.Application.Services.Interface;
using University.Core.Repositories.Interfaces;
using University.Infrastructure.Configurations;
using University.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();

builder.Services.AddScoped<IStudentRepository, EfStudentRepository>();
builder.Services.AddScoped<IStudentApplicationService, StudentApplicationService>();

builder.Services.AddScoped<ICourseRepository, EfCourseRepository>();
builder.Services.AddScoped<ICourseApplicationService, CourseApplicationService>();

builder.Services.AddScoped<IFieldRepository, EfFieldRepository>();
builder.Services.AddScoped<IFieldApplicationService, FieldApplicationService>();

builder.Services.AddScoped<ISelectUnitCourseRepository, EfSelectUnitCourseRepository>();
builder.Services.AddScoped<ISelectUnitCourseApplicationService, SelectUnitCourseApplicationService>();

builder.Services.AddScoped<ISelectUnitRepository, EfSelectUnitRepository>();
builder.Services.AddScoped<ISelectUnitApplicationService, SelectUnitApplicationService>();

builder.Services.AddScoped<IStudentCourseRepository, EfStudentCourseRepository>();
builder.Services.AddScoped<IStudentCourseApplicationService, StudentCourseApplicationService>();

builder.Services.AddScoped<ITeacherRepository, EfTeacherRepository>();
builder.Services.AddScoped<ITeacherApplicationService, TeacherApplicationService>();

builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<IUserApplicationService, UserApplicationService>();

builder.Services.AddDbContext<DatabaseContext>(x => x.UseSqlServer("Data Source=DESKTOP-S4HQQQE;Initial Catalog=University.Api;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;"));
//builder.Services.AddDbContext<DatabaseContext>(x => x.UseSqlServer("Data Source=DESKTOP-S4HQQQE;Initial Catalog=Airport.Api1;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ExceptionsMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
