
using System;
using System.Collections;
using System.Collections.Generic;

using XComponent.SwaggerPetstore.UserObject.Models;

namespace XComponent.SwaggerPetstore.UserObject
{
    [System.Serializable()]
    public class UploadFile
    {
        public long petId { get; set; }
public string additionalMetadata { get; set; }
public System.IO.Stream file { get; set; }

    }
}

