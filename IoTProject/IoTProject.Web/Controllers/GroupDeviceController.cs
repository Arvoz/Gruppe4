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
            IEnumerable<GroupDevice> groupDevice = _groupDeviceService.GetAllGroups();
            return View(groupDevice);
        }

        public IActionResult Details(string groupName)
        {
            var groupDevice = _groupDeviceService.GetGroupDeviceByName(groupName);
            if (groupDevice == null)
            {
                return NotFound();
            }
            return View(groupDevice);
        }

        [HttpGet]
        public IActionResult CreateOrUpdate(string? groupName)
        {
            GroupDevice groupDevice;

            // Hvis gruppenavn er null, oppretter vi en ny gruppe
            if (string.IsNullOrEmpty(groupName))
            {
                groupDevice = new GroupDevice(); // Ny tom gruppe
            }
            else
            {
                // Ellers henter vi eksisterende gruppe for redigering
                groupDevice = _groupDeviceService.GetGroupDeviceByName(groupName);
                if (groupDevice == null)
                {
                    return NotFound(); // Returner 404 hvis gruppen ikke finnes
                }
            }

            return View(groupDevice); // Returner viewet for å opprette eller oppdatere gruppen
        }

        [HttpPost]
        public IActionResult CreateOrUpdate(GroupDevice groupDevice)
        {
            if (ModelState.IsValid)
            {
                _groupDeviceService.CreateOrUpdateGroup(groupDevice);
                return RedirectToAction("Index");
            }
            return View(groupDevice);
        }

        public IActionResult Delete(string groupName)
        {
            _groupDeviceService.DeleteGroup(groupName);
            return RedirectToAction("Index");
        }
    }
}
