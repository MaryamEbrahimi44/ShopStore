﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CatalogTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int? ParentCatalogTypeId { get; set; }
    }
}
