
    using System.Collections.Generic;
    
    public interface INavigation
    {
         Pose PoseDesired { get; set; }
         Pose PoseActual { get; }
         List<Pose> Mission {get; set;}
    }