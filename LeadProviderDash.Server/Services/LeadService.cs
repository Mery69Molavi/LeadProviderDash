using LeadProviderDash.Server.Models;
namespace LeadProviderDash.Server.Services
{
    public interface ILeadService
    {
        IEnumerable<Lead> GetLeads();
        void AddLead(Lead lead);

    }
    public class LeadService : ILeadService
    {
        // in memory db
        private List<Lead> _leads = new List<Lead>();
        public void AddLead(Lead lead)
        {
            if (!_leads.Any(x => x.FirstName == lead.FirstName && x.LastName == lead.LastName && x.PhoneNumber == lead.PhoneNumber))
            {
                _leads.Add(lead);
                NotifyLead(lead);
            }
            else
            {
                throw new Exception("Lead already exists.");
            }
        }

        public IEnumerable<Lead> GetLeads()
        {
           return _leads;
        }

        private void NotifyLead(Lead lead)
        {
            if (lead.HasPermission)
            {
                // notify the lead we will call them soon 
            }

        }
    }
}
