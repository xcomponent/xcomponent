using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using Northwoods.GoXam.Model;
using SequenceDiagramViewer.Annotations;
using SequenceDiagramViewer.SequenceDiagramControl;
using XComponent.Common.ApiContext;

namespace SequenceDiagramViewer.ViewModels
{
    public class SequenceDiagramViewModel<TPublicMemberInstanceType> : GraphLinksModel<NodeData, String, String, LinkData> , ILinkSelector, INotifyPropertyChanged
        where TPublicMemberInstanceType : AbstractInstance
    {
        private const string InitialState = ">> Start";
        private Dictionary<string, string> _groupStateNameByStateModelName = new Dictionary<string, string>();
        private int _horizontalSpace = 100;
        private int _time = 1;
        private string _previousState;
        private string _stmEntryPoint;
        private readonly List<string> _stateList = new List<string>();
        private object _registeredStateMachineInstance = null;
        private EventInfo _registeredEventInfo;

        public Func<TPublicMemberInstanceType, bool> IsValidInstanceFunc { get; set; }
        public Func<TPublicMemberInstanceType, string> DisplayedTextFunc { get; set; }

        public Func<TPublicMemberInstanceType, string> StateNameFunc { get; set; }

        public int Duration { get; set; }

        public SequenceDiagramViewModel()
        {
            Duration = 2;

            NodesSource = new ObservableCollection<NodeData>();
            LinksSource = new ObservableCollection<LinkData>();
            DisplayedTextFunc = type => string.Empty;
        }

        private readonly MethodInfo _handlerMethod = typeof(SequenceDiagramViewModel<TPublicMemberInstanceType>).GetMethod("OnInstanceUpdated", BindingFlags.NonPublic | BindingFlags.Instance);

        public void Init<TClientApiType>(TClientApiType clientApi, string stmFirstStateName, Dictionary<string, string> groupStateNameByStateModelName, params string[] stmStates )
        {
            if (groupStateNameByStateModelName != null)
            {
                _groupStateNameByStateModelName = groupStateNameByStateModelName;
            }

            UnregisterEventInfo();

            _stmEntryPoint = stmFirstStateName;

            var clientApiType = typeof(TClientApiType);
            var componentProperties = clientApiType.GetProperties().Where(e => e.Name.EndsWith("_Component"));
            foreach (var component in componentProperties)
            {

                var stmProps = component.PropertyType.GetProperties().Where(e => e.Name.EndsWith("StateMachine"));
                foreach (var stmProp in stmProps)
                {
                    var componentTypeInstance = component.GetValue(clientApi, null);
                    _registeredStateMachineInstance = stmProp.GetValue(componentTypeInstance, null);
                    var eventInfo = _registeredStateMachineInstance.GetType().GetEvent("InstanceUpdated");

                    if (eventInfo != null)
                    {
                        var typeToFind = typeof(TPublicMemberInstanceType);
                        var instanceType =
                            eventInfo.EventHandlerType.GetGenericArguments()
                                .FirstOrDefault(e => e.FullName == typeToFind.FullName);
                        if (instanceType != null)
                        {
                            // Create handler
                            var handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, _handlerMethod);

                            // Attach to event
                            eventInfo.AddEventHandler(_registeredStateMachineInstance, handler);

                            _registeredEventInfo = eventInfo;
                            break;


                        }

                    }
                    if (_registeredEventInfo != null)
                    {
                        break;
                    }
                }

            }

            _stateList.Clear();
            _stateList.Add(InitialState);
            _stateList.AddRange(stmStates);

            ClearContent();
        }

        public void UnregisterEventInfo()
        {
            if (_registeredEventInfo != null && _registeredStateMachineInstance != null)
            {
                try
                {
                    var handler = Delegate.CreateDelegate(_registeredEventInfo.EventHandlerType, this, _handlerMethod);
                    _registeredEventInfo.RemoveEventHandler(_registeredStateMachineInstance, handler);

                   
                }
                catch (System.Exception)
                {
             
                }
                _registeredEventInfo = null;
                _registeredStateMachineInstance = null;
            }
        }

        public void ClearContent()
        {
            Links.Clear();
            Nodes.Clear();

            int xPos = 0;
            foreach (var stateName in _stateList)
            {
                var node = stateName;
                if (_groupStateNameByStateModelName.ContainsKey(stateName))
                {
                    node = _groupStateNameByStateModelName[stateName];
                }

                if (Nodes.FirstOrDefault(e => e.Key == node) == null)
                {
                    Nodes.Add(new NodeData()
                    {
                        Key = node,
                        Text = node,
                        IsSubGraph = true,
                        Location = new Point(xPos, 0)
                    });
                    xPos += HorizontalSpace;
                }
               
            }
        }

        public void InitFromHistory(IEnumerable<TPublicMemberInstanceType> publicMemberHistory)
        {
            ClearContent();
            foreach (var publicMember in publicMemberHistory)
            {
                OnInstanceUpdated(publicMember);
            }
        }

       

        private void OnInstanceUpdated(TPublicMemberInstanceType publicMemberInstance)
        {
            if (publicMemberInstance != null)
            {
                if (IsValidInstanceFunc == null)
                {
                    return;
                }

                if (!IsValidInstanceFunc(publicMemberInstance))
                {
                    return;
                }

                Application.Current.Dispatcher.BeginInvoke((Action)delegate
                {
                    var targetState = publicMemberInstance.StateName;
                    if (StateNameFunc != null)
                    {
                        targetState = StateNameFunc(publicMemberInstance);
                    }
                    if (_groupStateNameByStateModelName.ContainsKey(targetState))
                    {
                        targetState = _groupStateNameByStateModelName[targetState];
                    }

                    if (targetState == _stmEntryPoint)
                    {
                        
                        _time = 1;
                        Links.Add(new LinkData()
                        {
                            From = InitialState,
                            To = targetState,
                            Text = DisplayedTextFunc(publicMemberInstance),
                            Time = _time,
                            Duration = Duration,
                            Data = publicMemberInstance
                        });
                    }
                    else
                    {
                        Links.Add(new LinkData()
                        {
                            From = _previousState,
                            To = targetState,
                            Text = DisplayedTextFunc(publicMemberInstance),
                            Time = ++_time,
                            Duration = Duration,
                            Data = publicMemberInstance
                        });
                    }

                    _previousState = targetState;

                    Update();
                });
            }
        }

        public void Update()
        {
            // add an Activity node for each Message recipient
            Modifiable = true;
            double max = 0;
            foreach (LinkData d in LinksSource)
            {
                var grp = FindNodeByKey(d.To);
                if (grp != null)
                {
                    var act = new NodeData() {
                        SubGraphKey = d.To,
                        Location = new Point(grp.Location.X, BarRoute.ConvertTimeToY(d.Time) - BarRoute.ActivityInset),
                        Length = d.Duration * BarRoute.MessageSpacing + BarRoute.ActivityInset * 2,
                    };
                    AddNode(act);
                    max = Math.Max(max, act.Location.Y + act.Length);
                }
              
            }
            // now make sure all of the lifelines are long enough
            foreach (NodeData d in NodesSource)
            {
                if (d.IsSubGraph) d.Length = max - BarRoute.LineStart + BarRoute.LineTrail;
            }
            Modifiable = false;
        }

        public ObservableCollection<NodeData> Nodes
        {
            get
            {
                return NodesSource as ObservableCollection<NodeData>;
            }
        }

        public ObservableCollection<LinkData> Links
        {
            get
            {
                return LinksSource as ObservableCollection<LinkData>;
            }
        }

        public int HorizontalSpace
        {
            get { return _horizontalSpace; }
            set { _horizontalSpace = value; }
        }

        private object _selectedLink;

        private static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
        public object SelectedLink
        {
            get { return _selectedLink; }
            set
            {
                if (_selectedLink != value)
                {
                    _selectedLink = value;
                    if (_selectedLink != null)
                    {
                        _selectedLink = GetPropValue(_selectedLink, "PublicMember");
                    }
                    OnPropertyChanged();
                }
            }
        }

        public void OnLinkSelected(LinkData link)
        {
            SelectedLink = link.Data as TPublicMemberInstanceType;
 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
