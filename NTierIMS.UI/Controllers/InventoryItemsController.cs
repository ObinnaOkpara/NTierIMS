using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NTierIMS.Core.Entities;
using NTierIMS.Core.Interfaces;

namespace NTierIMS.UI.Controllers
{
    [Authorize]
    public class InventoryItemsController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IInventoryItemService inventoryItemService;
        public InventoryItemsController(UserManager<Employee> userManager, IInventoryItemService inventoryItemService)
        {
            _userManager = userManager;
            this.inventoryItemService = inventoryItemService;
        }


        // GET: InventoryItems
        public async Task<IActionResult> Index()
        {
            return View(await inventoryItemService.ListAllAsync());
        }

        // GET: InventoryItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View( await inventoryItemService.GetByIdAsync(id.Value));
        }

        // GET: InventoryItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InventoryItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventoryItem inventoryItem)
        {
            try
            {
                inventoryItem.CreatedBy = (await GetCurrentUserAsync()).Id;

                await inventoryItemService.AddAsync(inventoryItem);

                return RedirectToAction(nameof(Index), new { msg = "New Item added successfully" });
            }
            catch
            {
                return View(inventoryItem);
            }

        }

        // GET: InventoryItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryItem = await inventoryItemService.GetByIdAsync(id.Value);
            if (inventoryItem == null)
            {
                return NotFound();
            }


            return View(inventoryItem);
        }

        // POST: InventoryItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InventoryItem inventoryItem)
        {
            if (id != inventoryItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var dbItem = await inventoryItemService.GetByIdAsync(id);
                    if (dbItem == null)
                    {
                        return NotFound();
                    }

                    dbItem.Description = inventoryItem.Description;
                    dbItem.Name = inventoryItem.Name;
                    dbItem.UnitOfMeasurement = inventoryItem.UnitOfMeasurement;

                    await inventoryItemService.UpdateAsync(dbItem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index), new { msg = "New Item added successfully" });
            }
            return View(inventoryItem);
        }

        private Task<Employee> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
