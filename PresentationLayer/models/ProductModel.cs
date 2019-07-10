using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresentationLayer.models
{
    public class ProductViewModel : PageViewModel
    {
        public Product Product { get; set; }
        public Product NextProduct { get; set; }
    }

    public class ProductEditModel : PageEditModel
    {
        public int CategoryId { get; set; }

        //public int GetCategoryId()
        //{
        //    return categoryId;
        //}

        //public void SetCategoryId(int value)
        //{
        //    categoryId = value;
        //}

        public int Price { get; set; }
    }
}
