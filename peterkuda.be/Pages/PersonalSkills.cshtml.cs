using CurriculumVitae.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CurriculumVitae.Model;
namespace CurriculumVitae.Pages;

public class PersonalskillsModel : PageModel
{
    private readonly ILogger<PersonalskillsModel> logger;
    private readonly ICvService cvService = null!;
    [BindProperty]
    public List<PersonalSkill> SkillList { get; set; } = null!;
    
    public PersonalskillsModel(ILogger<PersonalskillsModel> logger, ICvService cvService)
    {
        this.logger = logger;
        this.cvService = cvService;
    }
    public void OnGet()
    {
        CvModel cv = cvService.GetCv();
        SkillList = cv.PersonalSkills.ToList();
    }
}
