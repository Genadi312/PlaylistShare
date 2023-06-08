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

            RuleFor(x => x.Author.Length).GreaterThan(5)
                                         .WithMessage("Minimum 5 characters")
                                         .LessThan(100)
                                         .WithMessage("Maximum 100 characters");
            RuleFor(x => x.Album).NotNull()
                                 .NotEmpty()
                                 .WithMessage("Album cannot be epty!");

        }
    }
}
}
