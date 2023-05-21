using ATR.API.Data;
using ATR.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ATR.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {
        private readonly WebAppMVCLesson1DbContext dbContext;

        public RoomController(WebAppMVCLesson1DbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [HttpGet]
        public async Task<IEnumerable<Room>> Get()
        {
            return await dbContext.Rooms.ToListAsync();
        }

        [HttpGet("GetRoomById")]
        public async Task<Room> Get(int id)
        {
            return await dbContext.Rooms.FindAsync(id);
        }


        [HttpPost]

        public async Task<IActionResult> Post([FromBody] Room room)
        {
            try
            {
                throw new Exception("test arr");
                dbContext.Rooms.Add(room); 
                dbContext.SaveChanges();
                
                return Ok(room);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut]

        public async Task<IActionResult> Put([FromForm] Room room)
        {
            var findRoom = dbContext.Rooms.Find(room.RoomId);
            if (findRoom == null)
            {
                return BadRequest("Такой команты не существует");
            }
            else
                try
                {
                    findRoom.RoomNumber = room.RoomNumber;
                    findRoom.MainPicturePath = room.MainPicturePath;
                    findRoom.CreateDate = room.CreateDate;
                    findRoom.Description = room.Description;
                    findRoom.Price = room.Price;
                    findRoom.CategoryId = room.CategoryId;
                    findRoom.CreateUser = room.CreateUser;
                    dbContext.SaveChanges();
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);

                }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int RoomId)
        {
            try
            {
                var findRoom = dbContext.Rooms.Find(RoomId);
                dbContext.Rooms.Remove(findRoom);
                dbContext.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
