﻿// <auto-generated />
using System;
using AbCorFloProyectoEasyTicketsP2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AbCorFloProyectoEasyTicketsP2.Migrations
{
    [DbContext(typeof(AbCorFloProyectoEasyTicketsP2Context))]
    partial class AbCorFloProyectoEasyTicketsP2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoEasyTicket.Models.ACFReviews", b =>
                {
                    b.Property<int>("ACFReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ACFReviewID"));

                    b.Property<int>("ACFCalificacion")
                        .HasColumnType("int");

                    b.Property<string>("ACFComentario")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("ACFFecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("ACFTicketID")
                        .HasColumnType("int");

                    b.HasKey("ACFReviewID");

                    b.HasIndex("ACFTicketID");

                    b.ToTable("ACFReviews");
                });

            modelBuilder.Entity("ProyectoEasyTicket.Models.ACFTicket", b =>
                {
                    b.Property<int>("ACFTicketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ACFTicketID"));

                    b.Property<string>("ACFButacaSeccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ACFContrasenia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ACFEvento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ACFFecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("ACFLugar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ACFPrecio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ACFTelefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ACFVendido")
                        .HasColumnType("bit");

                    b.HasKey("ACFTicketID");

                    b.ToTable("ACFTicket");
                });

            modelBuilder.Entity("ProyectoEasyTicket.Models.ACFReviews", b =>
                {
                    b.HasOne("ProyectoEasyTicket.Models.ACFTicket", "ACFTicket")
                        .WithMany("Reviewss")
                        .HasForeignKey("ACFTicketID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ACFTicket");
                });

            modelBuilder.Entity("ProyectoEasyTicket.Models.ACFTicket", b =>
                {
                    b.Navigation("Reviewss");
                });
#pragma warning restore 612, 618
        }
    }
}
