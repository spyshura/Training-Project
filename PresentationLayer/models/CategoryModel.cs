using DataLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.models
{
    public class CategoryViewModel : PageViewModel
    {
        public Category Category { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }

    public class CategoryEditModel : PageEditModel
    {
    }
}
