using AutoMapper;
using MinhaApp.Apresentacao.ViewModels;
using MinhaApp.Negocios.Entidades;

namespace MinhaApp.Apresentacao.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();
        }
    }
}
