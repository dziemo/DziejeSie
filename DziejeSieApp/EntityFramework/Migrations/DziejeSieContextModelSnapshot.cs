﻿// <auto-generated />
using System;
using EntityFramework.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DziejeSieApp.Migrations
{
    [DbContext(typeof(DziejeSieContext))]
    partial class DziejeSieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DziejeSieApp.Models.Events", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddDate");

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime>("EventDate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Postcode")
                        .IsRequired();

                    b.Property<string>("Town")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("DziejeSieApp.Models.Users", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("RegisterDate");

                    b.HasKey("IdUser");

                    b.ToTable("User");
                });

            modelBuilder.Entity("DziejeSieApp.Models.Events", b =>
                {
                    b.HasOne("DziejeSieApp.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
