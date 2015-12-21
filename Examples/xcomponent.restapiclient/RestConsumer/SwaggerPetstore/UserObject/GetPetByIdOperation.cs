
using System;
using System.Collections;
using System.Collections.Generic;

using XComponent.SwaggerPetstore.UserObject.Models;

namespace XComponent.SwaggerPetstore.UserObject
{
	[System.Serializable()]
    public class GetPetByIdOperation
    {
        public XComponent.SwaggerPetstore.UserObject.GetPetById Event { get; set; }
		public Pet OperationResult { get; set; }
		public bool HasErrors { get; set; }
        public string Message { get; set; }
    }
}

