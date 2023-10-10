using AutoMapper;
using SupplierApi.Application.DTOs;
using SupplierApi.Application.DTOs.Request;
using SupplierApi.Domain.Entities;

namespace SupplierApi.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();

            CreateMap<Cliente, ClienteRequest>().ReverseMap();            
        }
    }
}
