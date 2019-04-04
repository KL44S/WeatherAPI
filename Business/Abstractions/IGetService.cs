using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstractions
{
    public interface IGetRestService
    {
        Task<T> Get<T>(string url);
    }
}
