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
        public static void AddShirt(Shirt shirt)
        {
            int maxId = shirts.Max(s => s.ShirtId);  
            shirt.ShirtId = maxId + 1;
            shirts.Add(shirt);
        }

        public static Shirt? GetShirtByProperties(string? brand, string? gender, string? color, int? size)
        {
                       return shirts.FirstOrDefault(x =>
                       !string.IsNullOrWhiteSpace(brand) && 
                       !string.IsNullOrWhiteSpace(x.Brand) &&
                       x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
                       !string.IsNullOrWhiteSpace(gender) &&
                       !string.IsNullOrWhiteSpace(x.Gender) &&
                       x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
                       !string.IsNullOrWhiteSpace(color) &&
                       !string.IsNullOrWhiteSpace(x.Color) &&
                       x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
                       size.HasValue &&
                       x.Size.HasValue &&
                       size.Value == x.Size.Value);
        }
    }
}
