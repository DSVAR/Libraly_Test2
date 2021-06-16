using System.Threading.Tasks;

namespace Libraly.BLL.Interfaces
{
    public interface IUnitOfWorkBD
    {
        void SaveChanges();
    }
}