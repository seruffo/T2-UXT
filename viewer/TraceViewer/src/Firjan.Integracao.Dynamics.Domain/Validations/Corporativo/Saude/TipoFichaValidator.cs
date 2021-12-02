using FluentValidation;
using Firjan.Integracao.Dynamics.Domain.Models.Corporativo.Gestor;

namespace Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Saude
{
    public class TipoFichaValidator : AbstractValidator<TipoFicha>
    {
        public TipoFichaValidator()
        {
            RuleFor(e => e.Descricao)
                .NotNullNotEmpty()
                .Greater(15);

            RuleFor(e => e.Abdome)
                .NotNullNotEmpty();

            RuleFor(e => e.AcidTrab)
               .NotNullNotEmpty();

            RuleFor(e => e.AcidTrab)
               .NotNullNotEmpty();

            RuleFor(e => e.Assistencial)
               .NotNullNotEmpty();

            RuleFor(e => e.BioComport)
               .NotNullNotEmpty();

            RuleFor(e => e.CabecaPescoco)
               .NotNullNotEmpty();

            RuleFor(e => e.CondTrab)
               .NotNullNotEmpty();

            RuleFor(e => e.AcidTrab)
               .NotNullNotEmpty();

            RuleFor(e => e.Faixa)
               .NotNullNotEmpty();

            RuleFor(e => e.ColabResp)
               .NotNullNotEmpty();

            RuleFor(e => e.QtdEspectad)
               .NotNullNotEmpty();

            RuleFor(e => e.IndiSerie)
               .NotNullNotEmpty();

            RuleFor(e => e.Assistencial)
               .NotNullNotEmpty();

            RuleFor(e => e.TotAtend)
               .NotNullNotEmpty();

            RuleFor(e => e.Evento)
               .NotNullNotEmpty();

            RuleFor(e => e.Tema)
               .NotNullNotEmpty();

            RuleFor(e => e.QtdAtend)
               .NotNullNotEmpty();

            RuleFor(e => e.Entidade)
               .NotNullNotEmpty();

            RuleFor(e => e.Pessoa)
               .NotNullNotEmpty();

            RuleFor(e => e.TipoUtilizacao)
               .NotNullNotEmpty();

            RuleFor(e => e.Despesa)
               .NotNullNotEmpty();

            RuleFor(e => e.Umo)
               .NotNullNotEmpty();

            RuleFor(e => e.PrimVez)
               .NotNullNotEmpty();

            RuleFor(e => e.PrimeSpec)
               .NotNullNotEmpty();

            RuleFor(e => e.Dente)
               .NotNullNotEmpty();

            RuleFor(e => e.Valor)
               .NotNullNotEmpty();

            RuleFor(e => e.QtPesAtend)
               .NotNullNotEmpty();

            RuleFor(e => e.Turma)
               .NotNullNotEmpty();

            RuleFor(e => e.EntPrestadora)
               .NotNullNotEmpty();

            RuleFor(e => e.TipoPreenchimento)
               .NotNullNotEmpty();

            RuleFor(e => e.PublAlvo)
               .NotNullNotEmpty();

            RuleFor(e => e.Despesa)
               .NotNullNotEmpty();

            RuleFor(e => e.GeraAtendimento)
               .NotNullNotEmpty();

            RuleFor(e => e.Despesa)
               .NotNullNotEmpty();

            RuleFor(e => e.Receita)
               .NotNullNotEmpty();

            RuleFor(e => e.CidDeficiencia)
               .NotNullNotEmpty();

            RuleFor(e => e.GeraAtendimento)
               .NotNullNotEmpty();

        }

    }
}
