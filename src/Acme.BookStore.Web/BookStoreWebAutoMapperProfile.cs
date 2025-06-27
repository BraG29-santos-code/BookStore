using System;
using System.Globalization;
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
        CreateMap<Pages.Books.CreateModalModel.CreateBookViewModel, CreateUpdateBookDto>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => ParsePrice(src.Price)));
        CreateMap<BookDto, Pages.Books.EditModalModel.EditBookViewModel>();
        CreateMap<Pages.Books.EditModalModel.EditBookViewModel, CreateUpdateBookDto>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => ParsePrice(src.Price)));
    }
    
    private static float ParsePrice(string input)
    {
        if (float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out float result))
            return result;

        if (float.TryParse(input, NumberStyles.Float, new CultureInfo("es-ES"), out result))
            return result;

        throw new FormatException($"No se pudo convertir '{input}' a float.");
    }
}
