using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MVCProject.Models
{
    public class ProductsModel
    {
        [Key]
        [Column("ProductID")]
        public int ProductID { get; set; }

        [Column("ProductName")]
        public string ProductName { get; set; }

        [Column("SupplierID")]
        public int SupplierID { get; set; }

        [Column("CategoryID")]
        public int CategoryID { get; set; }

        [Column("QuantityPerUnit")]
        public string QuantityPerUnit { get; set; }

        [Column("UnitPrice")]
        public Decimal UnitPrice { get; set; }

        [Column("UnitsInStock")]
        public Int16 UnitsInStock { get; set; }

        [Column("UnitsOnOrder")]
        public Int16 UnitsOnOrder { get; set; }

        [Column("ReorderLevel")]
        public Int16 ReorderLevel { get; set; }

        [Column("Discontinued")]
        public Boolean Discontinued { get; set; }

        [ForeignKey("CategoryID")]
        public CategoriesModel Category { get; set; }
    }
}
