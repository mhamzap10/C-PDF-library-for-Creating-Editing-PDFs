using CreatePDF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CreatePDF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public FileResult CreatePDF(CreatePDFModel model)
        {
            var renderer = new ChromePdfRenderer();
            PdfDocument pdfDoc;
            if (model.isURL)
            {
                pdfDoc = renderer.RenderUrlAsPdf(model.Content);
            }
            else
            {
                pdfDoc = renderer.RenderHtmlAsPdf(model.Content);
            }
            byte[] fileBytes = pdfDoc.BinaryData;
            string fileName = "myPDF.pdf";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Pdf, fileName);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}