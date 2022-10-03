using Invoice_Module.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Invoice_Module.Data;

namespace Invoice_Module.Repository
{
    public class AssignPartyRepository
    {

        private readonly InvoiceModuleContext _context = null;

        public AssignPartyRepository(InvoiceModuleContext context)
        {
            _context = context;
        }

        public async Task<List<AssignPartyModel>> GetAllAssignParty()
        {
            return await _context.AssignParty
                  .Select(assignParty => new AssignPartyModel()
                  {
                      id = assignParty.id,
                      partyId = assignParty.partyId,
                      productId = assignParty.productId,
                      Party = assignParty.Party,
                      Product = assignParty.Product
                  }).ToListAsync();
        }

        public async Task<int> addAssignParty(AssignPartyModel assignPartyModel)
        {
            var y = _context.AssignParty
                    .Where(x => x.partyId == assignPartyModel.partyId && x.productId == assignPartyModel.productId).FirstOrDefault();

            if (y == null)
            {
                var newAssignParty = new AssignParty()
                {
                    partyId = assignPartyModel.partyId,
                    productId = assignPartyModel.productId
                };
                await _context.AssignParty.AddAsync(newAssignParty);
                await _context.SaveChangesAsync();

                return newAssignParty.id; 
            }
            return 0;
        }

        public async Task<int> editAssignParty(int id, AssignPartyModel assignPartyModel)
        {
            var y = _context.AssignParty
                    .Where(x => x.partyId == assignPartyModel.partyId && x.productId == assignPartyModel.productId && x.id!=id).FirstOrDefault();

            if (y == null)
            {
                var assignParty = new AssignParty()
                {
                    id = id,
                    partyId = assignPartyModel.partyId,
                    productId = assignPartyModel.productId
                };
                _context.AssignParty.Update(assignParty);
                await _context.SaveChangesAsync();
                return assignParty.id;
            }
            return 0;
        }

        public async Task<bool> deleteAssignParty(int id, AssignPartyModel assignPartyModel)
        {
            if (id == assignPartyModel.id)
            {
                var assignParty = new AssignParty()
                {
                    id = id
                };
                _context.AssignParty.Remove(assignParty);
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<AssignPartyModel>> GetAllAssignPartyDistinct()
        {
            return await _context.AssignParty
                  .Select(assignParty => new AssignPartyModel()
                  {
                      partyId = assignParty.partyId,
                      Party = assignParty.Party,
                  }).Distinct().ToListAsync();
        }

    }
}


//public List<AssignPartyModel> AssignParty()
//{
//    return new List<AssignPartyModel>()
//            {
//                new AssignPartyModel(){ id=1, partyId=7, productId=4},
//                new AssignPartyModel(){ id=2, partyId=11, productId=12},
//                new AssignPartyModel(){ id=3, partyId=12, productId=2},
//                new AssignPartyModel(){ id=4, partyId=7, productId=10},
//                new AssignPartyModel(){ id=5, partyId=12, productId=3},
//                new AssignPartyModel(){ id=6, partyId=8, productId=1},
//                new AssignPartyModel(){ id=7, partyId=7, productId=8}
//            };
//}
