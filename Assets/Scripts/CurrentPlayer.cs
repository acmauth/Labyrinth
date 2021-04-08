
/*
 * This static class will hold the position of the current player in the stats file. We will use it so that we can
 * globally know at all times in which position is the player we need to access (To get his name, score..., or even
 * to update those values)
 *
 * Αυτή η στατική κλάση θα κρατάει τη θέση του παίκτη στον stats φάκελο. Θα την χρησιμοποιήσουμε ώστε να μπορούμε
 * από παντού και κάθε στιμγή να ξέρουμε σε ποιά θέση βρίσκεται ο παίκτης (Πχ. για να πάρουμε το όνομα του, το σκορ,
 * ή ακόμη και να αλλάξουμε αυτές τις τιμές).
 */
public static class CurrentPlayer
{
    private static int playerPos;

    static CurrentPlayer()
    {
        playerPos = 0;
    }

    public static void ChangePosition(int pos)
    {
        playerPos = pos;
    }

    public static int GetPosition()
    {
        // Debug.Log("PlayerPos = " + playerPos);
        return playerPos;
    }
}
