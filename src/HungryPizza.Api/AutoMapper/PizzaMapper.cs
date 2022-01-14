using AutoMapper;
using HungryPizza.Api.Model;
using HungryPizza.Domain;

namespace HungryPizza.Api.AutoMapper
{
    public class PizzaMapper : Profile
    {
        public PizzaMapper()
        {
            CreateMap<Pizza, PizzaModel>();
        }
    }
}
