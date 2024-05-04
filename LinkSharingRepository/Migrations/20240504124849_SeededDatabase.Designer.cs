﻿// <auto-generated />
using LinkSharingRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LinkSharingRepository.Migrations
{
    [DbContext(typeof(SQLiteContext))]
    [Migration("20240504124849_SeededDatabase")]
    partial class SeededDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("LinkSharingRepository.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Icon = "icon-stack-overflow.svg",
                            Name = "Stack Overflow"
                        },
                        new
                        {
                            Id = 2,
                            Icon = "icon-youtube.svg",
                            Name = "You Tube"
                        },
                        new
                        {
                            Id = 3,
                            Icon = "icon-gitlab.svg",
                            Name = "GitHub"
                        },
                        new
                        {
                            Id = 4,
                            Icon = "icon-facebook.svg",
                            Name = "Facebook"
                        },
                        new
                        {
                            Id = 5,
                            Icon = "icon-twitter.svg",
                            Name = "Twitter"
                        },
                        new
                        {
                            Id = 6,
                            Icon = "icon-freecodecamp.svg",
                            Name = "Free Code Camp"
                        },
                        new
                        {
                            Id = 7,
                            Icon = "icon-twitch.svg",
                            Name = "Twitch"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}