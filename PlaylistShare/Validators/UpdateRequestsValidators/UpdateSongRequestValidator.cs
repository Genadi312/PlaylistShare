using FluentValidation;
using PlaylistShare.Models.Models.Requests.UpdateRequests;

namespace PlaylistShare.Validators
{
    public class UpdateSongRequestValidator : AbstractValidator<UpdateSongRequest>
    {
        public UpdateSongRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty!");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Name cannot be empty!");
            RuleFor(x => x.Author).NotEmpty().WithMessage("Author cannot be empty!");
            RuleFor(x => x.Album).NotEmpty().WithMessage("Album cannot be empty!");
            RuleFor(x => x.PlaylistId).NotEmpty().WithMessage("PlaylistId cannot be empty!");
        }
    }
}
