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
        public string SuccessData = "Veri başarıyla getirildi";
        public string SuccessUpdateData = "Veri başarıyla güncellendi";


        //error
        public string ErrorRemoveData = "Veri silme sırasında hata oluştu";
        public string ErrorData = "Veri bulunamadı";
        public string ErrorUpdateData = "Veri güncellenme sırasında hata oluştu";

    }
}
