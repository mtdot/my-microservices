using AutoMapper;

namespace Services.DataMapper
{
    public class ObjectMapper
    {
        private static IMapper _mapper;
        private static ObjectMapper _instance;

        public static ObjectMapper Instance
        {
            get
            {
                if (_instance != null) return _instance;
                
                _instance = new ObjectMapper();
                return _instance;
            }
        }

        public void Initialize()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            _mapper = mapperConfig.CreateMapper();
        }
        
        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}