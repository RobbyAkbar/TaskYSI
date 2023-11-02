namespace TaskYSI.Application.Course.Commands.DeleteCourse;

public record DeleteCourseCommand(Guid Id) : IRequest;
