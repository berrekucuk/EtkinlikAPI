using EtkinlikAPI.Models.DTO;
using FluentValidation;

namespace EtkinlikAPI.Models.Validations
{
    public class CreateActivityRequestValidator : AbstractValidator<CreateActivityRequestDto>
    {
        public CreateActivityRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Etkinlik adı boş geçilemez.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Etkinlik açıklaması boş geçilemez.");
            RuleFor(x => x.StartDate).NotEmpty().WithMessage("Etkinlik tarihi boş geçilemez.");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Etkinlik kategorisi boş geçilemez.");
            RuleFor(x => x.Images).NotEmpty().WithMessage("Etkinlik resmi boş geçilemez.");
        }
    }
}
