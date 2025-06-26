using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Acme.BookStore.Web;

public class BookStoreWebAutoMapperProfile : Profile
{
    public BookStoreWebAutoMapperProfile()
    {
        //Define your object mappings here, for the Web project
        
        //Libros
        CreateMap<BookDto, CreateUpdateBookDto>();
        
        //Autores
        CreateMap<Pages.Authors.CreateModalModel.CreateAuthorViewModel, CreateAuthorDto>();
        CreateMap<AuthorDto, Pages.Authors.EditModalModel.EditAuthorViewModel>();
        CreateMap<Pages.Authors.EditModalModel.EditAuthorViewModel,
            UpdateAuthorDto>();
    }
}
