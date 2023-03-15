using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AdminPanel.Web.Controllers.Base
{
    public class BaseController : Controller
    { 
        public DateTime CurrentDate = DateTime.Now.ToLocalTime();
    }
}

