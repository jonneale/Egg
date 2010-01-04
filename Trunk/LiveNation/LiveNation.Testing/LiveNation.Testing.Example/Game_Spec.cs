using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LiveNation.Bowling;
using NBehave.Spec.NUnit;
using NUnit.Framework;

namespace LiveNation.Testing.Example.Game_Specs
{
    [TestFixture]
    public class Game_SpecBaseContext : SpecBase<Game>
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

        protected Game CreateGameWithFirstFrameSpare()
        {
            var game = new Game();
            game.Roll(5);
            game.Roll(5);
            return game;
        }

        protected Game CreateGameWithFirstFrameStrike()
        {
            var game = new Game();
            game.Roll(10);
            return game;
        }
    }

    namespace Given_I_begin_a_new_game
    {
        public class When_I_roll_and_knock_6_pins_over : Game_SpecBaseContext
        {
            protected override void Because_of()
            {
                Sut.Roll(6);
                base.Because_of();
            }

            [Specification]
            public void then_points_should_be_equal_to_6()
            {
                Sut.TotalPoints.ShouldEqual(6);
            }
        }

        public class When_I_roll_and_knock_6_pins_over_and_3_more_on_the_second_roll : Game_SpecBaseContext
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
                Sut.TotalPoints.ShouldEqual(9);
            }
        }

        namespace and_im_on_my_second_frame
        {
            public class When_I_roll_and_knock_6_pins_over : Game_SpecBaseContext
            {

            }
        }
    }

    namespace Given_I_have_a_spare_in_my_first_frame
    {
        public class When_I_roll_and_knock_over_5_pins : Game_SpecBaseContext
        {
            protected override Game Establish_context()
            {
                return CreateGameWithFirstFrameSpare();
            }

            protected override void Because_of()
            {
                Sut.Roll(5);
                base.Because_of();
            }

            [Specification]
            public void then_I_should_have_20_total_points()
            {
                Sut.TotalPoints.ShouldEqual(20);
            }
        }
    }

    namespace Given_I_have_a_strike_in_my_first_game
    {
        public class When_I_roll_a_6 : Game_SpecBaseContext
        {
            protected override Game Establish_context()
            {
                return CreateGameWithFirstFrameStrike();
            }

            protected override void Because_of()
            {
                Sut.Roll(6);
                base.Because_of();
            }

            [Specification]
            public void then_I_should_have_a_score_of_22()
            {
                Sut.TotalPoints.ShouldEqual(22);
            }
        }
    }
}
