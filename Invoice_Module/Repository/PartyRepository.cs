﻿using Invoice_Module.Data;
using Invoice_Module.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Module.Repository
{
    public class PartyRepository
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
                        id=party.id,
                        partyName = party.partyName
                    });
                }
            }
            return parties;
        }

        public async Task<bool> DeletePartyAsync(int id, PartyModel partyModel)
        {
            if(id == partyModel.id)
            {
                var party = new Party()
                {
                    id = id
                };
                _context.Party.Remove(party);
            }
            await _context.SaveChangesAsync();
            return true;
        }
        

        public async Task editParty(int id, PartyModel partyModel)
        {
            var newParty = new Party()
            {
                id = id,
                partyName = partyModel.partyName
            };
            _context.Party.Update(newParty);
            await _context.SaveChangesAsync();
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