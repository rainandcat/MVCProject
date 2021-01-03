using System;
using System.Collections.Generic;
using System.Text;

namespace MVCProject.Service.ViewModels
{
    public class CategoriesViewModel
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public Byte[] Picture { get; set; }
    }
}
