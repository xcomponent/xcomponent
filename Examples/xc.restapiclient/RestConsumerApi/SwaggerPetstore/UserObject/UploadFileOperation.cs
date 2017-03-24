
using System;
using System.Collections;
using System.Collections.Generic;

using XComponent.SwaggerPetstore.UserObject.Models;

namespace XComponent.SwaggerPetstore.UserObject
{
	[System.Serializable()]
    public class UploadFileOperation
    {
        public XComponent.SwaggerPetstore.UserObject.UploadFile Event { get; set; }
		public ApiResponse OperationResult { get; set; }
		public bool HasErrors { get; set; }
        public string Message { get; set; }
    }
}

