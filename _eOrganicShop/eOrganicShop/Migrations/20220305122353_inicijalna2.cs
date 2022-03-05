using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eOrganicShop.Migrations
{
    public partial class inicijalna2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IznosBezPdv",
                table: "Narudzba");

            migrationBuilder.DropColumn(
                name: "Otkazano",
                table: "Narudzba");

            migrationBuilder.RenameColumn(
                name: "IznosSaPdv",
                table: "Narudzba",
                newName: "Iznos");

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "Sxqa1RA+wyfth0Rl0w01uuisKs4=", "JvS2c8kEYvcW/kzrhACafw==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "E/b4SkQIBmaQrFGPXBm6kPJDcJQ=", "JvS2c8kEYvcW/kzrhACafw==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 3,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "dZQ4tqPO+sR8z8Wrj8+fHClARRU=", "JvS2c8kEYvcW/kzrhACafw==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 4,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "6RHpcPJRNTDLUmH/ghKlNs8htDI=", "JvS2c8kEYvcW/kzrhACafw==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 5,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "JRRFE9AibY24sFcuuXPC4Ly9EDs=", "JvS2c8kEYvcW/kzrhACafw==" });

            migrationBuilder.UpdateData(
                table: "Narudzba",
                keyColumn: "NarudzbaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2022, 3, 5, 13, 23, 52, 303, DateTimeKind.Local).AddTicks(458));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Iznos",
                table: "Narudzba",
                newName: "IznosSaPdv");

            migrationBuilder.AddColumn<float>(
                name: "IznosBezPdv",
                table: "Narudzba",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "Otkazano",
                table: "Narudzba",
                type: "bit",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "w7ss0KgB3PnJt+/Sh+HhgOtpG5Y=", "dxMDnsRkbdumqsCXXoywjw==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "Pb8ropBulrkq39fbm6nw+/djuFY=", "dxMDnsRkbdumqsCXXoywjw==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 3,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "McnL+36yJWiH675tFCeZDR5n/QM=", "dxMDnsRkbdumqsCXXoywjw==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 4,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "RJaFzVVDYcsz6uX46Wu4llPpveI=", "dxMDnsRkbdumqsCXXoywjw==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 5,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "+iUU3EMCIiDNPP5RFm6PitSNbYQ=", "dxMDnsRkbdumqsCXXoywjw==" });

            migrationBuilder.UpdateData(
                table: "Narudzba",
                keyColumn: "NarudzbaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2022, 3, 5, 10, 27, 27, 117, DateTimeKind.Local).AddTicks(9949));
        }
    }
}
