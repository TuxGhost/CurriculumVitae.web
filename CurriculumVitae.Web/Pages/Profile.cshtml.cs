
using CurriculumVitae.common.Services;
using CurriculumVitaeRepository.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Frozen;
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
    public List<string> TaalLijst = new();
    public List<string> PersonalSkillList = new();
    public List<string> ComputerSkillList = new();

    public class CvUpdateDto
    {
        public Profiel? Profiel { get; set; }
        
        public List<Taal>? Talen { get; set; } = new();
        public List<Persoonlijkevaardigheid>? Persoonlijkevaardigheden { get; set; } = new();
        public List<Computervaardigheid>? Computerskills { get; set; } = new();
        public List<WerkErvaring>? Workexperiences { get; set; } = new();
        public List<string>? TalenDel { get; set; } = new();
        public List<string>? PersonalSkillsDel { get; set; } = new();
        public List<string>? ComputerSkillsDel { get; set; } = new();
        public List<string>? WorkexperiencesDel { get; set; } = new();
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
    public async Task<IActionResult> OnPostSave([FromBody] CvUpdateDto body, bool commit = false)    
    {

        //using var reader = new StreamReader(Request.Body);
        //var json = await reader.ReadToEndAsync();
        //var talen = data.talen;
        //var vaardigheden = data.Persoonlijkevaardigheden;
        /// TODO: Review Modelstate error Handling
        /*if (!ModelState.IsValid)
        {
            var errors = ModelState
            .Where(x => x.Value?.Errors.Count > 0)
            .SelectMany(x => x.Value!.Errors.Select(e => new
            {
                Field = x.Key,
                Message = e.ErrorMessage
            }));
            return BadRequest(errors);
        }*/
        Profiel? newProfile = null;
        if(body == null)
        {
            return BadRequest();
        }
        if(body.Profiel != null)
        {
            newProfile = await _service.UpdateProfileAsync(body.Profiel);
        } else
        {
            newProfile = await _service.AddProfileAsync(body.Profiel!);
        }                
        if (newProfile != null && body.Talen != null)
        {
            foreach(var t in body.Talen)
            {
                if (t.profiel == null)
                {
                    t.profiel = newProfile;
                    var l = await _service.AddLanguageAsync(newProfile,t);
                }
                else
                {
                    var l = await _service.UpdateLanguageAsync(newProfile, t);
                }
            }
        }
        if (newProfile != null && body.Persoonlijkevaardigheden != null)
        {
            foreach(var ps in body.Persoonlijkevaardigheden)
            {
                if(ps.Profiel == null)
                {
                    ps.Profiel = newProfile;
                    var s = await _service.AddPersonalSkill(newProfile, ps);
                } else
                {
                    var s = await _service.UpdatePersonalSkill(newProfile, ps);
                }
            }            
        }
        /// delete data
        /// 
        foreach(var d in body.PersonalSkillsDel??new List<string>())
        {
            var r = await _service.DeletePersonalSkill(d);
        }
        foreach (var d in body.TalenDel??new List<string>())
        {
            var r = await _service.DeleteLanguageAsync(d);
        }

        if (commit == true)
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
        // Profile dependend data
        Profiel = await _service.GetAsync(Id);
        if (Profiel != null)
        {
            Talen = await _service.GetLanguagesAsync(Profiel);
            Persoonlijkevaardigheden = await _service.GetPersonalskillsAsync(Profiel);
            Computervaardigheden = await _service.GetComputerskillsAsync(Profiel);
            Werkervaringen = await _service.GetWorkExperiencesAsync(Profiel);
        }
        // Profile independt data
        var talen = await _service.GetLanguagesAsync();
        foreach (Taal item in talen?.DistinctBy( d=> d.TaalOmschrijving) ?? new List<Taal>())
            TaalLijst.Add(item.TaalOmschrijving);
        var persoonlijkevaardigheden = await _service.GetPersonalskillsAsync();
        foreach (Persoonlijkevaardigheid item in persoonlijkevaardigheden.DistinctBy(d => d.Name) ?? new List<Persoonlijkevaardigheid>())
            PersonalSkillList.Add(item.Name);
        var computervaardigheden = await _service.GetComputerskillsAsync();
        
        
    }
}
