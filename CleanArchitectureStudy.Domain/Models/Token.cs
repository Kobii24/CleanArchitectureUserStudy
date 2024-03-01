using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureStudy.Domain.Models
{
    [Table("Token")]
    public class Token
    {
        [Key]
        public int TokenId { get; set; }
        public string token { get; set; }
        public string refreshToken { get; set; }
    }
}
