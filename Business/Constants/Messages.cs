using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    // If a class is static, you do not have to make new() when you want to use it.
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün İsmi Geçersiz";
        public static string ProductDeleted = "Ürün Silindi";
        public static string ProductUpdated = "Ürün Güncellendi";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string ProductsListed = "Ürünler Listelendi";
        public static string CategoryProductNumberLimit = "Bir Kategoride En Fazla 10 Ürün Olabilir.";
        public static string ProductNameAlreadyExist = "Aynı İsimde Ürün Eklenemez.";
        public static string CategoryLimitExceded = "Mevcut Kategori Sayısı 15'ten Fazla";
    }
}
