#region Includes 
using AutoMapper;
using Firjan.Integracao.Dynamics.Application.AutoMapperConfigs;
using Firjan.Integracao.Dynamics.Application.Interfaces;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.STI;
using Firjan.Integracao.Dynamics.Application.Interfaces.SGE;
using Firjan.Integracao.Dynamics.Application.Services;
using Firjan.Integracao.Dynamics.Application.Services.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Application.Services.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Application.Services.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Application.Services.Corporativo.STI;
using Firjan.Integracao.Dynamics.Application.Services.SGE;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.SGE;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.SGE;
using Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Services.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Services.Corporativo.STI;
using Firjan.Integracao.Dynamics.Domain.Services.SGE;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Protheus;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.STI;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.SGE;
using Microsoft.Extensions.DependencyInjection;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Gestor;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.SRC;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.Saude;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Services.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.STI;
using Firjan.Integracao.Dynamics.Application.Interfaces.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Application.Services.Corporativo.Gestor.Odontograma;
using Firjan.Integracao.Dynamics.Application.Interfaces.SMAIS;
using Firjan.Integracao.Dynamics.Application.Services.SMAIS;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services.SMAIS;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository.Corporativo.SMAIS;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo.SMAIS;
using Firjan.Integracao.Dynamics.Domain.Validations.Corporativo;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository;
using Firjan.Integracao.Dynamics.Domain.Interfaces.Services;
using Firjan.Integracao.Dynamics.Domain.Services;
using Firjan.Integracao.Dynamics.Domain.Validations;
#endregion

namespace Firjan.Integracao.Dynamics.Infrastructure.CrossCutting
{
    public class Injections
    {
        protected Injections() { }

        public static void RegistrarServicos(IServiceCollection services)
        {
            services.AddSingleton<IConfigurationProvider>(AutoMapperConfig.RegisterMappings());

            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            #region Add singleton
            services.AddSingleton<TraceValidator>();

            services.AddSingleton<ProdutoValidator>();
            services.AddSingleton<ItemContabilProdutoValidator>();
            services.AddSingleton<ContaContabilProdutoValidator>();
            services.AddSingleton<ClasseValorProdutoValidator>();
            services.AddSingleton<TUSSValidator>();
            services.AddSingleton<EmpresaValidator>();
            services.AddSingleton<EntidadeValidator>();
            services.AddSingleton<ModuloVersaoValidator>();
            services.AddSingleton<TipoEntidadeVinculoValidator>();
            services.AddSingleton<TabelaServicoTipoEntidadeVinculoValidator>();
            services.AddSingleton<ClasssificacaoValidator>();
            services.AddSingleton<SaudeValidator>();
            services.AddSingleton<TipoUnidadeNegocioTipoEntidadeVinculoValidator>();
            services.AddSingleton<TipoUnidadeNegocioValidator>();
            services.AddSingleton<EnderecoUnidadeValidator>();
            services.AddSingleton<SaudeFiguraOdontogramaValidator>();
            services.AddSingleton<LinhaServicoValidator>();
            services.AddSingleton<FiguraOdontogramaValidator>();
            services.AddSingleton<ProdutoTipoFichaValidator>();
            services.AddSingleton<LazerValidator>();
            services.AddSingleton<ExameValidator>();
            services.AddSingleton<RiscoValidator>();
            services.AddSingleton<OdontogramaValidator>();
            services.AddSingleton<TipoFichaValidator>();
            services.AddSingleton<FuncaoValidator>();
            services.AddSingleton<AreaValidator>();
            services.AddSingleton<GrupoClassificacaoValidator>();
            services.AddSingleton<PlataformaValidator>();
            services.AddSingleton<ClassificacaoServicoValidator>();
            services.AddSingleton<CodigoMunicipalValidator>();
            services.AddSingleton<ProdutoUnidadeNegocioValidator>();
            services.AddSingleton<EmpresaEntidadeVinculoValidator>();
            services.AddSingleton<CodigoMunicipalServicoCorporativoValidator>();
            services.AddSingleton<TipoRegiaoValidator>();
            services.AddSingleton<RegiaoUnidadeNegocioValidator>();
            services.AddSingleton<RegiaoValidator>();
            services.AddSingleton<Domain.Validations.Corporativo.Protheus.EmpresaValidator>();
            services.AddSingleton<EmpresaValidator>();
            #endregion

            #region Add Scoped AppService
            services.AddScoped<ITraceAppService, TraceAppService>();

            services.AddScoped<ITipoRegiaoAppService, TipoRegiaoAppService>();
            services.AddScoped<IRegiaoAppService, RegiaoAppService>();
            services.AddScoped<IFuncaoAppService, FuncaoAppService>();
            services.AddScoped<IPlataformaAppService, PlataformaAppService>();
            services.AddScoped<Application.Interfaces.Corporativo.STI.IAreaAppService, Application.Services.Corporativo.STI.AreaAppService>();
            services.AddScoped<Application.Interfaces.SGE.IAreaAppService, Application.Services.SGE.AreaAppService>();
            services.AddScoped<IModalidadeCursoAppService, ModalidadeCursoAppService>();
            services.AddScoped<IUnidadeNegocioAppService, UnidadeNegocioAppService>();
            services.AddScoped<ICodigoMunicipalServicoCorporativoAppService, CodigoMunicipalServicoCorporativoAppService>();
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<ITipoFichaAppService, TipoFichaAppService>();
            services.AddScoped<IItemContabilAppService, ItemContabilAppService>();
            services.AddScoped<IClasseValorAppService, ClasseValorAppService>();
            services.AddScoped<IContaContabilAppService, ContaContabilAppService>();
            services.AddScoped<ILinhaServicoAppService, LinhaServicoAppService>();
            services.AddScoped<IProdutoUnidadeNegocioAppService, ProdutoUnidadeNegocioAppService>();
            services.AddScoped<ICentroCustoAppService, CentroCustoAppService>();
            services.AddScoped<IFilialAppService, FilialAppService>();
            services.AddScoped<IRegiaoUnidadeNegocioAppService, RegiaoUnidadeNegocioAppService>();
            services.AddScoped<ICodigoMunicipalAppService, CodigoMunicipalAppService>();
            services.AddScoped<IClassificacaoServicoAppService, ClassificacaoServicoAppService>();
            services.AddScoped<IEntidadeAppService, EntidadeAppService>();
            services.AddScoped<IBairroAppService, BairroAppService>();
            services.AddScoped<IProdutoTipoFichaAppService, ProdutoTipoFichaAppService>();
            services.AddScoped<ITipoEntidadeVinculoAppService, TipoEntidadeVinculoAppService>();
            services.AddScoped<ITipoUnidadeNegocioTipoEntidadeVinculoAppService, TipoUnidadeNegocioTipoEntidadeVinculoAppService>();
            services.AddScoped<IProdutoAppService, ProdutoAppService>();
            services.AddScoped<IItemContabilProdutoAppService, ItemContabilProdutoAppService>();
            services.AddScoped<IContaContabilProdutoAppService, ContaContabilProdutoAppService>();
            services.AddScoped<IClasseValorProdutoAppService, ClasseValorProdutoAppService>();
            services.AddScoped<ITUSSAppService, TUSSAppService>();
            services.AddScoped<Application.Interfaces.Corporativo.Gestor.IEmpresaAppService, Application.Services.Corporativo.Gestor.EmpresaAppService>();
            services.AddScoped<Application.Interfaces.Protheus.IEmpresaAppService,Application.Services.Protheus.EmpresaAppService>();
            services.AddScoped<IModuloVersaoAppService, ModuloVersaoAppService>();
            services.AddScoped<ITabelaServicoTipoEntidadeVinculoAppService, TabelaServicoTipoEntidadeVinculoAppService>();
            services.AddScoped<IClassificacaoAppService, ClassificacaoAppService>();
            services.AddScoped<ISaudeAppService, SaudeAppService>();
            services.AddScoped<ITipoUnidadeNegocioAppService, TipoUnidadeNegocioAppService>();
            services.AddScoped<IEnderecoUnidadeAppService, EnderecoUnidadeAppService>();
            services.AddScoped<ISaudeFiguraOdontogramaAppService, SaudeFiguraOdontogramaAppService>();
            services.AddScoped<IFiguraOdontogramaAppService, FiguraOdontogramaAppService>();
            services.AddScoped<ILazerAppService, LazerAppService>();
            services.AddScoped<IExameAppService, ExameAppService>();
            services.AddScoped<IRiscoAppService, RiscoAppService>();
            services.AddScoped<IOdontogramaAppService, OdontogramaAppService>();
            services.AddScoped<IHierarquiaProdutoAppService, HierarquiaProdutoAppService>();
            #endregion

            #region Add Scoped Service
            services.AddScoped<ITraceService, TraceService>();

            services.AddScoped<ITipoRegiaoService, TipoRegiaoService>();
            services.AddScoped<IRegiaoService, RegiaoService>();
            services.AddScoped<Domain.Interfaces.Services.Corporativo.STI.IAreaService, Domain.Services.Corporativo.STI.AreaService>();
            services.AddScoped<Domain.Interfaces.Services.SGE.IAreaService, Domain.Services.SGE.AreaService>();
            services.AddScoped<IModalidadeCursoService, ModalidadeCursoService>();
            services.AddScoped<IFuncaoService, FuncaoService>();
            services.AddScoped<IPlataformaService, PlataformaService>();
            services.AddScoped<IUnidadeNegocioService, UnidadeNegocioService>();
            services.AddScoped<ICodigoMunicipalServicoCorporativoService, CodigoMunicipalServicoCorporativoService>();
            services.AddScoped<ITipoFichaService, TipoFichaService>();
            services.AddScoped<IItemcontabilService, ItemContabilService>();
            services.AddScoped<IClasseValorService, ClasseValorService>();
            services.AddScoped<IContaContabilService, ContaContabilService>();
            services.AddScoped<ILinhaServicoService, LinhaServicoService>();
            services.AddScoped<IProdutoUnidadeNegocioService, ProdutoUnidadeNegocioService>();
            services.AddScoped<IRegiaoUnidadeNegocioService, RegiaoUnidadeNegocioService>();
            services.AddScoped<ICodigoMunicipalService, CodigoMunicipalService>();
            services.AddScoped<IClassificacaoServicoService, ClassificacaoServicoService>();
            services.AddScoped<IEntidadeService, EntidadeService>();
            services.AddScoped<IBairroService, BairroService>();
            services.AddScoped<IProdutoTipoFichaService, ProdutoTipoFichaService>();
            services.AddScoped<ICentroCustoService, CentroCustoService>();
            services.AddScoped<IFilialService, FilialService>();
            services.AddScoped<ITipoEntidadeVinculoService, TipoEntidadeVinculoService>();
            services.AddScoped<ITipoUnidadeNegocioTipoEntidadeVinculoService, TipoUnidadeNegocioTipoEntidadeVinculoService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IItemContabilProdutoService, ItemContabilProdutoService>();
            services.AddScoped<IContaContabilProdutoService, ContaContabilProdutoService>();
            services.AddScoped<IClasseValorProdutoService, ClasseValorProdutoService>();
            services.AddScoped<ITUSSService, TUSSService>();
            services.AddScoped<Domain.Interfaces.Services.Protheus.IEmpresaService, Domain.Services.Protheus.EmpresaService>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IModuloVersaoService, ModuloVersaoService>();
            services.AddScoped<ITabelaServicoTipoEntidadeVinculoService, TabelaServicoTipoEntidadeVinculoService>();
            services.AddScoped<IClassificacaoService, ClassificacaoService>();
            services.AddScoped<ISaudeService, SaudeService>();
            services.AddScoped<ITipoUnidadeNegocioService, TipoUnidadeNegocioService>();
            services.AddScoped<IEnderecoUnidadeService, EnderecoUnidadeService>();
            services.AddScoped<ISaudeFiguraOdontogramaService, SaudeFiguraOdontogramaService>();
            services.AddScoped<IFiguraOdontogramaService, FiguraOdontogramaService>();
            services.AddScoped<ILazerService, LazerService>();
            services.AddScoped<IExameService, ExameService>();
            services.AddScoped<IRiscoService, RiscoService>();
            services.AddScoped<IOdontogramaService, OdontogramaService>();
            services.AddScoped<IHierarquiaProdutoService, HierarquiaProdutoService>();
            services.AddScoped<IEmpresaEntidadeVinculoService, EmpresaEntidadeVinculoService>();
            #endregion

            #region Add Scoped Repository

            services.AddScoped<ITraceRepository, TraceRepositorio>();

            services.AddScoped<ITipoRegiaoRepository, TipoRegiaoRepositorio>();
            services.AddScoped<IRegiaoRepository, RegiaoRepositorio>();
            services.AddScoped<IFuncaoRepository, FuncaoRepositorio>();
            services.AddScoped<Domain.Interfaces.Repository.Corporativo.STI.IAreaRepository, Data.Repositorios.Corporativo.STI.AreaRepositorio>();
            services.AddScoped<Domain.Interfaces.Repository.SGE.IAreaRepository, Data.Repositorios.SGE.AreaRepositorio>();
            services.AddScoped<IModalidadesRepository, ModalidadeCursoRepositorio>();
            services.AddScoped<IPlataformaRepository, PlataformaRepositorio>();
            services.AddScoped<IUnidadeNegocioRepository, UnidadeNegocioRepositorio>();
            services.AddScoped<ICodigoMunicipalServicoCorporativoRepository, CodigoMunicipalServicoCorporativoRepositorio>();
            services.AddScoped<ITipoFichaRepository, TipoFichaRepositorio>();
            services.AddScoped<IItemContabilRepository, ItemContabilRepositorio>();
            services.AddScoped<IClasseValorRepository, ClasseValorRepositorio>();
            services.AddScoped<IContaContabilRepository, ContaContabilRepositorio>();
            services.AddScoped<ILinhaServicoRepository, LinhaServicoRepositorio>();
            services.AddScoped<IProdutoUnidadeNegocioRepository, ProdutoUnidadeNegocioRepositorio>();
            services.AddScoped<IRegiaoUnidadeNegocioRepository, RegiaoUnidadeNegocioRepositorio>();
            services.AddScoped<ICodigoMunicipalRepository, CodigoMunicipalRepositorio>();
            services.AddScoped<IClassificacaoServicoRepository, ClassificacaoServicoRepositorio>();
            services.AddScoped<IEnderecoUnidadeRepository, EnderecoUnidadeRepositorio>();
            services.AddScoped<IEntidadeRepository, EntidadeRepositorio>();
            services.AddScoped<IBairroRepository, BairroRepositorio>();
            services.AddScoped<IProdutoTipoFichaRepository, ProdutoTipoFichaRepositorio>();
            services.AddScoped<ICentroCustoRepository, CentroCustoRepositorio>();
            services.AddScoped<IFilialRepository, FilialRepositorio>();
            services.AddScoped<ITipoEntidadeVinculoRepository, TipoEntidadeVinculoRepositorio>();
            services.AddScoped<ITipoUnidadeNegocioTipoEntidadeVinculoRepository, TipoUnidadeNegocioTipoEntidadeVinculoRepositorio>();
            services.AddScoped<IProdutoRepository,ProdutoRepositorio>();
            services.AddScoped<IItemContabilProdutoRepository, ItemContabilProdutoRepositorio>();
            services.AddScoped<IContaContabilProdutoRepository, ContaContabilProdutoRepositorio>();
            services.AddScoped<IClasseValorProdutoRepository, ClasseValorProdutoRepositorio>();
            services.AddScoped<ITUSSRepository, TUSSRepositorio>();
            services.AddScoped<Domain.Interfaces.Repository.Protheus.IEmpresaRepository, Data.Repositorios.Protheus.EmpresaRepositorio>();
            services.AddScoped<IEmpresaRepository, EmpresaRepositorio>();
            services.AddScoped<IModuloVersaoRepository, ModuloVersaoRepositorio>();
            services.AddScoped<ITabelaServicoTipoEntidadeVinculoRepository, TabelaServicoTipoEntidadeVinculoRepositorio>();
            services.AddScoped<IClassificacaoRepository, ClassificacaoRepositorio>();
            services.AddScoped<ISaudeRepository, SaudeRepositorio>();
            services.AddScoped<ITipoUnidadeNegocioRepository, TipoUnidadeNegocioRepositorio>();
            services.AddScoped<IEnderecoUnidadeRepository, EnderecoUnidadeRepositorio>();
            services.AddScoped<ISaudeFiguraOdontogramaRepository, SaudeFiguraOdontogramaRepositorio>();
            services.AddScoped<IFiguraOdontogramaRepository, FiguraOdontogramaRepositorio>();
            services.AddScoped<ILazerRepository, LazerRepositorio>();
            services.AddScoped<IExameRepository, ExameRepositorio>();
            services.AddScoped<IRiscoRepository, RiscoRepositorio>();
            services.AddScoped<IOdontogramaRepository, OdontogramaRepositorio>();
            services.AddScoped<IHierarquiaProdutoRepository, HierarquiaProdutoRepositorio>();
            services.AddScoped<IEmpresaEntidadeVinculoRepository, EmpresaEntidadeVinculoRepositorio>();
            #endregion
        }

        public static void RegistrarSeguranca(IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            var tokenConfigurations = new Application.Security.Configuration.TokenConfiguration();
            var signingConfigurations = new Application.Security.Configuration.SigningConfigurations();

            new Microsoft.Extensions.Options.ConfigureFromConfigurationOptions<Application.Security.Configuration.TokenConfiguration>(
                configuration.GetSection("TokenConfigurations")
            )
            .Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);

            services.AddSingleton(signingConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
                paramsValidation.ValidateIssuerSigningKey = true;
                paramsValidation.ValidateLifetime = true;
                paramsValidation.ClockSkew = System.TimeSpan.Zero;
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser()
                    .Build());
            });
        }
    }
}