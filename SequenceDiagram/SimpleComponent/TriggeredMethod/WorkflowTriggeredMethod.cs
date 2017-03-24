using System;
using System.Threading;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.SimpleComponent.Common;
using XComponent.SimpleComponent.Common.Senders;

namespace XComponent.SimpleComponent.TriggeredMethod
{
    public static class WorkflowTriggeredMethod
    {
        static readonly Random Random = new Random();

        public static void ExecuteOn_B_Through_AB(XComponent.SimpleComponent.UserObject.AB aB, XComponent.SimpleComponent.UserObject.Workflow workflow, object object_InternalMember, Context context, IABABOnBWorkflowSenderInterface sender)
        {
            workflow.LastUpdateDate = DateTime.Now;
            workflow.FromTransition = "AB";

            if (Random.Next(1, 1000) % 2 == 0)
            {
                sender.BC(context);
            }
            else
            {
                sender.BD(context);
            }
        }

        public static void ExecuteOn_C_Through_BC(XComponent.SimpleComponent.UserObject.BC bC, XComponent.SimpleComponent.UserObject.Workflow workflow, object object_InternalMember, Context context, IBCBCOnCWorkflowSenderInterface sender)
        {
            workflow.LastUpdateDate = DateTime.Now;
            workflow.FromTransition = "BC";

            if (Random.Next(1, 1000) % 2 == 0)
            {
                sender.CD(context);
            }
            else
            {
                sender.CE(context);
            }
        }

        public static void ExecuteOn_D_Through_BD(XComponent.SimpleComponent.UserObject.BD bD, XComponent.SimpleComponent.UserObject.Workflow workflow, object object_InternalMember, Context context, IBDBDOnDWorkflowSenderInterface sender)
        {
            workflow.LastUpdateDate = DateTime.Now;
            workflow.FromTransition = "BD";

            if (Random.Next(1, 1000) % 2 == 0)
            {
                sender.DC(context);
            }
            else
            {
                sender.DE(context);
            }
        }

        public static void ExecuteOn_D_Through_CD(XComponent.SimpleComponent.UserObject.CD cD, XComponent.SimpleComponent.UserObject.Workflow workflow, object object_InternalMember, Context context, ICDCDOnDWorkflowSenderInterface sender)
        {
            workflow.LastUpdateDate = DateTime.Now;
            workflow.FromTransition = "CD";

            if (Random.Next(1, 1000) % 2 == 0)
            {
                sender.DC(context);
            }
            else
            {
                sender.DE(context);
            }
        }

        public static void ExecuteOn_C_Through_DC(XComponent.SimpleComponent.UserObject.DC dC, XComponent.SimpleComponent.UserObject.Workflow workflow, object object_InternalMember, Context context, IDCDCOnCWorkflowSenderInterface sender)
        {
            workflow.LastUpdateDate = DateTime.Now;
            workflow.FromTransition = "DC";

            if (Random.Next(1, 1000) % 2 == 0)
            {
                sender.CD(context);
            }
            else
            {
                sender.CE(context);
            }
        }

        public static void ExecuteOn_A_Through_CreateStateMachine(XComponent.SimpleComponent.UserObject.CreateStateMachine createStateMachine, XComponent.SimpleComponent.UserObject.Workflow workflow, object object_InternalMember, Context context, ICreateStateMachineCreateStateMachineOnAWorkflowSenderInterface sender)
        {
            workflow.LastUpdateDate = DateTime.Now;
            workflow.FromTransition = "CreateStateMachine";
            workflow.Id = createStateMachine.Id;
            sender.AB(context);
        }
    }
}