using Tangy_Common;
using Newtonsoft.Json;
using WebLucky_Client.Service.IService;

namespace WebLucky_Client.Service
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;
        private string BaseServerUrl;
        public OrderService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            BaseServerUrl = _configuration.GetSection("BaseServerUrl").Value;
        }

        public async Task<OrderDTO> Get(int orderHeaderId)
        {
            var response = await _httpClient.GetAsync($"{SD.ORDER_API}/{orderHeaderId}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                var order = JsonConvert.DeserializeObject<OrderDTO>(content);
                return order;
            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorModelDTO>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }
        public async Task<IEnumerable<OrderDTO>> GetAll(string? userId)
        {
            var response = await _httpClient.GetAsync(SD.ORDER_API);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var orders = JsonConvert.DeserializeObject<IEnumerable<OrderDTO>>(content);
                return orders;
            }
            return new List<OrderDTO>();
        }
    }
}