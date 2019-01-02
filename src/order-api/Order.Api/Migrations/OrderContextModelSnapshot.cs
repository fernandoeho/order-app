﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Order.Api.Infrastructure;

namespace Order.Api.Migrations
{
    [DbContext(typeof(OrderContext))]
    partial class OrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065");

            modelBuilder.Entity("Order.Api.Models.Dish", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("TimeOfDay");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Dishes");

                    b.HasData(
                        new { Id = new Guid("7a9bb754-6026-4683-975f-f65bf3d25e96"), Name = "Eggs", TimeOfDay = 1, Type = 1 },
                        new { Id = new Guid("87dc3049-78cc-4f91-b1c0-ad1e1be4e7b2"), Name = "Toast", TimeOfDay = 1, Type = 2 },
                        new { Id = new Guid("3cb8ce5d-655c-4b54-a587-3a6f3e73b586"), Name = "Coffee", TimeOfDay = 1, Type = 3 },
                        new { Id = new Guid("3f70f7cf-7b84-47eb-8bcc-25bd9e42435c"), Name = "Steak", TimeOfDay = 2, Type = 1 },
                        new { Id = new Guid("65e37006-7644-4222-86bb-52743e498772"), Name = "Potato", TimeOfDay = 2, Type = 2 },
                        new { Id = new Guid("794d74ff-acbd-43a6-9476-0f702ba234fc"), Name = "Wine", TimeOfDay = 2, Type = 3 },
                        new { Id = new Guid("926f0a4d-d937-4f6f-ad6f-75b70716c912"), Name = "Cake", TimeOfDay = 2, Type = 4 }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
