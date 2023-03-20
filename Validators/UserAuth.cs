using FluentValidation;

namespace crudapi.Validators
{
    public class UserAuth: AbstractValidator<Model.DTO.LoginParams>
    {
        public UserAuth()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
