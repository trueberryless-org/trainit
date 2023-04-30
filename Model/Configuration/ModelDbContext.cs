using Model.Entities;
using Model.Entities.Assets;
using Model.Entities.Authentication;
using Model.Entities.Log;
using Model.Entities.per_User;

namespace Model.Configuration;

public class ModelDbContext : DbContext
{
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseMuscleAsset> ExerciseMuscleAssets { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
    public DbSet<ExerciseAsset> ExerciseAssets { get; set; }
    public DbSet<ExerciseAssetMuscleAsset> ExerciseAssetMuscleAssets { get; set; }
    public DbSet<MachineAsset> MachineAssets { get; set; }
    public DbSet<MuscleAsset> MuscleAssets { get; set; }
    public DbSet<WorkoutAsset> WorkoutAssets { get; set; }
    public DbSet<WorkoutAssetExerciseAsset> WorkoutAssetExerciseAssets { get; set; }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleClaim> RoleClaims { get; set; }
    public DbSet<LogEntry> LogEntries { get; set; }
    
    public ModelDbContext(DbContextOptions<ModelDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // ENUMS
        modelBuilder.Entity<LogEntry>()
            .Property(le => le.FieldType)
            .HasConversion<string>();
        
        // FOREIGN KEYS
        
        // per User
        modelBuilder.Entity<Activity>()
            .HasOne(a => a.Exercise)
            .WithMany(e => e.Activities)
            .HasForeignKey(a => a.ExerciseId);
        
        modelBuilder.Entity<Exercise>()
            .HasOne(e => e.User)
            .WithMany(u => u.Exercises)
            .HasForeignKey(e => e.UserId);
        
        modelBuilder.Entity<ExerciseMuscleAsset>()
            .HasOne(eml => eml.Exercise)
            .WithMany(e => e.ExerciseMuscleAssets)
            .HasForeignKey(eml => eml.ExerciseId);
        
        modelBuilder.Entity<Workout>()
            .HasOne(w => w.User)
            .WithMany(u => u.Workouts)
            .HasForeignKey(w => w.UserId);
        
        modelBuilder.Entity<WorkoutExercise>()
            .HasOne(we => we.Exercise)
            .WithMany(e => e.WorkoutExercises)
            .HasForeignKey(we => we.ExerciseId);
        
        modelBuilder.Entity<WorkoutExercise>()
            .HasOne(we => we.Workout)
            .WithMany(w => w.WorkoutExercises)
            .HasForeignKey(we => we.WorkoutId);
        
        // per User - Asset
        modelBuilder.Entity<Exercise>()
            .HasOne(e => e.MachineAsset)
            .WithMany()
            .HasForeignKey(e => e.MachineAssetId);
        
        modelBuilder.Entity<ExerciseMuscleAsset>()
            .HasOne(eml => eml.MuscleAsset)
            .WithMany()
            .HasForeignKey(eml => eml.MuscleAssetId);
        
        // Asset
        modelBuilder.Entity<ExerciseAsset>()
            .HasOne(el => el.MachineAsset)
            .WithMany(ml => ml.ExerciseAssets)
            .HasForeignKey(el => el.MachineAssetId);
        
        modelBuilder.Entity<ExerciseAssetMuscleAsset>()
            .HasOne(elml => elml.ExerciseAsset)
            .WithMany(el => el.ExerciseAssetMuscleAssets)
            .HasForeignKey(elml => elml.ExerciseAssetId);
        
        modelBuilder.Entity<ExerciseAssetMuscleAsset>()
            .HasOne(elml => elml.MuscleAsset)
            .WithMany(ml => ml.ExerciseAssetMuscleAssets)
            .HasForeignKey(elml => elml.MuscleAssetId);
        
        modelBuilder.Entity<WorkoutAssetExerciseAsset>()
            .HasOne(wlel => wlel.ExerciseAsset)
            .WithMany(el => el.WorkoutAssetExerciseAssets)
            .HasForeignKey(wlel => wlel.ExerciseAssetId);
        
        modelBuilder.Entity<WorkoutAssetExerciseAsset>()
            .HasOne(wlel => wlel.WorkoutAsset)
            .WithMany(wl => wl.WorkoutAssetExerciseAssets)
            .HasForeignKey(wlel => wlel.WorkoutAssetId);
        
        // Authentification
        modelBuilder.Entity<RoleClaim>()
            .HasOne(rc => rc.Role)
            .WithMany(r => r.RoleClaims)
            .HasForeignKey(rc => rc.RoleId);

        modelBuilder.Entity<RoleClaim>()
            .HasOne(rc => rc.User)
            .WithMany(u => u.RoleClaims)
            .HasForeignKey(rc => rc.UserId);
        
        modelBuilder.Entity<LogEntry>()
            .HasOne(le => le.User)
            .WithMany()
            .HasForeignKey(le => le.UserId);
        
        // UNIQUE
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Role>()
            .HasIndex(r => r.Identifier)
            .IsUnique();
        
        // HAS KEY
        modelBuilder.Entity<RoleClaim>()
            .HasKey(rc => new { rc.UserId, rc.RoleId });
        
        modelBuilder.Entity<WorkoutExercise>()
            .HasKey(we => new { we.ExerciseId, we.WorkoutId });
        
        modelBuilder.Entity<ExerciseMuscleAsset>()
            .HasKey(eml => new { eml.ExerciseId, eml.MuscleAssetId });
        
        modelBuilder.Entity<ExerciseAssetMuscleAsset>()
            .HasKey(elml => new { elml.ExerciseAssetId, elml.MuscleAssetId });
        
        modelBuilder.Entity<WorkoutAssetExerciseAsset>()
            .HasKey(wlel => new { wlel.WorkoutAssetId, wlel.ExerciseAssetId });
        
        // SEEDING
        modelBuilder.Entity<Role>()
            .HasData(new Role { Id = 1, Identifier = "Admin", Description = "Administrator" });
    }
}