﻿using eShop.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Aggregator.Contracts
{
    public interface ICatalogService
    {
        Task<IEnumerable<CatalogModel>> GetProducts(string? filter=null, string? orderBy=null, int? page=null, int? pageSize=null);
    }
}
