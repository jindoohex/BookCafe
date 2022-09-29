using BookCaféModelLib.model;

namespace BookCaféRest.Managers
{
    public class MerchantManager : IMerchantManager
    {

        private static List<Merchant> data = new List<Merchant>()
        {
            new Merchant(1, "Alex", "banan@banan.dk", "12345678"),
            new Merchant(2, "Jeppe", "banan@banan.dk", "12345678"),
            new Merchant(3, "Peppe", "banan@banan.dk", "12345678"),
            new Merchant(4, "Meppe", "banan@banan.dk", "12345678")
        };
        public Merchant Create(Merchant merchant)
        {
            throw new NotImplementedException();
        }

        public Merchant Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Merchant> Read()
        {
            throw new NotImplementedException();
        }

        public List<Merchant> Read(string name)
        {
            if (name is null)
            {
                return new List<Merchant>();
            }
            return data.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();
        }

        public List<Merchant> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Merchant Update(int id, Merchant merchant)
        {
            throw new NotImplementedException();
        }
    }
}
