using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Course.Queries.SearchCourseByName;

public record SearchCourseByNameQuery(string Keyword) : IRequest<List<SearchCourseResult>>;
