using BookCaféModelLib.model;

namespace BookCaféRest.Managers
{
    public interface IMerchantManager
    {
        // CRUD
        public Merchant Create(Merchant merchant);
        public List<Merchant> Read();
        public Merchant Update(int id, Merchant merchant);
        public Merchant Delete(int id);

        // Filtered search
        public List<Merchant> Read(string name);
        public List<Merchant> Read(int id);
    }
}
