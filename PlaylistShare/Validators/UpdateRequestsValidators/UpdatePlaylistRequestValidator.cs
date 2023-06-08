using FluentValidation;
using PlaylistShare.Models.Models.Requests.UpdateRequests;

namespace PlaylistShare.Validators.UpdateRequestsValidators
{
    public class UpdatePlaylistRequestValidator : AbstractValidator<UpdatePlaylistRequest>
    {
         public UpdatePlaylistRequestValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty!");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty!");
        RuleFor(x => x.Description.Length).GreaterThan(5)
                                          .WithMessage("Minimum 5 characters")
                                          .LessThan(100)
                                          .WithMessage("Maximum 100 characters");
    }
}
}
