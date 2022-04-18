// For Admin only
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using HMS_MVC.Models;
using HMS_MVC.Infrastructure;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HMS_MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRoomService _Room;
        private readonly ILogger<AdminController> _logger;
        //private readonly IBookingService<GuestController> _booking;

        #region "Constructor init"
        public AdminController(IRoomService room, ILogger<AdminController> logger)
        {
            _logger = logger;
            _logger.LogInformation("Room  called");
            _Room = room;
            //_booking = booking;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        

        public ActionResult GetRoomList()
        {
            _logger.LogInformation("GetRoomList endpoint starts");
            var roomobj = _Room.GetRoomList();
            try
            {
                if (roomobj == null) return NotFound();
                _logger.LogInformation("GetRoomList endpoint completed");
            }
            catch (Exception ex)
            {
                _logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
            //return Ok(student);
            return View(roomobj);
        }

        public IActionResult AdminMain()
        {
            return View();
        }

        #region "Add Room"
        [HttpPost]
        public ActionResult AddRoom(HMS_MVC.Models.RoomDetail roomobj)
        {
            //var room = await 
            _logger.LogInformation("-AddRoom endpoint start");
            try
            {
                _Room.AddRoomDetails(roomobj);
                _logger.LogInformation("-AddRoom end point end");
                return Ok("Room Added");

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occurred; Exception detail:" + ex.Message);
                _logger.LogError("Exception occurred; Exception detail:" + ex.InnerException);
                _logger.LogError("Exception occurred; Exception detail:" + ex);
                return BadRequest("Not Found");
            }
            //ViewBag.Message = string.Format("Room Added Successfully");
            //return View();
        }
        public IActionResult AddRoom()
        {
            return View();
        }
        #endregion


        public IActionResult UpdateRoom()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateRoom(HMS_MVC.Models.RoomDetail roomobj)
        {
            _logger.LogInformation("-UpdateRoom endpoint start");
            try
            {
                _Room.EditRoomDetails(roomobj);
                _logger.LogInformation("-UpdateRoom end point end");
                return Ok("Room Updated");  
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occurred; Exception detail:" + ex.Message);
                _logger.LogError("Exception occurred; Exception detail:" + ex.InnerException);
                _logger.LogError("Exception occurred; Exception detail:" + ex);
                return BadRequest("Not Found");
            }

        }

        public IActionResult SearchRoom()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SearchRoom(string status)
        {
            _logger.LogInformation("SearchRoom endpoint start");
            try
            {
                var Rooms = _Room.FindByStatus(status);
                if (Rooms != null && Rooms.Count > 0)
                {
                    return Ok(Rooms);
                }
                else
                {
                    return BadRequest("Not Found");
                }
                //_logger.LogInformation("SearchRoom endpoint end");

            }
            catch (Exception ex)
            {
                _logger.LogError("Exception occurred; Exception detail:" + ex.InnerException);
                return BadRequest("Not Found");
            }

        }
    }
}


