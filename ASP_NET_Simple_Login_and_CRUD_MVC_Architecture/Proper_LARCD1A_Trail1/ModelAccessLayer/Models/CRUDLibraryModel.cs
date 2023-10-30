using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelAccessLayer.Models
{
    public class CRUDLibraryModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string BookCode { get; set; }
        [Required]
        public string Summary { get; set; }
    }
}
