﻿namespace StoryTeller.Engine.Batching
{
    public class SynchronousExecutor : IStepExecutor
    {
        private readonly SpecContext _context;

        public SynchronousExecutor(SpecContext context)
        {
            _context = context;
        }

        public virtual void Line(ILineExecution execution)
        {
            if (!_context.CanContinue()) return;

            execution.Execute(_context);
        }

        public void Composite(ICompositeExecution execution)
        {
            foreach (var executionStep in execution.Steps)
            {
                if (!_context.CanContinue())
                {
                    break;
                }

                executionStep.AcceptVisitor(this);
            }
        }

        public ISpecContext CurrentContext => _context;
    }
}