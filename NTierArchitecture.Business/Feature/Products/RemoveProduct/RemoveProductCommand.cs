﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Feature.Products.RemoveProduct;
public sealed record RemoveProductCommand(
    Guid Id): IRequest<Unit>;
