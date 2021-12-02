#region Using
using Firjan.Integracao.Dynamics.Domain.Interfaces.Repository;
using Firjan.Integracao.Dynamics.Domain.Models;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Contextos;
using Firjan.Integracao.Dynamics.Infrastructure.Data.Extensions;
using Microsoft.AspNetCore.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml.Linq;
#endregion

namespace Firjan.Integracao.Dynamics.Infrastructure.Data.Repositorios
{
    public class TraceRepositorio : ITraceRepository
    {
        
        public Task<Trace> Adicionar(Trace item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> All(Expression<Func<Trace, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Any(Expression<Func<Trace, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<Trace> Atualizar(Trace item)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<Trace>> ComFiltros(string colunaOrdenacao, bool? asc, Expression<Func<Trace, bool>> filtro, int qtd, int pule, IEnumerable<string> includes)
        {

            XDocument xdoc = new XDocument();
            IEnumerable<Trace> traces = null;
            try
            {
                xdoc = XDocument.Load("C:\\\\UNIRIO\\T2-UXT\\viewer\\TraceViewer\\src\\Firjan.Integracao.Dynamics.Infrastructure.Repositorio\\Data\\trace.xml");
                traces = xdoc.Descendants("trace")
                                    .Elements("rawtrace")
                                    .Select(m => new Trace
                                    {
                                        image = m.Attribute("image").Value,
                                        type = m.Attribute("type").Value,
                                        time = m.Attribute("time").Value,
                                        Class = m.Attribute("Class").Value,
                                        Id = m.Attribute("Id").Value,
                                        MouseClass = m.Attribute("MouseClass").Value,
                                        MouseId = m.Attribute("MouseId").Value,
                                        X = m.Attribute("X").Value,
                                        Y = m.Attribute("Y").Value,
                                        keys = m.Attribute("keys").Value,
                                        scroll = m.Attribute("scroll").Value,
                                        height = m.Attribute("height").Value,
                                        url = m.Attribute("url").Value,
                                        date = m.Attribute("date").Value
                                    });
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return await Task.FromResult(traces);
        }

        public void Dispose()
        {
            
        }

        public Task<Trace> FirstOrDefault(Expression<Func<Trace, bool>> expression, IEnumerable<string> includes)
        {
            throw new NotImplementedException();
        }

        public Task<Trace> ObtemPorId(object id)
        {
            throw new NotImplementedException();
        }

        public Task<Trace> Remover(Trace item)
        {
            throw new NotImplementedException();
        }

        public Task<Trace> Remover(object id)
        {
            throw new NotImplementedException();
        }

        public Trace SetId(Trace item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Trace>> Where(Expression<Func<Trace, bool>> expression, IEnumerable<string> includes)
        {
            throw new NotImplementedException();
        }
    }
}
