using Microsoft.AspNetCore.Mvc;

namespace WhatsApp.Common
{
    public class Result<T>
    {
        public bool Success => ResultType == ResultTypes.Success;
        public string? Message { get; set; }
        public List<string> Errors { get; set; } = new();
        public T? Data { get; set; }
        public ResultTypes ResultType { get; set; } = ResultTypes.Success;

        public Result() { }

        public Result(ResultTypes resultType)
        {
            ResultType = resultType;
        }

        public Result(T data)
        {
            Data = data;
        }

        public Result<T> AddError(string error, ResultTypes type = ResultTypes.InvalidData)
        {
            Errors.Add(error);
            ResultType = type;
            return this;
        }

        public IActionResult ToActionResult()
        {
            return ResultType switch
            {
                ResultTypes.Success or ResultTypes.CompletedWithErrors => new OkObjectResult(this),
                ResultTypes.NotFound => new NotFoundObjectResult(this),
                ResultTypes.InvalidData => new BadRequestObjectResult(this),
                ResultTypes.PermissionDenied => new ForbidResult(),
                _ => new BadRequestObjectResult(this),
            };
        }
    }
}
