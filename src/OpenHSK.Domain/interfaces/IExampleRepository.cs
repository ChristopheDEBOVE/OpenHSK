using OpenHSK.Domain;
using System.Threading.Tasks;

namespace OpenHSK.Application.Examples.Commands
{
    public interface IAddExampleRepository
    {
        Task<int> AddAsync(Example example);
    }

    public interface IExampleRepository : IAddExampleRepository
    {
    }
}