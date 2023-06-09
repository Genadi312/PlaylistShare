using FluentValidation;
using PlaylistShare.Models.Models.Requests.UpdateRequests;

namespace PlaylistShare.Validators.UpdateRequestsValidators
{
    public class UpdateUserInfoRequestValidator : AbstractValidator<UpdateUserInfoRequest>
    {
        public UpdateUserInfoRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty!");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username cannot be empty!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be empty!");
        }
    }
}
