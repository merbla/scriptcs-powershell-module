/*
    Copyright (c) 2013 Code Owls LLC, All Rights Reserved.

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
*/


using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Host;
using ScriptCs.Contracts;

namespace CodeOwls.PowerShell.ScriptCS
{
    public class CurrentCmdletContext : IScriptPackContext, ICmdletContext
    {
        private ICmdletContext _cmdlet;

        public CurrentCmdletContext(ICmdletContext cmdlet)
        {
            _cmdlet = cmdlet;
        }
        
        public CommandOrigin CommandOrigin
        {
            get { return _cmdlet.CommandOrigin; }
        }

        public string GetResourceString(string baseName, string resourceId)
        {
            return _cmdlet.GetResourceString(baseName, resourceId);
        }

        public void WriteError(ErrorRecord errorRecord)
        {
            _cmdlet.WriteError(errorRecord);
        }

        public void WriteObject(object sendToPipeline)
        {
            _cmdlet.WriteObject(sendToPipeline);
        }

        public void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
            _cmdlet.WriteObject(sendToPipeline, enumerateCollection);
        }

        public void WriteVerbose(string text)
        {
            _cmdlet.WriteVerbose(text);
        }

        public void WriteWarning(string text)
        {
            _cmdlet.WriteWarning(text);
        }

        public void WriteCommandDetail(string text)
        {
            _cmdlet.WriteCommandDetail(text);
        }

        public void WriteProgress(ProgressRecord progressRecord)
        {
            _cmdlet.WriteProgress(progressRecord);
        }

        public void WriteDebug(string text)
        {
            _cmdlet.WriteDebug(text);
        }

        public bool ShouldProcess(string target)
        {
            return _cmdlet.ShouldProcess(target);
        }

        public bool ShouldProcess(string target, string action)
        {
            return _cmdlet.ShouldProcess(target, action);
        }

        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption)
        {
            return _cmdlet.ShouldProcess(verboseDescription, verboseWarning, caption);
        }

        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption,
                                  out ShouldProcessReason shouldProcessReason)
        {
            return _cmdlet.ShouldProcess(verboseDescription, verboseWarning, caption, out shouldProcessReason);
        }

        public bool ShouldContinue(string query, string caption)
        {
            return _cmdlet.ShouldContinue(query, caption);
        }

        public bool ShouldContinue(string query, string caption, ref bool yesToAll, ref bool noToAll)
        {
            return _cmdlet.ShouldContinue(query, caption, ref yesToAll, ref noToAll);
        }

        public bool TransactionAvailable()
        {
            return _cmdlet.TransactionAvailable();
        }

        public void ThrowTerminatingError(ErrorRecord errorRecord)
        {
            _cmdlet.ThrowTerminatingError(errorRecord);
        }

        public bool Stopping
        {
            get { return _cmdlet.Stopping; }
        }

        public ICommandRuntime CommandRuntime
        {
            get { return _cmdlet.CommandRuntime; }
            set { _cmdlet.CommandRuntime = value; }
        }

        public PSTransactionContext CurrentPSTransaction
        {
            get { return _cmdlet.CurrentPSTransaction; }
        }

        public PathInfo CurrentProviderLocation(string providerId)
        {
            return _cmdlet.CurrentProviderLocation(providerId);
        }

        public string GetUnresolvedProviderPathFromPSPath(string path)
        {
            return _cmdlet.GetUnresolvedProviderPathFromPSPath(path);
        }

        public Collection<string> GetResolvedProviderPathFromPSPath(string path, out ProviderInfo provider)
        {
            return _cmdlet.GetResolvedProviderPathFromPSPath(path, out provider);
        }

        public object GetVariableValue(string name)
        {
            return _cmdlet.GetVariableValue(name);
        }

        public object GetVariableValue(string name, object defaultValue)
        {
            return _cmdlet.GetVariableValue(name, defaultValue);
        }

        public string ParameterSetName
        {
            get { return _cmdlet.ParameterSetName; }
        }

        public InvocationInfo MyInvocation
        {
            get { return _cmdlet.MyInvocation; }
        }

        public CommandInvocationIntrinsics InvokeCommand
        {
            get { return _cmdlet.InvokeCommand; }
        }

        public PSHost Host
        {
            get { return _cmdlet.Host; }
        }

        public SessionState SessionState
        {
            get { return _cmdlet.SessionState; }
        }

        public PSEventManager Events
        {
            get { return _cmdlet.Events; }
        }

        public JobRepository JobRepository
        {
            get { return _cmdlet.JobRepository; }
        }

        public ProviderIntrinsics InvokeProvider
        {
            get { return _cmdlet.InvokeProvider; }
        }

        public object[] Input
        {
            get { return _cmdlet.Input; }
        }

        public  ICmdletContext ActiveCmdletContext
        {
            get { return _cmdlet; }
            internal set { _cmdlet = value ?? new NullCmdletContext(); }
        }
    }
}
