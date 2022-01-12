using Core_API.Models;
using Core_API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous] // Access Anonymously
    public class AuthController : ControllerBase
    {
        private readonly AuthenticationService _authService; 
        public AuthController(AuthenticationService auth)
        {
            _authService = auth;
        }

        [HttpPost("/createuser")]
        public async Task<ResponseStatus> RegisterNewUser(RegisterUser user)
        {
            ResponseStatus status = new ResponseStatus();
            if (ModelState.IsValid)
            {
                var result = await _authService.CreateUser(user);
                if (result)
                {
                    status.Message = $"User {user.Email} is Registered Successfully.";
                    status.Status = true;
                    return status;
                }
                else
                {
                    status.Message = $"User {user.Email} Creation Failed, it May be already available.";
                    status.Status = false;
                    return status;
                }
               
            }
            else 
            {
                status.Message = "UserName or Password Cannot be Empty";
                status.Status = false;
                return status;
            }
        }
        [HttpPost("/authuser")]
        public async Task<ResponseStatus> AuthenticateUser(LoginUser user)
        {
            ResponseStatus status = new ResponseStatus();
            if (ModelState.IsValid)
            {
                var res = await _authService.AuthUser(user);
                if (res.LoginStatus == LoginStatus.LoginFailed)
                { 
                    status = SetResponse(401, "UserName or Password not found", string.Empty, string.Empty);
                    return status;
                }
                if (res.LoginStatus == LoginStatus.NoRoleToUser)
                {
                    status = SetResponse(401, "UserName is not assugned to role", string.Empty, string.Empty);
                    return status;
                }
                if (res.LoginStatus == LoginStatus.LoginSuccessful)
                {
                    status = SetResponse(200, "Login Successful", res.Token, res.Role);
                    return status;
                }
                else
                {
                    status = SetResponse(500, "Internal Server Error", string.Empty, string.Empty);
                    return status;
                }
            }
            else
            {
                status.Message = "UserName or Password Cannot be Empty";
                return status;

            }
            
        }
        [HttpPost("/createrole")]
        public async Task<ResponseStatus> CreateNewRole(ApplicationRole role)
        {
            ResponseStatus status = new ResponseStatus();
            var res = await _authService.CreateRole(role);
            if (res)
            {
                status.Message = $"Role {role.Name} is Created Successfully.";
                status.Status = true;
                return status;
            }
            else
            {
                status.Message = $"Role {role.Name} Creation Filed.";
                status.Status = false;
                return status;
            }
            
        }

        [HttpPost("/assignusrtorole")]
        public async Task<ResponseStatus> AssignUserToRole(UserRole userRole)
        {
            ResponseStatus status = new ResponseStatus();
            var res = await _authService.AssignRoleToUser(userRole);
            if (res)
            {
                status.Message = $"Role  is Assigned Successfully.";
                status.Status = true;
                return status;
            }
            else
            {
                status.Message = $"Role  is Assigned Failed.";
                status.Status = false;
                return status;
            }

        }

        private ResponseStatus SetResponse(int code, string message, string token, string role)
        { 
             ResponseStatus response = new ResponseStatus() 
             {
               StatusCode = code,
               Message = message,
               Token = token,
               Role = role
             };

            return response;
        }
    }
}
