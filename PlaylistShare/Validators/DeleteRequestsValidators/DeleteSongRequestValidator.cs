using FluentValidation;
using PlaylistShare.Models.Models.Requests.DeleteRequests;

namespace PlaylistShare.Validators.DeleteReuqestsValidators
{
    public class DeleteSongRequestValidator : AbstractValidator<DeleteSongRequest>
    {
        public DeleteSongRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty!");
        }
    }
}
