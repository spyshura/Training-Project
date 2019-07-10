using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Entityes
{
    [TableAttribute("Category")]
    public class Category : Page
    {
        public List<Product> Product { get; set; }
    }
}
