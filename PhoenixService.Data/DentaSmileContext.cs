using Microsoft.EntityFrameworkCore;
using PhoenixService.Data.Models;

namespace PhoenixService.Data
{
    public partial class DentaSmileContext : DbContext
    {
        public DentaSmileContext()
        {
        }

        public DentaSmileContext(DbContextOptions<DentaSmileContext> options)
            : base(options)
        {
        }

        public virtual DbSet<IVoiceServer> IVoiceServer { get; set; }
        public virtual DbSet<IvoiceTask> IvoiceTask { get; set; }
        public virtual DbSet<Scenarios> Scenarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=DentaSmile;Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<IVoiceServer>(entity =>
            {
                entity.HasKey(e => e.Server);

                entity.ToTable("iVoiceServer");

                entity.Property(e => e.Server).ValueGeneratedNever();

                entity.Property(e => e.GetRecordUrl).IsUnicode(false);

                entity.Property(e => e.GetResultUrl).IsUnicode(false);

                entity.Property(e => e.GetStateUrl).IsUnicode(false);

                entity.Property(e => e.GetTaskUrl).IsUnicode(false);

                entity.Property(e => e.Login)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IvoiceTask>(entity =>
            {
                entity.ToTable("IVoiceTask");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Anket).IsUnicode(false);

                entity.Property(e => e.CallRecord).IsUnicode(false);

                entity.Property(e => e.Client)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IvoiceRequestId)
                    .HasColumnName("IVoiceRequestID")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.IvoiceState).HasColumnName("IVoiceState");

                entity.Property(e => e.Moment)
                    .HasColumnName("moment")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PhoenixTask)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RequestText).IsUnicode(false);

                entity.Property(e => e.SmsText).IsUnicode(false);

                entity.Property(e => e.SpList)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Stage)
                    .HasColumnName("stage")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Scenarios>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Dbquery)
                    .HasColumnName("DBQuery")
                    .IsUnicode(false);

                entity.Property(e => e.IVoiceQuery)
                    .HasColumnName("iVoiceQuery")
                    .IsUnicode(false);

                entity.Property(e => e.IVoiceScenarioId)
                    .HasColumnName("iVoiceScenarioID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Itype)
                    .HasColumnName("itype")
                    .HasDefaultValueSql("((9))");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RingFailureResult)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RingProcessResult)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RingSuccessResult)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SmssendResult)
                    .HasColumnName("SMSSendResult")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Smstemplate)
                    .HasColumnName("SMSTemplate")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Splist)
                    .HasColumnName("splist")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
        }
    }
}
