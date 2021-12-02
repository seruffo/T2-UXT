using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.SMAIS;
using Firjan.Integracao.Dynamics.Domain.Models.SMAIS;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.SMAIS;

public class ExameRepositorio : SMAISRepositorio<Exame>, IExameRepository
{
    private static string urlExames => "https://ws1.soc.com.br/WebSoc/exportadados?parametro={'empresa':'521019','codigo':'14321','chave':'2d14105a756adcd89d14','tipoSaida':'json','ativo':'1','inativo':'0'}";

    public ExameRepositorio() : base(urlExames) { }
}