using Application.ViewModels.Contact;

namespace API.SwaggerExamples
{
    using Swashbuckle.AspNetCore.Filters;

    public class ContactRequestExample : IExamplesProvider<ContactRequestModel>
    {
        public ContactRequestModel GetExamples()
        {
            return new ContactRequestModel
            {
                Name = "Jose Vieira",
                Ddd = "11",
                Phone = "98155-4567",
                Email = "jose.vieira@example.com"
            };
        }
    }

    public class ContactResponseExample : IExamplesProvider<ContactResponseModel>
    {
        public ContactResponseModel GetExamples()
        {
            return new ContactResponseModel
            {
                Id = 1,
                CreatedAt = new DateTime(2024, 08, 13).ToUniversalTime(),
                UpdatedAt = new DateTime(2024, 08, 13).ToUniversalTime(),
                Name = "Jose Vieira",
                Ddd = "11",
                Phone = "98155-4567",
                Email = "jose.vieira@example.com"
            };
        }
    }

    public class ListOfContactResponseExample : IExamplesProvider<IList<ContactResponseModel>>
    {
        public IList<ContactResponseModel> GetExamples()
        {
            return new List<ContactResponseModel>()
            {
                new()
                {
                    Id = 1,
                    CreatedAt = new DateTime(2024,08,13).ToUniversalTime(),
                    UpdatedAt = new DateTime(2024,08,13).ToUniversalTime(),
                    Name = "Jose Vieira",
                    Ddd = "11",
                    Phone = "98155-4567",
                    Email = "jose.vieira@example.com"
                }
            };
        }
    }
}
