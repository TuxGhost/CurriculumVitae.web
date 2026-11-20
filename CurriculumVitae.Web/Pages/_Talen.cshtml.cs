

using CurriculumVitae.Model;
using CurriculumVitae.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CurriculumVitae.Web.Pages;

public class TalenModel : PageModel
{
    // Private variables
    //private ICvService _cvService;
    // public variables
    //[BindProperty]
    public List<TaalModel> Talen { get; set; } = new List<TaalModel>();
    //public TalenModel(ICvService service)
    //{
    //    _cvService = service;
    //}
    public void OnGet()
    {
        
    }
    public void OnPost()
    {
       
    }
    
    public IActionResult  OnPostRemoveItem(string item)
    {
        return Page();
    }
}
