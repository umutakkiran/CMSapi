using Application.Abstraction.AbsContent;
using CMS.Persistence.Contexts;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Persistence.Concrete.ConContent
{
    public class ContentReadRepository : ReadRepository<Content>, IContentReadRepository
    {
        public ContentReadRepository(CmsDbContext context) : base(context)
        {
        }
    }
}
