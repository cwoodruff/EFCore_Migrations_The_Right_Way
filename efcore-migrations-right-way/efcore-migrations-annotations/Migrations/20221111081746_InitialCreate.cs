using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace efcoremigrationsannotations.Migrations
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
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false, comment: "The name of the artist")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                },
                comment: "Artists in the store");

            migrationBuilder.CreateTable(
                name: "Employee",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, computedColumnSql: "[LastName] + ', ' + [FirstName]"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ReportsTo = table.Column<int>(type: "int", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    State = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: false),
                    Fax = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ReportsToForeignKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_ReportsToForeignKey",
                        column: x => x.ReportsToForeignKey,
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
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                },
                comment: "The types of musical genres that that tracks can be assigned.");

            migrationBuilder.CreateTable(
                name: "MediaType",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaType", x => x.Id);
                },
                comment: "The types of media that customers can purchase music on the store.");

            migrationBuilder.CreateTable(
                name: "Playlist",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.Id);
                },
                comment: "The sets of tracks that have been curated for customers to buy.");

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false, comment: "The name of the album"),
                    ArtistId = table.Column<int>(type: "int", nullable: false),
                    ArtistForeignKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Album_Artist_ArtistForeignKey",
                        column: x => x.ArtistForeignKey,
                        principalSchema: "dbo",
                        principalTable: "Artist",
                        principalColumn: "Id");
                },
                comment: "Albums in the store");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false, computedColumnSql: "[LastName] + ', ' + [FirstName]"),
                    Company = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    State = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(24)", maxLength: 24, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SupportRepId = table.Column<int>(type: "int", nullable: false),
                    SupportRepForeignKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Employee_SupportRepForeignKey",
                        column: x => x.SupportRepForeignKey,
                        principalSchema: "dbo",
                        principalTable: "Employee",
                        principalColumn: "Id");
                },
                comment: "The customers that have purchased tracks in the store.");

            migrationBuilder.CreateTable(
                name: "Track",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AlbumId = table.Column<int>(type: "int", nullable: false),
                    MediaTypeId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Composer = table.Column<string>(type: "nvarchar(220)", maxLength: 220, nullable: true),
                    Milliseconds = table.Column<int>(type: "int", nullable: false),
                    Bytes = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    AlbumForeignKey = table.Column<int>(type: "int", nullable: true),
                    GenreForeignKey = table.Column<int>(type: "int", nullable: true),
                    MediaTypeForeignKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Track_Album_AlbumForeignKey",
                        column: x => x.AlbumForeignKey,
                        principalTable: "Album",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Track_Genre_GenreForeignKey",
                        column: x => x.GenreForeignKey,
                        principalSchema: "dbo",
                        principalTable: "Genre",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Track_MediaType_MediaTypeForeignKey",
                        column: x => x.MediaTypeForeignKey,
                        principalSchema: "dbo",
                        principalTable: "MediaType",
                        principalColumn: "Id");
                },
                comment: "The tracks that are in the store to buy.");

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    BillingAddress = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    BillingCity = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    BillingState = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    BillingCountry = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    BillingZipCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Total = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    CustomerForeignKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_CustomerForeignKey",
                        column: x => x.CustomerForeignKey,
                        principalSchema: "dbo",
                        principalTable: "Customer",
                        principalColumn: "Id");
                },
                comment: "The customer's invoices.");

            migrationBuilder.CreateTable(
                name: "PlaylistTrack",
                schema: "dbo",
                columns: table => new
                {
                    PlaylistsId = table.Column<int>(type: "int", nullable: false),
                    TracksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistTrack", x => new { x.PlaylistsId, x.TracksId });
                    table.ForeignKey(
                        name: "FK_PlaylistTrack_Playlist_PlaylistsId",
                        column: x => x.PlaylistsId,
                        principalSchema: "dbo",
                        principalTable: "Playlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistTrack_Track_TracksId",
                        column: x => x.TracksId,
                        principalSchema: "dbo",
                        principalTable: "Track",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    InvoiceForeignKey = table.Column<int>(type: "int", nullable: true),
                    TrackForeignKey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceLine_Invoice_InvoiceForeignKey",
                        column: x => x.InvoiceForeignKey,
                        principalSchema: "dbo",
                        principalTable: "Invoice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InvoiceLine_Track_TrackForeignKey",
                        column: x => x.TrackForeignKey,
                        principalSchema: "dbo",
                        principalTable: "Track",
                        principalColumn: "Id");
                },
                comment: "The details for the invoices in the store.");

            migrationBuilder.CreateIndex(
                name: "IFK_Artist_Album",
                table: "Album",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistForeignKey",
                table: "Album",
                column: "ArtistForeignKey");

            migrationBuilder.CreateIndex(
                name: "I_Artist_Name",
                schema: "dbo",
                table: "Artist",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IFK_Employee_Customer",
                schema: "dbo",
                table: "Customer",
                column: "SupportRepId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_SupportRepForeignKey",
                schema: "dbo",
                table: "Customer",
                column: "SupportRepForeignKey");

            migrationBuilder.CreateIndex(
                name: "IFK_Employee_ReportsTo",
                schema: "dbo",
                table: "Employee",
                column: "ReportsTo");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ReportsToForeignKey",
                schema: "dbo",
                table: "Employee",
                column: "ReportsToForeignKey");

            migrationBuilder.CreateIndex(
                name: "IFK_Customer_Invoice",
                schema: "dbo",
                table: "Invoice",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_CustomerForeignKey",
                schema: "dbo",
                table: "Invoice",
                column: "CustomerForeignKey");

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
                name: "IX_InvoiceLine_InvoiceForeignKey",
                schema: "dbo",
                table: "InvoiceLine",
                column: "InvoiceForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceLine_TrackForeignKey",
                schema: "dbo",
                table: "InvoiceLine",
                column: "TrackForeignKey");

            migrationBuilder.CreateIndex(
                name: "I_Playlist_Name",
                schema: "dbo",
                table: "Playlist",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistTrack_TracksId",
                schema: "dbo",
                table: "PlaylistTrack",
                column: "TracksId");

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
                name: "IX_Track_AlbumForeignKey",
                schema: "dbo",
                table: "Track",
                column: "AlbumForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Track_GenreForeignKey",
                schema: "dbo",
                table: "Track",
                column: "GenreForeignKey");

            migrationBuilder.CreateIndex(
                name: "IX_Track_MediaTypeForeignKey",
                schema: "dbo",
                table: "Track",
                column: "MediaTypeForeignKey");
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
                name: "Album");

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
