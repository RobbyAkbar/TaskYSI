using MediatR;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Queries.Course;

public record SearchCourseByNameQuery(string Keyword) : IRequest<List<SearchCourseResult>>;
