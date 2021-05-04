using OpenHSK.Domain;

namespace OpenHSK.Application.Examples.Commands
{
    public interface IAddExampleRepository
    {
        int Add(Example example);
    }

    public interface IExampleRepository : IAddExampleRepository
    {
    }
}