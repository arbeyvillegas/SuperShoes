using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShoes.Model
{
    public class Article
    {
        [ScaffoldColumn(true)]
        public int Id { get; set; }

        [Required(ErrorMessage = "The value of Name is required")]
        [StringLength(256)]
        public string Name { get; set; }

        [StringLength(512)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The value of Price is required")]
        [Range(0.00,999999999999999999.99)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The value of Total in shelf is required")]
        [Range(0, 999999999999999999)]
        [DisplayName("Total in shelf")]
        public int TotalInShelf { get; set; }

        [Required(ErrorMessage = "The value of Total in vault is required")]
        [Range(0, 999999999999999999)]
        [DisplayName("Total in vault")]
        public int TotalInVault { get; set; }

        [DisplayName("Store")]
        public int StoreId { get; set; }

        [DisplayName("Store")]
        public string StoreName { get; set; }

    }
}
