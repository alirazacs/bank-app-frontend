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
            string endPointUrl = AppRoutes.GET_ALL_APPLICANTS;
            var applicants = await httpClientService.SendGetRequest<List<Applicant>, List<Applicant>>(endPointUrl);
            return applicants;
        }

        public async Task UpdateApplicantList(string ApplicateName, string Address, string CNIC, String DOB, string Email, long? TellerId, AccountType AccountType, AccountStatus AccountStatus)
        {
            string endPointUrl = $"{AppRoutes.POST_APPLICANT}";
            await httpClientService.PostDataRequest<object, object>(endPointUrl, new { id = 0, applicateName = ApplicateName, address = Address, cnic = CNIC, email = Email, dob = DOB, accountType = 0, accountStatus = 0, tellerId = TellerId });
        }
    }
}
