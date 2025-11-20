using DGFWebApp.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace DGFWebApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        [HttpPost("bookingconfirmation")]
        public bool Post(BookingViewModel bookingViewModel)
        {
            try
            {
                string toAdminMessage = $"<h1>You got the booking inquiry</h1>" +
                  $"<p>Name: {bookingViewModel.FullName} </P>" +
                  $"<p>Email: {bookingViewModel.EmailAddress} </P>" +
                  $"<p>Phone Number: {bookingViewModel.MobileNumber} </P>";
                string toReciever = $"<h1>Thank you for the contacting us. We will get back to you shortally</h1>";
                sendEmail("rachanamanojverma@gmail.com", toAdminMessage);
                sendEmail(bookingViewModel.EmailAddress, toReciever);
            }
            catch (Exception ex) { 
            
            }
            return true;

        }

       void sendEmail(string toAddress, string messageBody)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("kirodiwalmanoj@gmail.com");
                mail.To.Add(toAddress);
                mail.Subject = "Booking Test Mail";
                mail.Body = messageBody; 
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("kirodiwalmanoj@gmail.com", "hmva sckq vrhp jxbz");

                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }

            }
        }
    }
}
