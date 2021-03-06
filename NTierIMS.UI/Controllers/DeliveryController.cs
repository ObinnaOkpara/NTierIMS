﻿using System;
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
    public class DeliveryController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly IDeliveryService deliveryService;
        private readonly IInventoryItemService inventoryItemService;
        private readonly IWarehouseService WarehouseService;

        public DeliveryController(UserManager<Employee> userManager, 
            IDeliveryService deliveryService,
            IInventoryItemService inventoryItemService,
            IWarehouseService WarehouseService)
        {
            _userManager = userManager;
            this.deliveryService = deliveryService;
            this.inventoryItemService = inventoryItemService;
            this.WarehouseService = WarehouseService;
        }


        // GET: InventoryItems
        public async Task<IActionResult> Index()
        {
            return View(await deliveryService.ListAllAsync());
        }

        // GET: InventoryItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View(await deliveryService.GetByIdAsync(id.Value));
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
        public async Task<IActionResult> Create(Delivery delivery)
        {
            try
            {
                delivery.EmployeeId = (await GetCurrentUserAsync()).Id;

                await deliveryService.AddAsync(delivery);

                return RedirectToAction(nameof(Index), new { msg = "Delivery recorded successfully" });
            }
            catch
            {
                ViewBag.Warehouses = (await WarehouseService.ListAllAsync()).Select(m => new SelectListItem(m.Name, m.Id.ToString()));
                ViewBag.InventoryItems = (await inventoryItemService.ListAllAsync()).Select(m => new SelectListItem(m.Name, m.Id.ToString()));
                return View(delivery);
            }

        }


        private Task<Employee> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
