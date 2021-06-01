using System.Collections.Generic;

namespace DAL.Abstractions.Interfaces
{
    public interface IRepository<T> where T: class
    {
        List<T> LoadRecords();
    }
}