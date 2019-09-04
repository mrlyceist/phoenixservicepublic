using PhoenixService.Domain;
using System.Threading.Tasks;

namespace PhoenixService.Data.Interfaces.Repositories
{
    public interface ISpecialTaskRepository
    {
        Task Save(SpecialTask task);
    }
}