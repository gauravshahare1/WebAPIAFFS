﻿// <auto-generated />
using System;
using WebAPIAFFS.DAL.DBContext1;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebAPIAFFS.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230921071643_intial")]
    partial class intial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebAPIAFFS.DAL.Entity.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<string>("RefCode")
                        .HasColumnType("character varying")
                        .HasColumnName("ref_code");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("departments");
                });

            modelBuilder.Entity("WebAPIAFFS.DAL.Entity.District", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<string>("RefCode")
                        .HasColumnType("character varying")
                        .HasColumnName("ref_code");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("districts");
                });

            modelBuilder.Entity("WebAPIAFFS.DAL.Entity.FinancialYear", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("financial_years");
                });

            modelBuilder.Entity("WebAPIAFFS.DAL.Entity.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid?>("DepartmentId")
                        .HasColumnType("uuid")
                        .HasColumnName("department_id");

                    b.Property<string>("Description")
                        .HasColumnType("character varying")
                        .HasColumnName("description");

                    b.Property<Guid?>("FinancialYearId")
                        .HasColumnType("uuid")
                        .HasColumnName("financial_year_id");

                    b.Property<char?>("Mode")
                        .HasColumnType("char")
                        .HasColumnName("mode");

                    b.Property<string>("Name")
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<Guid?>("ProjectNatureId")
                        .HasColumnType("uuid")
                        .HasColumnName("project_nature_id");

                    b.Property<Guid?>("ProjectTypeId")
                        .HasColumnType("uuid")
                        .HasColumnName("project_type_id");

                    b.Property<DateTime?>("UpdateAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("update_at");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("FinancialYearId");

                    b.HasIndex("ProjectNatureId");

                    b.HasIndex("ProjectTypeId");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("WebAPIAFFS.DAL.Entity.ProjectNature", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("project_natures");
                });

            modelBuilder.Entity("WebAPIAFFS.DAL.Entity.ProjectType", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<Guid?>("ProjectNatureId")
                        .HasColumnType("uuid")
                        .HasColumnName("project_nature_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("ProjectNatureId");

                    b.ToTable("prroject_type");
                });

            modelBuilder.Entity("WebAPIAFFS.DAL.Entity.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid?>("DistrictId")
                        .HasColumnType("uuid")
                        .HasColumnName("district_id");

                    b.Property<Guid?>("ProjectId")
                        .HasColumnType("uuid")
                        .HasColumnName("project_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.HasIndex("ProjectId");

                    b.ToTable("sites");
                });

            modelBuilder.Entity("WebAPIAFFS.DAL.Entity.Project", b =>
                {
                    b.HasOne("WebAPIAFFS.DAL.Entity.Department", "Department")
                        .WithMany("Projects")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("WebAPIAFFS.DAL.Entity.FinancialYear", "FinancialYear")
                        .WithMany("Projects")
                        .HasForeignKey("FinancialYearId");

                    b.HasOne("WebAPIAFFS.DAL.Entity.ProjectNature", "ProjectNature")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectNatureId");

                    b.HasOne("WebAPIAFFS.DAL.Entity.ProjectType", "ProjectType")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectTypeId");

                    b.Navigation("Department");

                    b.Navigation("FinancialYear");

                    b.Navigation("ProjectNature");

                    b.Navigation("ProjectType");
                });

            modelBuilder.Entity("WebAPIAFFS.DAL.Entity.ProjectType", b =>
                {
                    b.HasOne("WebAPIAFFS.DAL.Entity.ProjectNature", "ProjectNature")
                        .WithMany("ProjectTypes")
                        .HasForeignKey("ProjectNatureId");

                    b.Navigation("ProjectNature");
                });

            modelBuilder.Entity("WebAPIAFFS.DAL.Entity.Site", b =>
                {
                    b.HasOne("WebAPIAFFS.DAL.Entity.District", "District")
                        .WithMany("Sites")
                        .HasForeignKey("DistrictId");

                    b.HasOne("WebAPIAFFS.DAL.Entity.Project", "Project")
                        .WithMany("Sites")
                        .HasForeignKey("ProjectId");

                    b.Navigation("District");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("WebAPIAFFS.DAL.Entity.Department", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("WebAPIAFFS.DAL.Entity.District", b =>
                {
                    b.Navigation("Sites");
                });

            modelBuilder.Entity("WebAPIAFFS.DAL.Entity.FinancialYear", b =>
                {
                    b.Navigation("Projects");
                });

            modelBuilder.Entity("WebAPIAFFS.DAL.Entity.Project", b =>
                {
                    b.Navigation("Sites");
                });

            modelBuilder.Entity("WebAPIAFFS.DAL.Entity.ProjectNature", b =>
                {
                    b.Navigation("ProjectTypes");

                    b.Navigation("Projects");
                });

            modelBuilder.Entity("WebAPIAFFS.DAL.Entity.ProjectType", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
