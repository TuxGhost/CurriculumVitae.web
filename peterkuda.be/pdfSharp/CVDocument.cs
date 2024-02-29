using System.Security.Cryptography.X509Certificates;
using MigraDoc.DocumentObjectModel;
using PdfSharp.Fonts;
using PdfSharp.Snippets.Font;
namespace CurriculumVitae.pdfSharp;

public class CVDocument
{
    public static Document CreateDocument()
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
        paragraph.AddFormattedText("Hello, World");

        return document;
    }
}
