using AutoMapper;

namespace Financeiro.App_Start.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<DAL.Bank, Models.Admin.Bank>();
            CreateMap<DAL.User, Models.Admin.User>();
        }
    }
}