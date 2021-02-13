using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS_oneday_intern.Models
{
    public class Product
    {
        /// <summary>
        /// 產品id(json的第幾個產品)
        /// </summary>
        public int ProductId { get; set; }
        /// <summary>
        /// 產品名稱
        /// </summary>
        public string Product_Name { get; set; }

        /// <summary>
        /// 產品剩餘數量
        /// </summary>
        public int Inventory { get; set; }

        /// <summary>
        /// 產品種類
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// 產品品牌
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// 價格
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// 說明or備註
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 主圖片URL
        /// </summary>
        public string ImageURL { get; set; }

        /// <summary>
        /// 其他圖片URL
        /// </summary>
        public List<string> Thumbnails { get; set; }

    }
}
