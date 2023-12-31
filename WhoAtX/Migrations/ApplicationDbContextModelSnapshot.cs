﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhoAtX.Data;

#nullable disable

namespace WhoAtX.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.11");

            modelBuilder.Entity("WhoAtX.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AreasOfKnowledge")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NamePronunciationPath")
                        .HasColumnType("TEXT");

                    b.Property<string>("Projects")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Pronouns")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Team")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TimeZone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("WorkingHours")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserProfiles");
                });
#pragma warning restore 612, 618
        }
    }
}
