namespace LMS.Shared.DTOs;


// UPDATE / DELETE
public record ResultDto(bool Succeded, IReadOnlyList<string> Errors)
{    
    public static ResultDto Ok() => new(true, Array.Empty<string>());
    public static ResultDto Fail(params string[] Errors) => new(false, Errors);
    
}

// GET / CREATE
public record ResultDto<T>(bool Succeded, T? Value, IReadOnlyList<string> Errors)
{
    public static ResultDto<T> Ok(T value) => new(true , value, Array.Empty<string>());
    public static ResultDto<T> Fail(params string[] errors) => new(false, default, errors);
}