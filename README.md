Quick fix for elite spam in the new update.

In the new update, a new elite tier was introduced. It contains all the normal tier 1 elites and the new gilded elites, and becomes available once you've cleared 2 stages.

The problem is that this new elite tier has a cost multiplier of 3.5x (compared to the normal tier 1 cost multiplier of 6x). This means that as soon as this tier is available, all tier 1 elites can be spawned for only slightly more than half of their intended cost.

This mod attempts to fix the issue by:
- Finding the normal tier 1 by looking for whichever tier contains overloading elites but not gilded elites
- Finding the new tier by looking for whichever tier contains gilded elites
- Setting the new tier's cost multiplier to the same as the normal tier 1's cost multiplier
- Disabling the normal tier 1 once the new tier is available (not sure if this is actually needed)

This achieves what I believe was the intended behaviour - introducing gilded elites to the tier 1 elite pool starting at stage 3. There may be a better way to do this but considering how much harder this issue makes the game, I wanted to get this out fairly quick.

Message me (a cats) on discord if this mod has any problems :)
