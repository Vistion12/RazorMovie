using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorMovie.Model;
using RazorMovie.ViewModel;

namespace RazorMovie.Pages.Account;

public class RegisterModel(UserManager<User> userManager, SignInManager<User> signInManager) : PageModel
{
	[BindProperty]
	public RegisterViewModel? RegisterViewModel { get; set; }
	public async Task<IActionResult> OnPostAsync()
	{
		if (!ModelState.IsValid || RegisterViewModel is null)
		{
			return Page();
		}
		var user = await userManager.FindByEmailAsync(RegisterViewModel.EmailAddress);

		if (user is not null)
		{
			TempData["Error"] = "этот емейл занят";
			return Page();
		}
		if (RegisterViewModel.ConfirmPassword != RegisterViewModel.Password)
		{
			TempData["Error"] = "пароли не совпадают";
			return Page();
		}

		var newUser = new User
		{
			Email = RegisterViewModel.EmailAddress,
			UserName = RegisterViewModel.EmailAddress,
		};

		var newUserResponse = await userManager.CreateAsync(newUser, RegisterViewModel.Password);
		if (newUserResponse.Succeeded) 
		{
			await userManager.AddToRoleAsync(newUser,UserRoles.User);
		}
		return RedirectToPage("../Index");


	}
}
