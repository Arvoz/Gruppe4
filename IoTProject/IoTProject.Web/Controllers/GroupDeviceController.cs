using IoTProject.Application.Services;
using IoTProject.Core.Domain;
using IoTProject.Core.Ports;
using Microsoft.AspNetCore.Mvc;

namespace IoTProject.Web.Controllers
{
    public class GroupDeviceController : Controller
    {

        private readonly IGroupDeviceService _groupDeviceService;
        private readonly IDeviceRepository _deviceRepository;

        public GroupDeviceController(IGroupDeviceService groupDeviceService, IDeviceRepository deviceRepository)
        {
            _groupDeviceService = groupDeviceService;
            _deviceRepository = deviceRepository;
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
                foreach (var device in groupDevice.Devices)
                {
                    var devices = _deviceRepository.GetDeviceByName(device.DeviceName);
                    if (devices != null)
                    {
                        groupDevice.Devices.Add(devices);
                    }
                }
                _groupDeviceService.CreateOrUpdateGroup(groupDevice);

                return RedirectToAction("Index");
            }
            return View(groupDevice);
        }
        
    }
}
