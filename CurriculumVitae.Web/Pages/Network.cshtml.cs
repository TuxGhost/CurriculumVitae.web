using CurriculumVitae.common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CurriculumVitae.Web.Pages;

public class NetworkModel : PageModel
{
    private readonly INetworkService service;
    [BindProperty]
    public bool IsAddingMode { get; set; }
    [BindProperty]
    public bool Editable { get; set; } = false;    
    [BindProperty]
    public List<CurriculumVitae.common.DTOs.NetworkDto> Networks { get; set; } = new();
    [BindProperty]
    public uint IdChange { get; set; }

    public NetworkModel(INetworkService s)
    {
        service = s;
    }
    public async Task<IActionResult> OnGet()
    {
        Networks = await service.GetAll();
        return Page();
    }
    public IActionResult OnPostAddrequest()
    {
        IsAddingMode = true;
        return Page();
    }
    public async Task<IActionResult> OnPostAdd(CurriculumVitae.common.DTOs.NetworkDto network)
    {
        await service.Add(network);
        return RedirectToAction("Get");
    }
    public async Task<IActionResult> OnPostEdit(uint id)
    {
        IdChange = id;
        Networks = await service.GetAll();
        return Page();
    }
    public async Task<IActionResult> OnPostDelete(uint id)
    {
        await service.Delete(id);
        Networks = await service.GetAll();
        return Page();  
    }
    public async Task<IActionResult> OnPostUpdate(CurriculumVitae.common.DTOs.NetworkDto network)
    {    
        await service.Update(network);
        Networks = await service.GetAll();
        return Page();
    }
}
