using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core.Domain.Interface
{
    public interface IService<TRequest>
    {
        Task<TRequest> GetAsync(string endpoint);
        void Post(TRequest entity, string endpoint);

    }
}
