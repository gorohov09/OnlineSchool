namespace OnlineSchool.Domain.Course.Entities;

public class TaskEntity
{
    public Guid Id { get; }

    public string Name { get; }

    public int Order { get; private set; }

    public string Description { get; }

    public TaskTypeEnum TaskType { get; }

    public string RightAnswer { get; }

    public TaskEntity(string name, string description, string type, string rightAnswer)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        TaskType = GetTypeTask(type);
        RightAnswer = rightAnswer;
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
