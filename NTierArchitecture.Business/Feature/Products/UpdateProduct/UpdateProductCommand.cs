﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Feature.Products.UpdateProduct;
public sealed record UpdateProductCommand(
    Guid Id,
    string Name,
    decimal Price,
    int Quantity) : IRequest;
