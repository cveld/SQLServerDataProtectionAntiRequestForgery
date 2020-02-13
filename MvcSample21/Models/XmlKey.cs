using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MvcSample21.Models
{

    public class XmlKey : BaseEntity<int>
    {
        [Required]
        public string Xml { get; set; }
    }
}
