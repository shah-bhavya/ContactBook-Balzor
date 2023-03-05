using Microsoft.EntityFrameworkCore;

namespace ContactBook.Server.Data
{
    public class ContactService
    {
        #region Property
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ContactService> _logger;

        #endregion

        public ContactService(ApplicationDbContext context, ILogger<ContactService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Contact>> GetAll()
        {
            try
            {
                return await _context.Contacts.ToListAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError("ContactService - GetAll", ex);
            }
            return null;
        }

        public async Task<Contact> GetById(Guid Id)
        {
            try
            {
                return await _context.Contacts.Where(x => x.ContactId == Id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("ContactService - GetById", ex);
            }
            return null;
        }

        public async Task<bool> AddContact(Contact contact)
        {
            try
            {
                await _context.Contacts.AddAsync(contact);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("ContactService - AddContact", ex);
            }
            return false;
        }

        public async Task<bool> DeleteContact(Contact obj)
        {
            try
            {
                _context.Contacts.Remove(obj);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("ContactService - DeleteContact", ex);
            }
            return false;
        }

        public async Task<bool> UpdateContact(Contact contact)
        {
            try
            {
                _context.Contacts.Update(contact);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("ContactService - UpdateContact", ex);
            }
            return false;
        }

    }
}
