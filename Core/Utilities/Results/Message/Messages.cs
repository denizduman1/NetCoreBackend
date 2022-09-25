using Core.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Message
{
    public sealed class Messages
    {
        private static Messages? _instance;
        private Messages()
        {

        }
        
        public static Messages Instance()
        {
            if (_instance == null)
            {
                _instance = new Messages();
                return _instance;
            }
            return _instance;
        }

        //success
        public string SuccessAddData = "Veri başarıyla eklendi";
        public string SuccessRemoveData = "Veri başarıyla silindi";
        public string SuccessGetAllData = "Veri listesi başarıyla getirildi";
        public string SuccessGetData = "Veri başarıyla getirildi";
        public string SuccessUpdateData = "Veri başarıyla güncellendi";
        public string SuccessLogin = "Giriş başarılı";
        public string SuccessUseEmail = "Bu email kullanılabilir";
        public string SuccessRegister = "Kullanıcı başarıyla kayıt edildi.";
        public string AccessTokenCreated = "Access Token başarıyla oluşturuldu";

        //error
        public string ErrorRemoveData = "Veri silme sırasında hata oluştu";
        public string ErrorData = "Veri bulunamadı";
        public string ErrorUpdateData = "Veri güncellenme sırasında hata oluştu";
        public string ErrorUserClaim = "Kullanıcı var fakat yetkisi yok.";
        public string ErrorUserOrUserClaim = "Kullanıcı veya yetkisi bulunamadı.";
        public string ErrorUserEmailNotFound = "Bu emaile ait kullanıcı bulunamadı";
        public string ErrorPassword = "Kullanıcı şifre hatalı";
        public string ErrorEmailExistUser = "Böyle bir emaile sahip kullanıcı zaten var";
        public string AuthorizationDenied = "İşlem için yetki yok.";
    }
}
