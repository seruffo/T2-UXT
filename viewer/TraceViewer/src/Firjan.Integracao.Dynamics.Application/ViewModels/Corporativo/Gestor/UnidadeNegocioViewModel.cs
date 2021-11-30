using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using System;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    public class UnidadeNegocioViewModel : TipoViewModel<Int16>
    {
        ///<summary>
        ///Objeto Unidade de Negócio"/>
        ///</summary>
        [DataMember]
        public DateTime? Inicio { get; set; } = null;
        ///<summary>
        ///Indica a data fim do servico.
        ///</summary>
        [DataMember]
        public DateTime? Fim { get; set; } = null;
        ///<summary>
        ///Indica se a unidade operacional tem endereco próprio e não utiliza o
        ///mesmo endereco da empresaCNI a que está vinculada
        ///Ex: S ou N
        ///</summary>
        [DataMember]
        public string EnderecoProprio { get; set; }
        ///<summary>
        ///Indica se a unidade operacional tem endereco eletrônico próprio e
        ///não utiliza o mesmo endereco eletrônico da empresaCNI a que está vinculada
        ///Ex: S ou N
        ///</summary>        
        [DataMember]
        public string EnderecadoProprio { get; set; }
        ///<summary>
        ///Indica se a unidade operacional tem telefone próprio e não utiliza o
        ///mesmo telefone da empresaCNI a que está vinculada
        ///Ex: S ou N
        ///</summary>        
        [DataMember]
        public string DiscadoProprio { get; set; }
        [DataMember]
        public string SiglaSerie { get; set; }
        [DataMember]
        public string SiglaTitulo { get; set; }
        /////<summary>
        /////Este flag indica se a unidade gera preço para serviços. 
        /////Esta indicação filtra a geração do preço aplicado apenas para as que estiverem marcados com sim.
        /////Valores aceito 1 = SIM, 0 = Nao
        /////</summary>
        [DataMember]
        public bool AceitaPreco { get; set; }
        /////<summary>
        /////Indica se a unidade de negocio está autorizada pela área responsável (ASSECI) a ser divulgada na Intranet.
        /////</summary>
        [DataMember]
        public bool AutorizaDivulgacao { get; set; }
        /////<summary>
        /////Informa se o o Teleatendimento da unidade tem atendimento.
        /////</summary>
        [DataMember]
        public bool AtendimentoCentralizado { get; set; }
        /////<summary>
        /////Informa se o o Teleatendimento da unidade tem ativo de marcação de medicina assistencial
        /////</summary>
        [DataMember]
        public bool AtivoAssistMarca { get; set; }
        /////<summary>
        /////Informa se o o Teleatendimento da unidade tem ativo de marcação de medicina ocupacional
        /////</summary>
        [DataMember]
        public bool AtivoOcupMarca { get; set; }
        ///<summary>
        ///Informa se o o Teleatendimento da unidade tem ativo de desmarcação de medicina ocupacional
        ///</summary>
        [DataMember]
        public bool AtivoOcupDesMarca { get; set; }
        ///<summary>
        ///TipoUnidade
        ///</summary>
        [DataMember]
        public Int32 TipoUnidadeId { get; set; }
        ///<summary>
        ///TipoUnidade
        ///</summary>
        [DataMember]
        public bool FazFaturamento { get; set; }
        ///<summary>
        ///sequencial da entidade coordenadora
        ///</summary>
        [DataMember]
        public int? EmpresaSistemaCNICoordenadoraId { get; set; }
        ///<summary>
        ///Descricao abreviada
        ///</summary>
        [DataMember]
        public string DescricaoAbreviado { get; set; }
        ///<summary>
        ///O nome da Cogecor não faz distinção da Empresa. Pode ser utilizado
        ///para disponibilizar informações para o publico.
        ///Ex: SESI/SENAI Jacarepagua
        ///</summary>
        [DataMember]
        public string NomeCogecor { get; set; }
        ///<summary>
        ///Sigla da unidade de Negócio
        ///Ex: NIT, BAN, LUZ
        ///No caso de UPP: UPP_XXX_YY .
        ///Este nome não irá para carteirinha ( contempla 3 posições).
        ///Neste caso a carteirinha deve ter a sigla da unidade matricula (si_sq_unidnegocio_matricula).
        ///XXX - Abreviatura da UPP YY SS(SESI) e SN(SENAI)
        ///Ex: ch_sg_unidnegocio = 'UPP-FOG-SS' UPP Fogueteiro SESI
        ///--
        ///ch_sg_unidnegocio = 'UPP-FOR-SS' UPP Formiga SESI
        ///--
        ///ch_sg_unidnegocio = 'UPP-MAN-SS' UPP Mangueira SESI
        ///</summary>     
        [DataMember]
        public string Sigla { get; set; }
        [DataMember]
        public string Prestador { get; set; }
        [DataMember]
        public string Corporativo { get; set; }
    }
}
