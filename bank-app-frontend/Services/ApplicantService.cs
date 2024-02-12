﻿using bank;
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
            string endPointUrl = AppRoutes.APPLICANTS;
            var applicants = await httpClientService.SendGetRequest< List<Applicant>>(endPointUrl, typeof(List<Applicant>));
            return applicants;
        }


        public async Task<Transaction> AddTransaction(TransactionExtended transaction)
        {
            string endPointUrl = AppRoutes.TRANSACTION;
            var responseTransaction = await httpClientService.PostDataRequest<TransactionExtended, Transaction>(endPointUrl, transaction, typeof(Transaction));
            return responseTransaction;
        }

        public async Task UpdateApplicantList(string ApplicateName, string Address, string CNIC, DateOnly DOB, string Email, int AccountType)
        {
            string endPointUrl = $"{AppRoutes.APPLICANTS}";
            await httpClientService.PostDataRequest<object, object>(endPointUrl, new { id = 0, applicateName = ApplicateName, address = Address, cnic = CNIC, emailAddress = Email, dob = DOB, accountType = AccountType, accountStatus = 0, tellerId = 5 }, typeof(object));
        }

        public async Task<Applicant> GetApplicantById(long applicantId)
        {
            string endPointUrl = $"{AppRoutes.APPLICANTS}/{applicantId}";
            return await httpClientService.SendGetRequest<Applicant>(endPointUrl, typeof(Applicant));
        }
    }
}
