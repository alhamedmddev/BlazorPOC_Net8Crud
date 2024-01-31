using BlazorPOC_Net8Crud.ViewModel;

namespace BlazorPOC_Net8Crud.IServices
{
    public interface IUserService
    {
        Task<(bool IsUserRegistered, string Message)> RegisterNewUserAsync(UserVM userVM);
    }
}
