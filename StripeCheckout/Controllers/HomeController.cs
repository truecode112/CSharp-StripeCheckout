using Microsoft.AspNetCore.Mvc;
using StripeCheckout.Models;
using System.Diagnostics;
using Stripe;

namespace StripeCheckout.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string payment_intent, string payment_intent_client_secret, string redirect_status)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult createPaymentIntent()
        {
            var paymentIntentService = new PaymentIntentService();
            var paymentIntent = paymentIntentService.Create(new PaymentIntentCreateOptions
            {
                Amount = 995,
                Currency = "GBP",
                PaymentMethodTypes = new List<string> { "card", "paypal" },
                // In the latest version of the API, specifying the `automatic_payment_methods` parameter is optional because Stripe enables its functionality by default.
                /*AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                },*/
            });
            return Json(new { clientSecret = paymentIntent.ClientSecret });
        }

    }
}
