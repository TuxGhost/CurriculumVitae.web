
using CurriculumVitae.common.Services;
using CurriculumVitaeRepository.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CurriculumVitae.Web.Pages;

public class ProfileModel : PageModel
{
    private readonly IDbCurriculumVitaeService _service;
    [BindProperty]
    public uint Id { get; set; }
    [BindProperty]    
    public Profiel? Profiel { get; set; }
    [BindProperty]
    public IEnumerable<Taal>? Talen { get; set; }
    [BindProperty]
    public IEnumerable<Persoonlijkevaardigheid>? Persoonlijkevaardigheden { get; set; }
    [BindProperty]
    public IEnumerable<Computervaardigheid>? Computervaardigheden { get; set; }
    [BindProperty]
    public IEnumerable<WerkErvaring>? Werkervaringen { get; set; }
    [BindProperty]
    public bool IsEditing { get; set; } = false;
    [BindProperty]
    public string Message { get; set; } = string.Empty;
    [BindProperty]
    public string SelectLanguage { get; set; } = string.Empty;

    public class CvUpdateDto
    {
        public List<Taal> talen { get; set; } = new();
        public List<Persoonlijkevaardigheid> Persoonlijkevaardigheden { get; set; } = new();
    }
    public ProfileModel(IDbCurriculumVitaeService service)
    {
        _service = service;
    }
    /// <summary>
    /// Stander GET
    /// </summary>
    /// <param name="Id"></param>
    public async Task<IActionResult> OnGetAsync(uint Id)
    {
        this.Id = Id;
        LoadData();
        return Page();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="edit"></param>
    /// <returns></returns>
    public async Task<IActionResult> OnPostEditAsync(bool edit=false)
    {
        IsEditing = true;
        return Page();        
    }
    public async Task<IActionResult> OnPostSave([FromBody] CvUpdateDto data, bool commit = false)
    //public async Task<IActionResult> OnPostSave(bool commit = false)
    {
        //using var reader = new StreamReader(Request.Body);
        //var json = await reader.ReadToEndAsync();
        //var talen = data.talen;
        //var vaardigheden = data.Persoonlijkevaardigheden;
        if(SelectLanguage != string.Empty)
        {
            Talen.Append(new Taal { 
                profiel = this.Profiel,
                TaalOmschrijving = SelectLanguage,                  
                Niveau = "Beginner"
            });
        }
        if(commit == true)
        {
            
        }
        IsEditing = false;
        return Page();
    }
    public async Task<IActionResult> OnPostCancel()
    {        
        LoadData();
        return Page();        
    }
    /// <summary>
    /// Load data on start or on cancel update
    /// </summary>
    public async void LoadData()
    {
        IsEditing = false;
        Profiel = await _service.GetAsync(Id);
        if (Profiel != null)
        {
            Talen = await _service.GetLanguagesAsync();
            Persoonlijkevaardigheden = await _service.GetPersonalskillsAsync();
            Computervaardigheden = await _service.GetComputerskillsAsync();
            Werkervaringen = await _service.GetWorkExperiencesAsync(Profiel);
        }
    }
}
