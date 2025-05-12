namespace DesafioValide.Web.States
{
    public class LoadingFullscreenState
    {
        public bool IsLoading { get; private set; }

        public event Action<bool> OnChange;

        public void SetLoading(bool isLoading = true)
        {
            IsLoading = isLoading;
            OnChange?.Invoke(isLoading);
        }

    }
}
