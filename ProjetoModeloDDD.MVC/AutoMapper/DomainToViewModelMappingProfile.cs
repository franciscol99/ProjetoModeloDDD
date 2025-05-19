using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainMappingProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ProdutoViewModel, Produto>();
            Mapper.CreateMap<RegistroCompraViewModel, RegistroCompra>();
            Mapper.CreateMap<LivroViewModel, Livro>();
            Mapper.CreateMap<AnimalViewModel, Animal>();
            Mapper.CreateMap<MusicaViewModel, Musica>();
            Mapper.CreateMap<CarroViewModel, Carro>();
            Mapper.CreateMap<FabricanteViewModel, Fabricante>();
            Mapper.CreateMap<AgendaViewModel, Agenda>();
            Mapper.CreateMap<AgendaTelefonicaViewModel, AgendaTelefonica>();
            Mapper.CreateMap<CorretoraDeImoveisViewModel, CorretoraDeImoveis>();
            Mapper.CreateMap<GerenciadorDeTarefasViewModel, GerenciadorDeTarefas>();
        }
    }
}