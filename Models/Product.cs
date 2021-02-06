using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS_oneday_intern.Models
{
    public class Product
    {
        /// <summary>
        /// Product_Name	Category	Price	Remark	imageURL
        /// </summary>
        public string Product_Name { get; set; }

        /// <summary>
        /// Product_Name		Price	Remark	imageURL
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Product_Name		Price	Remark	imageURL
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Product_Name		Price	Remark	imageURL
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// Product_Name		Price	Remark	imageURL
        /// </summary>
        public string imageURL { get; set; }


    }
}
