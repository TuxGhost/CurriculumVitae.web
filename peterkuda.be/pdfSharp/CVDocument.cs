using MigraDoc.DocumentObjectModel;
using PdfSharp.Fonts;
using PdfSharp.Snippets.Font;
using CurriculumVitae.Model;
using NuGet.Protocol;

namespace CurriculumVitae.pdfSharp;

public class CVDocument
{        
    public static Document CreateDocument(CvModel model)
    {        
        if (PdfSharp.Capabilities.Build.IsCoreBuild)    
            GlobalFontSettings.FontResolver = new FailsafeFontResolver();
        var document = new Document
        {
            Info =
            {
                Title = "CV Peter Kuda",
                Subject =  "test",
                Author = "Peter Kuda"
            }
        };        
        var style = document.Styles[StyleNames.Normal]!;
        style.Font.Name = "Arial";        
        var section = document.AddSection();
        var paragraph = section.AddParagraph();
        if(model.Profiel != null)
            paragraph.AddFormattedText(model.Profiel);
        paragraph.AddLineBreak();
        paragraph.AddLineBreak();
        var paragraphTalen = section.AddParagraph();
        SetTaalText(ref paragraphTalen,model.Talen.ToArray());
        var paragraphPersonalSkills = section.AddParagraph();
        SetPersonalSkillText(ref paragraphTalen, model.PersonalSkills.ToArray());
        var paragraphComputerskills = section.AddParagraph();
        SetComputervaardigheidText(ref paragraphComputerskills, model.ComputerVaardigheden.ToArray());
        var paragraphWerkervaring = section.AddParagraph();
        SetWerkervaringText(ref paragraphWerkervaring, model.WerkErvaringen.ToArray());
        return document;
    }    
    protected static void SetTaalText(ref Paragraph paragraph, TaalModel[] talen)
    {
        paragraph.AddFormattedText("Talen");
        paragraph.AddLineBreak();
        paragraph.AddFormattedText("_____");
        paragraph.AddLineBreak();
        foreach (var item in talen)
        {
            paragraph.AddFormattedText(item.Taal);
            paragraph.AddLineBreak();
        }
        paragraph.AddLineBreak();
    }
    protected static void SetPersonalSkillText(ref Paragraph paragraph, PersonalSkill[] vaardigheden)
    {
        paragraph.AddFormattedText("Persoonlijke vaardigheden");
        paragraph.AddLineBreak();
        paragraph.AddFormattedText("_____");
        paragraph.AddLineBreak();
        foreach (var item in vaardigheden.Where(f => f.Enabled == true))
        {
            paragraph.AddFormattedText(item.Name);
            paragraph.AddLineBreak();
        }
        paragraph.AddLineBreak();        
    }
    protected static void SetComputervaardigheidText(ref Paragraph paragraph, ComputerVaardigheid[] vaardigheden)
    {
        paragraph.AddFormattedText("Computervaardigheden");
        paragraph.AddLineBreak();
        paragraph.AddFormattedText("_____");
        paragraph.AddLineBreak();
        foreach (var item in vaardigheden)
        {
            paragraph.AddFormattedText(item.Omschrijving);
            paragraph.AddLineBreak();
        }
        paragraph.AddLineBreak();
    }
    protected static void SetWerkervaringText(ref Paragraph paragraph, WerkErvaring[] ervaring)
    {
        paragraph.AddFormattedText("Werkervaring");
        paragraph.AddLineBreak();
        paragraph.AddFormattedText("____________");
        paragraph.AddLineBreak();
        foreach (var item in ervaring)
        {
            if (item.DatumTot != null)
            {
                paragraph.AddFormattedText($"{item.Bedrijf} - {item.Functie} - {item.DatumVan.ToShortDateString()} - {item.DatumTot?.ToShortDateString()}");
            } else
            {
                paragraph.AddFormattedText($"{item.Bedrijf} - {item.Functie} - {item.DatumVan.ToShortDateString()} - ...");
            }
                paragraph.AddLineBreak();
            foreach(var taak in item.Taken)
            {
                paragraph.AddFormattedText($"\t{taak}");
                paragraph.AddLineBreak();
            }
        }
        paragraph.AddLineBreak();
    }
}
