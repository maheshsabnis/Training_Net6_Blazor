using Microsoft.AspNetCore.Identity;
using Core_API.Models;
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

        public async Task<bool> AuthUser(LoginUser user)
        {
            bool isLogin = false;
            // 
            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, lockoutOnFailure: true);
            if (result.Succeeded)
            { 
                isLogin = true;
            }
            return isLogin;
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
    }
}
