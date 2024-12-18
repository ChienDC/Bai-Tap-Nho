using Bai_Tap_Nho.Models;

namespace Bai_Tap_Nho.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                var users = new[]
                {
                    new User { Name = "John Doe", Email = "john@example.com" },
                    new User { Name = "Jane Smith", Email = "jane@example.com" }
                };

                var products = Enumerable.Range(1, 30)
                    .Select(i => new Product { Name = $"Product {i}", Price = i * 10 })
                    .ToList();

                context.Users.AddRange(users);
                context.Products.AddRange(products);
                context.SaveChanges();

                var random = new Random();
                foreach (var user in users)
                {
                    var orders = Enumerable.Range(1, 5)
                        .Select(i => new Order
                        {
                            OrderDate = DateTime.Now.AddDays(-i),
                            User = user
                        }).ToList();

                    context.Orders.AddRange(orders);
                    context.SaveChanges();

                    foreach (var order in orders)
                    {
                        var details = Enumerable.Range(1, 3)
                            .Select(i => new OrderDetail
                            {
                                Order = order,
                                Product = products[random.Next(products.Count)],
                                Quantity = random.Next(1, 5),
                                UnitPrice = products[random.Next(products.Count)].Price
                            }).ToList();

                        context.OrderDetails.AddRange(details);
                    }
                }

                context.SaveChanges();
            }
        }
    }
}