using Microsoft.Extensions.Options;
using ServiceLayer.AuthentificationService;
using ServiceLayer.AuthentificationService.QueryObject;
using ServiceLayer.AuthorizeService.Abstract;
using ServiceLayer.UserService.Interface;

namespace ServiceLayer.AuthorizeService.Concrete
{
    public class LdapAuthentificationService : ILdapAuthentificationService
    {
        private readonly LdapConfig _ldapConfig;
        private IUserService _userRepository;

        public LdapAuthentificationService(IOptions<LdapConfig> config, IUserService userService)
        {
            _ldapConfig = config.Value;
            _userRepository = userService;
        }

        public bool CheckAuthenticate(AuthModel person)
        {
            var sd = person.GetUserFromAD(_ldapConfig, _userRepository);
            return false;
        }
    }
}
