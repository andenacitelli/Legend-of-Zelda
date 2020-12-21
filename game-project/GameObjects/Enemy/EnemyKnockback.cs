using game_project.ECS.Components;
using Microsoft.Xna.Framework;

namespace game_project.GameObjects.Enemy
{
    class EnemyKnockback : BehaviorScript
    {
    private Constants.Direction direction;
    private float distance;
    private float numFrames;
    private int frame;

    public EnemyKnockback(Constants.Direction direction, float distance, int numFrames)
    {
        this.direction = direction;
        this.distance = distance;
        this.numFrames = numFrames;
        this.frame = 0;
    }

    public override void Update(GameTime gameTime)
    {
        // Translate in direction we were instantiated with for a proportional distance
        switch (direction)
        {
            case Constants.Direction.RIGHT:
                entity.GetComponent<Transform>().position += new Vector2(distance / numFrames, 0);
                break;
            case Constants.Direction.DOWN:
                entity.GetComponent<Transform>().position += new Vector2(0, distance / numFrames);
                break;
            case Constants.Direction.LEFT:
                entity.GetComponent<Transform>().position += new Vector2(-1 * (distance / numFrames), 0);
                break;
            case Constants.Direction.UP:
                entity.GetComponent<Transform>().position += new Vector2(0, -1 * (distance / numFrames));
                break;
        }

        frame++;
        if (frame >= numFrames)
        {
            this.SetForDeletion();
        }
    }
}
}
