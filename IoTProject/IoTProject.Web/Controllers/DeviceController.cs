using IoTProject.Application.Services;
using IoTProject.Core.Domain;
using Microsoft.AspNetCore.Mvc;

namespace IoTProject.Web.Controllers
{
    public class DeviceController : Controller
    {
        private readonly DeviceService _DeviceService;

        public DeviceController(DeviceService deviceService)
        {
            _DeviceService = deviceService;
        }

        public IActionResult Index()
        {
            var devices = _DeviceService.GetAllDevices();
            return View(devices);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Device device)
        {
            if (ModelState.IsValid)
            {
                _DeviceService.AddDevice(device);
                return RedirectToAction("Index");
            }
            return View(device);
        }

    }
}
