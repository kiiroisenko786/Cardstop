﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardstop.Models
{
    public class Product
    {
        // ID of product
        [Key]
        public int Id { get; set; }
        // Product name
        [Required]
        public string Name { get; set; }
        // Product description
        [Required]
        public string Description { get; set; }
        // List price
        [Required]
        [DisplayName("List Price")]
        [Range(0.01, Double.MaxValue, ErrorMessage = "List price must be more than £0.00")]
        public double ListPrice { get; set; }
        // CategoryId Foreign Key
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        // Product code e.g Set code/set number/collection
        [DisplayName("Product Code")]
        public string? ProductCode { get; set; }

        // Product Stock
        [DisplayName("Stock")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be 0 or more")]
        public int ProductStock { get; set; }

        [ValidateNever]
        public List<ProductImage> ProductImages { get; set; }
    }
}
