namespace Firjan.Integracao.Dynamics.Domain.Models.Base
{
    public abstract class TipoModel<T> : BaseModel<T>
    {
        public new string Descricao { get; set; }
        protected TipoModel() { }
    }
}
