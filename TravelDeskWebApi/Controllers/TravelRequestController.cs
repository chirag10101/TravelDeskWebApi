using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelDeskWebApi.IRepo;
using TravelDeskWebApi.Model;

namespace TravelDeskWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelRequestController : ControllerBase
    {
        ITravelRequestRepo _repo;

        public TravelRequestController(ITravelRequestRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("GetAllLocations")]
        public async Task<IActionResult> GetAllLocations()
        {
            var data = await _repo.GetAllLocations();
            if(data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpGet]
        [Route("GetAllProjects")]
        public async Task<IActionResult> GetAllProjects()
        {
            var data = await _repo.GetAllProjects();
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpGet]
        [Route("GetAllFlightTypes")]
        public async Task<IActionResult> GetAllFlightTypes()
        {
            var data = await _repo.GetAllFlightType();
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpGet]
        [Route("GetAllBookingTypes")]
        public async Task<IActionResult> Get()
        {
            var data = await _repo.GetAllBookingTypes();
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);    
            }
        }


        [HttpGet]
        [Route("GetAllMealTypes")]
        public async Task<IActionResult> GetAllMealTypes()
        {
            var data = await _repo.GetAllMealTypes();
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpGet]
        [Route("GetAllMealPreferences")]
        public async Task<IActionResult> GetAllMealPreferences()
        {
            var data = await _repo.GetAllMealPreferences();
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpPost]
        [Route("AddToRequest")]
        public async Task<IActionResult> AddToRequest(TravelRequest travelRequest)
        {
            if (travelRequest == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(await _repo.AddTravelRequest(travelRequest));
            }
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> UploadFiles( [FromForm] IFormFile? aadharCardFile, [FromForm] IFormFile? passportFile, [FromForm] IFormFile? visaFile)
        {
            try
            {

                // Handle file uploads
                if (aadharCardFile != null)
                {
                    // Save aadharFile in the current directory
                    var aadharFileName = Path.Combine(Directory.GetCurrentDirectory(),  "_" + "AadharCard");
                    using (var stream = new FileStream(aadharFileName, FileMode.Create))
                    {
                        await aadharCardFile.CopyToAsync(stream);
                    }
                    // travelRequest.AadharFilePath = aadharFileName;
                }

                if (passportFile != null)
                {
                    // Save passportFile in the current directory
                    var passportFileName = Path.Combine(Directory.GetCurrentDirectory(), "_" + "PassPort");
                    using (var stream = new FileStream(passportFileName, FileMode.Create))
                    {
                        await passportFile.CopyToAsync(stream);
                    }
                    //travelRequest.PassportFilePath = passportFileName;
                }

                if (visaFile != null)
                {
                    // Save passportFile in the current directory
                    var visaFileName = Path.Combine(Directory.GetCurrentDirectory(), "_" + "Visa");
                    using (var stream = new FileStream(visaFileName, FileMode.Create))
                    {
                        await visaFile.CopyToAsync(stream);
                    }
                    //travelRequest.PassportFilePath = passportFileName;
                }

                return Ok();
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetRequestsByUserId/{userId}")]
        public async Task<IActionResult> GetRequestsByUserId(int userId)
        {
            var data = await _repo.GetRequestsByUserId(userId);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }


        [HttpGet]
        [Route("GetHistoryRequestsByUserId/{userId}")]
        public async Task<IActionResult> GetHistoryViewRequestsById(int userId)
        {
            var data =  _repo.GetViewRequestsByUserId(userId);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpGet]
        [Route("GetTravelRequestByRequestId/{requestId}")]
        public async Task<IActionResult> GetTravelRequestByRequestId(int requestId)
        {
            var data = _repo.GetTravelRequestByRequestId(requestId);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }


        //[HttpPost]
        //[Route("AddToHotelBooking")]
        //public async Task<IActionResult> AddToHotelBooking(HotelBooking hotelBooking)
        //{
        //    if (hotelBooking == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(await _repo.AddHotelBooking(hotelBooking));
        //    }
        //}

        //[HttpPost]
        //[Route("AddToAirTicketBooking")]
        //public async Task<IActionResult> AddToAirTicketBooking(AirTicketBooking airTicketBooking)
        //{
        //    if (airTicketBooking == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(await _repo.AddAirTicketBooking(airTicketBooking));
        //    }
        //}
    }
}
