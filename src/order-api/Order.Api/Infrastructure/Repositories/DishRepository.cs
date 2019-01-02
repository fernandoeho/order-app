using Order.Api.Models;

namespace Order.Api.Infrastructure.Repositories
{
    public class DishRepository : Repository<Dish>, IDishRepository
    {
        public DishRepository(OrderContext context)
            : base(context) { }
    }
}