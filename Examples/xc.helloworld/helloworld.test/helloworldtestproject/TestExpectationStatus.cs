using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XComponent.HelloWorld.IntegrationTests
{
    internal class TestExpectationStatus
    {
        public TestExpectationStatus(int constraintCount, int updateCount)
        {
            ConstraintCount = constraintCount;
            UpdateCount = updateCount;

            SatisfiedConstraintCountArray = new int[UpdateCount];
            ConstraintStatusArray = new TestConstraintStatus[UpdateCount][];
        }

        public int UpdateCount { get; set; }

        public int SatisfiedUpdateCount { get; private set; }

        public int[] SatisfiedConstraintCountArray { get; private set; }

        public int SatisfiedConstraintCount
        {
            get { return SatisfiedConstraintCountArray[SatisfiedUpdateCount]; }
            set { SatisfiedConstraintCountArray[SatisfiedUpdateCount] = value; }
        }

        public int ConstraintCount { get; set; }

        public bool IsSatisfied
        {
            get
            {
                if (ConstraintCount == 0)
                {
                    return SatisfiedUpdateCount == UpdateCount;
                }
                return SatisfiedConstraintCountArray.All(count => count == ConstraintCount);
            }
        }

        public TestConstraintStatus[][] ConstraintStatusArray { get; private set; }

        public TestConstraintStatus[] ConstraintStatus
        {
            get { return ConstraintStatusArray[SatisfiedUpdateCount]; }
            set { ConstraintStatusArray[SatisfiedUpdateCount] = value; }
        }

        public int ReceivedUpdateCount { get; set; }

        public void SetStatus(TestConstraintStatus[] bestConstraints)
        {
            ReceivedUpdateCount++;

            ConstraintStatus = bestConstraints;

            SatisfiedConstraintCount = bestConstraints.Count(constraint => constraint.IsSatisfied);

            if (SatisfiedConstraintCount == ConstraintCount)
            {
                SatisfiedUpdateCount++;
            }
        }
    }
}
