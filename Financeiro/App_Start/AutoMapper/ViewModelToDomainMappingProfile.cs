using AutoMapper;

namespace Financeiro.App_Start.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Models.Admin.Bank, DAL.Bank>();
            CreateMap<Models.Admin.User, DAL.User>();
        }
    }
}