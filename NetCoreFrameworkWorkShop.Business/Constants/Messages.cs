using NetCoreFrameworkWorkShop.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreFrameworkWorkShop.Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Urun baasari ile eklendi.";
        public static string ProductDeleted = "Urun baasari ile silindi.";
        public static string ProductUpdated = "Urun baasari ile guncellendi.";

        public static string UserNotFound = "Kullanıcı Bulunamadıç";

        public static string PasswordError = "Hatalı şifre";

        public static string SuccesFullLogin = "Sisteme giris basarili";

        public static string UserAlreadyExists = "Bu kullanici mevcuttur.";

        public static string UserRegisterdSuccesfully = "Kullanıcı başarı ile kaydedildi.";

        public static string AccessTokenCreated = "Access Token başarı ile olusturuldu.";

        public static string AuthorizationDenied = "Yetkiniz yoktur.";
    }
}
