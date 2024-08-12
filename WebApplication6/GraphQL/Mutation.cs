using HotChocolate;
using Microsoft.EntityFrameworkCore;
using WebApplication6.Data;
using WebApplication6.Models;


namespace WebApplication6.GraphQL
{
    public class Mutation
    {
        public async Task<Formdata> AddOrUpdateFormDataAsync(
            [Service] AppdbContext dbContext,
            Formdata formData)
        {
            if (formData == null)
            {
                throw new ArgumentNullException(nameof(formData));
            }

            var existingRecord = await dbContext.Users
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

                dbContext.Users.Update(existingRecord);
            }
            else
            {
                // Add new record
                await dbContext.Users.AddAsync(formData);
            }

            await dbContext.SaveChangesAsync();

            return formData;
        }
    }
}
