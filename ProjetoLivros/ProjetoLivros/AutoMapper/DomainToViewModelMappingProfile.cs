
using AutoMapper;
using ProjetoLivros.Domain.Entities;
using ProjetoLivros.ViewModels;

namespace ProjetoLivros.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public DomainToViewModelMappingProfile()
        {
            CreateMap<BookViewModel, Book>();
            CreateMap<LibraryViewModel, Library>();
        }
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }
    }
}