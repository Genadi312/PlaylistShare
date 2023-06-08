using FluentValidation;
using PlaylistShare.Models.Models.Requests.AddRequests;

namespace PlaylistShare.Validators.AddRequestsValidators
{
    public class AddUserInfoRequestValidator : AbstractValidator<AddUserInfoRequest>
    {
        public AddUserInfoRequestValidator()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email cannot be empty!");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password cannot be empty!");
        }
    }
}
