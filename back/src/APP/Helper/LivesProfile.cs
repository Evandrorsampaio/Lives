using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP.DTOS;
using AutoMapper;
using Domain.Entities;

namespace APP.Helper
{
    public class LivesProfile: Profile
    {
        public LivesProfile()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;

            CreateMap<LiveEntity, LiveDto>().ReverseMap();
            CreateMap<IEnumerable<InscricaoEntity>, LiveDto>().ReverseMap();
            CreateMap<IEnumerable<InscricaoDto>, LiveEntity>().ReverseMap();
            CreateMap<InstrutorEntity, LiveDto>().ReverseMap();
            CreateMap<InstrutorDto, LiveEntity>().ReverseMap();

            CreateMap<PessoaEntity, PessoaDto>().ReverseMap();

            CreateMap<InstrutorEntity, InstrutorDto>().ReverseMap();
            CreateMap<IEnumerable<LiveEntity>, InstrutorDto>().ReverseMap();
            CreateMap<IEnumerable<LiveDto>, InstrutorEntity>().ReverseMap();
            CreateMap<PessoaEntity, InstrutorDto>().ReverseMap();
            CreateMap<PessoaDto, InstrutorEntity>().ReverseMap();

            CreateMap<InscritoEntity, InscritoDto>().ReverseMap();
            CreateMap<IEnumerable<InscricaoEntity>, InscritoDto>().ReverseMap();
            CreateMap<IEnumerable<InscritoDto>, InscricaoEntity>().ReverseMap();
            CreateMap<PessoaEntity, InscritoDto>().ReverseMap();
            CreateMap<PessoaDto, InscritoEntity>().ReverseMap();

            CreateMap<InscricaoEntity, InscricaoDto>().ReverseMap();
            CreateMap<LiveEntity, InscricaoDto>().ReverseMap();
            CreateMap<LiveDto, InscricaoEntity>().ReverseMap();
            CreateMap<InscritoEntity, InscricaoDto>().ReverseMap();
            CreateMap<InscritoDto, InscricaoEntity>().ReverseMap();
            
        }
    }
}