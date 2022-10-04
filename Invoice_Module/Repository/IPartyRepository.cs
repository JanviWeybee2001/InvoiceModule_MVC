using Invoice_Module.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Invoice_Module.Repository
{
    public interface IPartyRepository
    {
        int addParty(PartyModel model);
        Task<bool> DeletePartyAsync(int id, PartyModel partyModel);
        Task<int> editParty(int id, PartyModel partyModel);
        Task<List<PartyModel>> GetAllParty();
    }
}