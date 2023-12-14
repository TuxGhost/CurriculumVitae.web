using CurriculumVitae.Model;

namespace CurriculumVitae.Services;

public interface ICvService
{
    public CvModel GetCv();
    public void SetProfiel(string  profiel);
}
