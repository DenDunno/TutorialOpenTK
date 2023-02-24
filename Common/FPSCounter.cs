
public class FPSCounter
{
    private int _fpsValue;
    private float _time;
    private int _valueToDisplay;

    public int Update(float deltaTime)
    {
        _time += deltaTime;
        ++_fpsValue;
        
        if (_time >= 1)
        {
            _valueToDisplay = _fpsValue;
            
            _time = 0;
            _fpsValue = 0;
        }

        return _valueToDisplay;
    }
}