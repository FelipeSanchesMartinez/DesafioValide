namespace DesafioValide.Web.ViewModels
{
    public class ApiResponse<T>
    {
        protected ApiResponse() { }
        public ApiResponse(bool success, T? data,  List<string> errors)
        {
            Success = success;
            Data = data;
            Errors = errors;
        }

        public bool Success { get; set; }
        public T? Data { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}
