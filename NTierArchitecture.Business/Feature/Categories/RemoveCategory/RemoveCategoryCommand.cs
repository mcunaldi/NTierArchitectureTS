using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Feature.Categories.DeleteCategory;
public sealed record RemoveCategoryCommand(
    Guid Id) : IRequest;
