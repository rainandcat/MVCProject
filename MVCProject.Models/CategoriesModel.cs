using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MVCProject.Models
{
    public class CategoriesModel
    {
        [Key]
        [Column("CategoryID")]
        public int CategoryID { get; set; }
        /// <summary>
        /// Category Name
        /// </summary>
        [Column("CategoryName")]
        public string CategoryName { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [Column("Description")]
        public string Description { get; set; }
        /// <summary>
        /// Picture
        /// </summary>
        [Column("Picture")]
        public Byte[] Picture { get; set; }
    }
}
