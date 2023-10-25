using MediatR;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Commands;

public record GetAllCourseCommand : IRequest<GetAllCourseResponse>;