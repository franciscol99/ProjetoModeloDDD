using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelMappingProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Produto, ProdutoViewModel>();
            Mapper.CreateMap<RegistroCompra, RegistroCompraViewModel>();
            Mapper.CreateMap<Livro, LivroViewModel>();
            Mapper.CreateMap<Animal, AnimalViewModel>();
            Mapper.CreateMap<Musica, MusicaViewModel>();
            Mapper.CreateMap<Carro, CarroViewModel>();
            Mapper.CreateMap<Fabricante, FabricanteViewModel>();
            Mapper.CreateMap<Agenda, AgendaViewModel>();
        }
    }
}