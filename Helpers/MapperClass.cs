using AutoMapper;
using WebAPIAFFS.DAL.Entity;
using WebAPIAFFS.Models;

namespace WebAPIAFFS.Helpers
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {

            CreateMap<Department,DepartmentModel>();
            CreateMap<DepartmentModel, Department>();

            CreateMap<District, DistrictModel>();
            CreateMap<DistrictModel, District>();
            //CreateMap<TokenEntry, TpBillModel>();
            //CreateMap<TokenModel, TokenEntry>();

            //            CreateMap<TpBtdetail, ByTransferModel>();
            //            CreateMap<ByTransferModel, TpBtdetail>();

            //<<<<<<< Updated upstream
            //            CreateMap<AllotmentTransaction, AllotmentModel>();
            //            CreateMap<AllotmentModel, AllotmentTransaction>();
            //=======
            //              CreateMap<TpBill, BillCheckingModel>()
            //               .ForMember(dest => dest.GloabalObjection, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<GloabalObjModel>>(src.GloabalObjection)))
            //               .ForMember(dest => dest.LocalObjection, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<LocalObjModel>>(src.LocalObjection)));
            //               ;
            //            CreateMap<BillCheckingModel,TpBill>()
            //                .ForMember(dest => dest.LocalObjection, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.LocalObjection)))
            //              .ForMember(dest => dest.GloabalObjection, opt => opt.MapFrom(src => JsonConvert.SerializeObject(src.GloabalObjection)));
            //>>>>>>> Stashed changes
        }
    }
}
