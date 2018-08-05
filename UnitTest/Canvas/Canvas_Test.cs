using DrawingFunctions.Canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.Canvas
{
    public class Canvas_Test
    {
        private readonly ICanvasOperation _canvasOpp;
        public Canvas_Test(ICanvasOperation canvasOpp)
        {
            _canvasOpp = canvasOpp;
        }

        [Fact]
        public void Should_CreatePersonAllergy()
        {
            //var createdAllergy = CreatePersonAllergy(AllergyCategory.NonDrug, AllergyState.Confirmed, false, "something", "Stone Gold", "S2708227J");
            //createdAllergy.Id.ShouldNotBeNull();
        }
    }
}
