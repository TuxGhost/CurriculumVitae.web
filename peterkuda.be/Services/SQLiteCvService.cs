using CurriculumVitae.Data;
using CurriculumVitae.Data.Entities;
using CurriculumVitae.Data.Migrations;
using CurriculumVitae.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CurriculumVitae.Services;

public class SQLiteCvService : ICvService
{
    private CvModel cvModels = null!;
    private CurriculumVitaeDbContext dbContext = null!;
    public SQLiteCvService(CurriculumVitaeDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public CvModel GetCv()
    {
        if (cvModels == null)
        {
            cvModels = new CvModel();
            Profiel? profiel = dbContext.Profielen.FirstOrDefault();
            if (profiel != null)
            {
                cvModels.Profiel = profiel.Beschrijving;
            }
            foreach (var taal in dbContext.Talen)
            {
                cvModels.Talen.Add(new Model.TaalModel { Taal = taal.Taal, Niveau = taal.Niveau });
            }
            foreach (var computervaardigheid in dbContext.computerVaardigheiden)
            {
                cvModels.ComputerVaardigheden.Add(new Model.ComputerVaardigheid
                {
                    Category = computervaardigheid.Category,
                    Niveau = computervaardigheid.Niveau,
                    Omschrijving = computervaardigheid.Omschrijving
                });
            }
            foreach (var werkervaring in dbContext.WerkErvaringen.Include(t => t.Taken))
            {
                List<string> taken = new();
                if (werkervaring.Taken != null)
                {
                    foreach (var taak in werkervaring.Taken)
                    {
                        taken.Add(taak.Bechrijving);
                    }
                }
                cvModels.WerkErvaringen.Add(new Model.WerkErvaring
                {
                    Id = werkervaring.Id,
                    Bedrijf = werkervaring.Bedrijf,
                    DatumVan = werkervaring.DatumVan,
                    DatumTot = werkervaring.DatumTot,
                    Functie = werkervaring.Functie,
                    Taken = taken
                });
            }
            foreach(var ervaring in dbContext.PersoonlijkeVaardigheden)
            {
                cvModels.PersoonlijkeVaardigheden.Add(ervaring.Name);
            }
        }
        cvModels.PersoonlijkeVaardigheden.Add("Analytisch");
        cvModels.PersoonlijkeVaardigheden.Add("Klantgerichtheid");
        cvModels.PersoonlijkeVaardigheden.Add("Leervermogen");
        cvModels.PersoonlijkeVaardigheden.Add("Onafhankelijk");
        return cvModels;
    }

    public void SetProfiel(string profiel)
    {
        if (profiel != null)
        {
            Profiel? profielObject = dbContext.Profielen.FirstOrDefault();
            if (profielObject == null)
            {
                profielObject = new Profiel { Beschrijving = profiel };                
                _ = dbContext.Profielen.Add(profielObject);
            }
            else
            {
                profielObject.Beschrijving = profiel;
                _ = dbContext.Profielen.Update(profielObject);
            }
            _ = dbContext.SaveChanges();
        }
    }
    public void AddLanguage(Data.Entities.TaalModel taal)
    {
        dbContext.Talen.Add(taal);
        dbContext.SaveChanges();
    }

    public void AddWorkExperience(Data.Entities.WerkErvaring werkervaring)
    {
        dbContext.WerkErvaringen.Add(werkervaring);
        dbContext.SaveChanges();
    }

    public void AddComputerServices(Data.Entities.ComputerVaardigheid computerVaardigheid)
    {
        dbContext.computerVaardigheiden.Add(computerVaardigheid);
        dbContext.SaveChanges();
    }

    public void DeleteLanguage(int id)
    {
        var language = dbContext.Talen.Find(id);
        if (language != null)
        {
            dbContext.Talen.Remove(language);
            dbContext.SaveChanges();
        }
    }

    public void DeleteWorkExpercience(int id)
    {
        var workexperience = dbContext.WerkErvaringen.Find(id);
        if (workexperience != null)
        {
            dbContext.WerkErvaringen.Remove(workexperience);
            dbContext.SaveChanges();
        }
    }

    public void DeleteComputerServices(int id)
    {
        var computerServices = dbContext.computerVaardigheiden.Find(id);
        if (computerServices != null)
        {
            dbContext.computerVaardigheiden.Remove(computerServices);
            dbContext.SaveChanges();
        }
    }

    public void AddWorkExperienceTask(int id, string taak)
    {
        var workexperience = dbContext.WerkErvaringen.Find(id);
        if (workexperience != null)
        {
            if (workexperience.Taken == null)
            {
                workexperience.Taken = new List<Taak>();
            }
            workexperience.Taken.Add(new Taak
            {
                Bechrijving = taak
            });
            dbContext.SaveChanges();
        }        
    }

    public void DeleteWorkExperienceTask(int workexperienceId, string taak)
    {
        var workexperience = dbContext.WerkErvaringen.Find(workexperienceId);
        if(workexperience != null)
        {
            var task = workexperience.Taken.Find(f => f.Bechrijving == taak);
            if(task != null)
            {
                workexperience.Taken.Remove(task);
                dbContext.SaveChanges();
            }            
        }
    }

    public void AddPersonalSkill(PersoonlijkeVaardigheid persoonlijkevaardigheid)
    {
        dbContext.PersoonlijkeVaardigheden.Add(persoonlijkevaardigheid);
        dbContext.SaveChanges() ;
    }

    public void DeletePersonalSkillTask(int id)
    {
        var vaardigheid = dbContext.PersoonlijkeVaardigheden.Find(id);
        if(vaardigheid != null)
        {
            dbContext.PersoonlijkeVaardigheden.Remove(vaardigheid);
            dbContext.SaveChanges() ;
        }
    }
}

