using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Protheus
{
    public class FilialViewModel : TipoViewModel<string>
    {
        public string Empresa { get; set; }
    }
}