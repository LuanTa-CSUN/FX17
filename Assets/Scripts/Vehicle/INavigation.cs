
    using UnityEngine;
    
    public interface INavigation
    {
         Pose PoseDesired { get; set; }
         Pose PoseActual { get; private set;}
         List<Pose> Mission {get; set;}
    }