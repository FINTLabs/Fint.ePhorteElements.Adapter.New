using System;
using Fint.Event.Model;
using FINT.Model.Administrasjon.Arkiv;
using FINT.Model.Kultur.Kulturminnevern;

namespace Fint.Sse.Adapter
{
    public class ActionUtils
    {
        public static bool IsValidArchiveAction(string eventAction)
        { 
            return Enum.TryParse(eventAction, true, out ArkivActions action) 
                   && AdapterActions.ArchiveActions().Contains(action);
        }

        public static bool IsValidKulturminneAction(string eventAction)
        { 
            return Enum.TryParse(eventAction, true, out KulturminnevernActions action) 
                   && AdapterActions.KulturminneActions().Contains(action);
        }

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