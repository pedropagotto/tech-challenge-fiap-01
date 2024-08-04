using Domain.Shared;
using Swashbuckle.AspNetCore.Filters;

namespace API.SwaggerExamples
{
    public class NotFoundResponseExample : IExamplesProvider<ErrorModel>
    {
        public ErrorModel GetExamples()
        {
            return new ErrorModel("001", "O contato não encontrado.");
        }
    }

    public class BadRequestResponseExample : IExamplesProvider<ValidationErrorModel>
    {
        public ValidationErrorModel GetExamples()
        {
            var fields = new List<Field>()
            {
                new Field
                {
                    Message = "Email informado inválido",
                    Name = "Email",
                    Value = "sanders.com"
                }
            };

            return new ValidationErrorModel("002", "Dados inválidos", "Tipo inválido.", fields);
        }
    }

    public class InternalServerErrorExample : IExamplesProvider<ErrorModel>
    {
        public ErrorModel GetExamples()
        {
            return new ErrorModel("005", "Ocorreu um erro inesperado.");
        }
    }
}
