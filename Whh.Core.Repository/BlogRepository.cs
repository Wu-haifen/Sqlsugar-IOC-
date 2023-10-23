using SqlSugar;
using Whh.Core.IRepository;
using Whh.Core.Model;
using Whh.Core.Repository.Base;

namespace Whh.Core.Repository
{
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {

    }
}