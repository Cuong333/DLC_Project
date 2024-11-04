using DLC_Project.Models; // Thay đổi cho phù hợp với namespace của bạn
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DLC_Project.Controllers
{
    public class CustomerController : Controller
    {
        private readonly DemoDlcContext db;

        // Inject DbContext vào Controller
        public CustomerController(DemoDlcContext context)
        {
            db = context;
        }
    
    }
}
