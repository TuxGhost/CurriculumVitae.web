using CurriculumVitae.Data.Entities;
using CurriculumVitae.Model;

namespace CurriculumVitae.Services;

public interface ICvService
{
    public CvModel GetCv();
    public void SetProfiel(string  profiel);
    public void AddLanguage(Data.Entities.TaalModel taal);
    public void AddWorkExperience(Data.Entities.WerkErvaring werkervaring);
    public void AddComputerServices(Data.Entities.ComputerVaardigheid computerVaardigheid);
}
