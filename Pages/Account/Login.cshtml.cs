using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorMovie.Model;
using RazorMovie.ViewModel;


namespace RazorMovie.Pages.Account;

public class LoginModel(UserManager<User> userManager, SignInManager<User> signInManager ) : PageModel
{
    [BindProperty]
    public LoginViewModel? LoginViewModel { get; set; }
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid || LoginViewModel is null)
        {
            return Page();
        }
        var user = await userManager.FindByEmailAsync(LoginViewModel.EmailAddress);
        if (user is not  null)
        {
            var passwordCheck = await userManager.CheckPasswordAsync(user,LoginViewModel.Password);

            if (passwordCheck)
            {
                var result = await signInManager.PasswordSignInAsync(user,LoginViewModel.Password, false,false);

                if (result.Succeeded)
                {
                    return RedirectToPage("../Index");
                }
            }
        }

        TempData["Error"] = "вы ввели не верные данные ";
        return Page();
    }
}
