
using System;
using System.Collections;
using System.Collections.Generic;

using XComponent.SwaggerPetstore.UserObject.Models;

namespace XComponent.SwaggerPetstore.UserObject
{
	[System.Serializable()]
    public class GetInventoryOperation
    {
        public XComponent.SwaggerPetstore.UserObject.GetInventory Event { get; set; }
		public System.Collections.Generic.IDictionary<string, int?> OperationResult { get; set; }
		public bool HasErrors { get; set; }
        public string Message { get; set; }
    }
}

