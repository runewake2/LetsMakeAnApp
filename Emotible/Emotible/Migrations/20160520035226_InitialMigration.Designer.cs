using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Emotible.Model;

namespace Emotible.Migrations
{
    [DbContext(typeof(EmoteContext))]
    [Migration("20160520035226_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rc2-20896");

            modelBuilder.Entity("Emotible.Model.EmoteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("LastUsed");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 64);

                    b.Property<int>("TimesUsed");

                    b.HasKey("Id");

                    b.ToTable("Emotes");
                });
        }
    }
}
