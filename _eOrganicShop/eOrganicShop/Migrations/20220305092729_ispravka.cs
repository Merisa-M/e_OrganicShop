using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eOrganicShop.Migrations
{
    public partial class ispravka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Transakcije",
                keyColumn: "TransakcijaID",
                keyValue: 5,
                column: "BrojNarudzbe",
                value: "N001");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "Rz9ynVERV5H+VKfXL6XiytLkz00=", "j8c39vPwH8CppCnt3mQQhA==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "yXqBAOz2BX0Yj+eTR3sR0kx7RM0=", "j8c39vPwH8CppCnt3mQQhA==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 3,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "5VbXO0vFk+TObMbFTqkGO24BytQ=", "j8c39vPwH8CppCnt3mQQhA==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 4,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "BR4ewSvVy0zO2N5/uERh6xghnTA=", "j8c39vPwH8CppCnt3mQQhA==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 5,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "X10il4JuJPilVt9FkWxJno7a2xs=", "j8c39vPwH8CppCnt3mQQhA==" });

            migrationBuilder.UpdateData(
                table: "Narudzba",
                keyColumn: "NarudzbaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2022, 3, 5, 9, 56, 54, 574, DateTimeKind.Local).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "Transakcije",
                keyColumn: "TransakcijaID",
                keyValue: 5,
                column: "BrojNarudzbe",
                value: "2233");
        }
    }
}
