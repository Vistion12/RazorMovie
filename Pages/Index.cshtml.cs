using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorMovie.Pages
{
    public class IndexModel : PageModel
    {
		
		public void OnGet()
		{
			ViewData["Title"] = "Главная страница";
			
		}
	}
}
