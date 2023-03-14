using DemoDISolution.Services.DemoScope;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoDISolution.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ITransientService transientService1;
        private readonly ITransientService transientService2;
        private readonly IScopedService scopedService1;
        private readonly IScopedService scopedService2;


        public IndexModel(
            ILogger<IndexModel> logger,
            ITransientService transientService1,
            ITransientService transientService2,
            IScopedService scopedService1,
            IScopedService scopedService2
        ) {
            _logger = logger;
            this.transientService1 = transientService1;
            this.transientService2 = transientService2;
            this.scopedService1 = scopedService1;
            this.scopedService2 = scopedService2;
        }

        public string message1 { get; set; }
        public string message2 { get; set; }
        public string message3 { get; set; }
        public string message4 { get; set; }
        public void OnGet()
        {
            message1 = "First Instance " + transientService1.GetID().ToString();
            message2 = "Second Instance " + transientService2.GetID().ToString();

            message3 = "First Instance " + scopedService1.GetID().ToString();
            message4 = "Second Instance " + scopedService2.GetID().ToString();
        }
    }
}