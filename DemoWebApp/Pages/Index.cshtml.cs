using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace DemoWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DemoDbContext _context;

        public IEnumerable<Country> Countries { get; set; }
        public IEnumerable<Region> Regions { get; set; }

        public IndexModel(
            ILogger<IndexModel> logger, 
            DemoDbContext context
            )
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Countries = _context.Countries.ToList();
        }
    }
}
