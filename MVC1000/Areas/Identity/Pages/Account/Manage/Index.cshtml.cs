using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVC1000.Data;

namespace MVC1000.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<MVC1000User> _userManager;
        private readonly SignInManager<MVC1000User> _signInManager;

        public IndexModel(
            UserManager<MVC1000User> userManager,
            SignInManager<MVC1000User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Firstname")]
            [DataType(DataType.Text)]
            public string Firstname { get; set; }
            [Required]
            [Display(Name = "Lastname")]
            [DataType(DataType.Text)]
            public string Lastname { get; set; }
            [Required]
            [Display(Name = "PostalCode")]
            [DataType(DataType.PostalCode)]
            public string PostalCode { get; set; }
            [Required]
            [Display(Name = "Streetname")]
            [DataType(DataType.Text)]
            public string StreetName { get; set; }
            [Required]
            [Display(Name = "House Number")]
            public int HouseNumber { get; set; }
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(MVC1000User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                PostalCode = user.PostalCode,
                StreetName = user.StreetName,
                HouseNumber = user.HouseNumber,
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }
            if (Input.Firstname != user.Firstname)
            {
                user.Firstname = Input.Firstname;
            }
            if (Input.Lastname != user.Lastname)
            {
                user.Lastname = Input.Lastname;
            }
            if (Input.PostalCode != user.PostalCode)
            {
                user.PostalCode = Input.PostalCode;
            }
            if (Input.StreetName != user.StreetName)
            {
                user.StreetName = Input.StreetName;
            }
            if (Input.HouseNumber != user.HouseNumber)
            {
                user.HouseNumber = Input.HouseNumber;
            }
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
