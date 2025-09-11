using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Sant_George.Models.User;
using Sant_George.UnitOfWorks;


namespace Sant_George.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfirmEmailController: IEmailSender
    {
        public IUnitOfWorks _unit;

        private readonly UserManager<ApplicationUser> _userManager;
        public ConfirmEmailController(UserManager<ApplicationUser> userManager, IUnitOfWorks unit)
        {
            _unit = unit;
            _userManager = userManager;

        }
        [HttpGet]
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fmail = "markmagdy822000@gmail.com";
            var fpassword = "jhtu ucxl xiyn choz";

            var mailMessage = new MailMessage();
            mailMessage.Subject = subject;
            mailMessage.Body = htmlMessage;
            mailMessage.From = new MailAddress(fmail);
            mailMessage.To.Add(email);
            mailMessage.Body = $"<html><body>{htmlMessage}</body></html>";
            mailMessage.IsBodyHtml = true;
            var smtp = new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(fmail, fpassword),
                Port = 587,
            };

            smtp.Send(mailMessage);
        }
        
        [HttpGet("EmailConfirmed")]
        public async Task EmailConfirmed(string userId, string token) {
            //if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token)) 
            //    return BadRequest("User ID and token are required!");

            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            //if (user == null) 
            //    return BadRequest("No User Found");

            var result = await _userManager.ConfirmEmailAsync(user, token);
            //if (result.Succeeded)
            //    return Ok("Email Confirmed Successfully!");
            //return BadRequest("Email Confirmation Failed");
            
            //await _userManager.UpdateAsync(user);
            //await _unit.SaveChanges();

        }


    }
}
