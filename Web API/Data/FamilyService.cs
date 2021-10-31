using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
namespace FileData
{
    public class FamilyService : IFamilyService
    {
        private FileContext fileContext = new FileContext();
        public async Task AddFamily(Family family)
        {
            fileContext.Families.Add(family);
            fileContext.SaveChanges();
        }

        public async Task EditFamily(Family family)
        {
            Family family1 = fileContext.Families.FirstOrDefault(f => f.Id == family.Id);
            fileContext.Families.Remove(family1);
            fileContext.Families.Add(family);
            fileContext.SaveChanges();
        }

        public async Task<IList<Family>> GetFamilies()
        {
            return fileContext.Families;
        }

        public async Task RemoveFamily(int id)
        {
            Family f = fileContext.Families.FirstOrDefault(f => f.Id == id);
            fileContext.Families.Remove(f);
            fileContext.SaveChanges();
        }
    }
}