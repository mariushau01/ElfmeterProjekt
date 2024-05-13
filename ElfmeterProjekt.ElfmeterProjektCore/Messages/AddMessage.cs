using CommunityToolkit.Mvvm.Messaging.Messages;
using ElfmeterProjekt.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElfmeterProjekt.ElfmeterProjektCore.Messages
{
    public class AddMessage : ValueChangedMessage<Team>
    {
        public AddMessage(Team value) : base(value)
        {
                
        }
    }
}
