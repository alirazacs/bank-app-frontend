using bank;
using Blazored.LocalStorage;
using Models;
using Newtonsoft.Json;


namespace Services
{
    public class UserService
    {
        private HttpClientService httpClientService;
        private ILocalStorageService localStorageService;
        public UserService(HttpClientService httpClientService, ILocalStorageService localStorageService)
        {
            this.httpClientService = httpClientService;
            this.localStorageService = localStorageService;
        }

        public async Task<T> LoginUser<T>(User user) where T: class
        {

            T userDetails = await httpClientService.PostDataRequest<User, T>(AppRoutes.LOGIN_URL, user, typeof(T));
            if(userDetails != null)
            {
                await localStorageService.SetItemAsStringAsync("userDetails", JsonConvert.SerializeObject(userDetails));
                await localStorageService.SetItemAsStringAsync("userType", user.UserType.ToString());
            }
            return userDetails;
        }
    }
}
