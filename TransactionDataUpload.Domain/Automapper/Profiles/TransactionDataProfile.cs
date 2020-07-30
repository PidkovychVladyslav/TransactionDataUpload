using AutoMapper;
using TransactionDataUpload.Data.Entities;
using TransactionDataUpload.Models.Dto;

namespace TransactionDataUpload.Domain.Profiles
{
    public class TransactionDataProfile : Profile
    {
        public TransactionDataProfile()
        {
            CreateMap<TransactionData, TransactionDataDto>()
                .ForMember(dest => dest.Id, src => src.MapFrom(m => m.Id))
                .ForMember(dest => dest.Payment, src => src.MapFrom(m => m.Amount))
                .ForMember(dest => dest.Status, src => src.MapFrom(m => m.Status));
        }
    }
}
