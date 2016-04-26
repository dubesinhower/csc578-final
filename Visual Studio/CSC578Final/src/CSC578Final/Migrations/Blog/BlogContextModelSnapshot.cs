using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using CSC578Final.Models;

namespace CSC578Final.Migrations.Blog
{
    [DbContext(typeof(BlogContext))]
    partial class BlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CSC578Final.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Author");

                    b.Property<string>("Body");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Edited");

                    b.Property<int>("PostId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CSC578Final.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AuthorId");

                    b.Property<string>("Body");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Edited");

                    b.Property<string>("Title");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("CSC578Final.Models.Comment", b =>
                {
                    b.HasOne("CSC578Final.Models.Post")
                        .WithMany()
                        .HasForeignKey("PostId");
                });
        }
    }
}
