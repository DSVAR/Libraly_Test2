using System.Data.Entity;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Libraly.BLL.Interfaces;
using Libraly.Data.Entities;
using Newtonsoft.Json;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Libraly.BLL.JsonPatterns
{
    public class DefaultJsonPattern:IDefaultJsonPattern
    {
        public async Task<string> DeffPatternAnswer(int status, string message,object item=null,dynamic errors=null)
        {
         return await Task.Run((() =>
            {
                var json = JsonConvert.SerializeObject(new {CodeStatus=status,
                    Message=message,
                    Item = item,
                    Errors=errors
                });
                return json;
            }));
           
        }
    }
}