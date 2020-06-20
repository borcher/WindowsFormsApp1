using AutoMapper;
using Newtonsoft.Json.Linq;

namespace ClassLibrary1.Mapper
{
    public class CustomMapper<Tdata>
    {
        private MapperConfiguration config;
        private IMapper _customMapper;
        public CustomMapper()
        {
            config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainProfile>();
            });
            CreateMapper();
        }
        private void CreateMapper()
        {
            _customMapper=config.CreateMapper();
        }

        public Tdata Map(JObject source)
        {
            return _customMapper.Map<JObject, Tdata>(source);
        }
    }
}
