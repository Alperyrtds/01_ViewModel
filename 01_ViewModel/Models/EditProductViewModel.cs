using _01_ViewModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01_ViewModel.Models
{
    public class EditProductViewModel
    {
        public Product Product { get; set; }

        public List<Category> AllCategories { get; set; }


    }
}