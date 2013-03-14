using System.Collections.Generic;

namespace AcademyPopcorn
{
    public class GiftBlock : Block
    {
        private char[,] giftBody = new char[,] { { '%' } };

        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
            this.ProduceObjects();
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed)
            {
                List<Gift> gifts = new List<Gift>();

                // add a gift to the list of produced objects
                gifts.Add(new Gift(this.topLeft, this.giftBody));

                return gifts;
            }
            else
            {
                return base.ProduceObjects();
            }
        }
    }
}
