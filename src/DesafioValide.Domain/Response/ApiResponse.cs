using DesafioValide.Domain.Notifications;
using Microsoft.AspNetCore.Http;

namespace DesafioValide.Domain.Response
{
    public class ApiResult
    {
        public static ApiResult SuccessResult(object? data = null) => new ApiResult(true, 200, data);
        public static ApiResult ErrorResult(object? data = null, int? status = null, params DomainNotification[] errors) =>
            new ApiResult(false, status ?? StatusCodes.Status400BadRequest, data, errors);
        public ApiResult(bool success, int status, object? data = null, IEnumerable<DomainNotification>? errors = null)
        {
            Success = success;
            Data = data;
            Errors = errors ?? Enumerable.Empty<DomainNotification>();
            Status = status;
        }

        public bool Success { get; set; }
        public object? Data { get; set; }
        public IEnumerable<DomainNotification> Errors { get; set; }
        public int Status { get; set; }
    }
}
