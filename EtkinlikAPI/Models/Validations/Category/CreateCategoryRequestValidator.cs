using EtkinlikAPI.Models.DTO;
using FluentValidation;

namespace EtkinlikAPI.Models.Validations
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequestDto>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name alanı boş geçilemez")
                .MinimumLength(2).WithMessage("2 Karakterden küçük bir kategori adı olamaz");

        }
    }
}
