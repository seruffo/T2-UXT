using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.SMAIS;
using Firjan.Integracao.Dynamics.Domain.Models.SMAIS;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.SMAIS;

public class RiscoRepositorio : SMAISRepositorio<Risco>, IRiscoRepository
{
    private static string urlRiscos => "https://ws1.soc.com.br/WebSoc/exportadados?parametro={'empresa':'521019','codigo':'25086','chave':'382edb4563feb2937cfc','tipoSaida':'json','empresaTrabalho':'521019'}";

    public RiscoRepositorio() : base(urlRiscos) { }
}