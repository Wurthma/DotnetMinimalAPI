using MiniTodo.ViewModels.Validations;

namespace MiniTodo.ViewModels
{
    public class CreateTodoViewModel
    {
        public string Title { get; set; }

        public Todo MapTo()
        {
            return new Todo(Guid.NewGuid(), Title, false);
        }
    }
}