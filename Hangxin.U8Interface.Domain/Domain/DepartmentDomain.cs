using Hangxin.U8Interface.Domain.Entitys;
using Hangxin.U8Interface.Infrastructure; 
using System.Collections.Generic;
using System.Linq; 

namespace Hangxin.U8Interface.Domain.Domain
{
    public class DepartmentDomain : IDepartmentDomain
    {
        IRepository<Department> _Repository;
        public DepartmentDomain(IRepository<Department> Repository)
        {
            this._Repository = Repository;
        }
        public Department Get(string id)
        {
            return _Repository.Get(id);
        }
        public IEnumerable<Department> GetAll()
        {
            return _Repository.GetAll().OrderBy(c => c.CDepCode);
        }
    }
}
