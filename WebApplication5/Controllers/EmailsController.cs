#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Route("api/mails")]
    [ApiController]
    public class EmailsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public EmailsController(ApplicationContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }
        private readonly IEmailSender _emailSender;

        
        // GET: api/Emails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Email>>> Getemails()
        {
            return await _context.emails.ToListAsync();
        }   

        // POST: api/Emails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<List<Email>> PostEmail([FromBody]Message message)
        {
            await _context.SaveChangesAsync();
            return _emailSender.SendEmail(message);
        }  
        private bool EmailExists(int id)
        {
            return _context.emails.Any(e => e.Id == id);
        }
    }
}
