﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantReservation.Db.Data;

namespace RestaurantReservation.Db.Migrations
{
    [DbContext(typeof(RestaurantReservationDbContext))]
    partial class RestaurantReservationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            CustomerPhoneNumber = "123-456-7890",
                            Email = "John.doe@example.com",
                            FirstName = "John",
                            LastName = "Doe"
                        },
                        new
                        {
                            CustomerId = 2,
                            CustomerPhoneNumber = "987-654-3210",
                            Email = "Jane.doe@example.com",
                            FirstName = "Jane",
                            LastName = "Doe"
                        },
                        new
                        {
                            CustomerId = 3,
                            CustomerPhoneNumber = "555-123-4567",
                            Email = "Alice.smith@example.com",
                            FirstName = "Alice",
                            LastName = "Smith"
                        },
                        new
                        {
                            CustomerId = 4,
                            CustomerPhoneNumber = "555-987-6543",
                            Email = "Bob.smith@example.com",
                            FirstName = "Bob",
                            LastName = "Smith"
                        },
                        new
                        {
                            CustomerId = 5,
                            CustomerPhoneNumber = "555-555-5555",
                            Email = "Charlie.brown@example.com",
                            FirstName = "Charlie",
                            LastName = "Brown"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Ella",
                            LastName = "Fitzgerald",
                            Position = "Manager",
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Louis",
                            LastName = "Armstrong",
                            Position = "Chef",
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Billie",
                            LastName = "Holiday",
                            Position = "Waiter",
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Charlie",
                            LastName = "Parker",
                            Position = "Cashier",
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Dizzy",
                            LastName = "Gillespie",
                            Position = "Waiter",
                            RestaurantId = 2
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("MenuItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A juicy beef patty with lettuce, tomato, and our special sauce.",
                            Name = "Classic Burger",
                            Price = 8.99m,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "A delicious and hearty vegetarian burger loaded with fresh vegetables.",
                            Name = "Veggie Burger",
                            Price = 9.50m,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Crisp romaine lettuce with grilled chicken breast, shaved parmesan, and croutons.",
                            Name = "Chicken Caesar Salad",
                            Price = 7.75m,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 4,
                            Description = "Classic pizza with fresh mozzarella, tomatoes, and basil.",
                            Name = "Margherita Pizza",
                            Price = 12.00m,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 5,
                            Description = "Creamy pasta with pancetta, parmesan cheese, and a touch of egg.",
                            Name = "Pasta Carbonara",
                            Price = 11.00m,
                            RestaurantId = 3
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReservationId")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("ReservationId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 5,
                            OrderDate = new DateTime(2024, 5, 18, 10, 0, 25, 896, DateTimeKind.Local).AddTicks(8183),
                            ReservationId = 1,
                            TotalAmount = 45m
                        },
                        new
                        {
                            Id = 2,
                            EmployeeId = 3,
                            OrderDate = new DateTime(2024, 5, 17, 10, 0, 25, 898, DateTimeKind.Local).AddTicks(1291),
                            ReservationId = 2,
                            TotalAmount = 30m
                        },
                        new
                        {
                            Id = 3,
                            EmployeeId = 3,
                            OrderDate = new DateTime(2024, 5, 16, 10, 0, 25, 898, DateTimeKind.Local).AddTicks(1316),
                            ReservationId = 3,
                            TotalAmount = 60m
                        },
                        new
                        {
                            Id = 4,
                            EmployeeId = 5,
                            OrderDate = new DateTime(2024, 5, 15, 10, 0, 25, 898, DateTimeKind.Local).AddTicks(1320),
                            ReservationId = 4,
                            TotalAmount = 22m
                        },
                        new
                        {
                            Id = 5,
                            EmployeeId = 3,
                            OrderDate = new DateTime(2024, 5, 14, 10, 0, 25, 898, DateTimeKind.Local).AddTicks(1322),
                            ReservationId = 5,
                            TotalAmount = 80m
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MenuItemId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            MenuItemId = 1,
                            OrderId = 1,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 2,
                            MenuItemId = 2,
                            OrderId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 3,
                            MenuItemId = 3,
                            OrderId = 2,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 4,
                            MenuItemId = 4,
                            OrderId = 2,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 5,
                            MenuItemId = 5,
                            OrderId = 3,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 6,
                            MenuItemId = 1,
                            OrderId = 3,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 7,
                            MenuItemId = 2,
                            OrderId = 4,
                            Quantity = 4
                        },
                        new
                        {
                            Id = 8,
                            MenuItemId = 3,
                            OrderId = 4,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 9,
                            MenuItemId = 4,
                            OrderId = 5,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 10,
                            MenuItemId = 5,
                            OrderId = 5,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int?>("TableId")
                        .HasColumnType("int");

                    b.HasKey("ReservationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantId");

                    b.HasIndex("TableId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            ReservationId = 1,
                            CustomerId = 1,
                            PartySize = 4,
                            ReservationDate = new DateTime(2024, 5, 22, 0, 0, 0, 0, DateTimeKind.Local),
                            RestaurantId = 1,
                            TableId = 1
                        },
                        new
                        {
                            ReservationId = 2,
                            CustomerId = 2,
                            PartySize = 2,
                            ReservationDate = new DateTime(2024, 5, 23, 0, 0, 0, 0, DateTimeKind.Local),
                            RestaurantId = 1,
                            TableId = 2
                        },
                        new
                        {
                            ReservationId = 3,
                            CustomerId = 3,
                            PartySize = 6,
                            ReservationDate = new DateTime(2024, 5, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            RestaurantId = 2,
                            TableId = 3
                        },
                        new
                        {
                            ReservationId = 4,
                            CustomerId = 4,
                            PartySize = 3,
                            ReservationDate = new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Local),
                            RestaurantId = 2,
                            TableId = 4
                        },
                        new
                        {
                            ReservationId = 5,
                            CustomerId = 5,
                            PartySize = 5,
                            ReservationDate = new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Local),
                            RestaurantId = 3,
                            TableId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Restaurant", b =>
                {
                    b.Property<int>("RestaurantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningHours")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RestaurantId");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            RestaurantId = 1,
                            Address = "1234 Culinary Blvd, Foodie Town",
                            Name = "Gourmet Hub",
                            OpeningHours = "9:00 AM - 11:00 PM",
                            PhoneNumber = "555-1234"
                        },
                        new
                        {
                            RestaurantId = 2,
                            Address = "5678 Pasta Lane, Little Italy",
                            Name = "The Italian Corner",
                            OpeningHours = "11:00 AM - 10:00 PM",
                            PhoneNumber = "555-5678"
                        },
                        new
                        {
                            RestaurantId = 3,
                            Address = "135 Sushi St, Downtown",
                            Name = "Sushi Sushi",
                            OpeningHours = "12:00 PM - 10:00 PM",
                            PhoneNumber = "555-1357"
                        },
                        new
                        {
                            RestaurantId = 4,
                            Address = "2468 Curry Ave, Spice City",
                            Name = "Curry Leaf",
                            OpeningHours = "10:00 AM - 9:00 PM",
                            PhoneNumber = "555-2468"
                        },
                        new
                        {
                            RestaurantId = 5,
                            Address = "7890 Burger Blvd, Greasy Corner",
                            Name = "The Burger Joint",
                            OpeningHours = "10:00 AM - 12:00 AM",
                            PhoneNumber = "555-7890"
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int?>("RestaurantId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Tables");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 4,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 2,
                            RestaurantId = 1
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 6,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 4,
                            Capacity = 4,
                            RestaurantId = 2
                        },
                        new
                        {
                            Id = 5,
                            Capacity = 8,
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 6,
                            Capacity = 4,
                            RestaurantId = 3
                        },
                        new
                        {
                            Id = 7,
                            Capacity = 4,
                            RestaurantId = 4
                        },
                        new
                        {
                            Id = 8,
                            Capacity = 2,
                            RestaurantId = 4
                        },
                        new
                        {
                            Id = 9,
                            Capacity = 4,
                            RestaurantId = 5
                        },
                        new
                        {
                            Id = 10,
                            Capacity = 6,
                            RestaurantId = 5
                        });
                });

            modelBuilder.Entity("RestaurantReservation.Db.ViewModels.EmployeeDetails", b =>
                {
                    b.Property<string>("EmployeeFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeLastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<string>("RestaurantName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantOpeningHours")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RestaurantPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.ToView("EmployeesDetailsView");
                });

            modelBuilder.Entity("RestaurantReservation.Db.ViewModels.ReservationDetails", b =>
                {
                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("CustomerPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OpeningHours")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PartySize")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.Property<int>("RestaurantId")
                        .HasColumnType("int");

                    b.Property<int>("TableId")
                        .HasColumnType("int");

                    b.ToView("ReservationsDetailsView");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Employee", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Entities.Restaurant", "Restaurant")
                        .WithMany("Employees")
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.MenuItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Entities.Restaurant", "Restaurant")
                        .WithMany("MenuItems")
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Order", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Entities.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("RestaurantReservation.Db.Entities.Reservation", "Reservation")
                        .WithMany("Orders")
                        .HasForeignKey("ReservationId");

                    b.Navigation("Employee");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.OrderItem", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Entities.MenuItem", "MenuItem")
                        .WithMany("OrderItems")
                        .HasForeignKey("MenuItemId");

                    b.HasOne("RestaurantReservation.Db.Entities.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Reservation", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Entities.Customer", "Customer")
                        .WithMany("Reservations")
                        .HasForeignKey("CustomerId");

                    b.HasOne("RestaurantReservation.Db.Entities.Restaurant", "Restaurant")
                        .WithMany("Reservations")
                        .HasForeignKey("RestaurantId");

                    b.HasOne("RestaurantReservation.Db.Entities.Table", "Table")
                        .WithMany("Reservations")
                        .HasForeignKey("TableId");

                    b.Navigation("Customer");

                    b.Navigation("Restaurant");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Table", b =>
                {
                    b.HasOne("RestaurantReservation.Db.Entities.Restaurant", "Restaurant")
                        .WithMany("Tables")
                        .HasForeignKey("RestaurantId");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Customer", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.MenuItem", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Reservation", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Restaurant", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("MenuItems");

                    b.Navigation("Reservations");

                    b.Navigation("Tables");
                });

            modelBuilder.Entity("RestaurantReservation.Db.Entities.Table", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
