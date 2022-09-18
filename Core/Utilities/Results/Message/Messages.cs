using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Message
{
    public static class Messages
    {
        //success
        public static string SuccessAddData = "Veri başarıyla eklendi";
        public static string SuccessRemoveData = "Veri başarıyla silindi";
        public static string SuccessGetAllData = "Veri listesi başarıyla getirildi";
        public static string SuccessData = "Veri başarıyla getirildi";
        public static string SuccessUpdateData = "Veri başarıyla güncellendi";


        //error
        public static string ErrorRemoveData = "Veri silme sırasında hata oluştu";
        public static string ErrorData = "Veri bulunamadı";
        public static string ErrorUpdateData = "Veri güncellenme sırasında hata oluştu";

    }
}
