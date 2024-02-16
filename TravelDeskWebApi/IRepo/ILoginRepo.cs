using TravelDeskWebApi.Context;
using TravelDeskWebApi.Model;

namespace TravelDeskWebApi.IRepo
{
    public interface ILoginRepo
    {
        public User Login(LoginUser loginuser);
    }
}
