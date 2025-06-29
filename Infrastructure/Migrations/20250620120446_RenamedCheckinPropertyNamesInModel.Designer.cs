﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AssignmentContext))]
    [Migration("20250620120446_RenamedCheckinPropertyNamesInModel")]
    partial class RenamedCheckinPropertyNamesInModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Models.CheckinModel", b =>
                {
                    b.Property<long>("checkin_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("checkin_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("checkin_id"));

                    b.Property<long>("created_by_id")
                        .HasColumnType("bigint")
                        .HasColumnName("created_by_id");

                    b.Property<string>("message")
                        .HasColumnType("text")
                        .HasColumnName("message");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("timestamp");

                    b.Property<long>("user_id")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("checkin_id");

                    b.ToTable("checkin");
                });
#pragma warning restore 612, 618
        }
    }
}
