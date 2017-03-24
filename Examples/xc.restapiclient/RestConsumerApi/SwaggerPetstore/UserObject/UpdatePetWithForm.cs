
using System;
using System.Collections;
using System.Collections.Generic;

using XComponent.SwaggerPetstore.UserObject.Models;

namespace XComponent.SwaggerPetstore.UserObject
{
    [System.Serializable()]
    public class UpdatePetWithForm
    {
        public long petId { get; set; }
public string name { get; set; }
public string status { get; set; }

    }
}

