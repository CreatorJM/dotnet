using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.IO;

public class AlumnosModel : PageModel
{
    public DataTable Alumnos { get; set; }
    public AlumnosModel()
    {
        Alumnos = new DataTable();
    }

    public void OnGet()
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "./data/alumno.xml");

        DataSet ds = new DataSet();
        ds.ReadXml("./data/alumno.xml");
        Alumnos = ds.Tables[0];
    }
}
