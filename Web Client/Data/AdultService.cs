using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;
using Model;
namespace Data
{
    public class AdultService : IAdultService
    {
        private HttpClientCommunicator httpClientCommunicator = new HttpClientCommunicator();
        private string url = "Adult";
        public IList<Adult> Adults {get;set;}

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            string result = await httpClientCommunicator.GetAsync(url);
            List<Adult> adults = JsonSerializer.Deserialize<List<Adult>>(result);
            Adults = adults;
            return adults;
        }
        public async Task AddAdultAsync(Adult adult)
        {
            await httpClientCommunicator.AddAsync(adult, url);
        }

        public async Task EditAdultAsync(Adult adult)
        {
            await httpClientCommunicator.PutAsync(adult, url+$"/{adult.Id}");
        }

        public async Task RemoveAdultAsync(Adult adult)
        {
            await httpClientCommunicator.DeleteAsync(url+$"/{adult.Id}");
        }
    }
}