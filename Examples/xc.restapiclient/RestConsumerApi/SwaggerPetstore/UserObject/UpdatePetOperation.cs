
using System;
using System.Collections;
using System.Collections.Generic;

using XComponent.SwaggerPetstore.UserObject.Models;

namespace XComponent.SwaggerPetstore.UserObject
{
	[System.Serializable()]
    public class UpdatePetOperation
    {
        public XComponent.SwaggerPetstore.UserObject.UpdatePet Event { get; set; }
		
		public bool HasErrors { get; set; }
        public string Message { get; set; }
    }
}

