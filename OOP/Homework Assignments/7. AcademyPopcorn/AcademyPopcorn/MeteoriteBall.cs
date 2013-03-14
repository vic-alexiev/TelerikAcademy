using System;
using System.Collections.Generic;

namespace AcademyPopcorn
{
    public class MeteoriteBall : Ball
    {
        private char[,] trailObjectBody = new char[,] { { '+' } };
        private int trailObjectLifetime;

        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed, int trailObjectLifetime)
            : base(topLeft, speed)
        {
            this.trailObjectLifetime = trailObjectLifetime;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<TrailObject> tail = new List<TrailObject>();

            // add a new trail object at the current position
            TrailObject trailObject = new TrailObject(this.TopLeft, this.trailObjectBody, this.trailObjectLifetime);
            tail.Add(trailObject);

            return tail;
        }
    }
}
