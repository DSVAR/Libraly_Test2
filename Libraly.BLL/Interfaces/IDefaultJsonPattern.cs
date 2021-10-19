using System.Threading.Tasks;

namespace Libraly.BLL.Interfaces
{
    public interface IDefaultJsonPattern
    {
        public Task<string> DeffPatternAnswer(int status, string message=null, object item = null, dynamic errors = null);
    }
}