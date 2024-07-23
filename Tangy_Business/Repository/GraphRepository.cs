using Tangy_Business.Repository.IRepository;

namespace Tangy_Business.Repository
{
    public class GraphRepository : IGraphRepository
    {
        private readonly IOrderRepository _or;
        public GraphRepository(IOrderRepository or)
        {
            _or = or;
        }

        public async Task<(double[] dailyRevenue, double[] weeklyRevenue, double[] monthlyRevenue, double[] yearlyRevenue)> SeriesWMY()
        {
            var today = DateTime.Today;
            var orders = await _or.GetAll();
            var dailyRevenue = new double[24];
            var weeklyRevenue = new Dictionary<DayOfWeek, double>();
            var monthlyRevenue = new double[DateTime.DaysInMonth(today.Year, today.Month)];
            var yearlyRevenue = new double[12];

            var currentWeekStart = today.AddDays(-(int)today.DayOfWeek);
            var currentMonthStart = new DateTime(today.Year, today.Month, 1);
            var currentYearStart = new DateTime(today.Year, 1, 1);

            var todayOrders = orders.Where(o => o.OrderHeader.OrderDate.Date == today).ToList();
            var weeklyOrders = orders.Where(o => o.OrderHeader.OrderDate >= currentWeekStart).ToList();
            var monthlyOrders = orders.Where(o => o.OrderHeader.OrderDate >= currentMonthStart).ToList();
            var yearlyOrders = orders.Where(o => o.OrderHeader.OrderDate >= currentYearStart).ToList();

            foreach (var order in todayOrders)
            {
                var hour = order.OrderHeader.OrderDate.Hour;
                dailyRevenue[hour] += order.OrderHeader.OrderTotal;
            }
            foreach (var order in weeklyOrders)
            {
                var dayOfWeek = order.OrderHeader.OrderDate.DayOfWeek;
                if (weeklyRevenue.ContainsKey(dayOfWeek))
                {
                    weeklyRevenue[dayOfWeek] += order.OrderHeader.OrderTotal;
                }
                else
                {
                    weeklyRevenue[dayOfWeek] = order.OrderHeader.OrderTotal;
                }
            }
            foreach (var order in monthlyOrders)
            {
                var day = order.OrderHeader.OrderDate.Day - 1;
                monthlyRevenue[day] += order.OrderHeader.OrderTotal;
            }
            foreach (var order in yearlyOrders)
            {
                var month = order.OrderHeader.OrderDate.Month - 1;
                yearlyRevenue[month] += order.OrderHeader.OrderTotal;
            }
            var weeklyRevenueArray = new double[7];
            foreach (var kvp in weeklyRevenue)
            {
                weeklyRevenueArray[(int)kvp.Key] = kvp.Value;
            }
            return (dailyRevenue, weeklyRevenueArray, monthlyRevenue, yearlyRevenue);
        }
    }
}
