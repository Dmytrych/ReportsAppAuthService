using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ReportsAppAuthService.Controllers
{
    [Route("[controller]")]
    public class FacultyInfoApiController : Controller
    {
        private readonly List<DormitoryInfoModel> Data = new List<DormitoryInfoModel>
        {
            new DormitoryInfoModel()
            {
                Id = 1,
                Address = "Pushkinska 41",
                CreationYear = 2002,
                Number = "1"
            },
            new DormitoryInfoModel()
            {
                Id = 2,
                Address = "Pushkinska 12",
                CreationYear = 1992,
                Number = "2"
            },
            new DormitoryInfoModel()
            {
                Id = 3,
                Address = "Pushkinska 44",
                CreationYear = 1950,
                Number = "3"
            }
        };

        
        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll(
            [FromQuery(Name = "id")] int? id,
            [FromQuery(Name = "address")] string address,
            [FromQuery(Name = "creationYear")] int? creationYear,
            [FromQuery(Name = "number")] string number)
        {
            var dormitories = Data;
            
            Console.WriteLine("Request came");
            if (id.HasValue)
            {
                dormitories = dormitories.Where(x => x.Id == id).ToList();
            }
            
            if (!string.IsNullOrEmpty(address))
            {
                dormitories = dormitories.Where(x => x.Address == address).ToList();
            }
            
            if (creationYear.HasValue)
            {
                dormitories = dormitories.Where(x => x.CreationYear == creationYear).ToList();
            }
            
            if (!string.IsNullOrEmpty(number))
            {
                dormitories = dormitories.Where(x => x.Number == number).ToList();
            }

            return Ok(dormitories);
        }
    }
}