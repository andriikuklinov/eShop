using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.BLL.Commands
{
    internal record CreateProductCommand(int Id, string Brand, string Model, 
        string Season, string Summary, string? ImgSrc, 
        decimal WholesalePrice, decimal RetailPrice, int Count, 
        int FreeCount, string Code, int CategoryId): IRequest<CreateProductResult>;

    internal record CreateProductResult(int Id);
}
