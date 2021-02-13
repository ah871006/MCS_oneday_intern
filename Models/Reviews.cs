using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCS_oneday_intern.Models
{
    public class Review
    {
        /// <summary>
        /// 評論Id
        /// </summary>
        public int ReviewId { get; set; }

        /// <summary>
        /// 評論Id
        /// </summary>
        public string Reviewer { get; set; }

        /// <summary>
        /// 評論時間
        /// </summary>
        public DateTime ReviewTime { get; set; }

        /// <summary>
        /// 評論內容
        /// </summary>
        public string ReviewContent { get; set; }
    }
}
