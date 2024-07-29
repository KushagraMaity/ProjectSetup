using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib.Model
{
    public class T_BOOK
    {
        public int BOOK_ID { get; set; }
        public string? BOOK_NAME { get; set; }
        public string? AUTHOR { get; set; }
        public DateTime? PUBLISH_DATE { get; set; }
        public DateTime? SUBMIT_DATE { get; set; }

    }
}
