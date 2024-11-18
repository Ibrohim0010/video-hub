using FluentValidation;

namespace VideoHub.Moduls.Video;

public class VideoValidator:AbstractValidator<VideoHub.Moduls.Video.Video>
{
    public VideoValidator()
    {
        RuleFor(x=>x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .Length(2, 50).WithMessage("Title must be between 2 and 50 characters.");
        
        RuleFor(chat => chat.IsPaid)
            .NotEmpty().WithMessage("IsPaid is required.");

        RuleFor(chat => chat.Description)
            .NotEmpty().WithMessage("Description is required.")
            .Length(2, 200).WithMessage("Description must be between 2 and 200 characters.");
    }
}