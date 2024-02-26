﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RPGCardsGenerator.Variables;

#nullable disable

namespace RPGCardsGenerator.Migrations
{
    [DbContext(typeof(BoardsContext))]
    partial class BoardsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RPGCardsGenerator.Variables.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Character");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Character");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("RPGCardsGenerator.Variables.Statistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("CharaterId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Statistics");
                });

            modelBuilder.Entity("RPGCardsGenerator.Variables.NPC", b =>
                {
                    b.HasBaseType("RPGCardsGenerator.Variables.Character");

                    b.HasDiscriminator().HasValue("NPC");
                });

            modelBuilder.Entity("RPGCardsGenerator.Variables.PlayerCharacter", b =>
                {
                    b.HasBaseType("RPGCardsGenerator.Variables.Character");

                    b.Property<string>("NameOfPlayer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("PlayerCharacter");
                });

            modelBuilder.Entity("RPGCardsGenerator.Variables.Statistic", b =>
                {
                    b.HasOne("RPGCardsGenerator.Variables.Character", "Character")
                        .WithMany("Stats")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("RPGCardsGenerator.Variables.Character", b =>
                {
                    b.Navigation("Stats");
                });
#pragma warning restore 612, 618
        }
    }
}