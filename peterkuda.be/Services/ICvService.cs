using CurriculumVitae.Data.Entities;
using CurriculumVitae.Model;

namespace CurriculumVitae.Services;

public interface ICvService
{
    public CvModel GetCv();
    public void SetProfiel(string  profiel);
    public void AddLanguage(Data.Entities.TaalModel taal);
    public void AddWorkExperience(Data.Entities.WerkErvaring werkervaring);
    public void AddWorkExperienceTask(int id, string taak);
    public void AddComputerServices(Data.Entities.ComputerVaardigheid computerVaardigheid);
    public void DeleteLanguage(int id);
    public void DeleteWorkExpercience(int id);
    public void DeleteWorkExperienceTask(int workexperienceId, string taak);
    public void DeleteComputerServices(int id);
    public void AddPersonalSkill(Data.Entities.PersoonlijkeVaardigheid vaardigheid);
    public void DeletePersonalSkillTask(int id);    

}
