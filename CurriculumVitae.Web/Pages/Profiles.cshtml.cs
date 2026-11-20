using CurriculumVitae.common.DTOs;
using CurriculumVitae.common.Services;
using CurriculumVitaeRepository.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CurriculumVitae.Web.Pages;

public class ProfilesModel : PageModel
{
    private readonly ICurriculumVitaeServices curriculumVitaeServices;
    [BindProperty]
    public List<ProfielDto> Profiles { get; private set; } = new List<ProfielDto>();
    [BindProperty]
    public int EnabledCount { get; private set; } = 0;
    public ProfilesModel(ICurriculumVitaeServices curriculumVitaeServices)
    {
        this.curriculumVitaeServices = curriculumVitaeServices;            
    }
    public async Task OnGet()
    {
        IEnumerable<Profiel> iProfiles;
        iProfiles = await curriculumVitaeServices.GetAllProfiles();
        
        foreach(var profile in iProfiles)
        {
            Profiles.Add(new ProfielDto
            {
                Id = profile.Id,
                Beschrijving = profile.Beschrijving,
                Enabled = profile.Enabled
            });
        };
        EnabledCount = Profiles.Where(p => p.Enabled == true).Count();
    }    
    public async Task<IActionResult> OnPostEdit(Profiel profiel)
    {
        if(ModelState.IsValid == false)
        {
            return Page();
        }
        await curriculumVitaeServices.UpdateProfile(profiel);
        return RedirectToPage();        
    }
    public async Task<IActionResult> OnPostDelete(uint id)
    {
        Profiel profiel= new Profiel { Id = (uint)id ,Beschrijving = "" };
        await curriculumVitaeServices.DeleteProfile(profiel);
        return RedirectToPage();
    }
    // TODO : Refactor EnableProfile to use the profile id instead of the entire profile object
    public async Task<IActionResult> OnPostEnable(Profiel profiel)
    {
        if(ModelState.IsValid == false)
        {
            return Page();
        }
        profiel.Enabled = true;
        await curriculumVitaeServices.UpdateProfile(profiel);
        return RedirectToPage();
    }
    // TODO : Refactor DisableProfile to use the profile id instead of the entire profile object
    public async Task<IActionResult> OnPostDisable(Profiel profiel)
    {
        if (ModelState.IsValid == false)
        {
            return Page();
        }
        profiel.Enabled = false;
        await curriculumVitaeServices.UpdateProfile(profiel);
        return RedirectToPage();
    }
}
