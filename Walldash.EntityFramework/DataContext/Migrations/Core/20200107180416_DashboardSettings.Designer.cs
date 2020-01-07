﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Walldash.EntityFramework.DataContext;

namespace Walldash.EntityFramework.DataContext.Migrations.Core
{
    [DbContext(typeof(CoreContext))]
    [Migration("20200107180416_DashboardSettings")]
    partial class DashboardSettings
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Walldash.Domain.Model.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Token")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.HasKey("Id");

                    b.HasAlternateKey("Token");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Walldash.Domain.Model.Dashboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BackgroundColor")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("#e7ecf2");

                    b.Property<int>("Columns")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(6);

                    b.Property<string>("NavbarColor")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("#0f1723");

                    b.Property<int>("Rows")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(3);

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Dashboards");
                });

            modelBuilder.Entity("Walldash.Domain.Model.Metric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Number")
                        .HasColumnType("float");

                    b.Property<string>("Tag")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("Timestamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValueSql("SYSDATETIMEOFFSET()");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Metrics");
                });

            modelBuilder.Entity("Walldash.Domain.Model.Widget", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BackgroundColor")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("#fff");

                    b.Property<int>("DashboardId")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("MetricAlias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TagFilter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextColor")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("#000");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.Property<string>("widget_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DashboardId");

                    b.ToTable("Widgets");

                    b.HasDiscriminator<string>("widget_type").HasValue("widget_base");
                });

            modelBuilder.Entity("Walldash.Domain.Model.GraphWidget", b =>
                {
                    b.HasBaseType("Walldash.Domain.Model.Widget");

                    b.Property<string>("GraphColor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GraphType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GraphValueX")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GraphValueY")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("widget_graph");
                });

            modelBuilder.Entity("Walldash.Domain.Model.Dashboard", b =>
                {
                    b.HasOne("Walldash.Domain.Model.Account", null)
                        .WithMany("Dashboards")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Walldash.Domain.Model.Metric", b =>
                {
                    b.HasOne("Walldash.Domain.Model.Account", null)
                        .WithMany("Metrics")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Walldash.Domain.Model.Widget", b =>
                {
                    b.HasOne("Walldash.Domain.Model.Dashboard", null)
                        .WithMany("Widgets")
                        .HasForeignKey("DashboardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
