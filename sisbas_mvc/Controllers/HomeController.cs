using sisbas_mvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace sisbas_mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Communication()
        {
            var lead = new Lead();
            return View(lead);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Communication([Bind(Include = "FirstName, LastName, Company, Message,Email, Phone")] Lead lead)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string ep = "sisemih@gmail.com";
                    string es = "Fifediojo179355.Asu";
                    try
                    {
                        SmtpClient client = new SmtpClient
                        {
                            Host = "smtp.gmail.com",
                            Port = 587,
                            EnableSsl = true,
                            DeliveryMethod = SmtpDeliveryMethod.Network,
                            Credentials = new System.Net.NetworkCredential(ep, es),
                            Timeout = 10000,
                        };
                        MailMessage mm = new MailMessage(lead.Email, ep, lead.Company, lead.Message);
                        client.Send(mm);
                        Response.Write("<script>alert('Mail Gönderildi')</script>");

                    }
                    catch (Exception e)
                    {
                        Response.Write("<script>alert('Mail Gönderilemedi')" + e.ToString() + "</script>");
                    }
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Eposta gönderimibşrısız oldu.");                
            }
            
            return View(lead);            
        }
        

    }
}