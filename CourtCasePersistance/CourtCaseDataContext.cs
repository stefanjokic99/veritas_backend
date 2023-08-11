using Microsoft.EntityFrameworkCore;
using CourtCaseDomain;

namespace CourtCasePersistance;

public partial class CourtCaseDataContext : DbContext
{
    public CourtCaseDataContext()
    {
    }

    public CourtCaseDataContext(DbContextOptions<CourtCaseDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Case> Cases { get; set; }

    public virtual DbSet<CasePhase> CasePhases { get; set; }

    public virtual DbSet<CasePhaseHistory> CasePhaseHistories { get; set; }

    public virtual DbSet<CaseStatus> CaseStatuses { get; set; }

    public virtual DbSet<CaseStatusHistory> CaseStatusHistories { get; set; }

    public virtual DbSet<CaseWorker> CaseWorkers { get; set; }

    public virtual DbSet<Court> Courts { get; set; }

    public virtual DbSet<CourtCase> CourtCases { get; set; }

    public virtual DbSet<CourtCase> CourtCases1 { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeInDepartment> EmployeeInDepartments { get; set; }

    public virtual DbSet<Hearing> Hearings { get; set; }

    public virtual DbSet<JobCatalog> JobCatalogs { get; set; }

    public virtual DbSet<JobPerType> JobPerTypes { get; set; }

    public virtual DbSet<SubjectType> SubjectTypes { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Case>(entity =>
        {
            entity.HasKey(e => new { e.DepartmentId, e.TypeId, e.Id }).HasName("PK_CASE");

            entity.ToTable("Case");

            entity.HasIndex(e => e.CurrentStatus, "CASESTATUS_FK");

            entity.HasIndex(e => e.DepartmentId, "DEPARTMENT");

            entity.HasIndex(e => e.TypeId, "TYPE_FK");

            entity.Property(e => e.DepartmentId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TypeId)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Id).HasColumnType("numeric(6, 0)");
            entity.Property(e => e.CurrentStatus).HasColumnType("numeric(2, 0)");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.CurrentStatusNavigation).WithMany(p => p.Cases)
                .HasForeignKey(d => d.CurrentStatus)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CASE_RELATIONS_CASESTAT");

            entity.HasOne(d => d.Department).WithMany(p => p.Cases)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CASE_DEPARTMEN_DEPARTME");

            entity.HasOne(d => d.Type).WithMany(p => p.Cases)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CASE_TYPE_SUBJECTT");
        });

        modelBuilder.Entity<CasePhase>(entity =>
        {
            entity.HasKey(e => new { e.TypeId, e.Id }).HasName("PK_CASEPHASE");

            entity.ToTable("CasePhase");

            entity.HasIndex(e => e.TypeId, "PHASE_FK");

            entity.Property(e => e.TypeId)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false);

            entity.HasOne(d => d.Type).WithMany(p => p.CasePhases)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CASEPHAS_FAZA_SUBJECTT");
        });

        modelBuilder.Entity<CasePhaseHistory>(entity =>
        {
            entity.HasKey(e => new { e.DepartmentId, e.TypeId, e.CaseNo, e.PhaseId, e.No }).HasName("PK_CASEPHASEHISTORY");

            entity.ToTable("CasePhaseHistory");

            entity.HasIndex(e => new { e.DepartmentId, e.TypeId, e.CaseNo }, "FOR_CASE_FK");

            entity.HasIndex(e => new { e.TypeId, e.PhaseId }, "PHASE_DURATION_FK");

            entity.Property(e => e.DepartmentId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TypeId)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.CaseNo).HasColumnType("numeric(6, 0)");
            entity.Property(e => e.PhaseId)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.No).ValueGeneratedOnAdd();
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.CasePhase).WithMany(p => p.CasePhaseHistories)
                .HasForeignKey(d => new { d.TypeId, d.PhaseId })
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CASEPHAS_DURATION__CASEPHAS");

            entity.HasOne(d => d.Case).WithMany(p => p.CasePhaseHistories)
                .HasForeignKey(d => new { d.DepartmentId, d.TypeId, d.CaseNo })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CASEPHAS_FOR_CASE_CASE");
        });

        modelBuilder.Entity<CaseStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CASESTATUS");

            entity.ToTable("CaseStatus");

            entity.Property(e => e.Id).HasColumnType("numeric(2, 0)");
            entity.Property(e => e.Description)
                .HasMaxLength(256)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CaseStatusHistory>(entity =>
        {
            entity.HasKey(e => new { e.DepartmentId, e.TypeId, e.CaseId, e.StatusId, e.No }).HasName("PK_CASESTATUSHISTORY");

            entity.ToTable("CaseStatusHistory");

            entity.HasIndex(e => new { e.DepartmentId, e.TypeId, e.CaseId }, "CASE_FK");

            entity.HasIndex(e => e.StatusId, "CASE_STATUS_FK");

            entity.Property(e => e.DepartmentId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TypeId)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.CaseId).HasColumnType("numeric(6, 0)");
            entity.Property(e => e.StatusId).HasColumnType("numeric(2, 0)");
            entity.Property(e => e.No).ValueGeneratedOnAdd();
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Judge)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Status).WithMany(p => p.CaseStatusHistories)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CASESTAT_RELATIONS_CASESTAT");

            entity.HasOne(d => d.Case).WithMany(p => p.CaseStatusHistories)
                .HasForeignKey(d => new { d.DepartmentId, d.TypeId, d.CaseId })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CASESTAT_RELATIONS_CASE");
        });

        modelBuilder.Entity<CaseWorker>(entity =>
        {
            entity.HasKey(e => new { e.DepartmentId, e.CaseId, e.EmployeeId, e.JobId, e.TypeId }).HasName("PK_CASEWORKER");

            entity.ToTable("CaseWorker");

            entity.HasIndex(e => new { e.DepartmentId, e.TypeId, e.CaseId }, "CASE_FK");

            entity.HasIndex(e => new { e.JobId, e.TypeId }, "JOB_TYPE_FK");

            entity.HasIndex(e => e.EmployeeId, "WORKER_FK");

            entity.Property(e => e.DepartmentId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CaseId).HasColumnType("numeric(6, 0)");
            entity.Property(e => e.JobId).HasColumnType("numeric(4, 0)");
            entity.Property(e => e.TypeId)
                .HasMaxLength(4)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.CaseWorkers)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CASEWORK_RADI_NA_P_EMPLOYEE");

            entity.HasOne(d => d.JobPerType).WithMany(p => p.CaseWorkers)
                .HasForeignKey(d => new { d.JobId, d.TypeId })
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_CASEWORK_RELATIONS_JOBPERTY");

            entity.HasOne(d => d.Case).WithMany(p => p.CaseWorkers)
                .HasForeignKey(d => new { d.DepartmentId, d.TypeId, d.CaseId })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CASEWORK_ZAPOSLENI_CASE");
        });

        modelBuilder.Entity<Court>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_COURT");

            entity.ToTable("Court");

            entity.Property(e => e.Id)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CourtCase>(entity =>
        {
            entity.HasKey(e => e.No).HasName("CourtCase_PK");

            entity.ToTable("CourtCase");

        });

        modelBuilder.Entity<CourtCase>(entity =>
        {
            entity.HasKey(e => new { e.DepartmentId, e.TypeId, e.CaseId, e.CourtId, e.No }).HasName("PK_COURTCASES");

            entity.ToTable("CourtCases");

            entity.HasIndex(e => new { e.DepartmentId, e.TypeId, e.CaseId }, "CASE_FK");

            entity.HasIndex(e => e.CourtId, "COURT_FK");

            entity.Property(e => e.DepartmentId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TypeId)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.CaseId).HasColumnType("numeric(6, 0)");
            entity.Property(e => e.CourtId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.No).ValueGeneratedOnAdd();
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Court).WithMany(p => p.CourtCases)
                .HasForeignKey(d => d.CourtId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_COURTCAS_RELATIONS_COURT");

            entity.HasOne(d => d.Case).WithMany(p => p.CourtCases)
                .HasForeignKey(d => new { d.DepartmentId, d.TypeId, d.CaseId })
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_COURTCAS_RELATIONS_CASE");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_DEPARTMENT");

            entity.ToTable("Department");

            entity.Property(e => e.Id)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EMPLOYEE");

            entity.ToTable("Employee");

            entity.Property(e => e.Forename)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Jmbg)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("JMBG");
            entity.Property(e => e.ParentName)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Sex)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Surename)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmployeeInDepartment>(entity =>
        {
            entity.HasKey(e => new { e.EmployeeId, e.DepartmentId, e.No }).HasName("PK_EMPLOYEEINDEPARTMENT");

            entity.ToTable("EmployeeInDepartment");

            entity.HasIndex(e => e.DepartmentId, "DEPARTMENT_FK");

            entity.HasIndex(e => e.EmployeeId, "EMPLOYEE_FK");

            entity.Property(e => e.DepartmentId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.No)
                .ValueGeneratedOnAdd()
                .HasColumnType("numeric(6, 0)");
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Department).WithMany(p => p.EmployeeInDepartments)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_EMPLOYEE_DEPARTMEN_DEPARTME");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeInDepartments)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_EMPLOYEE_EMPLOYEEO_EMPLOYEE");
        });

        modelBuilder.Entity<Hearing>(entity =>
        {
            entity.HasKey(e => new { e.DepartmentId, e.TypeId, e.CaseId, e.CourtId, e.No }).HasName("PK_HEARING");

            entity.ToTable("Hearing");

            entity.HasIndex(e => new { e.DepartmentId, e.TypeId, e.CaseId }, "CASE_FK");

            entity.HasIndex(e => e.CourtId, "COURT_FK");

            entity.Property(e => e.DepartmentId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TypeId)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.CaseId).HasColumnType("numeric(6, 0)");
            entity.Property(e => e.CourtId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.No).ValueGeneratedOnAdd();
            entity.Property(e => e.EndTime).HasColumnType("datetime");
            entity.Property(e => e.Record).HasColumnType("text");
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.Court).WithMany(p => p.Hearings)
                .HasForeignKey(d => d.CourtId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_HEARING_RELATIONS_COURT");

            entity.HasOne(d => d.Case).WithMany(p => p.Hearings)
                .HasForeignKey(d => new { d.DepartmentId, d.TypeId, d.CaseId })
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_HEARING_RELATIONS_CASE");
        });

        modelBuilder.Entity<JobCatalog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_JOBCATALOG");

            entity.ToTable("JobCatalog");

            entity.Property(e => e.Id).HasColumnType("numeric(4, 0)");
            entity.Property(e => e.Name)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.PlannedNumber).HasColumnType("numeric(3, 0)");
        });

        modelBuilder.Entity<JobPerType>(entity =>
        {
            entity.HasKey(e => new { e.JobId, e.TypeId }).HasName("PK_JOBPERTYPE");

            entity.ToTable("JobPerType");

            entity.HasIndex(e => e.JobId, "JOB_FK");

            entity.HasIndex(e => e.TypeId, "TYPE_FK");

            entity.Property(e => e.JobId).HasColumnType("numeric(4, 0)");
            entity.Property(e => e.TypeId)
                .HasMaxLength(4)
                .IsUnicode(false);

            entity.HasOne(d => d.Job).WithMany(p => p.JobPerTypes)
                .HasForeignKey(d => d.JobId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_JOBPERTY_RELATIONS_JOBCATAL");

            entity.HasOne(d => d.Type).WithMany(p => p.JobPerTypes)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_JOBPERTY_RELATIONS_SUBJECTT");
        });

        modelBuilder.Entity<SubjectType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SUBJECTTYPE");

            entity.ToTable("SubjectType");

            entity.Property(e => e.Id)
                .HasMaxLength(4)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
