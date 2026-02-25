using CurriculumVitae.Data;
using CurriculumVitaeRepository;
using CurriculumVitaeRepository.Entities;
using Microsoft.EntityFrameworkCore;
namespace CurriculumVitae.Web.Data;

public class dbMaintenance
{
    private CurriculumVitaeDbContext _dbContextV1;
    private CVDbContext _dbContextV2;
    
    public dbMaintenance(CVDbContext cVDbContextV2,CurriculumVitaeDbContext cvDbContextV1) 
    {             
        _dbContextV1 = cvDbContextV1;
        _dbContextV2 = cVDbContextV2;
    }
    /// <summary>
    /// Copy database from dutch tablenames to english (new version)
    ///     Entities are created in another class.
    /// </summary>
    /// <param name="dbContextSource"></param>
    /// <returns></returns>
    public async Task<bool> copyFromDatabase()
    {
        await copyProfiles();
        return  true;
    }
    /// <summary>
    /// Copy profiels and include ALL info from other tables into this profile -> after old tables are not used any more this should be improved.
    /// </summary>
    /// <returns></returns>
    private async Task<int> copyProfiles()
    {
        List<int> newIds = new List<int>();
        foreach (var item in _dbContextV1.Profielen)
        {
            Profiel newProfile = new Profiel
            {
                Beschrijving = item.Beschrijving,
                Enabled = item.Enabled,
            };
            _dbContextV2.Profielen.Add(newProfile);                
        }
        await _dbContextV2.SaveChangesAsync();            
        //newIds = _dbContextV2.ChangeTracker.Entries<Profiel>().Select(e => (int)e.Entity.Id).ToList();
        List<Profiel> newProfiles = _dbContextV2.ChangeTracker.Entries<Profiel>().Select(e => e.Entity).ToList();
        foreach (var item in newProfiles)
        {
            await copyTalenToProfile(item);
            await copyPersonalSkilsToProfile(item);
            await copyComputerSkilsToProfile(item);
            await copyWorkExperienceToProfile(item);
        }
        return newIds.Count();
    }
    /// <summary>
    /// copy talen to profile  
    /// </summary>
    /// <param name="profile"></param>
    /// <returns></returns>
    private async Task<int> copyTalenToProfile(Profiel profile)
    {
        foreach(var item in _dbContextV1.Talen)
        {
            Taal newTaal = new Taal
            {
                TaalOmschrijving = item.Taal,
                Niveau = item.Niveau,
                profiel = profile
            };
            _dbContextV2.Talen.Add(newTaal);
        }
        await _dbContextV2.SaveChangesAsync();
        return _dbContextV2.ChangeTracker.Entries<Taal>().Select(e => (int)e.Entity.Id).Count();

    }
    /// <summary>
    /// copy personal skills
    /// </summary>
    /// <param name="profile"></param>
    /// <returns></returns>
    private async Task<int> copyPersonalSkilsToProfile(Profiel profile)
    {
        foreach (var item in _dbContextV1.PersoonlijkeVaardigheden)
        {
            Persoonlijkevaardigheid newSkill = new Persoonlijkevaardigheid
            {
                 Name  = item.Name,
                Enabled = item.Enabled,
                Profiel = profile
            };
            _dbContextV2.Persoonlijkevaardigheden.Add(newSkill);
        }
        await _dbContextV2.SaveChangesAsync();
        return _dbContextV2.ChangeTracker.Entries<Persoonlijkevaardigheid>().Select(e => (int)e.Entity.Id).Count();

    }
    /// <summary>
    /// copy computerskills to profile
    /// </summary>
    /// <param name="profile"></param>
    /// <returns></returns>
    private async Task<int> copyComputerSkilsToProfile(Profiel profile)
    {
        foreach (var item in _dbContextV1.computerVaardigheiden)
        {
           Computervaardigheid newSkill = new Computervaardigheid
            {
                 Omschrijving  = item.Omschrijving,
                 Niveau = item.Niveau,
                 Category = item.Category,
                 Profiel = profile                  
            };
            _dbContextV2.ComputerVaardigheden.Add(newSkill);
        }
        await _dbContextV2.SaveChangesAsync();
        return _dbContextV2.ChangeTracker.Entries<Computervaardigheid>().Select(e => (int)e.Entity.Id).Count();

    }
    private async Task<int> copyWorkExperienceToProfile(Profiel profile)
    {
        foreach (CurriculumVitae.Data.Entities.WerkErvaring item in _dbContextV1.WerkErvaringen.Include(w => w.Taken))
        {            
            List<CurriculumVitaeRepository.Entities.Taak> taken = new List<CurriculumVitaeRepository.Entities.Taak>();
            foreach (var taak in item.Taken)
            {
                CurriculumVitaeRepository.Entities.Taak newTaak = new CurriculumVitaeRepository.Entities.Taak
                {
                    Beschrijving = taak.Bechrijving,
                    WerkErvaring = null! // this will be set when the werkervaring is created, otherwise we have a circular reference
                };
                taken.Add(newTaak);
            }
            CurriculumVitaeRepository.Entities.WerkErvaring newSkill = new CurriculumVitaeRepository.Entities.WerkErvaring
            {                
                 profiel = profile,
                 Bedrijf = item.Bedrijf,
                 DatumVan = item.DatumVan,                    
                 DatumTot = item.DatumTot, // if null in old database, it will be null in new database, if not null it will be copied. check real type in database.
                Functie = item.Functie,
                Taken = taken
            };
            _dbContextV2.WerkErvaringen.Add(newSkill);
        }
        await _dbContextV2.SaveChangesAsync();
        IEnumerable<CurriculumVitaeRepository.Entities.WerkErvaring> newList =  _dbContextV2.ChangeTracker.Entries<CurriculumVitaeRepository.Entities.WerkErvaring>().Select(e => e.Entity);
        return newList.Count();
    }    
}
