using bank;
using Models;

namespace Services
{
    public class ApplicantService
    {
        private readonly HttpClientService httpClientService;
        public ApplicantService(HttpClientService httpClientService) {
            this.httpClientService = httpClientService;
        }

        public async Task<List<Applicant>> GetApplicantsList()
        {
            string endPointUrl = AppRoutes.GET_ALL_APPLICANTS;
            var applicants = await httpClientService.SendGetRequest<List<Applicant>>(endPointUrl, typeof(List<Applicant>));
            return applicants;
        }


        public async Task<Transaction> AddTransaction(TransactionExtended transaction)
        {
            string endPointUrl = AppRoutes.TRANSACTION;
            var responseTransaction = await httpClientService.PostDataRequest<TransactionExtended, Transaction>(endPointUrl, transaction, typeof(Transaction));
            return responseTransaction;
        }
    }
}
