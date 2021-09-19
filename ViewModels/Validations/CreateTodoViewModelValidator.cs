using FluentValidation;
using MiniTodo.ViewModels;

namespace MiniTodo.ViewModels.Validations
{
    public class CreateTodoViewModelValidator : AbstractValidator<CreateTodoViewModel>
    {
        public CreateTodoViewModelValidator() 
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Informe o título da tarefa");
            RuleFor(x => x.Title).MaximumLength(5).WithMessage("O título deve conter mais de 5 caracteres");
        }
    }
}