using AutoMapper;
using Hangxin.U8Interface.Application.Models;
using Hangxin.U8Interface.Domain.Entitys;

namespace Hangxin.U8Interface.Application
{
    public class BasicProfile : Profile
    {
        public BasicProfile()
        {
            CreateMap<TestDto, Test>();
            CreateMap<Test, TestDto>();

            CreateMap<Code, CodeDto>().ForMember(destinationMember: des => des.cCodeName, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.Ccode_Name); });
            CreateMap<Fitem, FitemDto>().ForMember(destinationMember: des => des.cItemClass, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.Citem_Class); })
                .ForMember(destinationMember: des => des.cItemName, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.Citem_Name); });
            CreateMap<Vendor, VendorDto>();
            CreateMap<Person, PersonDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Department, DepartmentDto>();

            CreateMap<GLAccvouchDto, GlAccvouch>().ForMember(destinationMember: des => des.Cdigest, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.cDigest); })
                .ForMember(destinationMember: des => des.Ccode, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.cCode); })
                .ForMember(destinationMember: des => des.Mc, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.mcMoney); })
                .ForMember(destinationMember: des => des.Md, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.mdMoney); })
                .ForMember(destinationMember: des => des.Dbill_Date, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.cBillDate); })
                .ForMember(destinationMember: des => des.Cperson_Id, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.cPersonCode); })
                .ForMember(destinationMember: des => des.Cdept_Id, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.cDepCode); })
                .ForMember(destinationMember: des => des.Ccus_Id, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.cCusCode); })
                .ForMember(destinationMember: des => des.Csup_Id, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.cSupCode); })
                .ForMember(destinationMember: des => des.Citem_Id, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.cItemCode); })
                .ForMember(destinationMember: des => des.Citem_Class, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.cItemClass); })
                .ForMember(destinationMember: des => des.Cbill, memberOptions: opt => { opt.MapFrom(mapExpression: map => map.cBillUser); });
        }
    }
}
