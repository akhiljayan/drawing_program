using Canvas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace drawing_program.Logics
{
    public class InjectInterfaces
    {
        public IUnityContainer container;
        public InjectInterfaces()
        {
            this.container = new UnityContainer();
        }
        public ILogic Start()
        {
            container.RegisterType<ILogic, Logic>();
            container.RegisterType<ICanvasOperation, CanvasOperation>();
            return container.Resolve<ILogic>();
        }
    }
}
