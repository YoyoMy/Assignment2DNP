using System.Collections.Generic;
using System.Threading.Tasks;
using Model;
namespace FileData
{
    public interface IFamilyService
    {
        public Task<IList<Family>> GetFamilies();
        public Task AddFamily(Family family);
        public Task EditFamily(Family family);
        public Task RemoveFamily(int id);
    }
}