using Mapster;
using OnlineSchool.App.Task.Queries.Common;
using OnlineSchool.Contracts.Course.Task.Get;

namespace OnlineSchool.API.Common.Mapping;

public class TaskMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<TaskDetailsVm, GetDetailsTaskResponse>()
            .Map(dest => dest.TaskId, src => src.TaskId)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Question, src => src.Question)
            .Map(dest => dest.Type, src => src.Type)
            .Map(dest => dest.LastAttempt, src => src.LastAttempt)
            .Map(dest => dest.LastResultAttempt, src => src.LastResultAttempt)
            .Map(dest => dest.LastAnswerAttempt, src => src.LastAnswerAttempt);
    }
}