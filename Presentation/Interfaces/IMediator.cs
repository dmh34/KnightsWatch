using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnightsWatch.Presentation.Interfaces
{
    public delegate void ReceivedItemsHandller(IEnumerable<object> items);

    public interface IMediator
    {
        void SendObjects(object o);
        void Register(ICompoent compoent);
    }

    public class Mediator : IMediator
    {
   

        private IList<ICompoent> compoents;

        public Mediator()
        {
            compoents = new List<ICompoent>(); 
        }

        public void SendObjects(object o)
        {
            foreach (var item in compoents)
            {
                item.RecieveItems(o);
            }
        }

        public void Register(ICompoent compoent)
        {
            if (compoent != null)
                compoents.Add(compoent);
        }

       
    }

    public interface ICompoent
    {
        void RecieveItems(object o);
    }

}
