using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SuperShoes.Model
{
    public class Store
    {
        [ScaffoldColumn(true)]
        public int Id { get; set; }

        [Required(ErrorMessage="The value of Name is required")]
        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(512)]
        public string Address { get; set; }

    }
}
