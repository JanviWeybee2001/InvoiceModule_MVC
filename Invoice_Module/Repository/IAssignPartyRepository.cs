using Invoice_Module.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invoice_Module.Repository
{
    public interface IAssignPartyRepository
    {
        Task<int> addAssignParty(AssignPartyModel assignPartyModel);
        Task<bool> deleteAssignParty(int id, AssignPartyModel assignPartyModel);
        Task<int> editAssignParty(int id, AssignPartyModel assignPartyModel);
        Task<List<AssignPartyModel>> GetAllAssignParty();
        Task<List<AssignPartyModel>> GetAllAssignPartyDistinct();
    }
}