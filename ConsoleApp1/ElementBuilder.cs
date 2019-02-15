using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DslStateMachine
{
    public class ElementBuilder : AbstractStateBuilder
    {
        public override Entity Build()
        {
            return Init(
                Entity("Water").
                Variable("Temperature").IntegerVariable().VariableValue(20).
                Variable("Energy").IntegerVariable().VariableValue(0).
                    State("Solid").
                        Trasition("Melt").To("Liquid").When("Temperature").IntegerRule().MoreOrEqual().RuleValue(0).
                            When("Energy").IntegerRule().MoreOrEqual().RuleValue(10).
                    State("Liquid").
                        Trasition("Freeze").To("Solid").When("Temperature").IntegerRule().Less().RuleValue(0).
                        Trasition("Vaporize").To("Gas").When("Temperature").IntegerRule().MoreOrEqual().RuleValue(100).
                    State("Gas").
                        Trasition("Condense").To("Liquid").When("Temperature").IntegerRule().Less().RuleValue(100).
                Finish());
        }

        public Entity Build(string name, int startTemperature, int melt, int freeze, int vaporize, int condense)
        {
            return Init(
                Entity(name).
                Variable("Temperature").IntegerVariable().VariableValue(startTemperature).
                    State("Solid").
                        Trasition("Melt").To("Liquid").When("Temperature").IntegerRule().MoreOrEqual().RuleValue(melt).
                    State("Liquid").
                        Trasition("Freeze").To("Solid").When("Temperature").IntegerRule().Less().RuleValue(freeze).
                        Trasition("Vaporize").To("Gas").When("Temperature").IntegerRule().MoreOrEqual().RuleValue(vaporize).
                    State("Gas").
                        Trasition("Condense").To("Liquid").When("Temperature").IntegerRule().Less().RuleValue(condense).
                Finish());
        }

        private Entity Init(Entity e)
        {
            Element element = (Element) e;
            element.Init();
            return element;
        }

        public override AbstractStateBuilder Entity(string name)
        {
            CurrentEntity = new Element(name);
            return this;
        }
    }
}
