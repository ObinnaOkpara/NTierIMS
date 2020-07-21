using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NTierIMS.Core.Entities;
using NTierIMS.Core.Interfaces;

namespace NTierIMS.UI.Controllers
{
    [Authorize]
    public class RemovalController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IRemovalService removalService;
        private readonly IInventoryItemService inventoryItemService;
        private readonly IWarehouseService WarehouseService;

        public RemovalController(UserManager<Employee> userManager,
            IRemovalService removalService,
            IInventoryItemService inventoryItemService,
            IWarehouseService WarehouseService)
        {
            _userManager = userManager;
            this.removalService = removalService;
            this.inventoryItemService = inventoryItemService;
            this.WarehouseService = WarehouseService;
        }


        // GET: InventoryItems
        public async Task<IActionResult> Index()
        {
            return View(await removalService.ListAllAsync());
        }

        // GET: InventoryItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View(await removalService.GetByIdAsync(id.Value));
        }

        // GET: InventoryItems/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Warehouses = (await WarehouseService.ListAllAsync()).Select(m => new SelectListItem(m.Name, m.Id.ToString()));
            ViewBag.InventoryItems = (await inventoryItemService.ListAllAsync()).Select(m => new SelectListItem(m.Name, m.Id.ToString()));
            return View();
        }

        // POST: InventoryItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Removal removal)
        {
            try
            {
                removal.EmployeeId = (await GetCurrentUserAsync()).Id;

                var rtn = await removalService.AddAsync(removal);

                if (!rtn.StartsWith("Error"))
                {
                    return RedirectToAction(nameof(Index), new { msg = "Removal recorded successfully" });
                }
                else
                {
                    ViewBag.Warehouses = (await WarehouseService.ListAllAsync()).Select(m => new SelectListItem(m.Name, m.Id.ToString()));
                    ViewBag.InventoryItems = (await inventoryItemService.ListAllAsync()).Select(m => new SelectListItem(m.Name, m.Id.ToString()));
                    
                    ModelState.AddModelError(string.Empty, rtn);
                    return View(removal);
                }
            }
            catch
            {
                ViewBag.Warehouses = (await WarehouseService.ListAllAsync()).Select(m => new SelectListItem(m.Name, m.Id.ToString()));
                ViewBag.InventoryItems = (await inventoryItemService.ListAllAsync()).Select(m => new SelectListItem(m.Name, m.Id.ToString()));
                return View(removal);
            }

        }


        private Task<Employee> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
