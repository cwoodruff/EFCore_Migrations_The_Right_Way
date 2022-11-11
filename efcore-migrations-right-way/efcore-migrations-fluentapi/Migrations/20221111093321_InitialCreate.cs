using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efcoremigrationsfluentapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Artist",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "[LastName] + ', ' + [FirstName]"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ReportsTo = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    State = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Report",
                        column: x => x.ReportsTo,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MediaType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Playlist",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Album_ArtistId",
                        column: x => x.ArtistId,
                        principalSchema: "dbo",
                        principalTable: "Artist",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true, computedColumnSql: "[LastName] + ', ' + [FirstName]"),
                    Company = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    State = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    SupportRepId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Employee_SupportRepId",
                        column: x => x.SupportRepId,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    MediaTypeId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Composer = table.Column<string>(type: "nvarchar(220)", maxLength: 220, nullable: true),
                    Milliseconds = table.Column<int>(type: "int", nullable: false),
                    Bytes = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Track_AlbumId",
                        column: x => x.AlbumId,
                        principalSchema: "dbo",
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Track_GenreId",
                        column: x => x.GenreId,
                        principalSchema: "dbo",
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Track_MediaType",
                        column: x => x.MediaTypeId,
                        principalSchema: "dbo",
                        principalTable: "MediaType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    BillingAddress = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    BillingCity = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    BillingState = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    BillingCountry = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    BillingPostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Total = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer",
                        column: x => x.CustomerId,
                        principalSchema: "dbo",
                        principalTable: "Customer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlaylistTrack",
                schema: "dbo",
                columns: table => new
                {
                    PlaylistId = table.Column<int>(type: "int", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist_A4A6282E25869641", x => new { x.PlaylistId, x.TrackId });
                    table.ForeignKey(
                        name: "FK_PlaylistTrack_Playlist",
                        column: x => x.PlaylistId,
                        principalSchema: "dbo",
                        principalTable: "Playlist",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlaylistTrack_Track",
                        column: x => x.TrackId,
                        principalSchema: "dbo",
                        principalTable: "Track",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceLine",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    TrackId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLines_Invoice",
                        column: x => x.InvoiceId,
                        principalSchema: "dbo",
                        principalTable: "Invoice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceLines_Track",
                        column: x => x.TrackId,
                        principalSchema: "dbo",
                        principalTable: "Track",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IFK_Artist_Album",
                schema: "dbo",
                table: "Album",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IPK_ProductItem",
                schema: "dbo",
                table: "Album",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "I_Artist_Name",
                schema: "dbo",
                table: "Artist",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IPK_Artist",
                schema: "dbo",
                table: "Artist",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IFK_Employee_Customer",
                schema: "dbo",
                table: "Customer",
                column: "SupportRepId");

            migrationBuilder.CreateIndex(
                name: "IPK_Customer",
                schema: "dbo",
                table: "Customer",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IFK_Employee_ReportsTo",
                schema: "dbo",
                table: "Employee",
                column: "ReportsTo");

            migrationBuilder.CreateIndex(
                name: "IPK_Employee",
                schema: "dbo",
                table: "Employee",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IPK_Genre",
                schema: "dbo",
                table: "Genre",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IFK_Customer_Invoice",
                schema: "dbo",
                table: "Invoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IPK_Invoice",
                schema: "dbo",
                table: "Invoice",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IFK_Invoice_InvoiceLine",
                schema: "dbo",
                table: "InvoiceLine",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IFK_Track_InvoiceLine",
                schema: "dbo",
                table: "InvoiceLine",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IPK_InvoiceLine",
                schema: "dbo",
                table: "InvoiceLine",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IPK_MediaType",
                schema: "dbo",
                table: "MediaType",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "I_Playlist_Name",
                schema: "dbo",
                table: "Playlist",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IPK_Playlist",
                schema: "dbo",
                table: "Playlist",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IFK_Playlist_PlaylistTrack",
                schema: "dbo",
                table: "PlaylistTrack",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IFK_Track_PlaylistTrack",
                schema: "dbo",
                table: "PlaylistTrack",
                column: "TrackId");

            migrationBuilder.CreateIndex(
                name: "IPK_PlaylistTrack",
                schema: "dbo",
                table: "PlaylistTrack",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IFK_Album_Track",
                schema: "dbo",
                table: "Track",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IFK_Genre_Track",
                schema: "dbo",
                table: "Track",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IFK_MediaType_Track",
                schema: "dbo",
                table: "Track",
                column: "MediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IPK_Track",
                schema: "dbo",
                table: "Track",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceLine",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PlaylistTrack",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Invoice",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Playlist",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Track",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Album",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Genre",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MediaType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Employee",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Artist",
                schema: "dbo");
        }
    }
}
