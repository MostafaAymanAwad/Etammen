using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Repositories;
using DataAccessLayerEF.Context;
using DataAccessLayerEF.Models;

using Etammen.MappingProfile;

using Etammen.Mapping.ClinicForAdmin;
using Etammen.Mapping.DoctorForAdmin;
using Etammen.Mapping.PatientForAdmin;
using Etammen.Mapping_Profiles;
using Etammen.Settings;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Etammen.Mapping;
using Etammen.Services.ServicesConfigurations;
using Etammen.Services.Email;
using Microsoft.AspNetCore.Authentication.Cookies;
using BusinessLogicLayer.Services.SMS;
using BusinessLogicLayer.Services.ServicesConfigurations;
using Etammen.Helpers;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(jsonOptions =>
{
    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
});



builder.Services.AddDbContext<EtammenDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
        , b => b.MigrationsAssembly(typeof(EtammenDbContext).Assembly.FullName));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
    options.SignIn.RequireConfirmedEmail = true;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";

}).AddEntityFrameworkStores<EtammenDbContext>()
  .AddDefaultTokenProviders()
  .AddTokenProvider<EmailConfirmationTokenProvider<ApplicationUser>>("emailconfirmation")
  .AddRoles<IdentityRole>();


builder.Services.Configure<EmailConfirmationTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromDays(7);
});

builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
{
    options.TokenLifespan = TimeSpan.FromHours(2);
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
{
    options.Cookie.Expiration = TimeSpan.FromDays(14);
});

builder.Services.AddAuthentication().AddFacebook("facebook", options =>
{
    var facebookAuth = builder.Configuration.GetSection("Authentication:Facebook");
    options.ClientId = facebookAuth["AppId"];
    options.ClientSecret = facebookAuth["AppSecret"];
    options.SignInScheme = IdentityConstants.ExternalScheme;
});

builder.Services.AddAuthentication().AddGoogle("google", options =>
{
    var googleAuth = builder.Configuration.GetSection("Authentication:Google");
    options.ClientId = googleAuth["ClientId"];
    options.ClientSecret = googleAuth["ClientSecret"];
    options.SignInScheme = IdentityConstants.ExternalScheme;
});



builder.Services.Configure<EmailConfiguration>(builder.Configuration.GetSection("EmailConfiguration"));
builder.Services.Configure<SmsConfiguration>(builder.Configuration.GetSection("Twillio"));
builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("StripeConfiguration"));



builder.Services.AddTransient<IEmailService,EmailService>();
builder.Services.AddTransient<ISmsService, SmsService>();



builder.Services.AddTransient<DoctorRegisterationHelper>();
builder.Services.AddTransient<AccountMapper>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();



builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IClinicRepository, ClinicRepository>();
builder.Services.AddScoped<IApplicationUser, ApplicationUserRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IDoctorReviewsRepository, DoctorReviewsRepository>();
 

//Admin Services
builder.Services.AddScoped<DoctorsAdminMapper>();
builder.Services.AddScoped<ClinicAdminMapper>();
builder.Services.AddScoped<PatientForAdminMapper>();
builder.Services.AddScoped<DoctorReviewMapping>();
builder.Services.AddScoped<DoctorDetailsMapping>();
builder.Services.AddScoped<ClinicDetailsForDoctorPageMapper>();


builder.Services.Configure<TwilioSettings>(builder.Configuration.GetSection("Twilio"));
builder.Services.AddTransient<ISmsService, SmsService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Patient}/{action=Search}/{id?}");

app.Run();
