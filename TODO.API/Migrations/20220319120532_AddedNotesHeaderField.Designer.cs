// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TODO.API.Data;

#nullable disable

namespace Todo.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220319120532_AddedNotesHeaderField")]
    partial class AddedNotesHeaderField
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.2");

            modelBuilder.Entity("TODO.API.Models.NotesDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Archived")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("NotesHeaderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NotesHeaderId");

                    b.ToTable("NotesDetails");
                });

            modelBuilder.Entity("TODO.API.Models.NotesHeader", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("NotesHeaders");
                });

            modelBuilder.Entity("TODO.API.Models.NotesDetail", b =>
                {
                    b.HasOne("TODO.API.Models.NotesHeader", "NotesHeader")
                        .WithMany("NotesDetails")
                        .HasForeignKey("NotesHeaderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NotesHeader");
                });

            modelBuilder.Entity("TODO.API.Models.NotesHeader", b =>
                {
                    b.Navigation("NotesDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
