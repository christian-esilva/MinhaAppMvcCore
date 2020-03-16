using MinhaApp.Negocios.Entidades;
using MinhaApp.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhaApp.Negocios.Servicos
{
    public class ProdutoServico : BaseServico, IProdutoServico
    {
        public Task Adicionar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
