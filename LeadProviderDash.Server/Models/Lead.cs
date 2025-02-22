using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace LeadProviderDash.Server.Models
{
    public class Lead
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty; 
        public string ZipCode { get; set; }
        public bool HasPermission { get; set; }
    }
}
