using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using tracker.api.Model.DataTransferObj;
using tracker.api.Model.DataTransferObj.AuthDTOs;
using tracker.api.Repositories;

namespace tracker.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authcontroller : ControllerBase
    {

        public UserManager<IdentityUser> UserManager;
        private readonly InterfaceTokenRepository tokenrepos;

        public Authcontroller(UserManager<IdentityUser> userManager , InterfaceTokenRepository tokenrepo)
        {
            this.UserManager = userManager;
            this.tokenrepos = tokenrepo;
        }

        //post : /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterrequestDTO requestidentityuser)
        {
            var identityuser = new IdentityUser
            {
                UserName = requestidentityuser.Username,
                Email = requestidentityuser.Username
            };
           var identityResult = await UserManager.CreateAsync(identityuser, requestidentityuser.Password);

            if (identityResult.Succeeded)
            {
                identityResult = await UserManager.AddToRolesAsync(identityuser, requestidentityuser.Roles);
                if (identityResult.Succeeded)
                {
                    return Ok(identityResult);
                }
            }
            
                return BadRequest("try again");
        }

        //post: api/auth/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody]LoginRequestDTO Userdetails)
        {
           var user = await UserManager.FindByEmailAsync(Userdetails.userid);

            if (user == null)
            {
                return BadRequest("user doesnt exist");
            }

            var validUser = await UserManager.CheckPasswordAsync(user, Userdetails.password);
            if (validUser)
            {
                var roless = await UserManager.GetRolesAsync(user);

                if (roless != null)
                {
                    //return token
                   var jwttoken = tokenrepos.CreateJWT(user, roless.ToList());
                    var response = new LoginResponseDTO() 
                    {
                        JWTToken = jwttoken
                    };
                    return Ok(response);
                }
                return BadRequest("your not authenticated to access any resource");
            }
            return BadRequest("password incorrect");
        }
    }
}
