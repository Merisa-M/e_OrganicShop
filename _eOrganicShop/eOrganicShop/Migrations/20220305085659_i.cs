using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eOrganicShop.Migrations
{
    public partial class i : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 1,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "qff/A9jSz3/i4RFEQbakFLbbccg=", "TWZSMXXkeI4qHkLnbOB3Kg==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 2,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "SiElFXYGV5FqiKizPaq0Uhw8pJw=", "TWZSMXXkeI4qHkLnbOB3Kg==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 3,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "AQA0G0L1KB05tT35JpvRypY+T58=", "TWZSMXXkeI4qHkLnbOB3Kg==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 4,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "//rI7CtVa12NPeAlO4EyB0B/3uw=", "TWZSMXXkeI4qHkLnbOB3Kg==" });

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 5,
                columns: new[] { "LozinkaHash", "LozinkaSalt" },
                values: new object[] { "ms17mlk/f4Q79dK8VBfDafjuTPw=", "TWZSMXXkeI4qHkLnbOB3Kg==" });

            migrationBuilder.UpdateData(
                table: "Narudzba",
                keyColumn: "NarudzbaID",
                keyValue: 1,
                column: "Datum",
                value: new DateTime(2022, 3, 5, 9, 47, 57, 299, DateTimeKind.Local).AddTicks(2028));
        }
    }
}
