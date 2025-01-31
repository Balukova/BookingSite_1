﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductRepository: Repository<ProductEntity, int>, IProductRepository<ProductEntity, int>
    {
       
        BookingDbContext context;
        public ProductRepository(BookingDbContext context) : base(context)
        {
            this.context = context;
        }
    }
}
