using AutoMapper;
using ElevenNote.Data.Entities;
using ElevenNote.Models.CategoryModels;
using ElevenNote.Models.NoteModels;

namespace ElevenNote.Services.Configurations
{
    public class MapperConfigurations : Profile
    {
        public MapperConfigurations()
        {
            CreateMap<Category, CategoryCreate>().ReverseMap();
            CreateMap<Category, CategoryListItem>().ReverseMap();


            CreateMap<Note, NoteCreate>().ReverseMap();
            CreateMap<Note, NoteListItem>().ReverseMap();
            CreateMap<Note, NoteDetail>().ReverseMap();
            CreateMap<Note, NoteEdit>().ReverseMap();
        }
    }
}