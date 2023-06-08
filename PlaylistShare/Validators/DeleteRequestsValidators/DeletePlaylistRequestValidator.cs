using FluentValidation;
using PlaylistShare.Models.Models.Requests.DeleteRequests;

namespace PlaylistShare.Validators.DeleteReuqestsValidators
{
    public class DeletePlaylistRequestValidator : AbstractValidator<DeletePlaylistRequest>
    {
        public DeletePlaylistRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty!");
        }
    }
}
