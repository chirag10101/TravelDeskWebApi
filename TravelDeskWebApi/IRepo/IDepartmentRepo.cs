using TravelDeskWebApi.Model;

namespace TravelDeskWebApi.IRepo
{
    public interface IDepartmentRepo
    {
        public List<Department> GetAllDepts();
    }
}
