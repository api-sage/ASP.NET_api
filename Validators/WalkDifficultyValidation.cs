using FluentValidation;

namespace crudapi.WalkDifficultyValidation
{
    public class WalkDifficultyValidation : AbstractValidator<Model.DTO.AddWalkDifficultyRequest> 
    {
        public WalkDifficultyValidation()
        {
            RuleFor(w => w.Code).NotEmpty();
            RuleFor(w => w.Code).Length(4,6);
        }
    }

    public class WalkDifficultyValidation1 : AbstractValidator<Model.DTO.UpdateWalkDifficulty>
    {
        public WalkDifficultyValidation1()
        {
            RuleFor(w => w.Code).NotEmpty();
            RuleFor(w => w.Code).Length(4, 6);
        }
    }
}
