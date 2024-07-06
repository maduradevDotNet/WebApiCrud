using AutoMapper;
using WebApiCrud.Model;

namespace WebApiCrud
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<EmployeeDto, Employee>();
                config.CreateMap<Employee, EmployeeDto>();
            });

            return mappingConfig;
        }
    }
}
