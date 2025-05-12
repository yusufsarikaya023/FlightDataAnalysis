namespace Application.Validations;

/// <summary>
/// Validator for Pagination class
/// This class is used to validate the pagination parameters.
/// </summary>
public class PaginationValidator: AbstractValidator<Pagination>
{
    public PaginationValidator()
    {
        RuleFor(x=> x.Page)
            .GreaterThan(0)
            .WithMessage("Page must be greater than 0");
        
        RuleFor(x=> x.PageSize)
            .GreaterThan(0)
            .WithMessage("PageSize must be greater than 0");
        
        RuleFor(x=> x.PageSize)
            .LessThanOrEqualTo(100)
            .WithMessage("PageSize must be less than 100");
    }
}