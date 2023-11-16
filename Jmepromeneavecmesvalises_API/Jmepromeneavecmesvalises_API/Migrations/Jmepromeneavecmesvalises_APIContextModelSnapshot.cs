﻿// <auto-generated />
using System;
using Jmepromeneavecmesvalises_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Jmepromeneavecmesvalises_API.Migrations
{
    [DbContext(typeof(Jmepromeneavecmesvalises_APIContext))]
    partial class Jmepromeneavecmesvalises_APIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Jmepromeneavecmesvalises_API.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "fc647606-84c1-11ee-b9d1-0242ac120002",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "711fff69-64d4-457e-ad34-0480e5241254",
                            Email = "admin@test.org",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@TEST.ORG",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEPZEiKnZZQCuDTJh3pdQzMEeV7kegWLp7yxDmEnnS01/vZAUUCYVpwBNZ2GuLiQVmw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1c988132-726d-4a82-be29-8f098940b5da",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = "fc647c64-84c1-11ee-b9d1-0242ac120002",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "487965a9-c84b-4618-a7cc-4c90b1958333",
                            Email = "moi@test.org",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "MOI@TEST.ORG",
                            NormalizedUserName = "MOI",
                            PasswordHash = "AQAAAAIAAYagAAAAEIfjTzULLUueyYGWZeGGE0bDv1Fy/WhXNK0tK+CCwp+NK07u4LwSIFOGAT/OmboRgA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "25be519c-8034-4bad-8f40-2e5cb50c4df3",
                            TwoFactorEnabled = false,
                            UserName = "Moi"
                        },
                        new
                        {
                            Id = "fc647608-84c1-11ee-b9d1-0242ac120002",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "cfa402b6-3ae5-4111-a1f3-17826ad23e2c",
                            Email = "toi@test.org",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "TOI@TEST.ORG",
                            NormalizedUserName = "TOI",
                            PasswordHash = "AQAAAAIAAYagAAAAEPKWqMKtAOq/p+lYQ81J8+jMk0WjmJ50uVbAO/Xr/J8EFsALxtD6UHZOBaDcWmLUgw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f946ffe6-93b5-4722-864e-08e290860735",
                            TwoFactorEnabled = false,
                            UserName = "Toi"
                        });
                });

            modelBuilder.Entity("Jmepromeneavecmesvalises_API.Models.Voyage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Img")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Voyage");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Destination = "Séoul",
                            Img = "https://content.r9cdn.net/rimg/dimg/30/0c/6318617a-city-35982-163ff913019.jpg?width=1366&height=768&xhint=2421&yhint=1876&crop=true",
                            IsPublic = true
                        },
                        new
                        {
                            Id = 2,
                            Destination = "Tachkent",
                            Img = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/15/33/fb/7b/tashkent.jpg?w=700&h=500&s=1",
                            IsPublic = true
                        },
                        new
                        {
                            Id = 3,
                            Destination = "Damas",
                            Img = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/51/Damascus2009.JPG/1200px-Damascus2009.JPG",
                            IsPublic = false
                        },
                        new
                        {
                            Id = 4,
                            Destination = "Kiev",
                            Img = "https://cdn.britannica.com/18/194818-050-E7A7A993/view-Kiev-Ukraine.jpg",
                            IsPublic = false
                        },
                        new
                        {
                            Id = 5,
                            Destination = "Jérusalem",
                            Img = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a4/2014-06_Israel_-_Jerusalem_090_%2814936890061%29.jpg/640px-2014-06_Israel_-_Jerusalem_090_%2814936890061%29.jpg",
                            IsPublic = false
                        },
                        new
                        {
                            Id = 6,
                            Destination = "Pyongyang",
                            Img = "https://static.latribune.fr/1061511/les-sanctions-us-mauvaises-pour-la-denuclearisation-selon-pyongyang.jpg",
                            IsPublic = true
                        },
                        new
                        {
                            Id = 7,
                            Destination = "Moscou",
                            Img = "https://aeroports-de-lyon.imgix.net/sites/default/files/2020-05/moscou-header.jpg?fit=max&ixlib=php-3.3.1&w=900&s=c4a830ca34826699af3b72b3560efc32",
                            IsPublic = false
                        },
                        new
                        {
                            Id = 8,
                            Destination = "Kigali",
                            Img = "https://prod.cdn-medias.jeuneafrique.com/cdn-cgi/image/q=auto,f=auto,metadata=none,width=1215,height=810,fit=cover/https://prod.cdn-medias.jeuneafrique.com/medias/2017/07/21/13764hr_-e1501750068833.jpg",
                            IsPublic = false
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("UserVoyage", b =>
                {
                    b.Property<string>("ProprietairesId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("VoyagesId")
                        .HasColumnType("int");

                    b.HasKey("ProprietairesId", "VoyagesId");

                    b.HasIndex("VoyagesId");

                    b.ToTable("UserVoyage");

                    b.HasData(
                        new
                        {
                            ProprietairesId = "fc647606-84c1-11ee-b9d1-0242ac120002",
                            VoyagesId = 1
                        },
                        new
                        {
                            ProprietairesId = "fc647c64-84c1-11ee-b9d1-0242ac120002",
                            VoyagesId = 2
                        },
                        new
                        {
                            ProprietairesId = "fc647608-84c1-11ee-b9d1-0242ac120002",
                            VoyagesId = 3
                        },
                        new
                        {
                            ProprietairesId = "fc647606-84c1-11ee-b9d1-0242ac120002",
                            VoyagesId = 4
                        },
                        new
                        {
                            ProprietairesId = "fc647c64-84c1-11ee-b9d1-0242ac120002",
                            VoyagesId = 5
                        },
                        new
                        {
                            ProprietairesId = "fc647608-84c1-11ee-b9d1-0242ac120002",
                            VoyagesId = 6
                        },
                        new
                        {
                            ProprietairesId = "fc647606-84c1-11ee-b9d1-0242ac120002",
                            VoyagesId = 7
                        },
                        new
                        {
                            ProprietairesId = "fc647c64-84c1-11ee-b9d1-0242ac120002",
                            VoyagesId = 8
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Jmepromeneavecmesvalises_API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Jmepromeneavecmesvalises_API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jmepromeneavecmesvalises_API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Jmepromeneavecmesvalises_API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserVoyage", b =>
                {
                    b.HasOne("Jmepromeneavecmesvalises_API.Models.User", null)
                        .WithMany()
                        .HasForeignKey("ProprietairesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Jmepromeneavecmesvalises_API.Models.Voyage", null)
                        .WithMany()
                        .HasForeignKey("VoyagesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
