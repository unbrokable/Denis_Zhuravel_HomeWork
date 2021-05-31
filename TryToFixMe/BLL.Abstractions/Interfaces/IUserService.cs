using System.Collections.Generic;

namespace BLL.Abstractions.Interfaces
{
    public interface IUserService
    {
        List<T> LoadRecords<T>();
    }
}