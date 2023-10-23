using SqlSugar;
namespace Whh.Core.Model.Base
{
    public class BaseId
    {
        [SugarColumn(IsIdentity = true, IsPrimaryKey = true)]
        public int Id { get; set; }
    }
}