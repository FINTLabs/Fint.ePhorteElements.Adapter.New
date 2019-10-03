using System;
using Fint.Event.Model;

namespace Fint.Sse.Adapter
{
    public class ActionUtils
    {
        public static bool IsValidStatusAction(string eventAction)
        {
            if (Enum.TryParse(eventAction, true, out DefaultActions action))
            {
                if (Enum.IsDefined(typeof(DefaultActions), action))
                {
                    return true;
                }
            }
            return false;
        }
    }
}