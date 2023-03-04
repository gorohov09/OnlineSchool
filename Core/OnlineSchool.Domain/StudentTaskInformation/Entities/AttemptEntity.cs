namespace OnlineSchool.Domain.StudentTaskInformation.Entities;

public class AttemptEntity
{
    public Guid Id { get; }

    /// <summary>
    /// Дата отправки
    /// </summary>
    public DateTime DateDispatch { get; }

    /// <summary>
    /// Ответ
    /// </summary>
    public string Answer { get; }

    public bool IsRight { get; }

    public AttemptEntity(DateTime dateDispatch, bool isRight)
    {
        DateDispatch = dateDispatch;
        IsRight = isRight;
        Answer = Answer;
    }

    public StudentTaskInformationEntity StudentTaskInformation { get; }
}