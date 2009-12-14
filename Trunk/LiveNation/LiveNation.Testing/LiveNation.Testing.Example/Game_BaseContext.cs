using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Bowling;
using NBehave.Spec.NUnit;
using NUnit.Framework;

namespace LiveNation.Testing.Example
{
    [TestFixture]
    public class Game_BaseContext : SpecBase<Game>
    {
        [SetUp]
        public override void MainSetup()
        {
            base.MainSetup();
        }

        protected override Game Establish_context()
        {
            return new Game();
        }
    }

    namespace Given_I_begin_a_new_game
    {
        public class When_I_roll_and_knock_6_pins_over : Game_BaseContext
        {
            protected override void Because_of()
            {
                Sut.Roll(6);
                base.Because_of();
            }

            [Specification]
            public void then_points_should_be_equal_to_6()
            {
                Sut.Points.ShouldEqual(6);
            }
        }

        public class When_I_roll_and_knock_6_pins_over_and_then_3_more_in_second_roll : Game_BaseContext
        {
            protected override void Because_of()
            {
                Sut.Roll(6);
                Sut.Roll(3);
                base.Because_of();
            }

            [Specification]
            public void then_points_should_be_equal_to_9()
            {
                Sut.Points.ShouldEqual(9);
            }
        }
    }
}
