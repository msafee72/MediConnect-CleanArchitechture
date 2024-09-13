using Application;
using Application.Interface;
using Application.Service;
using Core.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Web.Data;
using Web.hub;
using Web.Models;
using Microsoft.AspNetCore.SignalR;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Configure Identity with your custom user class (MyUser)
builder.Services.AddDefaultIdentity<MyUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true; // Make the session cookie HTTP only
    options.Cookie.IsEssential = true; // Make the session cookie essential
});

builder.Services.AddMemoryCache();
builder.Services.AddSignalR();


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.RequireClaim(ClaimTypes.Email, "adminmc@mediconnect.com"));

    options.AddPolicy("DoctorPolicy", policy =>
        policy.RequireClaim(ClaimTypes.Email, "doctormc@mediconnect.com"));

    options.AddPolicy("LaboratorianPolicy", policy =>
        policy.RequireClaim(ClaimTypes.Email, "laboratorianmc@mediconnect.com"));
});

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



builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // Ensure this is before UseAuthorization
app.UseAuthentication(); // Ensure authentication is configured
app.UseAuthorization();







app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();


app.MapHub<ChatHub>("/ChatHub");


app.Run();
