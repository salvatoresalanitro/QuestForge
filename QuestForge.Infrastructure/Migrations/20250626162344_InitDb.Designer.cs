﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuestForge.Infrastructure.Data;

#nullable disable

namespace QuestForge.Infrastructure.Migrations
{
    [DbContext(typeof(QuestForgeContext))]
    [Migration("20250626162344_InitDb")]
    partial class InitDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.6");

            modelBuilder.Entity("QuestForge.Core.Entities.Campaign", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("QuestForge.Core.Entities.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ArmorClass")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("CampaignId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Class")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HitPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Level")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Species")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("QuestForge.Core.Entities.Enemy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CampaignId")
                        .HasColumnType("TEXT");

                    b.Property<double>("ChallengeRating")
                        .HasColumnType("REAL");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.ToTable("Enemies");
                });

            modelBuilder.Entity("QuestForge.Core.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CampaignId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("OwnerCharacterId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.HasIndex("OwnerCharacterId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("QuestForge.Core.Entities.Npc", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CampaignId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CampaignId");

                    b.ToTable("Npcs");
                });

            modelBuilder.Entity("QuestForge.Core.Entities.Character", b =>
                {
                    b.HasOne("QuestForge.Core.Entities.Campaign", "Campaign")
                        .WithMany("Characters")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("QuestForge.Core.Entities.Enemy", b =>
                {
                    b.HasOne("QuestForge.Core.Entities.Campaign", "Campaign")
                        .WithMany("Enemies")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("QuestForge.Core.Entities.Item", b =>
                {
                    b.HasOne("QuestForge.Core.Entities.Campaign", "Campaign")
                        .WithMany("Items")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QuestForge.Core.Entities.Character", "OwnerCharacter")
                        .WithMany("Items")
                        .HasForeignKey("OwnerCharacterId");

                    b.Navigation("Campaign");

                    b.Navigation("OwnerCharacter");
                });

            modelBuilder.Entity("QuestForge.Core.Entities.Npc", b =>
                {
                    b.HasOne("QuestForge.Core.Entities.Campaign", "Campaign")
                        .WithMany("Npcs")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("QuestForge.Core.Entities.Campaign", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Enemies");

                    b.Navigation("Items");

                    b.Navigation("Npcs");
                });

            modelBuilder.Entity("QuestForge.Core.Entities.Character", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
