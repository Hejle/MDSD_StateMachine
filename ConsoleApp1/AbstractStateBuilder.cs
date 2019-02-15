using ConsoleApp1.Rule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class AbstractStateBuilder {

        private Dictionary<string, State> stateDic = new Dictionary<string, State>();
        private List<StateTrasition> transitionStateList = new List<StateTrasition>();

        private protected Entity CurrentEntity;

        private State CurrentState;

        private Transition CurrentTransition;

        private string CurrentRuleVariable;

        private Boolean CurrentRuleMore;

        private Boolean CurrentRuleLess;

        private Boolean CurrentRuleEqual;

        private String CurrentTypeRule;

        private Object CurrentRuleValue;

        private string CurrentVariableName;

        private string CurrentVariableType;

        private object CurrentVariableValue;

        public abstract AbstractStateBuilder Entity(String name);
        public abstract Entity Build();

        private Entity Init(Entity e)
        {
            e.Init();
            return e;
        }

        public Entity Finish()
        {
            CreateStuff();
            foreach (StateTrasition entry in transitionStateList)
            {
                State state = stateDic[entry.state];
                To(entry.transition, state);
            }

            FlushAll();

            return CurrentEntity;
        }

        private void CreateStuff()
        {
            if (CurrentTransition != null)
            {
                if (CurrentRuleVariable != null)
                {
                    CreateRule();
                }
                FlushTransition();
            }
            if (CurrentVariableName != null)
            {
                CreateVariable();
            }
        }

        public AbstractStateBuilder Trasition(String name)
        {
            CreateStuff();
            CurrentTransition = new Transition(name, CurrentState);
            CurrentState.AddTransition(name, CurrentTransition);
            return this;
        }

        public AbstractStateBuilder To(String state)
        {
            transitionStateList.Add(new StateTrasition(state, CurrentTransition));
            return this;
        }

        public AbstractStateBuilder State(String name)
        {
            CreateStuff();

            this.CurrentState = new State(name);
            stateDic.Add(name, CurrentState);
            if (CurrentEntity.CurrentState == null)
            {
                CurrentEntity.CurrentState = this.CurrentState;
            }
            return this;
        }

        public AbstractStateBuilder When(String variable)
        {
            if (CurrentRuleVariable != null)
            {
                CreateRule();
            }
            CurrentRuleVariable = variable;
            return this;
        }

        public AbstractStateBuilder IntegerRule()
        {
            CurrentTypeRule = "Integer";
            return this;
        }

        public AbstractStateBuilder More()
        {
            CurrentRuleMore = true;
            return this;
        }

        public AbstractStateBuilder Less()
        {
            CurrentRuleLess = true;
            return this;
        }

        public AbstractStateBuilder MoreOrEqual()
        {
            CurrentRuleMore = true;
            CurrentRuleEqual = true;
            return this;
        }

        public AbstractStateBuilder LessAndEqual()
        {
            CurrentRuleLess = true;
            CurrentRuleEqual = true;
            return this;
        }

        public AbstractStateBuilder Equal()
        {
            CurrentRuleEqual = true;
            return this;
        }

        public AbstractStateBuilder RuleValue(Object input)
        {
            CurrentRuleValue = input;
            return this;
        }

        public AbstractStateBuilder And() {
            return this;
        }



        public AbstractStateBuilder Variable(String name)
        {
            CreateStuff();
            CurrentVariableName = name;
            return this;
        }

        public AbstractStateBuilder IntegerVariable()
        {
            CurrentVariableType = "Integer";
            return this;
        }

        public AbstractStateBuilder VariableValue(object value)
        {
            CurrentVariableValue = value;
            return this;
        }

        private void To(Transition transition, State resultState)
        {
            transition.ResultState = resultState;
        }

        private void CreateVariable()
        {
            Variable var = null;
            if (CurrentVariableType.Equals("Integer"))
            {
                try
                {
                    int i = (int)CurrentVariableValue;
                    var = new Variable(CurrentVariableName, CurrentVariableValue, CurrentVariableType);
                }
                catch (InvalidCastException)
                {
                    throw new ArgumentException("An Integer was expected for this type of Variable");
                }
            } else
            {
                throw new ArgumentException("Type: " + CurrentVariableType + " is not a supported type for variables");
            }
            CurrentEntity.AddVariable(var);
            CurrentVariableName = null;
            CurrentVariableValue = null;
            CurrentVariableType = null;
        }

        private Boolean IsInteger(object currentVariableValue)
        {
            try
            {
                int i = (int)currentVariableValue;
                return true;
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException("An Integer was expected for this type of Variable");
            }
        }

        private void CreateRule()
        {
            if (CurrentTypeRule.Equals("Integer")) {
                int value = (int)CurrentRuleValue;
                if (CurrentRuleEqual == true)
                {
                    if (CurrentRuleLess == true)
                    {
                        CurrentTransition.AddRule(new LessEqualRule(CurrentRuleVariable, value));
                    } else if (CurrentRuleMore == true)
                    {
                        CurrentTransition.AddRule(new MoreEqualRule(CurrentRuleVariable, value));
                    } else
                    {
                        CurrentTransition.AddRule(new EqualRule(CurrentRuleVariable, value));
                    }
                } else
                {
                    if (CurrentRuleLess == true)
                    {
                        CurrentTransition.AddRule(new LessRule(CurrentRuleVariable, value));
                    }
                    else if (CurrentRuleMore == true)
                    {
                        CurrentTransition.AddRule(new MoreRule(CurrentRuleVariable, value));
                    }
                }
            } else
            {
                throw new ArgumentException("Type: " + CurrentTypeRule + " is not a supported type for rules");
            }
            FlushRule();
        }

        private void FlushTransition()
        {
            CurrentTransition = null;
            FlushRule();
        }

        private void FlushRule()
        {
            CurrentRuleVariable = null;

            CurrentRuleMore = false;

            CurrentRuleLess = false;

            CurrentRuleEqual = false;

            CurrentTypeRule = "";

            CurrentRuleValue = false;
        }

        private void FlushAll()
        {
            stateDic = new Dictionary<string, State>();
            transitionStateList = new List<StateTrasition>();
            CurrentState = null;
            FlushRule();
            FlushTransition();
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
