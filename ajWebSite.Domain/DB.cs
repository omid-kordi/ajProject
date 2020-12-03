using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ajWebSite.Domain.Common;
using ajWebSite.Domain.ajWebSite;
using ajWebSite.Domain.Security;

namespace ajWebSite.Domain
{
    public class DB : DbContext
    {
        //public DB()
        //{

        //}
        public DB(DbContextOptions<DB> options) : base(options)
        {
        }
        #region Common
        public DbSet<Lookup> Lookups { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<FileBinary> FileBinaries { get; set; }

        #endregion

        public DbSet<Parking> Parkings { get; set; }

        public DbSet<Person> People { get; set; }
        public DbSet<PersonDetail> PersonDetails { get; set; }
        public DbSet<PersonDoc> PersonDocs { get; set; }
        public DbSet<TextMessage> TextMessages { get; set; }

        public DbSet<survey> surveys { get; set; }
        public DbSet<surveyQuestion> surveyQuestions { get; set; }
        public DbSet<surveyQuestionAnswer> surveyQuestionAnswers { get; set; }
        public DbSet<ticket> tickets { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<comment> comments { get; set; }
        public DbSet<vote> votes { get; set; }
        public DbSet<config> configs { get; set; }
        public DbSet<newsAndItem> newsAndItems { get; set; }
        public DbSet<salon> salons { get; set; }
        #region security
        public DbSet<User> Users { get; set; }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<UserAccess> UserAccesses { get; set; }
        public DbSet<ActivationCode> ActivationCodes { get; set; }
        #endregion





        protected override void OnModelCreating(ModelBuilder builder)
        {

            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.Relational().TableName = entity.DisplayName();
                //if (entity.BaseType == null)
                //{
                //    entity.SetTableName(entity.DisplayName());
                //}
                //entity.FindProperty("DateInserted").SetDefaultValueSql("GETDATE()");


                var cascadeFKs = entity.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

                foreach (var fk in cascadeFKs)
                    fk.DeleteBehavior = DeleteBehavior.Restrict;

            }


            //foreach (var property in builder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(decimal)))
            //{
            //    property.setSetColumnType("decimal(18, 2)");
            //}



            builder.Entity<FileBinary>().HasIndex(x => x.GUId);


            builder.Entity<survey>().HasMany(p => p.questions).WithOne(o => o.survey).HasForeignKey(p => p.surveyId);
            builder.Entity<surveyQuestion>().HasMany(o => o.answers).WithOne(p => p.question).HasForeignKey(f => f.questionId);

            builder.Entity<User>().ToTable("Users");
            //builder.Entity<AuctionItemWastage>().ToTable("AuctionItemWastage");
            builder.Entity<comment>().HasOne(p => p.parent).WithMany(b => b.childComments).HasForeignKey(p => p.parentId);
        }
    }
}
