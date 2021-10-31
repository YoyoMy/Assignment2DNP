using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
namespace FileData
{
    public interface IAdultService
    {
        public Task<IList<Adult>> GetAdultsAsync();
        public Task AddAdultsAsync(Adult adult);
        public Task UpdateAdultsAsync(Adult adult);
        public  Task DeleteAdultsAsync(int id);
    }
}