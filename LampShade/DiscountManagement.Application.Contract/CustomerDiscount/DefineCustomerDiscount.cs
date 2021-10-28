﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;

namespace DiscountManagement.Application.Contract.CustomerDiscount
{
    public class DefineCustomerDiscount
    {
        [Range(1,100000,ErrorMessage = ValidationMessages.IsRequired)]
        public long ProductId { get; set; }
        [Range(1,100,ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLength)]
        public int DiscountRate { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string StartDate { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string EndDate { get; set; }
        public string Reason { get; set; }
        public List<ProductViewModel> Products { get; set; }


    }
}
