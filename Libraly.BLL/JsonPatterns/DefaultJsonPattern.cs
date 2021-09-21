using System.Data.Entity;
using System.Linq;
using System.Text.Json.Serialization;
using Libraly.Data.Entities;
using Newtonsoft.Json;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Libraly.BLL.JsonPatterns
{
    public class DefaultJsonPattern
    {
        public string DefJsnP(int status, string message,object item=null)
        {
            var items = JsonConvert.SerializeObject(item);
            var json = JsonConvert.SerializeObject(new {CodeStatus=status,
                Message=message,
                ItemCount=items.LongCount(),
                Item = items,
                objects=item
            });
            return json;
        }
    }
}