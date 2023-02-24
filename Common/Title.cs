
public class Title
{
    private readonly Window _window;

    public Title(Window window)
    {
        _window = window;
    }

    public void SetValue(string text)
    {
        _window.Title = text;
    }
}