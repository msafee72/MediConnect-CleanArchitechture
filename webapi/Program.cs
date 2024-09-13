using Application.Interface;
using Application.Service;
using Application;
using Core.Interfaces;
using Infrastructure;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Add JWT authentication
var key = Encoding.ASCII.GetBytes("your-secret-key"); // Replace with your actual secret key

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});




builder.Services.AddMemoryCache();

builder.Services.AddScoped<IDoctorRepository, DoctorRepository>(provider =>
    new DoctorRepository(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;"));

builder.Services.AddScoped<ILaboratorianRepository, LaboratorianRepository>(provider =>
    new LaboratorianRepository(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;"));

builder.Services.AddScoped<ILabResultRepository, LabResultRepository>(provider =>
    new LabResultRepository(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;"));

builder.Services.AddScoped<ILabTestRepository, LabTestRepository>(provider =>
    new LabTestRepository(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;"));

builder.Services.AddScoped<IPatientRepository, PatientRepository>(provider =>
    new PatientRepository(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;"));

builder.Services.AddScoped<IPrescriptionRepository, PrescriptionRepository>(provider =>
    new PrescriptionRepository(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MedConnectDB;Integrated Security=True;"));




// Register services
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<ILaboratorianService, LaboratorianService>();
builder.Services.AddScoped<ILabTestService, LabTestService>();
builder.Services.AddScoped<ILabResultService, LabResultService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();



builder.Services.AddScoped<IFileStorageService>(provider =>
{
    // Retrieve the storage path from configuration
    var storagePath = builder.Configuration.GetValue<string>("FileStoragePath") ?? "D:\\University\\6th Semester\\SCD\\Medi-Connect (Clean-Architechture)\\Web\\wwwroot\\uploads\\";
    return new FileStorageService(storagePath);
});





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
