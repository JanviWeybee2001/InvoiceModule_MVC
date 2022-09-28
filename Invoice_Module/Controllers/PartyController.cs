using Invoice_Module.Models;
using Invoice_Module.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Module.Controllers
{
    public class PartyController : Controller
    {
        private readonly PartyRepository partyRepository = null;

        public PartyController(PartyRepository _partyRepository)
        {
            partyRepository = _partyRepository;
        }

        [Route("~/Party")]
        public async Task<IActionResult> allPartyItem()
        {
            var data = await partyRepository.GetAllParty();
            return View(data);
        }


        public ViewResult addParty(bool isSuccess = false, bool isFailed = false)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.IsFailed = isFailed;
            return View();
        }

        [HttpPost]
        public IActionResult addParty(PartyModel model)
        {
            if (ModelState.IsValid)
            {
                int id = partyRepository.addParty(model);

                if (id > 0)
                {
                    return RedirectToAction(nameof(addParty), new { isSuccess = true });
                }
                else
                {
                    return RedirectToAction(nameof(addParty), new { isFailed = true });
                }
            }
            return View(); // ok thxs
        }
        
        public async Task<IActionResult> DeleteParty(int id, PartyModel partyModel)
        {
            bool isDeleted = await partyRepository.DeletePartyAsync(id, partyModel);
            if (isDeleted)
            {
                return RedirectToAction("allPartyItem");
            }
            return null;
        }

        [HttpGet("editParty/{id}/{partyName}")]
        public IActionResult editParty(string partyName, bool isSuccess = false, [FromRoute] int partyId = 0)
        {
            return View();
        }

        [HttpPost("editParty/{id}/{partyName}")]
        public async Task<IActionResult> editParty([FromRoute] int id, PartyModel partyModel)
        {
            if (ModelState.IsValid)
            {
                await partyRepository.editParty(id, partyModel);
            }
            return RedirectToAction("allPartyItem");
        }
    }
}
