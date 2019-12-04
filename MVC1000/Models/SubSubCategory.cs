using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC1000.Models
{
    public class SubSubCategory
    {
        [Key]
        public int SubSubCategoryId { get; set; }
        public SubCategory SubCategoryId { get; set; }
        public string SubSubCategorys { get; set; }
    }

    public class SubCategory
    {
        [Key]
        public int SubcategoryId { get; set; }
        public Category CategoryId { get; set; }
        public string SubCategorys { get; set; }
    }

    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Categorys { get; set; }
    }

    public class Categoryproduct
    {
        [Key]
        public Products ProductId { get; set; }
        public SubSubCategory SubSubCategoryId { get; set; }
    }

}
