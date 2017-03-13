
using System;
using System.Collections;
using System.Collections.Generic;

using XComponent.SwaggerPetstore.UserObject.Models;

namespace XComponent.SwaggerPetstore.UserObject
{
	[System.Serializable()]
    public class FindPetsByStatusOperation
    {
        public XComponent.SwaggerPetstore.UserObject.FindPetsByStatus Event { get; set; }
		public System.Collections.Generic.IList<Pet> OperationResult { get; set; }
		public bool HasErrors { get; set; }
        public string Message { get; set; }
    }
}

