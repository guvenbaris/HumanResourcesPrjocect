using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constans
{
    public static class Messages
    {
        
        public static string PhoneNumberIsNotCorrect = "Telefon numarası 0 ile başlayamaz";
        public static string SalaryPerHourIsNotCorrect = "İşçinin saatlik ücreti 17 tl den küçük olamaz";
        public static string TotalSalaryIsNotCorrect = "İşçinin toplam maaşı 2825 tlden küçük olamaz";
        public static string WorkingHoursIsNotCorrect = "İşçinin çalışma saatleri 8 saatten az 10 saatten fazla olamaz";
        public static string EmployeeAdded = "Çalışan eklendi";
        public static string EmployeeUpdated ="Çalışan Güncellendi";
        public static string AddressAdded = "Adres eklendi";
        public static string AddressCountryMustBeTurkey ="Ülke Türkiye olmak zorundadır.";
        public static string AddressUpdated ="Adres güncenlendi";
        public static string MissionAdded ="Görev eklendi";
        public  static string MissionUpdated = "Görev güncellendi";
        public  static string DepartmentUpdated ="Departman güncellendi";
        public static string DepartmentAdded ="Departman eklendi";
        public static string ManagerAdded = "Yönetici eklendi";
        public static string ManagerUpdated = "Yönetiic güncellendi";
        public static string WorkerAdded  ="İşçi eklendi";
        public static string WorkerUpdated ="İşçi güncellendi";
        public static string DepartmentCountIsNotCorrect ="Bir yöenetici 2 den fazla departmanı kontrol edemez ";
        public static string SpanOfControlNotCorrect ="Bir yönetici en az 1 en fazla 15 kişi yi kontrol edebilir";
        public static string WorkerMissionCountNotCorrect ="Bir görev de 1 kişiden az veya 10 kişiden fazla kişi çalışamaz";
        public static string ManagerRankHighLevel ="Bu seviyede ki yöneticiye görev atayamazsınız";
    }
}
