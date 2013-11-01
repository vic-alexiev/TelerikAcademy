using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        public int AttackPoints { get; private set; }

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.AttackPoints = 0;
            this.HitPoints = 1;
        }

        public int DefensePoints
        {
            get { return Int32.MaxValue; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    int maxHitPoints = availableTargets.Max(wo => wo.HitPoints);

                    if (availableTargets[i].HitPoints == maxHitPoints)
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }

            if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += (2 * resource.Quantity);
                return true;
            }

            return false;
        }
    }
}
