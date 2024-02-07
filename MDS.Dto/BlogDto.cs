using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Dto
{
    public class BlogDto
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public long CurrentUserId { get; set; }
    }
}
