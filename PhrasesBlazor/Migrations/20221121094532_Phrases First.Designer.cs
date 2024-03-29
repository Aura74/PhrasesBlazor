﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhrasesBlazor.Services;

#nullable disable

namespace PhrasesBlazor.Migrations
{
    [DbContext(typeof(PhrasesDbContext))]
    [Migration("20221121094532_Phrases First")]
    partial class PhrasesFirst
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PhrasesBlazor.Data.Phrases", b =>
                {
                    b.Property<int>("PhraseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhraseID"));

                    b.Property<int>("ApplicationID")
                        .HasColumnType("int");

                    b.Property<string>("Culture")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Element")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OrginalPhrase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PageID")
                        .HasColumnType("int");

                    b.Property<string>("Phrase")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhraseDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created")
                        .HasColumnType("datetime2");

                    b.HasKey("PhraseID");

                    b.ToTable("Phrases");
                });
#pragma warning restore 612, 618
        }
    }
}
