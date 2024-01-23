using BlazorPOC_Net8Crud.Model;
using BlazorPOC_Net8Crud.ViewModel;

namespace BlazorPOC_Net8Crud.IServices
{
    public interface IEmployeeService
    {
        Task<(bool IsEmpSaved, string message)> SaveNewEmpAsync(EmployeeVM employeeVM);
        Task<(bool IsEmpSaved, string message)> UpdateEmpAsync(EmployeeVM employeeVM);
        Task<(bool IsGetSuccess, List<EmployeeVM> employeeVM)> GetEmployeeAsync();
        Task<(bool IsGetSuccess, EmployeeVM employeeVM)> GetEmployeeByIDAsync(int Id);

        Task<(bool IsGetSuccess, string message)> DeleteEMployeeAsync(int Id);
    }
}
