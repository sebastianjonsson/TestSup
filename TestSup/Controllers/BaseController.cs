using Logic;
using System.Linq;
using System.Web.Mvc;


namespace TestSup.Controllers
{
    public class BaseController : Controller
    {
        protected DatabaseContext db = new DatabaseContext();
        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
        

    }
}