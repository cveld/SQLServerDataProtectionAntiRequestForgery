using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcSample21.Models
{
    public abstract class BaseEntity<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
