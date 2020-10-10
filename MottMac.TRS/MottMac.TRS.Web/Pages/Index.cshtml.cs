using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MottMac.TRS.RoboCore;
using MottMac.TRS.RoboCore.Interfaces;

namespace MottMac.TRS.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IRobot _robot;

        public IndexModel(ILogger<IndexModel> logger, IRobot robot)
        {
            _logger = logger;
            _robot = robot;
        }
        [BindProperty]
        public string Command { get; set; }
        [TempData]
        public string Output { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Output = _robot.SendCommand(Command);
            return RedirectToPage("./Index");
        }
    }
}
