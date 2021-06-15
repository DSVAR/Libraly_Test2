using System.Threading.Tasks;

namespace Libraly.BLL.Interfaces
{
    public interface IUnitOfWork<T> where T : class
    {
        //CRUD для бд;
        Task Creat(T obj);
        Task Read(T obj);
        Task Update(T obj);
        Task Delete(T obj);
        void SaveChanges();
    }
}