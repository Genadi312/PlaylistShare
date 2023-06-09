using FluentValidation;
using PlaylistShare.Models.Models.Requests.AddRequests;

namespace PlaylistShare.Validators
{
    public class AddSongRequestValidator : AbstractValidator<AddSongRequest>
    {
        public AddSongRequestValidator()
        {
            RuleFor(x => x.Title).NotNull()
                                .NotEmpty()
                                .WithMessage("Title cannot be empty!");

            RuleFor(x => x.Author.Length).NotEmpty()
                                         .WithMessage("Title cannot be empty!");


            RuleFor(x => x.Album).NotNull()
                                 .NotEmpty()
                                 .WithMessage("Album cannot be empty!");

        }
    }
}
