using Order.Api.Models;

namespace Order.Api.Infrastructure.Repositories
{
    public class MealRepository : Repository<Meal>, IMealRepository
    {
        public MealRepository(OrderContext context)
            : base(context) { }
    }
}