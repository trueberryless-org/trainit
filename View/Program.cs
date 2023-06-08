using Domain.Repositories.Implementations;
using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Model.Entities;
using MudBlazor;
using MudBlazor.Services;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using View.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthenticationCore();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// then we can add the Options
// this adds services we need
builder.Services.AddOptions();

builder.Services.AddDbContextFactory<ModelDbContext>(
    options => options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 27))
    )
);

// MudBlazor
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomCenter;

    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 3000;
    config.SnackbarConfiguration.HideTransitionDuration = 200;
    config.SnackbarConfiguration.ShowTransitionDuration = 200;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});

// Repositories
builder.Services.AddScoped<ILogEntryRepository, LogEntryRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<IRoleClaimRepository, RoleClaimRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IExerciseAssetMuscleAssetRepository, ExerciseAssetMuscleAssetRepository>();
builder.Services.AddScoped<IExerciseAssetRepository, ExerciseAssetRepository>();
builder.Services.AddScoped<IExerciseMuscleAssetRepository, ExerciseMuscleAssetRepository>();
builder.Services.AddScoped<IExerciseRepository, ExerciseRepository>();
builder.Services.AddScoped<IMachineAssetRepository, MachineAssetRepository>();
builder.Services.AddScoped<IMuscleAssetRepository, MuscleAssetRepository>();
builder.Services.AddScoped<IWorkoutAssetExerciseAssetRepository, WorkoutAssetExerciseAssetRepository>();
builder.Services.AddScoped<IWorkoutAssetRepository, WorkoutAssetRepository>();
builder.Services.AddScoped<IWorkoutExerciseRepository, WorkoutExerciseRepository>();
builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();

builder.Services.AddScoped<CircuitHandler, CircuitTracker>();

builder.Services.AddScoped<EventProvider>();
builder.Services.AddScoped<NavigationProvider>();
builder.Services.AddScoped<DateManager>();
builder.Services.AddScoped<ThemeProvider>();
builder.Services.AddScoped<BrowserService>();
builder.Services.AddScoped<FuzzySearch>();

builder.Services.AddLogging(); // the default Logger

builder.Services.AddHttpContextAccessor(); // this services enables us to access to HttpContext of our App

builder.Services
    .AddScoped<AuthenticationStateProvider,
        CustomAuthStateProvider>(); // we register our implementation of the AuthenticationStateProvider
builder.Services.AddScoped<UserService>(); // The UserService we use to login/register/logout

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<ModelDbContext>();

    try
    {
        context.Database.EnsureCreated();
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
        else
        {
            // Create a new migration
            var migrator = context.Database.GetService<IMigrator>();
            migrator.Migrate();
        }
    }
    catch
    {
        // ignored
    }
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();