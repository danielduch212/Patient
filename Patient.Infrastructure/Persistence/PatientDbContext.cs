using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Patient.Domain.Entities;
using Patient.Domain.Entities.Actors;
using Shared.Main;

namespace Patient.Infrastructure.Persistence;

internal class PatientDbContext(DbContextOptions<PatientDbContext> options) : IdentityDbContext<User>(options)
{
    internal DbSet<Domain.Entities.Actors.Patient> Patients { get; set; }
    internal DbSet<Doctor> Doctors { get; set; }
    internal DbSet<Admin> Admins { get; set; }
    internal DbSet<MedicalFile> MedicalFiles { get; set; }
    internal DbSet<MedicalRecommandation> MedicalRecommandations { get; set; }
    internal DbSet<Medicine> Medicines { get; set; }
    internal DbSet<Payment> Payments { get; set; }
    internal DbSet<Prescription> Prescriptions { get; set; }
    internal DbSet<Report> Reports { get; set; }
    internal DbSet<Disease> Diseases { get; set; }
    internal DbSet<PrescriptionRequest> PrescriptionRequests { get; set; }
    internal DbSet<PatientsDisease> PatientsDiseases { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
   
        modelBuilder.Entity<Admin>()
            .ToTable("Admins")
            .OwnsOne(a => a.Address);

        modelBuilder.Entity<Domain.Entities.Actors.Patient>()
            .ToTable("Patients")
            .OwnsOne(p => p.Address);

        modelBuilder.Entity<Doctor>()
            .ToTable("Doctors")
            .OwnsOne(d => d.Address);

        //patient
        modelBuilder.Entity<Domain.Entities.Actors.Patient>()
            .HasMany(p => p.Reports)
            .WithOne(r=>r.Patient)
            .HasForeignKey(r => r.PatientId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Domain.Entities.Actors.Patient>()
            .HasMany(p => p.Doctors)
            .WithMany(d=>d.Patients);


        modelBuilder.Entity<Domain.Entities.Actors.Patient>()
            .HasMany(p => p.MedicalFiles)
            .WithOne(mi=>mi.Patient)
            .HasForeignKey(mf => mf.PatientId)
            .OnDelete(DeleteBehavior.Restrict); 


        modelBuilder.Entity<Domain.Entities.Actors.Patient>()
            .HasMany(p => p.Prescriptions)
            .WithOne(pre=>pre.Patient)
            .HasForeignKey(pre => pre.PatientId)
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Domain.Entities.Actors.Patient>()
            .HasMany(p=>p.TreatedDiseases)
            .WithOne(p=>p.Patient)
            .HasForeignKey(p=>p.PatientId)
            .OnDelete(DeleteBehavior.Restrict);



        //doctor

        modelBuilder.Entity<Doctor>()
            .HasMany(d => d.PrescriptionsIssued)
            .WithOne(pi=>pi.Doctor)
            .HasForeignKey(pi => pi.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Doctor>()
            .HasMany(d=>d.MedicalRecommandations)
            .WithOne(mr=>mr.Doctor)
            .HasForeignKey(mr=>mr.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        //medical recommandation

        modelBuilder.Entity<MedicalRecommandation>()
            .HasOne(mr => mr.Prescription);

        modelBuilder.Entity<MedicalRecommandation>()
            .HasOne(mr => mr.Report)
            .WithOne(r => r.MedicalRecommandation)
            .HasForeignKey<Report>(r => r.MedicalRecommandationId)
            .OnDelete(DeleteBehavior.Restrict);

        //report ;/
        modelBuilder.Entity<Report>()
            .HasMany(r => r.DoctorsToCheck)
            .WithMany(d=>d.ReportsToCheck);

        modelBuilder.Entity<Report>()
            .HasMany(r => r.DoctorsWhoChecked)
            .WithMany(d => d.ReportsChecked);

        //PatientDiseases
        modelBuilder.Entity<PatientsDisease>()
            .HasOne(pd=>pd.Patient)
            .WithMany(p=>p.TreatedDiseases)
            .HasForeignKey(pd=>pd.PatientId)
            .OnDelete(DeleteBehavior.Restrict);
        
            

    }

}
