using API.ViewModel;
using AutoMapper;
using Business.Models;

namespace API.Configuration
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();

            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();

            CreateMap<ClienteProduto, ClienteProdutoViewModel>()
                .ForMember(dest => dest.ClienteDescricao, opt => opt.MapFrom(src => src.Cliente.Descricao))
                .ForMember(dest => dest.ProdutoDescricao, opt => opt.MapFrom(src => src.Produto.Descricao));
            CreateMap<ClienteProdutoViewModel, ClienteProduto>();

            CreateMap<Coletor, ColetorViewModel>().ReverseMap();

            CreateMap<Frota, FrotaViewModel>().ReverseMap();

            CreateMap<Movimento, MovimentoViewModel>()
                .ForMember(dest => dest.UsuarioCodigo, opt => opt.MapFrom(src => src.Usuario.Codigo))
                .ForMember(dest => dest.UsuarioNome, opt => opt.MapFrom(src => src.Usuario.Nome))
                .ForMember(dest => dest.FrotaPlaca, opt => opt.MapFrom(src => src.Frota.Placa));

            CreateMap<ItemMovimento, ItemMovimentoViewModel>()
                .ForMember(dest => dest.ClienteCodigo, opt => opt.MapFrom(src => src.ClienteProduto.Cliente.Codigo))
                .ForMember(dest => dest.ClienteDescricao, opt => opt.MapFrom(src => src.ClienteProduto.Cliente.Descricao))
                .ForMember(dest => dest.ProdutoCodigo, opt => opt.MapFrom(src => src.ClienteProduto.Produto.Codigo))
                .ForMember(dest => dest.ProdutoDescricao, opt => opt.MapFrom(src => src.ClienteProduto.Produto.Descricao));

            CreateMap<FilterMovim, FilterMovimViewModel>().ReverseMap();
        }
    }
}
