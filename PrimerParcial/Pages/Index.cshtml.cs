using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Finally.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    public DataSet dts;
    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
        dts = GetData();
    }

    public DataSet GetData(){
        dts = new DataSet();
        dts.ReadXml("./data/alumno.xml");
        return dts;
    }

    public void OnGet()
    {

    }
}
