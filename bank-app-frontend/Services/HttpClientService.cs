using bank;
using Models;

namespace Services
{
    public class HttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient) {
            this._httpClient = httpClient;
        }

        public async  Task<IEnumerable<Applicant>> GetApplicants()
        {
            return await _httpClient.GetFromJsonAsync<List<Applicant>>($"{AppRoutes.GET_ALL_APPLICANTS}");
        }

        public async Task UpdateApplicantStatus(long applicantId,AccountStatus accountStatus,long? tellerId)
        {
            var data = new { applicantId = applicantId, accountStatus= (int) accountStatus,tellerId= tellerId };
            await _httpClient.PutAsJsonAsync($"{AppRoutes.CHANGE_TELLER_STATUS}", data);
        }


    }
}
