using DesafioValide.Web.Interfaces;

namespace DesafioValide.Web.Services
{
    public class AlertService : IAlertService
    {
        public event Action<bool> AlertIsOpenOnChange;
        public TaskCompletionSource<bool>? TaskCompletionSourceConfirm;
        public string? Title { get; set; }
        public string? Content { get; set; }
        public Task<bool> Confirm(string? title = null, string? content = null)
        {
            Title = title;
            Content = content;

            TaskCompletionSourceConfirm = new TaskCompletionSource<bool>();

            AlertIsOpenOnChange?.Invoke(true);

            return TaskCompletionSourceConfirm.Task;
        }

        public void Cancel()
        {
            TaskCompletionSourceConfirm?.SetResult(false);
            AlertIsOpenOnChange?.Invoke(false);
        }

        public void Ok()
        {
            TaskCompletionSourceConfirm?.SetResult(true);
            AlertIsOpenOnChange?.Invoke(false);
        }
    }
}
