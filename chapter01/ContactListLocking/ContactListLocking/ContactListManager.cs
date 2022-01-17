namespace ContactListLocking
{
    public class ContactListManager
    {
        private readonly List<Contact> contacts;
        private readonly ReaderWriterLockSlim contactLock = new ReaderWriterLockSlim();

        public ContactListManager(List<Contact> initialContacts)
        {
            contacts = initialContacts;
        }

        public void AddContact(Contact newContact)
        {
            try
            {
                contactLock.EnterWriteLock();
                contacts.Add(newContact);
            }
            finally
            {
                contactLock.ExitWriteLock();
            }
        }

        public Contact GetContactByPhoneNumber(string phoneNumber)
        {
            try
            {
                contactLock.EnterReadLock();
                return contacts.FirstOrDefault(x => x.PhoneNumber == phoneNumber);
            }
            finally
            {
                contactLock.ExitReadLock();
            }
        }
    }
}