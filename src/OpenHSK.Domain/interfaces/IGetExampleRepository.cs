using System.Threading.Tasks;
using OpenHSK.Domain.Queries.ReadModel;

namespace OpenHSK.Domain.interfaces
{
    public interface IGetExampleRepository
    {
        Task<Example[]> GetAll();
    }
}