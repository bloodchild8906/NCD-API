using AutoMapper;
using MH.Domain.DBModel;
using MH.Domain.Dto;
using MH.Domain.Model;


namespace MH.Domain.Mapping;

public class ContactDetailsMapping : Profile
{
    public ContactDetailsMapping()
    {
        CreateMap<ContactDetails,ContactDetailsModel>()
            .ReverseMap()
            .ForSourceMember(x => x.Userid, y => y.DoNotValidate());
        CreateMap<ContactDetails,ContactDetail>()
            .ForMember(u => u.UserId, dest => dest.MapFrom(x => x.UserProfile.UserId))
            .ForMember(u => u.ContactDataTypeName, dest => dest.MapFrom(x => x.ContactDataType.Name))
            .ForMember(u => u.ContactTypeName, dest => dest.MapFrom(x => x.ContactType.Name))
            .ForMember(u => u.ContactEntityName, dest => dest.MapFrom(x => x.ContactEntity.Name))
            .ReverseMap();
    }
}