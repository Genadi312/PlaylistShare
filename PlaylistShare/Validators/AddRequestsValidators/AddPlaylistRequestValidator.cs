using FluentValidation;
using PlaylistShare.Models.Models.Requests.AddRequests;

namespace PlaylistShare.Validators.AddRequestsValidators
{
    public class AddPlaylistRequestValidator : AbstractValidator<AddPlaylistRequest>
    {
        public AddPlaylistRequestValidator()
        {
            RuleFor(x => x.Name).NotNull()
                                .NotEmpty()
                                .WithMessage("Name cannot be empty!");

            RuleFor(x => x.Description.Length).GreaterThan(5)
                                              .WithMessage("Minimum 5 characters")
                                              .LessThan(100)
                                              .WithMessage("Maximum 100 characters");
        }
    }
}

