using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using TaskOne.Models;
using Microsoft.AspNetCore.Cors;


namespace TaskOne.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        public readonly TaskOneLenguageContext _dbContext;
        public UserController(TaskOneLenguageContext _context) {
            _dbContext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<TbUser> lista = new List<TbUser>();
            try
            {
                lista = _dbContext.TbUsers.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }
        [HttpGet]
        [Route("GetUser/{card_user}")]
        public IActionResult GetUser(string card_user)
        {
            try
            {
                TbUser user = _dbContext.TbUsers.FirstOrDefault(u => u.CardUser == card_user);
                if (user == null)
                {
                    return BadRequest("Usuario no encontrado");
                }

                return Ok(new { mensaje = "ok", response = user });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
        [HttpPost]
        [Route("SaveUser")]
        public IActionResult SaveUser([FromBody] TbUser user)
        {
            try
            {
                _dbContext.TbUsers.Add(user);
                _dbContext.SaveChanges();

                return Ok(new { mensaje = "Usuario guardado correctamente", response = user });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
        [HttpPut]
        [Route("UpdateUser/{idUser}")]
        public IActionResult UpdateUser(int idUser, [FromBody] TbUser updatedUser)
        {
            try
            {
                var user = _dbContext.TbUsers.Find(idUser);
                if (user == null)
                {
                    return NotFound("Usuario no encontrado");
                }

                // Actualizar solo los atributos que no sean nulos en updatedUser
              
                
                    user.NameCompleteUser = updatedUser.NameCompleteUser  is null ? user.NameCompleteUser : updatedUser.NameCompleteUser;
                    user.LastNameUser = updatedUser.LastNameUser is null ? user.LastNameUser : updatedUser.LastNameUser;
                    user.CardUser = updatedUser.CardUser is null ? user.CardUser : updatedUser.CardUser;
                    user.PhoneNumberUser = updatedUser.PhoneNumberUser is null ? user.PhoneNumberUser : updatedUser.PhoneNumberUser;
                    user.DirectionUser = updatedUser.DirectionUser is null ? user.DirectionUser: updatedUser.DirectionUser;

                _dbContext.Update(user);
                _dbContext.SaveChanges();

                return Ok(new { mensaje = "Usuario actualizado correctamente", response = user });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteUser/{idUser}")]
        public IActionResult DeleteUser(int idUser)
        {
            try
            {
                var user = _dbContext.TbUsers.Find(idUser);
                if (user == null)
                {
                    return NotFound("Usuario no encontrado");
                }

                _dbContext.TbUsers.Remove(user);
                _dbContext.SaveChanges();

                return Ok("Usuario eliminado correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }




    }
}
