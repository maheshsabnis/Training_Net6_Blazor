using Microsoft.AspNetCore.Identity;
using Core_API.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Core_API.Repositories
{
    public class AuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthenticationService(UserManager<IdentityUser> user, SignInManager<IdentityUser> signIn, RoleManager<IdentityRole> role)
        {
            _userManager = user;
            _signInManager = signIn;
            _roleManager = role;
        }

        public async Task<bool> CreateUser(RegisterUser user)
        {
            bool isCreated = false;
            // Create anm Instance of IdentityUser based on RegisterUser
            var registerUser = new IdentityUser() { UserName = user.Email, Email = user.Email };
            // Create a User, The CreateAsync() method will Has the Password
            var result = await _userManager.CreateAsync(registerUser, user.Password);
            if (result.Succeeded)
            {
                isCreated = true;
            }
            return isCreated;
        }

        public async Task<AuthStatus> AuthUser(LoginUser user)
        {
            AuthStatus authStatus = new AuthStatus();
            LoginStatus loginStatus; 
            string token = string.Empty;
            string roleName = string.Empty;
            // 
            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, lockoutOnFailure: true);
            if (result.Succeeded)
            {
                // logic for generating token
                // 1. Read the UserId
                var authUser = await _userManager.FindByEmailAsync(user.UserName);
                // 2. Read the Role(s) for the Authenticated user
                // This is Role List for the Assigned to User
                var userRoles = await _userManager.GetRolesAsync(authUser);
                // if there are no role to the user then signout
                if (userRoles.Count == 0)
                {
                    await _signInManager.SignOutAsync();
                    // Throw Exception or Inform that the role is not available to the user
                    loginStatus = LoginStatus.NoRoleToUser;
                }
                else
                {
                    roleName = userRoles[0];
                    // generate the token
                    token = GenerateToken(authUser.Id, roleName);
                    loginStatus = LoginStatus.LoginSuccessful;
                }
            }
            else
            {
                loginStatus = LoginStatus.LoginFailed;
                token = string.Empty;
            }

            authStatus.LoginStatus = loginStatus;
            authStatus.Token = token;
            authStatus.Role=roleName;
            return authStatus;
        }
        /// <summary>
        /// CreatingRole
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public async Task<bool> CreateRole(ApplicationRole role)
        {
            bool isRoleCreated = false;
            IdentityRole roleIdentity = new IdentityRole()
            { 
               Name = role.Name,
               NormalizedName = role.NormalizedName
            };

            var result = await _roleManager.CreateAsync(roleIdentity);

            if (result.Succeeded)
            { 
              isRoleCreated = true;
            }
            return isRoleCreated;
        }

        public async Task<bool> AssignRoleToUser(UserRole userRole)
        {
            bool isRoleAssignedToUser = false;
            // 1. Get the Role Object based on The Role Name 
            var role = await _roleManager.FindByNameAsync(userRole.RoleName);
            // Finding the USer Object based on the USerNAme
            var registeredUser = await _userManager.FindByNameAsync(userRole.UserName);
            if (role != null)
            {
                // Assign Role to the user
                var res = await _userManager.AddToRoleAsync(registeredUser, role.Name);
                if (res.Succeeded)
                {
                    isRoleAssignedToUser=true;
                }
            }
            return isRoleAssignedToUser;
        }


        private string GenerateToken(string userId, string roleName)
        {

            // get the secret key from the byte generated Value
            var secertKey = Convert.FromBase64String("MNyFyANIvTjwFW2StGH73ez1Rf1jGQD0as9+NxE2cor4wwUapS6J3QCqDWQkxwzs8FW8pFpw/0R69aVD8qsWuA==");


            // set the Tokn Metadata
            var tokenDescriptor = new SecurityTokenDescriptor() 
            {
               Issuer = null,
               Audience = null,
               Subject = new ClaimsIdentity(new List<Claim>() { 
                  new Claim("userId", userId),
                  new Claim("role", roleName)
               }),
               Expires = DateTime.UtcNow.AddMinutes(20),
               IssuedAt = DateTime.UtcNow,
               NotBefore = DateTime.UtcNow,
               SigningCredentials= new SigningCredentials(new SymmetricSecurityKey(secertKey), SecurityAlgorithms.HmacSha256Signature)
            };

            // Generate the token based on the Metadata
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.CreateJwtSecurityToken(tokenDescriptor);
            string token = jwtHandler.WriteToken(jwtToken);
            return token;
        }
    }
}
