using SqlSugar;
using Whh.Core.Model.Base;

namespace Whh.Core.Model
{
    [SugarTable("Blogs")]
    public class Blog : BaseId
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
