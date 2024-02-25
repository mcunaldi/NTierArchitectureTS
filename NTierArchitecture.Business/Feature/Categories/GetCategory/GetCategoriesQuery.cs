using MediatR;
using NTierArchitecture.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Business.Feature.Categories.GetCategory;
public sealed record GetCategoriesQuery() : IRequest<List<Category>>;

