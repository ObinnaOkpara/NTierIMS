using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NTierIMS.Core.Entities;
using NTierIMS.Core.Interfaces;

namespace NTierIMS.UI.Controllers
{
    [Authorize]
    public class WarehouseController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IWarehouseService WarehouseService;
        public WarehouseController(UserManager<Employee> userManager, IWarehouseService WarehouseService)
        {
            _userManager = userManager;
            this.WarehouseService = WarehouseService;
        }

        public async Task<IActionResult> Index()
        {
            var allwarehouse = await WarehouseService.ListAllAsync();
            return View(allwarehouse);
        }

        // GET: TestController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var warehouse = await WarehouseService.GetByIdAsync(id);
            return View(warehouse);
        }

        // GET: TestController/Create
        public ActionResult Create()
        {
            return View( new Warehouse() );
        }

        // POST: TestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Warehouse warehouse)
        {
            try
            {
                warehouse.CreatedBy = (await GetCurrentUserAsync()).Id;

                await WarehouseService.AddAsync(warehouse);

                return RedirectToAction(nameof(Index), new { msg = "New warehouse added successfully" });
            }
            catch
            {
                return View(warehouse);
            }
        }

        private Task<Employee> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
