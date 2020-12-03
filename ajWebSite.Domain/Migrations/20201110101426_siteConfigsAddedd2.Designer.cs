﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ajWebSite.Domain;

namespace ajWebSite.Domain.Migrations
{
    [DbContext(typeof(DB))]
    [Migration("20201110101426_siteConfigsAddedd2")]
    partial class siteConfigsAddedd2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ajWebSite.Domain.Common.FileBinary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Binary");

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("GUId")
                        .HasColumnType("varchar(36)")
                        .HasMaxLength(40);

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<int?>("UpdaterId");

                    b.Property<int?>("attachmentType");

                    b.Property<int>("fileBinaryType");

                    b.Property<string>("filePath");

                    b.Property<string>("ownerID");

                    b.HasKey("Id");

                    b.HasIndex("GUId");

                    b.ToTable("FileBinary");
                });

            modelBuilder.Entity("ajWebSite.Domain.Common.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsDelete");

                    b.Property<int?>("UpdaterId");

                    b.Property<int>("groupType");

                    b.Property<int?>("parentId");

                    b.Property<string>("title");

                    b.HasKey("Id");

                    b.HasIndex("parentId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("ajWebSite.Domain.Common.Lookup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsDelete");

                    b.Property<int>("Type");

                    b.Property<int?>("UpdaterId");

                    b.Property<string>("Value")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Lookup");
                });

            modelBuilder.Entity("ajWebSite.Domain.Common.Parking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Name");

                    b.Property<int>("TypeId");

                    b.Property<int?>("UpdaterId");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Parking");
                });

            modelBuilder.Entity("ajWebSite.Domain.Common.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Amount");

                    b.Property<bool>("Approved");

                    b.Property<string>("CardNumber")
                        .HasMaxLength(20);

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description")
                        .HasMaxLength(200);

                    b.Property<string>("DigitalReceipt")
                        .HasMaxLength(100);

                    b.Property<bool>("IsDelete");

                    b.Property<string>("RefNumber")
                        .HasMaxLength(20);

                    b.Property<string>("TerminalNumber")
                        .HasMaxLength(20);

                    b.Property<string>("TrackingCode")
                        .HasMaxLength(20);

                    b.Property<int>("Type");

                    b.Property<int?>("UpdaterId");

                    b.HasKey("Id");

                    b.ToTable("Payment");
                });

            modelBuilder.Entity("ajWebSite.Domain.Common.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("LastName")
                        .HasMaxLength(100);

                    b.Property<string>("Mobile")
                        .HasMaxLength(15);

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<string>("NationalCode")
                        .HasMaxLength(15);

                    b.Property<int>("PersonType");

                    b.Property<int?>("UpdaterId");

                    b.HasKey("Id");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("ajWebSite.Domain.Common.PersonDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountNumber")
                        .HasMaxLength(30);

                    b.Property<string>("AccountSheba")
                        .HasMaxLength(30);

                    b.Property<string>("Address")
                        .HasMaxLength(200);

                    b.Property<string>("BankBranch")
                        .HasMaxLength(30);

                    b.Property<int>("BankId");

                    b.Property<DateTime?>("BirthDate");

                    b.Property<string>("City")
                        .HasMaxLength(30);

                    b.Property<int?>("CompanyTypeId");

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("EcoNumber")
                        .HasMaxLength(11);

                    b.Property<string>("Email")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Job")
                        .HasMaxLength(50);

                    b.Property<int>("PersonId");

                    b.Property<string>("Phone")
                        .HasMaxLength(10);

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10);

                    b.Property<string>("Province")
                        .HasMaxLength(30);

                    b.Property<DateTime?>("RegisterDate");

                    b.Property<string>("RegisterNumber")
                        .HasMaxLength(10);

                    b.Property<string>("RepNationalCode")
                        .HasMaxLength(10);

                    b.Property<int?>("UpdaterId");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.HasIndex("CompanyTypeId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonDetail");
                });

            modelBuilder.Entity("ajWebSite.Domain.Common.PersonDoc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("FileBinaryUId")
                        .HasMaxLength(40);

                    b.Property<int>("FileTypeId");

                    b.Property<bool>("IsDelete");

                    b.Property<int>("PersonId");

                    b.Property<int?>("UpdaterId");

                    b.HasKey("Id");

                    b.HasIndex("FileTypeId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonDoc");
                });

            modelBuilder.Entity("ajWebSite.Domain.Common.TextMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Message")
                        .HasMaxLength(500);

                    b.Property<string>("Mobile")
                        .HasMaxLength(15);

                    b.Property<string>("Result")
                        .HasMaxLength(100);

                    b.Property<int?>("UpdaterId");

                    b.HasKey("Id");

                    b.ToTable("TextMessage");
                });

            modelBuilder.Entity("ajWebSite.Domain.Common.comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsDelete");

                    b.Property<int?>("UpdaterId");

                    b.Property<string>("commentText");

                    b.Property<bool?>("isValid");

                    b.Property<int>("ownerID");

                    b.Property<int>("partParam");

                    b.Property<int>("secondPartParam");

                    b.HasKey("Id");

                    b.ToTable("comment");
                });

            modelBuilder.Entity("ajWebSite.Domain.Common.config", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsDelete");

                    b.Property<int?>("UpdaterId");

                    b.Property<int>("configName");

                    b.Property<string>("configValue");

                    b.HasKey("Id");

                    b.ToTable("config");
                });

            modelBuilder.Entity("ajWebSite.Domain.Common.newsAndItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description");

                    b.Property<bool>("IsDelete");

                    b.Property<int?>("UpdaterId");

                    b.Property<DateTime?>("beginReleaseDateTime");

                    b.Property<int>("businessType");

                    b.Property<DateTime?>("endReleaseDatetime");

                    b.Property<int?>("groupId");

                    b.Property<float>("price");

                    b.Property<int>("releaseType");

                    b.Property<string>("summary");

                    b.Property<string>("tags");

                    b.Property<string>("title");

                    b.HasKey("Id");

                    b.HasIndex("groupId");

                    b.ToTable("newsAndItem");
                });

            modelBuilder.Entity("ajWebSite.Domain.Common.vote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsDelete");

                    b.Property<int?>("UpdaterId");

                    b.Property<bool?>("isValid");

                    b.Property<int>("ownerID");

                    b.Property<int>("partParam");

                    b.Property<int>("secondPartParam");

                    b.Property<float>("value");

                    b.HasKey("Id");

                    b.ToTable("vote");
                });

            modelBuilder.Entity("ajWebSite.Domain.ajWebSite.ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsDelete");

                    b.Property<int?>("RecieverId");

                    b.Property<int?>("SenderId");

                    b.Property<int?>("UpdaterId");

                    b.Property<string>("attachmentUrl");

                    b.Property<string>("emailAddress");

                    b.Property<string>("messageText");

                    b.Property<string>("messageTitle");

                    b.Property<int>("serverityLevel");

                    b.Property<string>("sessionID");

                    b.Property<string>("title");

                    b.HasKey("Id");

                    b.HasIndex("RecieverId");

                    b.HasIndex("SenderId");

                    b.ToTable("ticket");
                });

            modelBuilder.Entity("ajWebSite.Domain.Security.Access", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<int?>("UpdaterId");

                    b.HasKey("Id");

                    b.ToTable("Access");
                });

            modelBuilder.Entity("ajWebSite.Domain.Security.ActivationCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasMaxLength(5);

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<DateTime>("ExpireDate");

                    b.Property<bool>("IsDelete");

                    b.Property<string>("Mobile")
                        .HasMaxLength(15);

                    b.Property<int?>("UpdaterId");

                    b.HasKey("Id");

                    b.ToTable("ActivationCode");
                });

            modelBuilder.Entity("ajWebSite.Domain.Security.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsDelete");

                    b.Property<bool>("IsFullRegistered");

                    b.Property<DateTime?>("LastLoginAttemptDate");

                    b.Property<DateTime?>("LastLoginDate");

                    b.Property<int>("NumberOfLoginAttempt");

                    b.Property<string>("Password")
                        .HasMaxLength(100);

                    b.Property<int?>("PersonId");

                    b.Property<int>("Type");

                    b.Property<int?>("UpdaterId");

                    b.Property<string>("Username")
                        .HasMaxLength(50);

                    b.Property<string>("emailAddress");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PersonId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ajWebSite.Domain.Security.UserAccess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessId");

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("DateInserted");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsDelete");

                    b.Property<int?>("UpdaterId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AccessId");

                    b.HasIndex("UserId");

                    b.ToTable("UserAccess");
                });

            modelBuilder.Entity("ajWebSite.Domain.Common.Group", b =>
                {
                    b.HasOne("ajWebSite.Domain.Common.Group", "parent")
                        .WithMany()
                        .HasForeignKey("parentId");
                });

            modelBuilder.Entity("ajWebSite.Domain.Common.Parking", b =>
                {
                    b.HasOne("ajWebSite.Domain.Common.Lookup", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ajWebSite.Domain.Common.PersonDetail", b =>
                {
                    b.HasOne("ajWebSite.Domain.Common.Lookup", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ajWebSite.Domain.Common.Lookup", "CompanyType")
                        .WithMany()
                        .HasForeignKey("CompanyTypeId");

                    b.HasOne("ajWebSite.Domain.Common.Person", "Person")
                        .WithMany("Details")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ajWebSite.Domain.Common.PersonDoc", b =>
                {
                    b.HasOne("ajWebSite.Domain.Common.Lookup", "FileType")
                        .WithMany()
                        .HasForeignKey("FileTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ajWebSite.Domain.Common.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("ajWebSite.Domain.Common.newsAndItem", b =>
                {
                    b.HasOne("ajWebSite.Domain.Common.Group", "group")
                        .WithMany()
                        .HasForeignKey("groupId");
                });

            modelBuilder.Entity("ajWebSite.Domain.ajWebSite.ticket", b =>
                {
                    b.HasOne("ajWebSite.Domain.Security.User", "Reciever")
                        .WithMany()
                        .HasForeignKey("RecieverId");

                    b.HasOne("ajWebSite.Domain.Security.User", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId");
                });

            modelBuilder.Entity("ajWebSite.Domain.Security.User", b =>
                {
                    b.HasOne("ajWebSite.Domain.Common.Lookup", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("ajWebSite.Domain.Common.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("ajWebSite.Domain.Security.UserAccess", b =>
                {
                    b.HasOne("ajWebSite.Domain.Security.Access", "Access")
                        .WithMany()
                        .HasForeignKey("AccessId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ajWebSite.Domain.Security.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
