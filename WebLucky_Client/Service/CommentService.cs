using Newtonsoft.Json;
using System.Net.Http.Json;
using Tangy_Common;
using WebLucky_Client.Service.IService;

namespace WebLucky_Client.Service
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;
        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CommentDTO>> GetAll(int productId)
        {
            var response = await _httpClient.GetAsync($"{SD.PAGE_API}{SD.COMMENT_API}/getall/{productId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<CommentDTO>>(content);
            }
            return new List<CommentDTO>();
        }
        public async Task<CommentDTO> Create(CommentDTO commentDTO)
        {
            var response = await _httpClient.PostAsJsonAsync($"{SD.PAGE_API}{SD.COMMENT_API}/create", commentDTO);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CommentDTO>(content);
            }
            return null;
        }
        public async Task<CommentDTO> Update(CommentDTO commentDTO)
        {
            var response = await _httpClient.PostAsJsonAsync($"{SD.PAGE_API}{SD.COMMENT_API}/update", commentDTO);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CommentDTO>(content);
            }
            return new CommentDTO();
        }
        public async Task<bool> Delete(int commentId)
        {
            var response = await _httpClient.DeleteAsync($"{SD.PAGE_API}{SD.COMMENT_API}/delete/{commentId}");
            return response.IsSuccessStatusCode;
        }
    }
}
