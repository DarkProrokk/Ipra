using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context;

public partial class IpraContext : DbContext
{
    public IpraContext()
    {
    }

    public IpraContext(DbContextOptions<IpraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AddressType> AddressTypes { get; set; }

    public virtual DbSet<Buro> Buros { get; set; }

    public virtual DbSet<Citizenship> Citizenships { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<DocType> DocTypes { get; set; }

    public virtual DbSet<DysfunctionsDegree> DysfunctionsDegrees { get; set; }

    public virtual DbSet<EventSubtype> EventSubtypes { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    public virtual DbSet<Executor> Executors { get; set; }

    public virtual DbSet<Files> Files { get; set; }

    public virtual DbSet<FuncCompensation> FuncCompensations { get; set; }

    public virtual DbSet<FuncRecovery> FuncRecoveries { get; set; }

    public virtual DbSet<GroupsTask> GroupsTasks { get; set; }

    public virtual DbSet<HelpCategory> HelpCategories { get; set; }

    public virtual DbSet<Ipra> Ipras { get; set; }

    public virtual DbSet<IpraHelpCategory> IpraHelpCategories { get; set; }

    public virtual DbSet<IpraMovesHistory> IpraMovesHistories { get; set; }

    public virtual DbSet<IpraStatus> IpraStatuses { get; set; }

    public virtual DbSet<MO> MOs { get; set; }

    public virtual DbSet<Move> Moves { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<PrognozResult> PrognozResults { get; set; }

    public virtual DbSet<RecipientType> RecipientTypes { get; set; }

    public virtual DbSet<RehabPotential> RehabPotentials { get; set; }

    public virtual DbSet<RehabPrognoz> RehabPrognozs { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tasks> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserMO> UserMOs { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("ru_RU.UTF-8");

        modelBuilder.Entity<AddressType>(entity =>
        {
            entity.ToTable("AddressType", tb => tb.HasTrigger("AddressTypeUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.AddressTypeCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_AddressTypeCreatedUser");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.AddressTypeModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_AddressTypeModifiedUser");
        });

        modelBuilder.Entity<Buro>(entity =>
        {
            entity.ToTable("Buro", tb => tb.HasTrigger("BuroUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.BuroCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_BuroCreatedUser");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.BuroModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_BuroModifiedUser");
        });

        modelBuilder.Entity<Citizenship>(entity =>
        {
            entity.ToTable("Citizenship", tb => tb.HasTrigger("CitizenshipUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.CitizenshipCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CitizenshipCreatedUser");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.CitizenshipModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_CitizenshipModifiedUser");
        });

        modelBuilder.Entity<DocType>(entity =>
        {
            entity.ToTable("DocType", tb => tb.HasTrigger("DocTypeUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.DocTypeCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DocTypeCreatedUser");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.DocTypeModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DocTypeModifiedUser");
        });

        modelBuilder.Entity<EventSubtype>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Type).WithMany(p => p.EventSubtypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EventSubtype_EventType");
        });

        modelBuilder.Entity<EventType>(entity => { entity.Property(e => e.Id).ValueGeneratedNever(); });

        modelBuilder.Entity<Files>(entity =>
        {
            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Patient).WithMany(p => p.Files).HasConstraintName("fk_FilePatient");
        });

        modelBuilder.Entity<FuncCompensation>(entity =>
        {
            entity.ToTable("FuncCompensation", tb => tb.HasTrigger("FuncCompensationUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.FuncCompensationCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_FuncCompensationCreatedUser");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.FuncCompensationModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_FuncCompensationModifiedUser");
        });

        modelBuilder.Entity<FuncRecovery>(entity =>
        {
            entity.ToTable("FuncRecovery", tb => tb.HasTrigger("FuncRecoveryUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.FuncRecoveryCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_FuncRecoveryCreatedUser");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.FuncRecoveryModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_FuncRecoveryModifiedUser");
        });

        modelBuilder.Entity<GroupsTask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DroupTask");

            entity.HasOne(d => d.User).WithMany(p => p.GroupsTasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_GroupsTasks_Users");
        });

        modelBuilder.Entity<HelpCategory>(entity =>
        {
            entity.ToTable("HelpCategory", tb => tb.HasTrigger("HelpCategoryUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.HelpCategoryCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_HelpCategoryCreatedUser");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.HelpCategoryModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_HelpCategoryModifiedUser");
        });

        modelBuilder.Entity<Ipra>(entity =>
        {
            entity.ToTable("Ipra", tb =>
            {
                tb.HasTrigger("IpraInsMovesHistory");
                tb.HasTrigger("IpraUpdMovesHistory");
                tb.HasTrigger("IpraUpdTS");
            });

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.HasNoLivingAddress).HasDefaultValue(false);
            entity.Property(e => e.HasNoRegAddress).HasDefaultValue(false);
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ProsthesisNeed).HasDefaultValue(false);
            entity.Property(e => e.ReconsSurgeryNeed).HasDefaultValue(false);
            entity.Property(e => e.ResortNeed).HasDefaultValue(false);
            entity.Property(e => e.SectorName).IsFixedLength();
            entity.Property(e => e.SectorNumber).IsFixedLength();
            entity.Property(e => e.SectorType).IsFixedLength();

            entity.HasOne(d => d.Buro).WithMany(p => p.Ipras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Buro");

            entity.HasOne(d => d.Citizenship).WithMany(p => p.Ipras).HasConstraintName("fk_IpraCitizenship");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.IpraCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IpraCreatedUser");

            entity.HasOne(d => d.DD).WithMany(p => p.Ipras).HasConstraintName("FK_Ipra_DysfunctionsDegrees");

            entity.HasOne(d => d.Files).WithMany(p => p.Ipras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IpraFile");

            entity.HasOne(d => d.LivingAddressType).WithMany(p => p.IpraLivingAddressTypes)
                .HasConstraintName("fk_IpraLivingAddressType");

            entity.HasOne(d => d.Mo).WithMany(p => p.IpraMos).HasConstraintName("fk_IpraMO");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.IpraModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IpraModifiedUser");

            entity.HasOne(d => d.PR).WithMany(p => p.Ipras).HasConstraintName("FK_Ipra_PrognozResult");

            entity.HasOne(d => d.Patient).WithMany(p => p.Ipras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IpraPatient");

            entity.HasOne(d => d.PrognozCompensation).WithMany(p => p.Ipras)
                .HasConstraintName("fk_IpraPrognozCompensation");

            entity.HasOne(d => d.PrognozRecovery).WithMany(p => p.Ipras).HasConstraintName("fk_IpraPrognozRecovery");

            entity.HasOne(d => d.RecipientType).WithMany(p => p.Ipras).HasConstraintName("fk_IpraRecipientType");

            entity.HasOne(d => d.RegAddressType).WithMany(p => p.IpraRegAddressTypes)
                .HasConstraintName("fk_IpraRegAddressType");

            entity.HasOne(d => d.RepresentativeAuthDocTypeNavigation)
                .WithMany(p => p.IpraRepresentativeAuthDocTypeNavigations)
                .HasConstraintName("fk_IpraRepresentativeAuthDocType");

            entity.HasOne(d => d.RepresentativeIdentDocTypeNavigation)
                .WithMany(p => p.IpraRepresentativeIdentDocTypeNavigations)
                .HasConstraintName("fk_IpraRepresentativeIdentDocType");

            entity.HasOne(d => d.SenderMo).WithMany(p => p.IpraSenderMos).HasConstraintName("fk_IpraSenderMo");

            entity.HasOne(d => d.Status).WithMany(p => p.Ipras)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IpraStatus");
        });

        modelBuilder.Entity<IpraHelpCategory>(entity =>
        {
            entity.ToTable("IpraHelpCategory", tb => tb.HasTrigger("IpraHelpCategoryUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.IpraHelpCategoryCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IpraHelpCategoryCreatedUser");

            entity.HasOne(d => d.HelpCategory).WithMany(p => p.IpraHelpCategories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_HelpCategory");

            entity.HasOne(d => d.Ipra).WithMany(p => p.IpraHelpCategories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Ipra");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.IpraHelpCategoryModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IpraHelpCategoryModifiedUser");
        });

        modelBuilder.Entity<IpraMovesHistory>(entity =>
        {
            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.IpraMovesHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MovesHistoryCreatedUser");

            entity.HasOne(d => d.Ipra).WithMany(p => p.IpraMovesHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MovesHistoryIpra");

            entity.HasOne(d => d.Move).WithMany(p => p.IpraMovesHistories)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MovesHistoryMove");
        });

        modelBuilder.Entity<IpraStatus>(entity =>
        {
            entity.ToTable("IpraStatus", tb => tb.HasTrigger("IpraStatusUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.IpraStatusCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IpraStatusCreatedUser");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.IpraStatusModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_IpraStatusModifiedUser");
        });

        modelBuilder.Entity<MO>(entity =>
        {
            entity.ToTable("MO", tb => tb.HasTrigger("MOUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DbName).IsFixedLength();
            entity.Property(e => e.FomsCode).IsFixedLength();
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.MOCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MOCreatedUser");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.MOModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MOModifiedUser");
        });

        modelBuilder.Entity<Move>(entity =>
        {
            entity.ToTable("Move", tb => tb.HasTrigger("MoveUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.MoveCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MoveCreatedUser");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.MoveModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_MoveModifiedUser");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("PatientsUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.PatientCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_PatientsCreatedUser");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.PatientModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_PatientsModifiedUser");
        });

        modelBuilder.Entity<RecipientType>(entity =>
        {
            entity.ToTable("RecipientType", tb => tb.HasTrigger("RecipientTypeUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.RecipientTypeCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_RecipientTypeCreatedUser");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.RecipientTypeModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_RecipientTypeModifiedUser");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasOne(d => d.CreatedUser).WithMany(p => p.Reports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reports_Users");

            entity.HasOne(d => d.EventSubtype).WithMany(p => p.Reports).HasConstraintName("FK_Reports_EventSubtype");

            entity.HasOne(d => d.EventType).WithMany(p => p.Reports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reports_EventType");

            entity.HasOne(d => d.Executor).WithMany(p => p.Reports).HasConstraintName("FK_Reports_Executors");

            entity.HasOne(d => d.Ipra).WithMany(p => p.Reports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Reports_Ipra");

            entity.HasOne(d => d.Result).WithMany(p => p.Reports).HasConstraintName("FK_Reports_Result");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MseName).IsFixedLength();
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("RolesUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.RoleCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_RolesCreatedUser");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.RoleModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_RolesModifiedUser");
        });

        modelBuilder.Entity<Tasks>(entity =>
        {
            entity.ToTable("Task", tb => tb.HasTrigger("TaskUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.TaskCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_TaskCreatedUser");

            entity.HasOne(d => d.Files).WithMany(p => p.Tasks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_TaskFile");

            entity.HasOne(d => d.GroupTask).WithMany(p => p.Tasks).HasConstraintName("FK_Task_GroupsTasks");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.TaskModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_TaskModifiedUser");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("UsersUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.InverseCreatedUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_UsersCreatedUser");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.InverseModifiedUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_UsersModifiedUser");
        });

        modelBuilder.Entity<UserMO>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("UserMOsUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.UserMOCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_UserMOsCreatedUser");

            entity.HasOne(d => d.MO).WithMany(p => p.UserMOs).HasConstraintName("FK_UserMOs_MO");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.UserMOModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_UserMOsModifiedUser");

            entity.HasOne(d => d.User).WithMany(p => p.UserMOUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserMOs_Users");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable(tb => tb.HasTrigger("UserRolesUpdTS"));

            entity.Property(e => e.CreatedTS).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ModifiedTS).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.CreatedUser).WithMany(p => p.UserRoleCreatedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_UserRolesCreatedUser");

            entity.HasOne(d => d.ModifiedUser).WithMany(p => p.UserRoleModifiedUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_UserRolesModifiedUser");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Roles");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoleUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserRoles_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}