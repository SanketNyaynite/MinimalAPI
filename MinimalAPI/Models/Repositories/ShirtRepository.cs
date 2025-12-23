namespace MinimalAPI.Models.Repositories
{
    public static class ShirtRepository
    {
        private static List<Shirt> shirts = new List<Shirt>()
    {
        new Shirt { ShirtId = 1, Brand ="Goof", Color="Blue", Gender= "Men", Price = 30, Size = 10 },
        new Shirt { ShirtId = 2, Brand ="Swoof", Color="Black", Gender= "Men", Price = 35, Size = 12 },
        new Shirt { ShirtId = 3, Brand ="Loof", Color="Green", Gender= "Women", Price = 28, Size = 8 },
        new Shirt { ShirtId = 4, Brand ="Doof", Color="Red", Gender= "Women", Price = 30, Size = 9 },
    };

        public static List<Shirt> GetShirts()
        {
            return shirts;
        }

        public static bool ShirtExist(int id)  //this method is not called in the current code but can be used in future to check if shirt exists
        {
            return shirts.Any(s => s.ShirtId == id);
        }

        public static Shirt? GetShirtById(int id)
        {
            return shirts.FirstOrDefault(s => s.ShirtId == id);
        }
    }
}
