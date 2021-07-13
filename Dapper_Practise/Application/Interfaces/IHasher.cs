using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IHasher
    {
        string Hash(string data);
        public T HashObject<T>(T data);
    }
}
