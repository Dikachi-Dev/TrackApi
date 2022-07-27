using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackAPI.Data;
using TrackAPI.Helper;
using TrackAPI.Models;

namespace TrackAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly TrackAPIContext _context;
       

        public ItemsController(TrackAPIContext context)
        {
            _context = context;
        }

        //GET: api/Items
       [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItem()
        {
            return await _context.Item.ToListAsync();
        }

        //Get : item by trackid
        [HttpGet("{searchstring}/item")]
        public async Task<ActionResult<Item>> Track(string searchstring)
        {

            var track = await _context.Item.FirstOrDefaultAsync(x => x.TrackID == searchstring);
            return track;
           
        }



        

        // GET: api/item/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
        {
            var item = await _context.Item.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/item/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            
            

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/item
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {

            var generator = new Track();

            string it = generator.Trackid();
            if (TrackIDExists(it))
            {
               
                it = generator.Trackid();
            }
            item.TrackID = it;

            _context.Item.Add(item);

            //// sed Mail
            //string Message = "Your order with tracking id :  " + item.TrackID + "\n " + "Has been created and will arrive at: " + "\n" + item.DeliveryDate;
            //string Email = item.Email;
            //// Credentials
            //var credentials = new NetworkCredential("Sender mail m", "Sender password ");

            //// Mail message
            //var mail = new MailMessage()
            //{
            //    From = new MailAddress("Sender mail", " Sender name"),
            //    Subject = " Mail title   ",
            //    Body = Message
            //};

            //mail.IsBodyHtml = true;
            //mail.To.Add(new MailAddress(Email));

            //// Smtp client
            //var client = new SmtpClient()
            //{
            //    Port = 25,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Host = "Smtp server address",
            //    EnableSsl = false,
            //    Credentials = credentials
            //};

            //client.Send(mail); // Send the mail

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.Id }, item);
        }

        // DELETE: api/item/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Item.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.Id == id);
        }
        private bool TrackIDExists(string it )
        {
            return _context.Item.Any(e => e.TrackID == it);
        }
    }
}
