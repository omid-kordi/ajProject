using Microsoft.EntityFrameworkCore;
using ajWebSite.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ajWebSite.Common.Enums;
using ajWebSite.Domain.Security;

namespace ajWebSite.Domain
{
    public class DBOrcl : DbContext
    {
        //public DBOrcl()
        //{

        //}
        public DBOrcl(DbContextOptions<DBOrcl> options) : base(options)
        { 
        }

        #region Common
        public DbSet<Lookup> Lookups { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<FileBinary> FileBinaries { get; set; }

        #endregion

        public DbSet<Person> People { get; set; }
        public DbSet<TextMessage> TextMessages { get; set; }


        #region security
        public DbSet<User> Users { get; set; }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<UserAccess> UserAccesses { get; set; }
        public DbSet<ActivationCode> ActivationCodes { get; set; }
        #endregion



        protected override void OnModelCreating(ModelBuilder builder)
        { 
            //foreach (var property in builder.Model.GetEntityTypes().SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(decimal)))
            //{
            //    property.SetField(property.Name.ToUpper());
            //}

            foreach (var entity in builder.Model.GetEntityTypes())
            {
                
                entity.Relational().TableName = entity.DisplayName().ToUpper();
                entity.Relational().Schema = "AUCTION";

                //if (entity.BaseType == null)
                //{
                //    entity.SetTableName(entity.DisplayName());
                //}
                //entity.FindProperty("DateInserted").SetDefaultValueSql("GETDATE()");

                foreach (var property in entity.GetProperties())
                {
                    var columnName = property.Name.ToUpper();
                    if (columnName == "NUMBER")
                        columnName = "NUMBER_";
                    entity.FindProperty(property.Name).Relational().ColumnName = columnName;

                }
                

                var cascadeFKs = entity.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

                foreach (var fk in cascadeFKs)
                    fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            builder.Entity<User>().ToTable("USERS");
            builder.Entity<Access>().ToTable("ACCESSTYPE");

            builder.Entity<survey>().HasMany(p => p.questions).WithOne(o => o.survey).HasForeignKey(p => p.surveyId);
            builder.Entity<surveyQuestion>().HasMany(o => o.answers).WithOne(p => p.question).HasForeignKey(f => f.questionId);

            builder.Entity<FileBinary>().Property(x=>x.Binary).HasColumnType("blob");
            builder.Entity<FileBinary>().HasIndex(x => x.GUId);
        }
    }
}
