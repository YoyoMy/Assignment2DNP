using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Model;
namespace Data
{
    public class FamilyService : IFamilyService
    {
        HttpClientCommunicator httpClientCommunicator = new HttpClientCommunicator();
        string url = "Family";

        public IList<Family> Families {get;set;}

        public async Task AddFamily(Family family)
        {
            await httpClientCommunicator.AddAsync(family, url);
        }

        public async Task EditFamily(Family family)
        {
            await httpClientCommunicator.PutAsync(family, url+$"/{family.Id}");
        }

        public async Task<IList<Family>> GetFamilies()
        {
            string result = await httpClientCommunicator.GetAsync(url);
            List<Family> families = JsonSerializer.Deserialize<List<Family>>(result);
            Families = families;
            return families;
        }

        public async Task RemoveFamily(Family family)
        {
            await httpClientCommunicator.DeleteAsync(url+$"/{family.Id}");
        }
    }
}