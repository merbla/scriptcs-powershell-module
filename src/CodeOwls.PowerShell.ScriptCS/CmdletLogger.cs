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


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;
using Common.Logging;
using Common.Logging.Factory;

namespace CodeOwls.PowerShell.ScriptCS
{
    class CmdletLogger : AbstractLogger
    {
        private readonly Cmdlet _cmdlet;
        private readonly string _name;

        public CmdletLogger(Cmdlet cmdlet)
        {
            _cmdlet = cmdlet;

            _name = (from attr in _cmdlet.GetType().GetCustomAttributes(true)
                     let cmdletattr = attr as CmdletAttribute
                     where null != cmdletattr
                     select cmdletattr.NounName + "-" + cmdletattr.VerbName).FirstOrDefault()
                     ?? "Unknown Cmdlet";
        }

        void Write(Action<string> writeAction, object message )
        {
            if (null != message)
            {
                writeAction( _name + " - " + message);
            }
        }

        protected override void WriteInternal(LogLevel level, object message, Exception exception)
        {
            switch (level)
            {
                case( LogLevel.All ):
                case( LogLevel.Debug ):
                    {
                        Write( _cmdlet.WriteDebug, message );
                        Write(_cmdlet.WriteDebug, exception);
                        break;
                    }
                case (LogLevel.Trace):
                case (LogLevel.Info):
                    {
                        Write(_cmdlet.WriteVerbose, message);
                        Write(_cmdlet.WriteVerbose, exception);
                        break;
                    }
                case (LogLevel.Warn):
                    {
                        Write(_cmdlet.WriteWarning, message);
                        Write(_cmdlet.WriteWarning, exception);
                        break;
                    }
                case (LogLevel.Error):
                case (LogLevel.Fatal):
                    {
                        var errorRecord = new ErrorRecord(
                            exception,
                            "ScriptCS",
                            ErrorCategory.NotSpecified, 
                            message 
                        );
                        _cmdlet.WriteError( errorRecord );
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public override bool IsTraceEnabled
        {
            get { return true; }
        }

        public override bool IsDebugEnabled
        {
            get { return true; }
        }

        public override bool IsErrorEnabled
        {
            get { return true; }
        }

        public override bool IsFatalEnabled
        {
            get { return true; }
        }

        public override bool IsInfoEnabled
        {
            get { return true; }
        }

        public override bool IsWarnEnabled
        {
            get { return true; }
        }

    
    }
}
