using Mapster;

var todo = new ToDo(1,"Test 1","lorm part",true);

var config = TypeAdapterConfig.GlobalSettings;

config.NewConfig<(ToDo todo, Guid CategoryId), ToDoDemo>()
    .Map(dest => dest, src => src.todo)
    .Map(dest => dest.CategoryId, src => src.CategoryId);


var todoDemo = (todo, Guid.NewGuid()).Adapt<ToDoDemo>();

Console.WriteLine(todo);
Console.WriteLine(todoDemo);



public record ToDo(int Id, String Title, String Description, bool IsCompleted);
public record ToDoDemo(string Title, bool IsCompleted, string CategoryId);






