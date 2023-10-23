using Whh.Core.Model;
using Whh.Core.IRepository;
using Whh.Core.Services.Base;
using Whh.Core.IServices;

namespace Whh.Core.Services
{
    public class BlogService : ServicesBase<Blog>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogService(IBlogRepository iPowerRepository)
        {
            base._iBaseRepository = iPowerRepository;
            _blogRepository = iPowerRepository;
        }
    }
}