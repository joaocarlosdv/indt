using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contratacao.Domain.Interfaces
{
    public interface IHttpClientApiService
    {
        HttpClient GerarHttpClient();
    }
}
