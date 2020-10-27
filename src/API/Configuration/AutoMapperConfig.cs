using API.ViewModel;
using AutoMapper;
using Business.Models;

namespace API.Configuration
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            /*CreateMap*/
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();

            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();

            CreateMap<ClienteProduto, ClienteProdutoViewModel>()
                .ForMember(dest => dest.ClienteDescricao, opt => opt.MapFrom(src => src.Cliente.Descricao))
                .ForMember(dest => dest.ProdutoDescricao, opt => opt.MapFrom(src => src.Produto.Descricao));
            CreateMap<ClienteProdutoViewModel, ClienteProduto>();

            CreateMap<Coletor, ColetorViewModel>().ReverseMap();

            CreateMap<Frota, FrotaViewModel>().ReverseMap();
        }
    }
}
