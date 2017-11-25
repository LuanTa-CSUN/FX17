using System.Collections.Generic;
    using UnityEngine;
    
    public interface INavigation
    {
         Pose PoseDesired { get; set; }
         Pose PoseActual { get; }
         List<Pose> Mission {get; set;}
    }