using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using WebApplication6.Data;
using WebApplication6.Models;


namespace WebApplication6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormdataController : ControllerBase

    {
        private readonly AppdbContext _dbContext;

        public FormdataController(AppdbContext appdbContext)
        {
            _dbContext = appdbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateFormData([FromBody] Formdata formData)
        {
            if (formData == null)
            {
                return BadRequest("FormData is null.");
            }

            var existingRecord = await _dbContext.Users
                .FirstOrDefaultAsync(f => f.Name == formData.Name);

            if (existingRecord != null)
            {
                // Update existing record
                existingRecord.Description = formData.Description;
                existingRecord.Monitor = formData.Monitor;
                existingRecord.TestUrl = formData.TestUrl;
                existingRecord.RequestType = formData.RequestType;
                existingRecord.IsActive = formData.IsActive;
                existingRecord.StartDate = formData.StartDate;
                existingRecord.EndDate = formData.EndDate;

                _dbContext.Users.Update(existingRecord);
            }
            else
            {
                // Add new record
                _dbContext.Users.Add(formData);
            }

            await _dbContext.SaveChangesAsync();

            return Ok(formData);
        }



    }
}
