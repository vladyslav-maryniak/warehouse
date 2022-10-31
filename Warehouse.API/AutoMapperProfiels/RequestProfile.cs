using AutoMapper;
using Warehouse.API.DTOs.Requests;
using Warehouse.Infrastructure.Entities;

namespace Warehouse.API.AutoMapperProfiels
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<AddRequestCommand, Request>();
            CreateMap<UpdateRequestCommand, Request>();
        }
    }
}
