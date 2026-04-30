using AutoMapper;
using ArtGallery.DAL.Entities;
using ArtGallery.BLL.DTOs;

namespace ArtGallery.BLL.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Artist, ArtistDto>();
        CreateMap<CreateArtistDto, Artist>();
        CreateMap<UpdateArtistDto, Artist>();

        CreateMap<Artwork, ArtworkDto>();
        CreateMap<CreateArtworkDto, Artwork>();
        CreateMap<UpdateArtworkDto, Artwork>();

        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>();

        CreateMap<Exhibition, ExhibitionDto>();
        CreateMap<CreateExhibitionDto, Exhibition>();
        CreateMap<UpdateExhibitionDto, Exhibition>();

        CreateMap<User, UserDto>();       
        CreateMap<CreateUserDto, User>(); 
        CreateMap<UpdateUserDto, User>(); 

        CreateMap<Favorite, FavoriteDto>();
    }
}