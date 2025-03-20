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
        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/alumnos.xml");

        DataSet ds = new DataSet();
        ds.ReadXml(path); // Leer XML en DataSet

        Alumnos = ds.Tables[0]; // Cargar la tabla de alumnos
    }
}
