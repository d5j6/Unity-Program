
namespace HttpUtility
{
    public interface IInputHandler
    {
        byte[] HandleInputToRawData(object[] parameters);
    }
}

