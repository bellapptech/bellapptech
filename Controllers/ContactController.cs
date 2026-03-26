using Microsoft.AspNetCore.Mvc;
using MailKit.Net.Smtp;
using MimeKit;

namespace BellAppTech.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public IActionResult Index(string product)
        {
            ViewBag.SelectedProduct = product;
            return View();
        }

        // POST: Contact/Send
        [HttpPost]
        public IActionResult Send(string name, string email, string phone, string product, string message)
        {
            try
            {
                var emailMessage = new MimeMessage();
                emailMessage.From.Add(new MailboxAddress(name, email));
                emailMessage.To.Add(new MailboxAddress("BellAppTech", "info@bellapptech.com")); // Your Outlook email
                emailMessage.Subject = $"Quote Request: {product}";
                emailMessage.Body = new TextPart("plain")
                {
                    Text = $"Name: {name}\nEmail: {email}\nPhone: {phone}\nProduct: {product}\nMessage: {message}"
                };

                using (var client = new SmtpClient())
                {
                    // Outlook SMTP
                    client.Connect("smtp.office365.com", 587, false);
                    client.Authenticate("info@bellapptech.com", "YOUR_OUTLOOK_PASSWORD");
                    client.Send(emailMessage);
                    client.Disconnect(true);
                }

                ViewBag.Success = "Your quote request has been sent!";
            }
            catch
            {
                ViewBag.Error = "Error sending email. Please try again later.";
            }

            return View("Index");
        }
    }
}