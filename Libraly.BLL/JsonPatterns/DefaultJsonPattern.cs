using System.Data.Entity;
using System.Text.Json.Serialization;
using Libraly.Data.Entities;
using Newtonsoft.Json;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace Libraly.BLL.JsonPatterns
{
    public class DefaultJsonPattern
    {
        public string DefJsnP(int status,object someObject, EntityState state,string description)
        {
            var json = JsonConvert.SerializeObject(new {Status=status,State= state,
                Description=description,
                Item=new {someObject}
            });
            return json;
        }
    }
}