﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tracker.api.data;

#nullable disable

namespace tracker.api.Migrations.AuthDB
{
    [DbContext(typeof(AuthDBContext))]
    [Migration("20231128072012_Auth_one")]
    partial class Auth_one
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IdentityRole");

                    b.HasData(
                        new
                        {
                            Id = "ded07973-30ec-4d8e-aa14-92b55cf3b066",
                            ConcurrencyStamp = "ded07973-30ec-4d8e-aa14-92b55cf3b066",
                            Name = "Reader",
                            NormalizedName = "READER"
                        },
                        new
                        {
                            Id = "c80e669a-ec46-412b-9e0a-3a6ec5f63316",
                            ConcurrencyStamp = "c80e669a-ec46-412b-9e0a-3a6ec5f63316",
                            Name = "Writer",
                            NormalizedName = "WRITER"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}