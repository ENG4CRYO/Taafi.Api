using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Taafi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Specialties",
                columns: new[] { "Id", "IconUrl", "Name" },
                values: new object[,]
                {
                    { "spec-derma-004", "uploads/specialties/derma.png", "الجلدية والتجميل" },
                    { "spec-ent-007", "uploads/specialties/ent.png", "أنف وأذن وحنجرة" },
                    { "spec-eyes-005", "uploads/specialties/eye.png", "طب العيون" },
                    { "spec-heart-001", "uploads/specialties/heart.png", "أمراض القلب" },
                    { "spec-kids-003", "uploads/specialties/baby.png", "طب الأطفال" },
                    { "spec-ortho-006", "uploads/specialties/bone.png", "العظام والمفاصل" },
                    { "spec-teeth-002", "uploads/specialties/tooth.png", "طب الأسنان" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Bio", "ExperienceYears", "ImageUrl", "IsActive", "Location", "Name", "Rate", "SpecialtyId" },
                values: new object[,]
                {
                    { "doc-ahmed-001", "أخصائي جراحة القلب والأوعية الدموية، بورد عربي، خبرة 15 سنة في القسطرة العلاجية.", 15, "uploads/doctors/dr_ahmed.jpg", true, "بغداد - الكرادة - قرب ساحة كهرمانة", "د. أحمد عباس خالد", 4.9m, "spec-heart-001" },
                    { "doc-ali-003", "أخصائي طب الأطفال وحديثي الولادة، متابعة النمو والتغذية.", 10, "uploads/doctors/dr_ali.jpg", true, "بغداد - زيونة - مقابل دار الأزياء", "د. علي حسين كاظم", 4.5m, "spec-kids-003" },
                    { "doc-hassan-007", "أخصائي جراحة العظام والكسور وتبديل المفاصل.", 18, "uploads/doctors/dr_hassan.jpg", true, "النجف - حي السعد", "د. حسن كامل", 4.9m, "spec-ortho-006" },
                    { "doc-layla-004", "أخصائية الأمراض الجلدية والعلاج بالليزر، حقن الفيلر والبوتوكس.", 6, "uploads/doctors/dr_layla.jpg", true, "أربيل - شارع 100", "د. ليلى عبد العزيز", 4.8m, "spec-derma-004" },
                    { "doc-mona-008", "علاج حساسية الأنف والجيوب الأنفية، عمليات تجميل الأنف.", 7, "uploads/doctors/dr_mona.jpg", true, "بغداد - شارع فلسطين", "د. منى سامي", 4.3m, "spec-ent-007" },
                    { "doc-noor-006", "جراحة وجه وفكين، زراعة الأسنان.", 5, "uploads/doctors/dr_noor.jpg", true, "البصرة - الجزائر", "د. نور الهدى", 4.4m, "spec-teeth-002" },
                    { "doc-omar-005", "استشاري طب وجراحة العيون، تصحيح البصر بالليزك.", 20, "uploads/doctors/dr_omar.jpg", true, "بغداد - الحارثية", "د. عمر فاروق", 4.6m, "spec-eyes-005" },
                    { "doc-sara-002", "طبيبة أسنان اختصاص تجميل وتقويم، حاصلة على شهادة البورد الأمريكي.", 8, "uploads/doctors/dr_sara.jpg", true, "بغداد - المنصور - شارع 14 رمضان", "د. سارة محمد علي", 4.7m, "spec-teeth-002" }
                });

            migrationBuilder.InsertData(
                table: "DoctorSchedules",
                columns: new[] { "Id", "DayOfWeek", "DoctorId", "EndTime", "IsAvailable", "StartTime" },
                values: new object[,]
                {
                    { "sch-ahmed-1", 0, "doc-ahmed-001", new TimeOnly(20, 0, 0), true, new TimeOnly(16, 0, 0) },
                    { "sch-ahmed-2", 1, "doc-ahmed-001", new TimeOnly(20, 0, 0), true, new TimeOnly(16, 0, 0) },
                    { "sch-ahmed-3", 3, "doc-ahmed-001", new TimeOnly(20, 0, 0), true, new TimeOnly(16, 0, 0) },
                    { "sch-ali-1", 0, "doc-ali-003", new TimeOnly(13, 0, 0), true, new TimeOnly(9, 0, 0) },
                    { "sch-ali-2", 1, "doc-ali-003", new TimeOnly(13, 0, 0), true, new TimeOnly(9, 0, 0) },
                    { "sch-ali-3", 2, "doc-ali-003", new TimeOnly(13, 0, 0), true, new TimeOnly(9, 0, 0) },
                    { "sch-ali-4", 3, "doc-ali-003", new TimeOnly(13, 0, 0), true, new TimeOnly(9, 0, 0) },
                    { "sch-ali-5", 4, "doc-ali-003", new TimeOnly(13, 0, 0), true, new TimeOnly(9, 0, 0) },
                    { "sch-layla-1", 1, "doc-layla-004", new TimeOnly(21, 0, 0), true, new TimeOnly(17, 0, 0) },
                    { "sch-layla-2", 4, "doc-layla-004", new TimeOnly(21, 0, 0), true, new TimeOnly(17, 0, 0) },
                    { "sch-sara-1", 6, "doc-sara-002", new TimeOnly(14, 0, 0), true, new TimeOnly(10, 0, 0) },
                    { "sch-sara-2", 2, "doc-sara-002", new TimeOnly(19, 0, 0), true, new TimeOnly(15, 0, 0) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: "sch-ahmed-1");

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: "sch-ahmed-2");

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: "sch-ahmed-3");

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: "sch-ali-1");

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: "sch-ali-2");

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: "sch-ali-3");

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: "sch-ali-4");

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: "sch-ali-5");

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: "sch-layla-1");

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: "sch-layla-2");

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: "sch-sara-1");

            migrationBuilder.DeleteData(
                table: "DoctorSchedules",
                keyColumn: "Id",
                keyValue: "sch-sara-2");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "doc-hassan-007");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "doc-mona-008");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "doc-noor-006");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "doc-omar-005");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "doc-ahmed-001");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "doc-ali-003");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "doc-layla-004");

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: "doc-sara-002");

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: "spec-ent-007");

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: "spec-eyes-005");

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: "spec-ortho-006");

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: "spec-derma-004");

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: "spec-heart-001");

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: "spec-kids-003");

            migrationBuilder.DeleteData(
                table: "Specialties",
                keyColumn: "Id",
                keyValue: "spec-teeth-002");
        }
    }
}
