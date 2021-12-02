namespace Firjan.Integracao.Dynamics.Application.Interfaces
{
    public interface ILoginAppService
    {
        object FindByLogin(Domain.Models.User user);
    }
}