
using System.Diagnostics;

namespace BaseLearn
{
    public class TestDefine 
    {
        [Conditional("LOG_INFO")]
        public void Haha()
        {
            
        }
    }

   
    
    public struct PartMain
    {
        public const int Num = 0;
        public static Part Part;
        public static int Id;

      
    }

    public enum Part
    {
        None,
        Main,
        Tool,
        Learn = 55
    }
}