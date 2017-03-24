
using System;
using System.Collections;
using System.Collections.Generic;

using XComponent.SwaggerPetstore.UserObject.Models;

namespace XComponent.SwaggerPetstore.UserObject
{
    [System.Serializable()]
    public class DeletePet
    {
        public string apiKey { get; set; }
public long petId { get; set; }

    }
}

