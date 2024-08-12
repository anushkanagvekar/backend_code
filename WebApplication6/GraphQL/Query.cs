using HotChocolate;
using HotChocolate.Data;
using WebApplication6.Data;
using WebApplication6.Models;


namespace WebApplication6.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppdbContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Formdata> GetFormdatas([Service(ServiceKind.Pooled)] AppdbContext dbContext)
        {
            return dbContext.Users;
        }
    }
}
