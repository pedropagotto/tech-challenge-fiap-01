using Application.ViewModels;

namespace Application.Services
{
    public interface IContactService
    {
        Task<IList<ContactResponseModel>> ListAll();
        Task<List<ContactResponseModel>> FilterByDdd(string Ddd);
        Task<ContactResponseModel>? GetById(int id);
        Task<ContactResponseModel> Create(ContactRequestModel contact);
        Task<ContactResponseModel> Update(ContactRequestModel contact);
        Task Delete(int id);
    }
}
