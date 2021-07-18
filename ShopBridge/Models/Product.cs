using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ShopBridge.Models
{

    public class Product
    {
        public int ID { get; set; }
        [Column("Product Name")]
        [Required(ErrorMessage ="Please provide the name of the product")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please provide the description of the product")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Please provide the price of the product")]
        public double Price { get; set; }
    }

}