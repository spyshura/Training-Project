using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public static class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if (!context.Categories.Any())
            {
                context.Categories.Add(new Entityes.Category() {Name="Meat", Title= "Meat of wild animals, poultry meat" });
                context.Categories.Add(new Entityes.Category() {Name= "Fish", Title = "Sea fish, freshwater fish" });
                context.Categories.Add(new Entityes.Category() { Name = "Vegetables", Title = "Tuber vegetables, root vegetables, legumes"});
                context.SaveChanges();

                context.Products.Add(new Entityes.Product() {Name= "Chicken", Title = "Chicken's description", Price=250, CategoryId=context.Categories.First().Id });
                context.Products.Add(new Entityes.Product() {Name= "Turkey", Title = "Turkey's description", Price=350, CategoryId = context.Categories.First().Id });
                context.Products.Add(new Entityes.Product() {Name= "Potatoes", Title = "Potatoes's description",Price=28, CategoryId = context.Categories.Last().Id });
                context.SaveChanges();
            }
        }
    }
}
