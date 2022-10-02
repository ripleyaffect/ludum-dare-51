using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EPlayerReviewRequested : EBase { }

public class ELevelChanged : EBase
{
    public LevelData NewLevelData;
}

public class EPlayerLose : EBase { }

public class EPlayerWin : EBase { }

public class EActivityZoneEntered : EBase
{
    public Activity Activity;
}

public class EActivityZoneExited : EBase
{
    public Activity Activity;
}

public class ETaskCompleted : EBase
{
    public Task Task;
}

public class ETaskFailed : EBase
{
    public Task Task;
}

public class EPlaySfx : EBase
{
    public SfxTypes Type;
}
