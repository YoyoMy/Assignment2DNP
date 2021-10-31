using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
namespace FileData
{
    public class AdultService : IAdultService
    {
        private FileContext fileContext = new FileContext();

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            return fileContext.Adults;
        }
        public async Task AddAdultsAsync(Adult adult)
        {
            fileContext.Adults.Add(adult);
            fileContext.SaveChanges();
        }

        public async Task UpdateAdultsAsync(Adult adult)
        {
            Adult ad = fileContext.Adults.FirstOrDefault(ad => ad.Id == adult.Id);
            fileContext.Adults.Remove(ad);
            fileContext.Adults.Add(adult);
            fileContext.SaveChanges();
        }

        public async Task DeleteAdultsAsync(int id)
        {
            Adult ad  = fileContext.Adults.FirstOrDefault(d => d.Id == id);
            fileContext.Adults.Remove(ad);
            fileContext.SaveChanges();
        }
    }
}