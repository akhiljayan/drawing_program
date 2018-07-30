using DrawingFunctions.Canvas;
using DrawingFunctions.Line;
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
        public IDrawingService Start()
        {
            container.RegisterType<IDrawingService, DrawingService>();
            container.RegisterType<ICanvasOperation, CanvasOperation>();
            container.RegisterType<ILineOperation, LineOperation>();
            return container.Resolve<IDrawingService>();
        }
    }
}
