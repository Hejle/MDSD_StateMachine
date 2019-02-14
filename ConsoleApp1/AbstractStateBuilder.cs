using ConsoleApp1.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class AbstractStateBuilder {

        private Dictionary<String, State> stateDic = new Dictionary<string, State>();
        private List<StateTrasition> transitionStateList = new List<StateTrasition>();

        private protected Entity currentEntity;

        private State currentState;

        private Transition currentTransition;

        private Boolean currentRule;

        private Boolean currentRuleMore;

        private Boolean currentRuleLess;

        private Boolean currentRuleEqual;

        private String currentTypeRule;

        private Object currentRuleValue;

        public abstract AbstractStateBuilder Entity(String name);
        public abstract Entity Build();

        public Entity Finish()
        {
            createStuff();
            foreach (StateTrasition entry in transitionStateList)
            {
                State state = stateDic[entry.state];
                To(entry.transition, state);
            }

            return currentEntity;
        }

        private void createStuff()
        {
            if (currentTransition != null)
            {
                if (currentRule)
                {
                    CreateRule();
                }
                flushTransition();
            }
        }

        public AbstractStateBuilder Trasition(String name)
        {
            createStuff();
            currentTransition = new Transition(name, currentState);
            currentState.AddTransition(name, currentTransition);
            return this;
        }

        public AbstractStateBuilder To(String state)
        {
            transitionStateList.Add(new StateTrasition(state, currentTransition));
            return this;
        }

        public AbstractStateBuilder State(String name)
        {
            createStuff();

            this.currentState = new State(name);
            stateDic.Add(name, currentState);
            if (currentEntity.CurrentState == null)
            {
                currentEntity.CurrentState = this.currentState;
            }
            return this;
        }

        public AbstractStateBuilder When()
        {
            if(currentRule == true)
            {
                CreateRule();
            }
            currentRule = true;
            return this;
        }

        public AbstractStateBuilder IntegerRule()
        {
            currentTypeRule = "Integer";
            return this;
        }

        public AbstractStateBuilder More()
        {
            currentRuleMore = true;
            return this;
        }

        public AbstractStateBuilder Less()
        {
            currentRuleLess = true;
            return this;
        }

        public AbstractStateBuilder MoreOrEqual()
        {
            currentRuleMore = true;
            currentRuleEqual = true;
            return this;
        }

        public AbstractStateBuilder LessAndEqual()
        {
            currentRuleLess = true;
            currentRuleEqual = true;
            return this;
        }

        public AbstractStateBuilder Equal()
        {
            currentRuleEqual = true;
            return this;
        }

        public AbstractStateBuilder RuleValue(Object input)
        {
            currentRuleValue = input;
            return this;
        }

        private void To(Transition transition, State resultState)
        {
            transition.ResultState = resultState;
        }

        public AbstractStateBuilder Temperatur(int temperature)
        {
            ((Element)currentEntity).Temperature = temperature;
            return this;
        }

        private void CreateRule()
        {
            if (currentTypeRule.Equals("Integer")) {
                int value = (int)currentRuleValue;
                if (currentRuleEqual == true)
                {
                    if (currentRuleLess == true)
                    {
                        currentTransition.Rule = new LessEqualRule(value);
                    } else if (currentRuleMore == true)
                    {
                        currentTransition.Rule = new MoreEqualRule(value);
                    } else
                    {
                        currentTransition.Rule = new EqualRule(value);
                    }
                } else
                {
                    if (currentRuleLess == true)
                    {
                        currentTransition.Rule = new LessRule(value);
                    }
                    else if (currentRuleMore == true)
                    {
                        currentTransition.Rule = new MoreRule(value);
                    }
                }
            }
            flushRule();
        }

        private void flushTransition()
        {
            currentTransition = null;
            flushRule();
        }

        private void flushRule()
        {
            currentRule = false;

            currentRuleMore = false;

            currentRuleLess = false;

            currentRuleEqual = false;

            currentTypeRule = "";

            currentRuleValue = false;
        }

        private class StateTrasition
        {
            public String state;

            public Transition transition;

            public StateTrasition(string state, Transition transition)
            {
                this.state = state;
                this.transition = transition;
            }

        }

    }
}
