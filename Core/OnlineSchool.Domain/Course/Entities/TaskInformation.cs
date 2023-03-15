namespace OnlineSchool.Domain.Course.Entities;

public class TaskInformation
{
    public string Name { get; set; }

    public TypeTask Type { get; set; }

    public string Description { get; set; }

    public string Question { get; set; }

    public Answer Answer { get; set; }

    public List<Answer> Answers { get; set; }

    public List<Answer> WrongAnswers { get; set; }

    public bool CheckAnswer(string answerStudent)
    {
        if (Type == TypeTask.FreeResponse || Type == TypeTask.OneAnswer)
            return Answer.Value == answerStudent;

        return false;
    }

    public string GetTypeTask()
    {
        return Type switch
        {
            TypeTask.FreeResponse => "Свободный ответ",
            TypeTask.OneAnswer => "Один ответ",
            TypeTask.ManyAnswer => "Несколько ответов",
            _ => throw new NotImplementedException()
        };
    }
}

public class Answer
{
    public string Value { get; set; }
}

public enum TypeTask
{
    FreeResponse,
    OneAnswer,
    ManyAnswer
}

