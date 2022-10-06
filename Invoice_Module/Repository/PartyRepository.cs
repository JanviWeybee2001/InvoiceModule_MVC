using Invoice_Module.Data;
using Invoice_Module.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Module.Repository
{
    public class PartyRepository : IPartyRepository
    {
        private readonly InvoiceModuleContext _context = null;

        public PartyRepository(InvoiceModuleContext context)
        {
            _context = context;
        }

        public int addParty(PartyModel model)
        {
            var y = _context.Party
                    .Where(x => x.partyName == model.partyName).FirstOrDefault();

            if (y == null)
            {
                var newParty = new Party()
                {
                    partyName = model.partyName
                };

                _context.Party.Add(newParty);
                _context.SaveChanges();

                return newParty.id;
            }
            return 0;
        }

        public async Task<List<PartyModel>> GetAllParty()
        {
            var parties = new List<PartyModel>();
            var allparties = await _context.Party.ToListAsync();
            if (allparties?.Any() == true)
            {
                foreach (var party in allparties)
                {
                    parties.Add(new PartyModel()
                    {
                        id = party.id,
                        partyName = party.partyName
                    });
                }
            }
            return parties;
        }

        public async Task<bool> DeletePartyAsync(int id, PartyModel partyModel)
        {
            var check = _context.AssignParty.Where(x => x.partyId == partyModel.id).FirstOrDefault();
            var checkInvoice = _context.Invoice.Where(x => x.PartyId == id).ToList();
            if (check==null)
            {
                if (id == partyModel.id)
                {
                    var party = new Party()
                    {
                        id = id
                    };
                    _context.Party.Remove(party);
                }
                if (checkInvoice != null)
                {
                    _context.Invoice.RemoveRange(checkInvoice);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
            
        }


        public async Task<int> editParty(int id, PartyModel partyModel)
        {
            var y = _context.Party
                    .Where(x => x.partyName == partyModel.partyName && x.id != id).FirstOrDefault();

            if (y == null)
            {
                var newParty = new Party()
                {
                    id = id,
                    partyName = partyModel.partyName
                };
                _context.Party.Update(newParty);
                await _context.SaveChangesAsync();
                return id;
            }
            return 0;
        }
    }
}


//public List<PartyModel> party()
//{
//    return new List<PartyModel>()
//            {
//                new PartyModel(){ id=1, partyName="Toyoto"},
//                new PartyModel(){ id=2, partyName="Ford"},
//                new PartyModel(){ id=3, partyName="BMW"},
//                new PartyModel(){ id=4, partyName="Nestle"},
//                new PartyModel(){ id=5, partyName="Cadbury"}
//            };
//}