﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(LivesContext))]
    [Migration("20220219044700_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.InscricaoEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<int>("idInscrito")
                        .HasColumnType("int");

                    b.Property<int>("idLive")
                        .HasColumnType("int");

                    b.Property<int>("situacao")
                        .HasColumnType("int");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("vencimento")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("idInscrito");

                    b.HasIndex("idLive");

                    b.ToTable("INSCRICAO", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.InscritoEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<int>("pessoaId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("pessoaId");

                    b.ToTable("INSCRITO", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.InstrutorEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<int>("pessoaId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("pessoaId");

                    b.ToTable("INSTRUTOR", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.LiveEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("dtHrInicio")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int>("duracaoMin")
                        .HasColumnType("int");

                    b.Property<int>("idInstrutor")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("id");

                    b.HasIndex("idInstrutor");

                    b.ToTable("LIVE", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.PessoaEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<bool>("ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("dtNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("instagram")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("PESSOA", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.InscricaoEntity", b =>
                {
                    b.HasOne("Domain.Entities.InscritoEntity", "inscrito")
                        .WithMany("inscricoes")
                        .HasForeignKey("idInscrito")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Domain.Entities.LiveEntity", "live")
                        .WithMany("inscricoes")
                        .HasForeignKey("idLive")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("inscrito");

                    b.Navigation("live");
                });

            modelBuilder.Entity("Domain.Entities.InscritoEntity", b =>
                {
                    b.HasOne("Domain.Entities.PessoaEntity", "pessoa")
                        .WithMany()
                        .HasForeignKey("pessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pessoa");
                });

            modelBuilder.Entity("Domain.Entities.InstrutorEntity", b =>
                {
                    b.HasOne("Domain.Entities.PessoaEntity", "pessoa")
                        .WithMany()
                        .HasForeignKey("pessoaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pessoa");
                });

            modelBuilder.Entity("Domain.Entities.LiveEntity", b =>
                {
                    b.HasOne("Domain.Entities.InstrutorEntity", "instrutor")
                        .WithMany("lives")
                        .HasForeignKey("idInstrutor")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("instrutor");
                });

            modelBuilder.Entity("Domain.Entities.InscritoEntity", b =>
                {
                    b.Navigation("inscricoes");
                });

            modelBuilder.Entity("Domain.Entities.InstrutorEntity", b =>
                {
                    b.Navigation("lives");
                });

            modelBuilder.Entity("Domain.Entities.LiveEntity", b =>
                {
                    b.Navigation("inscricoes");
                });
#pragma warning restore 612, 618
        }
    }
}
