using IoTProject.Application.Services;
using IoTProject.Core.Domain;
using IoTProject.Core.Ports;
using Microsoft.AspNetCore.Mvc;

namespace IoTProject.Web.Controllers
{
    public class GroupDeviceController : Controller
    {

        private readonly IGroupDeviceService _groupDeviceService;

        public GroupDeviceController(IGroupDeviceService groupDeviceService)
        {
            _groupDeviceService = groupDeviceService;
        }

        public IActionResult Index()
        {
            var groupDevices = _groupDeviceService.GetAllGroups();
            return View(groupDevices);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GroupDevice groupDevice)
        {
            if (ModelState.IsValid)
            {
                _groupDeviceService.CreateOrUpdateGroup(groupDevice);
                return RedirectToAction("Index");
            }
            return View(groupDevice);
        }


    }
}
