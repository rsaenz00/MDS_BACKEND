using MDS.Infrastructure.DbUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.DbContext.Entities
{
    public class Blog : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Url { get; set; }

        //public List<Post> Posts { get; } = new List<Post>();
    }
}
