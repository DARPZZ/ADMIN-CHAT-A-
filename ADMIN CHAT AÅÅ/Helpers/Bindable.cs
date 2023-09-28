using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ADMIN_CHAT_AÅÅ.Helpers
{
    /*  
     *Informerer lyttere om, at en egenskab er blevet ændret, hvilket udløser PropertyChanged-begivenheden.
     *<param name="memberName">Navnet på den ændrede egenskab (automatisk udfyldt af CallerMemberName-attributten).</param>
     */
    public class Bindable : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void propertyIsChanged([CallerMemberName] string memberName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
        }
    }
}
