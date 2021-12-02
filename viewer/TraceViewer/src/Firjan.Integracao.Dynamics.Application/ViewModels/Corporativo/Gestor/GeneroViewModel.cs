using System;
using Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Base;
using System.Runtime.Serialization;

namespace Firjan.Integracao.Dynamics.Application.ViewModels.Corporativo.Gestor
{
    ///<summary>
    ///Objeto Genero"/>
    ///</summary>
    [DataContract]
    public class GeneroViewModel : TipoViewModel<string>
    {
        public RamoAtividadeViewModel RamoAtividade { get; set; }
    }
}