namespace Msg
{
    public class MessagePlayer
    {
        public virtual void Send(string msg)
        {
            TestBroker.GetInistance().Send(msg);
        }
 
    }
}
