namespace OnlineSchool.Domain.Course.Entities;

public class TaskEntity
{
    public Guid Id { get; }

    public string Name { get; }

    public int Order { get; private set; }

    public string Description { get; }

    public TaskTypeEnum TaskType { get; }

    public string Question { get; }

    public string RightAnswer { get; }

    public LessonEntity Lesson { get; }

    public TaskEntity(string name, string description, string type, string question, string rightAnswer)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        TaskType = GetTypeTask(type);
        Question = question;
        RightAnswer = rightAnswer;
    }

    public TaskEntity()
    {

    }

    public void SetOrder(int order) => Order = order;

    private TaskTypeEnum GetTypeTask(string type)
    {
        var result = type switch
        {
            "lecture" => TaskTypeEnum.Lecture,
            "practice" => TaskTypeEnum.Practice,
            _ => throw new Exception("IncorrectType")
        };
        return result;
    }

}

public enum TaskTypeEnum
{
    Lecture,
    Practice
}
