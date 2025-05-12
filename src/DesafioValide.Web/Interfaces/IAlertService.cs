namespace DesafioValide.Web.Interfaces
{
    public interface IAlertService
    {
        string? Content { get; set; }
        string? Title { get; set; }

        event Action<bool> AlertIsOpenOnChange;

        void Cancel();
        Task<bool> Confirm(string? title = null, string? content = null);
        void Ok();
    }
}