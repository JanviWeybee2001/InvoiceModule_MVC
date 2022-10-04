using Invoice_Module.Models;
using Invoice_Module.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice_Module.Controllers
{
    public class AssignPartyController : Controller
    {
        private readonly IAssignPartyRepository _assignPartyRepository = null;

        public AssignPartyController(IAssignPartyRepository assignPartyRepository)
        {
            _assignPartyRepository = assignPartyRepository;
        }


        [Route("~/assignParty")]
        public async Task<IActionResult> allAssignPartyItem()
        {
            var data = await _assignPartyRepository.GetAllAssignParty();
            return View(data);
        }

        public IActionResult addAssignParty(bool isSuccess = false, bool isFailed = false, int assignPartyId = 0, string assignParty = null, string assignProduct = null)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.IsFailed = isFailed;
            ViewBag.assignPartyId = assignPartyId;
            ViewBag.assignParty = assignParty;
            ViewBag.assignProduct = assignProduct;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> addAssignParty(AssignPartyModel assignPartyModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _assignPartyRepository.addAssignParty(assignPartyModel);

                if (id > 0)
                {
                    return RedirectToAction(nameof(addAssignParty), new { isSuccess = true, isFailed = false });
                }
                else
                {
                    return RedirectToAction(nameof(addAssignParty), new { isSuccess = false, isFailed = true });
                }
            }

            return View();
        }

        [HttpGet("EditAssignParty/{id}/{partyId}/{productId}")]
        public IActionResult editAssignParty(int partyId, int productId, bool isSuccess = false, bool isFailed = false, [FromRoute] int assignPartyId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.IsFailed = isFailed;
            return View();
        }

        [HttpPost("EditAssignParty/{id}/{partyId}/{productId}")]
        public async Task<IActionResult> editAssignParty([FromRoute] int id, AssignPartyModel assignPartyModel)
        {
            if (ModelState.IsValid)
            {
                int ids = await _assignPartyRepository.editAssignParty(id, assignPartyModel);
                if (ids == 0)
                    return RedirectToAction("editAssignParty", new { isFailed = true });

                return RedirectToAction("editAssignParty", new { isSuccess = true });
            }
            return RedirectToAction("allAssignPartyItem");
        }

        public async Task<IActionResult> deleteAssignParty(int id, AssignPartyModel assignPartyModel)
        {
            bool isDeleted = await _assignPartyRepository.deleteAssignParty(id, assignPartyModel);
            if (isDeleted)
            {
                return RedirectToAction("allAssignPartyItem");
            }
            return null;
        }

    }
}
