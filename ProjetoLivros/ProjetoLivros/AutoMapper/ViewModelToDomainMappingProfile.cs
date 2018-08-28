
using AutoMapper;
using ProjetoLivros.Domain.Entities;
using ProjetoLivros.ViewModels;

namespace ProjetoLivros.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Book, BookViewModel>();
            CreateMap<Library, LibraryViewModel>();
        }
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }
    }
}