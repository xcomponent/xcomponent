using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Akka.FSharp;
using XComponent.SequenceDiagramProject.SequenceDiagramProjectApi.SimpleComponent;
using XComponent.SimpleComponent.UserObject;

namespace SequenceDiagramViewer.ViewModels
{
    class SimpleComponentViewModel
    {
        private readonly SequenceDiagramViewModel<WorkflowInstance> _workflowDiagramViewModel = new SequenceDiagramViewModel<WorkflowInstance>();
        private ICommand _createStmCommand;
        public SimpleComponentViewModel()
        {
            if (Application.Current != null)
            {
                Application.Current.Dispatcher.BeginInvoke((Action)delegate
                {
                    WorkflowDiagramViewModel.HorizontalSpace = 150;
            
                    WorkflowDiagramViewModel.IsValidInstanceFunc += delegate(WorkflowInstance instance)
                    {
                        return true;
                    };
                    WorkflowDiagramViewModel.DisplayedTextFunc += delegate(WorkflowInstance instance)
                    {
                        return instance.PublicMember.LastUpdateDate.ToString("hh:mm:ss:m") + " - From " +
                               instance.PublicMember.FromTransition;
                    };
                    ClientApiWrapper.Instance.Init();
                    WorkflowDiagramViewModel.Init(ClientApiWrapper.Instance.Api, Workflow_StateMachine.WorkflowStateEnum.A.ToString(), new Dictionary<string, string>(),
                        Enum.GetNames(typeof (Workflow_StateMachine.WorkflowStateEnum)));
                });

                _createStmCommand = new RelayCommand(delegate(object o)
                {
                    WorkflowDiagramViewModel.ClearContent();
                    ClientApiWrapper.Instance.Api.SimpleComponent_Component.SimpleComponent_StateMachine.SendEvent(new CreateStateMachine()
                    {
                        Id = Guid.NewGuid().ToString().Substring(0, 5)
                    });
                });

            }
        }

        public SequenceDiagramViewModel<WorkflowInstance> WorkflowDiagramViewModel
        {
            get { return _workflowDiagramViewModel; }
        }

        public ICommand CreateStmCommand
        {
            get { return _createStmCommand; }
        }
    }
}
