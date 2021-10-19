using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQL.Models
{
    /// <summary>
    /// Order data model
    /// </summary>
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate{ get; set; }
        
        [Required]
        public string CustomerName { get; set; }
       
        [Required]
        public double TotalAmount { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
