namespace Tangy_Business.Repository.IRepository
{
    public interface IGraphRepository
    {
        public Task<(double[] dailyRevenue, double[] weeklyRevenue, double[] monthlyRevenue, double[] yearlyRevenue)> SeriesWMY();
    }
}
