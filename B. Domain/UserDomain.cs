using Data;

namespace Domain;

public class UserDomain: IUserDomain
{  
    private IUserData _userData;
    private IEncryptDomain _encryptDomain;
    private ITokenDomain _tokenDomain;
    public UserDomain(IUserData userData,IEncryptDomain encryptDomain,ITokenDomain tokenDomain)
    {
        _userData = userData;
        _encryptDomain = encryptDomain;
        _tokenDomain = tokenDomain;
    }

    public async Task<string> Login(User user)
    {
        var foundUser = await _userData.GetByUsername(user.Username);
        
        if (_encryptDomain.Ecnrypt(user.Password) == foundUser.Password)
        {
            return _tokenDomain.GenerateJwt(foundUser.Username);
        }

        throw new ArgumentException("Invalid username or password");
    }

    public async Task<int> Signup(User user)
    {       
        var foundUser = await _userData.GetByUsername(user.Username);

        if (foundUser != null) throw new ArgumentException("user already exits");
        
        user.Password = _encryptDomain.Ecnrypt(user.Password);
        return await _userData.Signup(user);
    }
}