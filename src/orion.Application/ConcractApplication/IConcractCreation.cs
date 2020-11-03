using Abp.Application.Services;
using orion.ConcractApplication.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace orion.ConcractApplication
{
    public interface IConcractCreationService : IApplicationService
    {
        Task UserPartCreation(ConcractDTO input);
        Task CreateConcract(List<int> input,ConcractDTO partConcract,bool mode);
        Task DeleteConcract(int id);

        Task<string> GetPDF(int idConcract);
    }
}
