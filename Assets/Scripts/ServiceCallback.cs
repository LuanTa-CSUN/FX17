using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class ServiceCallback
{
    public static void ServiceCallBack(string service, string response)
    {
        if (response == null)
            Debug.Log("ServiceCallback for service " + service);
        else
            Debug.Log("ServiceCallback for service " + service + " response " + response);
    }
}