using Microsoft.EntityFrameworkCore;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var specHeartId = "spec-heart-001";
        var specTeethId = "spec-teeth-002";
        var specKidsId = "spec-kids-003";
        var specDermaId = "spec-derma-004";
        var specEyesId = "spec-eyes-005";
        var specOrthoId = "spec-ortho-006"; 
        var specEntId = "spec-ent-007";     

       
        var drAhmedId = "doc-ahmed-001";
        var drSaraId = "doc-sara-002";
        var drAliId = "doc-ali-003";
        var drLaylaId = "doc-layla-004";
        var drOmarId = "doc-omar-005";
        var drNoorId = "doc-noor-006";
        var drHassanId = "doc-hassan-007";
        var drMonaId = "doc-mona-008";

        modelBuilder.Entity<Specialty>().HasData(
            new Specialty { Id = specHeartId, Name = "أمراض القلب", IconUrl = "uploads/specialties/heart.png" },
            new Specialty { Id = specTeethId, Name = "طب الأسنان", IconUrl = "uploads/specialties/tooth.png" },
            new Specialty { Id = specKidsId, Name = "طب الأطفال", IconUrl = "uploads/specialties/baby.png" },
            new Specialty { Id = specDermaId, Name = "الجلدية والتجميل", IconUrl = "uploads/specialties/derma.png" },
            new Specialty { Id = specEyesId, Name = "طب العيون", IconUrl = "uploads/specialties/eye.png" },
            new Specialty { Id = specOrthoId, Name = "العظام والمفاصل", IconUrl = "uploads/specialties/bone.png" },
            new Specialty { Id = specEntId, Name = "أنف وأذن وحنجرة", IconUrl = "uploads/specialties/ent.png" }
        );


        modelBuilder.Entity<Doctor>().HasData(

            new Doctor
            {
                Id = drAhmedId,
                Name = "د. أحمد عباس خالد",
                Bio = "أخصائي جراحة القلب والأوعية الدموية، بورد عربي، خبرة 15 سنة في القسطرة العلاجية.",
                SpecialtyId = specHeartId,
                Location = "بغداد - الكرادة - قرب ساحة كهرمانة",
                Rate = 4.9m,
                ExperienceYears = 15,
                ImageUrl = "uploads/doctors/dr_ahmed.jpg",
                IsActive = true
            },
        
            new Doctor
            {
                Id = drSaraId,
                Name = "د. سارة محمد علي",
                Bio = "طبيبة أسنان اختصاص تجميل وتقويم، حاصلة على شهادة البورد الأمريكي.",
                SpecialtyId = specTeethId,
                Location = "بغداد - المنصور - شارع 14 رمضان",
                Rate = 4.7m,
                ExperienceYears = 8,
                ImageUrl = "uploads/doctors/dr_sara.jpg",
                IsActive = true
            },
          
            new Doctor
            {
                Id = drAliId,
                Name = "د. علي حسين كاظم",
                Bio = "أخصائي طب الأطفال وحديثي الولادة، متابعة النمو والتغذية.",
                SpecialtyId = specKidsId,
                Location = "بغداد - زيونة - مقابل دار الأزياء",
                Rate = 4.5m,
                ExperienceYears = 10,
                ImageUrl = "uploads/doctors/dr_ali.jpg",
                IsActive = true
            },
         
            new Doctor
            {
                Id = drLaylaId,
                Name = "د. ليلى عبد العزيز",
                Bio = "أخصائية الأمراض الجلدية والعلاج بالليزر، حقن الفيلر والبوتوكس.",
                SpecialtyId = specDermaId,
                Location = "أربيل - شارع 100",
                Rate = 4.8m,
                ExperienceYears = 6,
                ImageUrl = "uploads/doctors/dr_layla.jpg",
                IsActive = true
            },
          
            new Doctor
            {
                Id = drOmarId,
                Name = "د. عمر فاروق",
                Bio = "استشاري طب وجراحة العيون، تصحيح البصر بالليزك.",
                SpecialtyId = specEyesId,
                Location = "بغداد - الحارثية",
                Rate = 4.6m,
                ExperienceYears = 20,
                ImageUrl = "uploads/doctors/dr_omar.jpg",
                IsActive = true
            },
            
            new Doctor
            {
                Id = drNoorId,
                Name = "د. نور الهدى",
                Bio = "جراحة وجه وفكين، زراعة الأسنان.",
                SpecialtyId = specTeethId,
                Location = "البصرة - الجزائر",
                Rate = 4.4m,
                ExperienceYears = 5,
                ImageUrl = "uploads/doctors/dr_noor.jpg",
                IsActive = true
            },
           
            new Doctor
            {
                Id = drHassanId,
                Name = "د. حسن كامل",
                Bio = "أخصائي جراحة العظام والكسور وتبديل المفاصل.",
                SpecialtyId = specOrthoId,
                Location = "النجف - حي السعد",
                Rate = 4.9m,
                ExperienceYears = 18,
                ImageUrl = "uploads/doctors/dr_hassan.jpg",
                IsActive = true
            },
           
            new Doctor
            {
                Id = drMonaId,
                Name = "د. منى سامي",
                Bio = "علاج حساسية الأنف والجيوب الأنفية، عمليات تجميل الأنف.",
                SpecialtyId = specEntId,
                Location = "بغداد - شارع فلسطين",
                Rate = 4.3m,
                ExperienceYears = 7,
                ImageUrl = "uploads/doctors/dr_mona.jpg",
                IsActive = true
            }
        );


      
        modelBuilder.Entity<DoctorSchedule>().HasData(
            new DoctorSchedule { Id = "sch-ahmed-1", DoctorId = drAhmedId, DayOfWeek = DayOfWeek.Sunday, StartTime = new TimeOnly(16, 0), EndTime = new TimeOnly(20, 0), IsAvailable = true },
            new DoctorSchedule { Id = "sch-ahmed-2", DoctorId = drAhmedId, DayOfWeek = DayOfWeek.Monday, StartTime = new TimeOnly(16, 0), EndTime = new TimeOnly(20, 0), IsAvailable = true },
            new DoctorSchedule { Id = "sch-ahmed-3", DoctorId = drAhmedId, DayOfWeek = DayOfWeek.Wednesday, StartTime = new TimeOnly(16, 0), EndTime = new TimeOnly(20, 0), IsAvailable = true }
        );

     
        modelBuilder.Entity<DoctorSchedule>().HasData(
            new DoctorSchedule { Id = "sch-sara-1", DoctorId = drSaraId, DayOfWeek = DayOfWeek.Saturday, StartTime = new TimeOnly(10, 0), EndTime = new TimeOnly(14, 0), IsAvailable = true },
            new DoctorSchedule { Id = "sch-sara-2", DoctorId = drSaraId, DayOfWeek = DayOfWeek.Tuesday, StartTime = new TimeOnly(15, 0), EndTime = new TimeOnly(19, 0), IsAvailable = true }
        );

       
        modelBuilder.Entity<DoctorSchedule>().HasData(
            new DoctorSchedule { Id = "sch-ali-1", DoctorId = drAliId, DayOfWeek = DayOfWeek.Sunday, StartTime = new TimeOnly(09, 0), EndTime = new TimeOnly(13, 0), IsAvailable = true },
            new DoctorSchedule { Id = "sch-ali-2", DoctorId = drAliId, DayOfWeek = DayOfWeek.Monday, StartTime = new TimeOnly(09, 0), EndTime = new TimeOnly(13, 0), IsAvailable = true },
            new DoctorSchedule { Id = "sch-ali-3", DoctorId = drAliId, DayOfWeek = DayOfWeek.Tuesday, StartTime = new TimeOnly(09, 0), EndTime = new TimeOnly(13, 0), IsAvailable = true },
            new DoctorSchedule { Id = "sch-ali-4", DoctorId = drAliId, DayOfWeek = DayOfWeek.Wednesday, StartTime = new TimeOnly(09, 0), EndTime = new TimeOnly(13, 0), IsAvailable = true },
            new DoctorSchedule { Id = "sch-ali-5", DoctorId = drAliId, DayOfWeek = DayOfWeek.Thursday, StartTime = new TimeOnly(09, 0), EndTime = new TimeOnly(13, 0), IsAvailable = true }
        );

      
        modelBuilder.Entity<DoctorSchedule>().HasData(
            new DoctorSchedule { Id = "sch-layla-1", DoctorId = drLaylaId, DayOfWeek = DayOfWeek.Monday, StartTime = new TimeOnly(17, 0), EndTime = new TimeOnly(21, 0), IsAvailable = true },
            new DoctorSchedule { Id = "sch-layla-2", DoctorId = drLaylaId, DayOfWeek = DayOfWeek.Thursday, StartTime = new TimeOnly(17, 0), EndTime = new TimeOnly(21, 0), IsAvailable = true }
        );
    }
}

