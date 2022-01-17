using AutoMapper;
using HungryPizza.Api.AutoMapper;

namespace HungryPizza.Api.Tests.Model
{
    public class ModelFixture
    {
        private IMapper _mapper;

        public IMapper ObterMapper()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new PedidoMapper());
                    mc.AddProfile(new PizzaMapper());
                    mc.AddProfile(new UsuarioMapper());
                });

                var mapper = mappingConfig.CreateMapper();

                _mapper = mapper;
            }

            return _mapper;
        }
    }
}
