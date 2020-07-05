﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageWeb.Models.Storage.Category
{
    public class CategoryViewModel
    {
        public int idcategory { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool condition { get; set; }
    }
}
