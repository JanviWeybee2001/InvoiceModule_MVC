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
        private readonly IPartyRepository partyRepository = null;

        public PartyController(IPartyRepository _partyRepository)
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
        public IActionResult editParty(string partyName, bool isSuccess = false, bool isFailed = false, [FromRoute] int partyId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.IsFailed = isFailed;
            ViewBag.PartyName = partyName;
            return View();
        }

        [HttpPost("editParty/{id}/{partyName}")]
        public async Task<IActionResult> editParty([FromRoute] int id, PartyModel model)
        {
            if (ModelState.IsValid)
            {
                int ids = await partyRepository.editParty(id, model);
                if(ids == 0)
                    return RedirectToAction("editParty", new { isFailed = true });

                return RedirectToAction("editParty", new { isSuccess = true, partyName = model.partyName});
            }
            return RedirectToAction("allPartyItem");
        }
    }
}
