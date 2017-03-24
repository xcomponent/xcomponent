using System.Collections.Generic;
using XComponent.Engine.Execution.HashCode;

namespace XComponent.SwaggerPetstore.Common.EventHashCodeCalculator
{
	public class SwaggerPetstoreEventHashCodeCalculatorRepository : IEventHashCodeCalculatorRepository
	{
		Dictionary<int, IEventHashCodeCalculator> _calculators;

		public SwaggerPetstoreEventHashCodeCalculatorRepository()
		{
			_calculators = new Dictionary<int, IEventHashCodeCalculator>();
			_calculators.Add(6, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.DefaultEventEventHashCodeCalculator());
			_calculators.Add(8, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.AddPetEventHashCodeCalculator());
			_calculators.Add(9, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.AddPetOperationEventHashCodeCalculator());
			_calculators.Add(10, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.CreateUserEventHashCodeCalculator());
			_calculators.Add(11, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.CreateUserOperationEventHashCodeCalculator());
			_calculators.Add(12, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.CreateUsersWithArrayInputEventHashCodeCalculator());
			_calculators.Add(13, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.CreateUsersWithArrayInputOperationEventHashCodeCalculator());
			_calculators.Add(14, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.CreateUsersWithListInputEventHashCodeCalculator());
			_calculators.Add(15, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.CreateUsersWithListInputOperationEventHashCodeCalculator());
			_calculators.Add(16, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.DeleteOrderEventHashCodeCalculator());
			_calculators.Add(17, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.DeleteOrderOperationEventHashCodeCalculator());
			_calculators.Add(18, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.DeletePetEventHashCodeCalculator());
			_calculators.Add(19, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.DeletePetOperationEventHashCodeCalculator());
			_calculators.Add(20, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.DeleteUserEventHashCodeCalculator());
			_calculators.Add(21, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.DeleteUserOperationEventHashCodeCalculator());
			_calculators.Add(23, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.FindPetsByStatusEventHashCodeCalculator());
			_calculators.Add(24, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.FindPetsByStatusOperationEventHashCodeCalculator());
			_calculators.Add(25, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.FindPetsByTagsEventHashCodeCalculator());
			_calculators.Add(26, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.FindPetsByTagsOperationEventHashCodeCalculator());
			_calculators.Add(27, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.GetInventoryEventHashCodeCalculator());
			_calculators.Add(28, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.GetInventoryOperationEventHashCodeCalculator());
			_calculators.Add(29, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.GetOrderByIdEventHashCodeCalculator());
			_calculators.Add(30, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.GetOrderByIdOperationEventHashCodeCalculator());
			_calculators.Add(31, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.GetPetByIdEventHashCodeCalculator());
			_calculators.Add(32, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.GetPetByIdOperationEventHashCodeCalculator());
			_calculators.Add(33, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.GetUserByNameEventHashCodeCalculator());
			_calculators.Add(34, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.GetUserByNameOperationEventHashCodeCalculator());
			_calculators.Add(35, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.LoginUserEventHashCodeCalculator());
			_calculators.Add(36, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.LoginUserOperationEventHashCodeCalculator());
			_calculators.Add(37, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.LogoutUserEventHashCodeCalculator());
			_calculators.Add(38, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.LogoutUserOperationEventHashCodeCalculator());
			_calculators.Add(46, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.PlaceOrderEventHashCodeCalculator());
			_calculators.Add(47, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.PlaceOrderOperationEventHashCodeCalculator());
			_calculators.Add(50, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.UpdatePetEventHashCodeCalculator());
			_calculators.Add(51, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.UpdatePetOperationEventHashCodeCalculator());
			_calculators.Add(52, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.UpdatePetWithFormEventHashCodeCalculator());
			_calculators.Add(53, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.UpdatePetWithFormOperationEventHashCodeCalculator());
			_calculators.Add(54, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.UpdateUserEventHashCodeCalculator());
			_calculators.Add(55, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.UpdateUserOperationEventHashCodeCalculator());
			_calculators.Add(56, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.UploadFileEventHashCodeCalculator());
			_calculators.Add(57, new XComponent.SwaggerPetstore.Common.EventHashCodeCalculator.SwaggerPetstore.UploadFileOperationEventHashCodeCalculator());
		}

		public Dictionary<int, IEventHashCodeCalculator> GetEventHashCodeCalculators()
		{
			return _calculators;
		}
	}
}