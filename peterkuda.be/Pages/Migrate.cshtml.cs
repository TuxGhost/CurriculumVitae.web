using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CurriculumVitae.Data;
using CurriculumVitae.Web.Data;
using Microsoft.AspNetCore.Authorization;


namespace CurriculumVitae.Web.Pages;

//[Authorize(Roles = "Admin")]
public class MigrationModel : PageModel
{
    private readonly dbMaintenance dbMaintenance;

    [BindProperty]
    public string MigrationMessage { get; set; } = string.Empty;
    public MigrationModel(dbMaintenance dbMaintenance)
    {
        this.dbMaintenance = dbMaintenance;
    }
    public void OnGet()
    {
    }
    public  async Task<IActionResult> OnPostMigrate()
    {         
        bool executed = await dbMaintenance.copyFromDatabase();
        if (executed)
        {
            MigrationMessage = "Migratie succesvol uitgevoerd.";
        }
        else
        {
            MigrationMessage = "Er is een fout opgetreden tijdens de migratie.";
        }   
        return Page();
    }
}
