using Infra.Context;

namespace UseFul.ClientApi.Dtos
{
    public class BaseDto<TB> where TB : class, new()
    {
        private static TB _instance;
        private AuthContext _context;

        public static TB Instance => _instance ?? (_instance = new TB());

        public AuthContext Context
        {
            get
            {
                if (_context != null)
                {
                    return _context;
                }
                _context = new AuthContext();
                return _context;
            }
        }        
    }
}
