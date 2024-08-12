using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class Formdata
    {
        [Key]
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Monitor { get; set; }
        public required string TestUrl { get; set; }
        public required string RequestType { get; set; }
        public bool IsActive { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
