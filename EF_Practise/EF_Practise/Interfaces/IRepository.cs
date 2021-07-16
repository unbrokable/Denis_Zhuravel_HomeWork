using EFlecture.Core.Specifications;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Practise.Interfaces
{
    interface IRepository
    {
        Task<T> FindAsync<T>(Specification<T> specification) where T : class, new();
        Task<IQueryable<T>> GetAsync<T>(Specification<T> specification) where T : class, new();
    }
}
