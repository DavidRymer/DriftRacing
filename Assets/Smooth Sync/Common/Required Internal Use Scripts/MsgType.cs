namespace Smooth
{
    public class MsgType
    {
        public static short SmoothSyncTeleportForSpawnChildren = short.MaxValue - 5;
        public static short SmoothSyncFromServerToNonOwners = short.MaxValue - 2;
        public static short SmoothSyncFromOwnerToServer = short.MaxValue - 1;
    }
}