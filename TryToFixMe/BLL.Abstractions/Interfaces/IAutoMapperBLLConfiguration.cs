using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstractions.Interfaces
{
    public interface IAutoMapperBLLConfiguration
    {
        IMapper GetMapper();
    }
}
