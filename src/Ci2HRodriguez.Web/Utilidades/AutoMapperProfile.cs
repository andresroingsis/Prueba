using AutoMapper;
using Ci2HRodriguez.Aplicacion.Dtos;
using Ci2HRodriguez.Aplicacion.EntidadesDePersistencia;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ci2HRodriguez.Web.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TareaDto, Tarea>().ReverseMap();
        }
    }
}
