namespace TravelDeskWebApi.IRepo
{
    public interface ILoginRepo
    {
        public bool Login(string email, string password);
    }
}
