using AutoMapper;
using OnlyFreights.Books;

namespace OnlyFreights.Blazor.Client;

public class OnlyFreightsBlazorAutoMapperProfile : Profile
{
    public OnlyFreightsBlazorAutoMapperProfile()
    {
        CreateMap<BookDto, CreateUpdateBookDto>();
        
        //Define your AutoMapper configuration here for the Blazor project.
    }
}