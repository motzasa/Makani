using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Makani.Models;

namespace Makani.Migrations
{
    [DbContext(typeof(MakaniContext))]
    [Migration("20160409122225_forign")]
    partial class forign
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Makani.Models.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("PackagePackageId");

                    b.HasKey("CityId");
                });

            modelBuilder.Entity("Makani.Models.Package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("CommercialName");

                    b.Property<string>("Continent");

                    b.Property<string>("Country");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Creator");

                    b.Property<string>("Description");

                    b.Property<string>("DurationCategory");

                    b.Property<string>("DurationDays");

                    b.Property<decimal>("Price");

                    b.Property<string>("Rate");

                    b.Property<string>("TTD");

                    b.Property<string>("TTDDescription");

                    b.Property<decimal>("TotalPrice");

                    b.HasKey("PackageId");
                });

            modelBuilder.Entity("Makani.Models.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int?>("PackagePackageId");

                    b.Property<string>("Path");

                    b.HasKey("PhotoId");
                });

            modelBuilder.Entity("Makani.Models.City", b =>
                {
                    b.HasOne("Makani.Models.Package")
                        .WithMany()
                        .HasForeignKey("PackagePackageId");
                });

            modelBuilder.Entity("Makani.Models.Photo", b =>
                {
                    b.HasOne("Makani.Models.Package")
                        .WithMany()
                        .HasForeignKey("PackagePackageId");
                });
        }
    }
}
