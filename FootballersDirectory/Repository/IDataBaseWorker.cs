using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FootballersDirectory.Models;

namespace FootballersDirectory.Repository
{
    public interface IDataBaseWorker
    {
        Task CreateFootballer(FootballerEntity footballer);
        Task<List<FootballerEntity>> GetAllFootballers();
        List<string> GetAllCommands();
        List<string> GetAllGenders();
        Task<FootballerEntity> EditFootballer(int? id);
        Task EditConfirm(FootballerEntity footballer);
        Task DeleteFootballerById(int? id);
    }
}
