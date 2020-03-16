using MinhaApp.Negocios.Entidades;
using MinhaApp.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhaApp.Negocios.Servicos
{
    public class FornecedorServico : BaseServico, IFornecedorServico
    {
        public Task Adicionar(Fornecedor fornecedor)
        {
            // Validar o estado da entidade


            // Verificar senão existe o mesmo documento
            throw new NotImplementedException();
        }

        public Task Atualizar(Fornecedor fornecedor)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarEndereco(Endereco endereco)
        {
            throw new NotImplementedException();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
