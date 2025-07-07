using AutoMapper;
using OnlyFreights.Books;

namespace OnlyFreights;

public class OnlyFreightsApplicationAutoMapperProfile : Profile
{
    public OnlyFreightsApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
