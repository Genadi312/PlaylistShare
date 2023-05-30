using FluentValidation;
using PlaylistShare.DL.Models;

namespace PlaylistShare.Validators
{
    public class AddSongValidator:AbstractValidator<Song>

    {
        public AddSongValidator() 
        {
            RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("Title cannot be empty!");
            RuleFor(x => x.Author).NotNull().NotEmpty().WithMessage("Author cannot be empty!");
            RuleFor(x => x.Album).NotNull().NotEmpty().WithMessage("Album cannot be empty!");
        }
    }
}
