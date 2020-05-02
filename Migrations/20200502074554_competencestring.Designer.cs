﻿// <auto-generated />
using System;
using ContosoUniversity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContosoUniversity.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20200502074554_competencestring")]
    partial class competencestring
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContosoUniversity.Models.EmpQuestionnaire", b =>
                {
                    b.Property<int>("EmpQuestionnaireID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("QuestionnaireID")
                        .HasColumnType("int");

                    b.HasKey("EmpQuestionnaireID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("QuestionnaireID");

                    b.ToTable("EmpQuestionnaire");
                });

            modelBuilder.Entity("ContosoUniversity.Models.EmpTeam", b =>
                {
                    b.Property<int>("EmpTeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("EmpTeamID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("TeamID");

                    b.ToTable("EmpTeam");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EmpTeamDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<bool>("IsManager")
                        .HasColumnName("IsManager")
                        .HasColumnType("bit");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnName("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonalityType")
                        .HasColumnName("PersonalityType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnName("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Questionnaire", b =>
                {
                    b.Property<int>("QuestionnaireID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompetencesString")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Cycle")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("QuestionnaireID");

                    b.ToTable("Questionnaire");
                });

            modelBuilder.Entity("ContosoUniversity.Models.QuestionnaireCompetence", b =>
                {
                    b.Property<int>("QuestionnaireCompetenceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Competence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionnaireID")
                        .HasColumnType("int");

                    b.HasKey("QuestionnaireCompetenceID");

                    b.HasIndex("QuestionnaireID");

                    b.ToTable("QuestionnaireCompetence");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Synergy")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("TeamID");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("ContosoUniversity.Models.TeamQuestionnaire", b =>
                {
                    b.Property<int>("TeamQuestionnaireID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("QuestionnaireID")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("TeamQuestionnaireID");

                    b.HasIndex("QuestionnaireID");

                    b.HasIndex("TeamID");

                    b.ToTable("TeamQuestionnaire");
                });

            modelBuilder.Entity("ContosoUniversity.Models.EmpQuestionnaire", b =>
                {
                    b.HasOne("ContosoUniversity.Models.Employee", "Employee")
                        .WithMany("EmpQuestionnaires")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContosoUniversity.Models.Questionnaire", "Questionnaire")
                        .WithMany("EmpQuestionnaires")
                        .HasForeignKey("QuestionnaireID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ContosoUniversity.Models.EmpTeam", b =>
                {
                    b.HasOne("ContosoUniversity.Models.Employee", "Employee")
                        .WithMany("EmpTeams")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContosoUniversity.Models.Team", "Team")
                        .WithMany("EmpTeams")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ContosoUniversity.Models.QuestionnaireCompetence", b =>
                {
                    b.HasOne("ContosoUniversity.Models.Questionnaire", "Questionnaire")
                        .WithMany("QuestionnaireCompetences")
                        .HasForeignKey("QuestionnaireID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ContosoUniversity.Models.TeamQuestionnaire", b =>
                {
                    b.HasOne("ContosoUniversity.Models.Questionnaire", "Questionnaire")
                        .WithMany("TeamQuestionnaires")
                        .HasForeignKey("QuestionnaireID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContosoUniversity.Models.Team", "Team")
                        .WithMany("TeamQuestionnaires")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
