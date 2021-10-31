using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Model;
namespace Data
{
    public interface IAdultService
    {
        public Task<IList<Adult>> GetAdultsAsync();
        public Task AddAdultAsync(Adult adult);
        public Task EditAdultAsync(Adult adult);
        public Task RemoveAdultAsync(Adult adult);
        public IList<Adult> Adults {get;set;}
    }
}