using System;
using System.ComponentModel.DataAnnotations;

namespace Firjan.Integracao.Dynamics.Application.ViewModels
{
    public class DiscadoUnidadeViewModel
    {
        public int Id { get; set; }
        public Int16 CodigoPais { get; set; }
        public Byte TipoComunicacao { get; set; }
        public Int16 CodigoUnidadeNegocio { get; set; }
        public string Telefone { get; set; }
        public string Ramal { get; set; }
        public string CodigoArea { get; set; }
        public string BipDiscado { get; set; }
        public char Tipo { get; set; }
    }
}