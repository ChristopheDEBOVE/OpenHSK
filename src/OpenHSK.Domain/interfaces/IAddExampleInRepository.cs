using System.Threading.Tasks;
using OpenHSK.Domain.Commands.WriteModel;

namespace OpenHSK.Domain.interfaces
{
    public interface IAddExampleRepository
    {
        Task<int> AddAsync(Example example);
    }

    public interface IAddExampleInRepository : IAddExampleRepository
    {
    }
}