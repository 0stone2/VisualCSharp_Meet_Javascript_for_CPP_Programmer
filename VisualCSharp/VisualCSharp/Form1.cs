using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ChakraHost.Hosting;


namespace VisualCSharp
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            this.Text = System.String.Format("Visual C#, {0}를 만나다", Constants.SCRIPT);

            this.groupBox1.Text = System.String.Format("1장 - C#에서 {0} 호출하기", Constants.SCRIPT);
            this.button1.Text = System.String.Format("예제 1 - {0} 스크립트\n파일 실행하기", Constants.SCRIPT);
            this.button2.Text = System.String.Format("예제 2 - {0} 전역 변수\n 조작하기", Constants.SCRIPT);
            this.button3.Text = System.String.Format("예제 3 - {0} 함수\n호출하기", Constants.SCRIPT);


            this.groupBox2.Text = System.String.Format("2장 - {0}에서 C# 호출하기", Constants.SCRIPT);
            this.button4.Text = System.String.Format("예제 4 - {0}에서 호출 가능한\nC# 함수 만들기 1", Constants.SCRIPT);

            win32.SetDllDirectory("C:/Script/ChakraCore/Build/VcBuild/bin/x86_release");
        }

        private string LoadJSFile(string pszJSFile)
        {
            string jsContext = System.IO.File.ReadAllText(pszJSFile);
            return jsContext;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JavaScriptRuntime runtime;
            JavaScriptContext context;
            JavaScriptSourceContext currentSourceContext = JavaScriptSourceContext.FromIntPtr(IntPtr.Zero);

            bool bSuccess = false;

            try {
                string script = System.IO.File.ReadAllText("C:/Temp/Script/Sample01.js");

                runtime = JavaScriptRuntime.Create();
                context = runtime.CreateContext();
                JavaScriptContext.Current = context;
                JavaScriptContext.RunScript(script, currentSourceContext++, "");

                bSuccess = true;
            }
            finally
            {
                if(true == bSuccess)
                    System.Diagnostics.Trace.WriteLine("Success");
                else 
                    System.Diagnostics.Trace.WriteLine("Error");
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JavaScriptRuntime runtime;
            JavaScriptContext context;
            JavaScriptSourceContext currentSourceContext = JavaScriptSourceContext.FromIntPtr(IntPtr.Zero);
            JavaScriptValue jsValue;
            string szWelcomMessage;
            string szWhoamI;
            double nVersion;
            bool bSuccess = false;

            try
            {
                string script = System.IO.File.ReadAllText("C:/Temp/Script/Sample02.js");


                runtime = JavaScriptRuntime.Create();
                context = runtime.CreateContext();
                JavaScriptContext.Current = context;
                JavaScriptContext.RunScript(script, currentSourceContext++, "");

                jsValue = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("szWelcomMessage"));
                szWelcomMessage = jsValue.ToString();

                jsValue = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("szWhoamI"));
                szWhoamI = jsValue.ToString();

                jsValue = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("nVersion"));
                nVersion = jsValue.ToDouble();

                System.Diagnostics.Trace.WriteLine("szWelcomMessage = " + szWelcomMessage);
                System.Diagnostics.Trace.WriteLine("szWhoamI = " + szWhoamI);
                System.Diagnostics.Trace.WriteLine("nVersion = " + nVersion.ToString());





                jsValue = JavaScriptValue.FromString("New_Sample02.js");
                JavaScriptValue.GlobalObject.SetProperty(JavaScriptPropertyId.FromString("szWhoamI"), jsValue, true);


                jsValue = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("szWelcomMessage"));
                szWelcomMessage = jsValue.ToString();

                jsValue = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("szWhoamI"));
                szWhoamI = jsValue.ToString();

                jsValue = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("nVersion"));
                nVersion = jsValue.ToDouble();

                System.Diagnostics.Trace.WriteLine("szWelcomMessage = " + szWelcomMessage);
                System.Diagnostics.Trace.WriteLine("szWhoamI = " + szWhoamI);
                System.Diagnostics.Trace.WriteLine("nVersion = " + nVersion.ToString());

                bSuccess = true;
            }
            finally
            {
                if (true == bSuccess)
                    System.Diagnostics.Trace.WriteLine("Success");
                else
                    System.Diagnostics.Trace.WriteLine("Error");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            JavaScriptRuntime runtime;
            JavaScriptContext context;
            JavaScriptSourceContext currentSourceContext = JavaScriptSourceContext.FromIntPtr(IntPtr.Zero);
            JavaScriptValue jsValue;
            string szWelcomMessage;
            string szWhoamI;


            JavaScriptValue returnValue;
            JavaScriptValue myfunc_1;
            JavaScriptValue myfunc_2;
            JavaScriptValue myfunc_3;
            JavaScriptValue myfunc_4;

            bool bSuccess = false;

            try
            {
                string script = System.IO.File.ReadAllText("C:/Temp/Script/Sample03.js");


                runtime = JavaScriptRuntime.Create();
                context = runtime.CreateContext();
                JavaScriptContext.Current = context;
                JavaScriptContext.RunScript(script, currentSourceContext++, "");

                jsValue = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("szWelcomMessage"));
                szWelcomMessage = jsValue.ToString();

                jsValue = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("szWhoamI"));
                szWhoamI = jsValue.ToString();

                System.Diagnostics.Trace.WriteLine("szWelcomMessage = " + szWelcomMessage);
                System.Diagnostics.Trace.WriteLine("szWhoamI = " + szWhoamI);



                // myfunc_1

                JavaScriptValue[] args1 = new JavaScriptValue[1] { JavaScriptValue.FromString("self") };
                myfunc_1 = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("myfunc_1"));
                myfunc_1.CallFunction(args1);


                jsValue = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("szWelcomMessage"));
                szWelcomMessage = jsValue.ToString();

                jsValue = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("szWhoamI"));
                szWhoamI = jsValue.ToString();


                System.Diagnostics.Trace.WriteLine("szWelcomMessage = " + szWelcomMessage);
                System.Diagnostics.Trace.WriteLine("szWhoamI = " + szWhoamI);



                // myfunc_2
                JavaScriptValue[] args2 = new JavaScriptValue[1] { JavaScriptValue.GlobalObject };
                myfunc_2 = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("myfunc_2"));
                returnValue = myfunc_2.CallFunction(args2);


                jsValue = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("szWelcomMessage"));
                szWelcomMessage = jsValue.ToString();

                jsValue = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("szWhoamI"));
                szWhoamI = jsValue.ToString();

                System.Diagnostics.Trace.WriteLine("Return Value = " + returnValue.ToString());
                System.Diagnostics.Trace.WriteLine("szWelcomMessage = " + szWelcomMessage);
                System.Diagnostics.Trace.WriteLine("szWhoamI = " + szWhoamI);


                // myfunc_3
                JavaScriptValue[] args3 = new JavaScriptValue[2] { JavaScriptValue.GlobalObject, JavaScriptValue.FromString("myfunc_3") };
                myfunc_3 = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("myfunc_3"));
                returnValue = myfunc_3.CallFunction(args3);


                jsValue = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("szWelcomMessage"));
                szWelcomMessage = jsValue.ToString();

                jsValue = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("szWhoamI"));
                szWhoamI = jsValue.ToString();

                System.Diagnostics.Trace.WriteLine("Return Value[0] = " + (returnValue.GetIndexedProperty(JavaScriptValue.FromInt32(0))).ToString());
                System.Diagnostics.Trace.WriteLine("Return Value[1] = " + (returnValue.GetIndexedProperty(JavaScriptValue.FromInt32(1))).ToBoolean());
                System.Diagnostics.Trace.WriteLine("szWelcomMessage = " + szWelcomMessage);
                System.Diagnostics.Trace.WriteLine("szWhoamI = " + szWhoamI);


                // myfunc_4
                JavaScriptValue[] args4 = new JavaScriptValue[3] { JavaScriptValue.GlobalObject, JavaScriptValue.FromString("myfunc_4"), JavaScriptValue.FromBoolean(false) };
                myfunc_4 = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("myfunc_4"));
                returnValue = myfunc_4.CallFunction(args4);


                jsValue = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("szWelcomMessage"));
                szWelcomMessage = jsValue.ToString();

                jsValue = JavaScriptValue.GlobalObject.GetProperty(JavaScriptPropertyId.FromString("szWhoamI"));
                szWhoamI = jsValue.ToString();

                System.Diagnostics.Trace.WriteLine("Return Value[0] = " + (returnValue.GetIndexedProperty(JavaScriptValue.FromInt32(0))).ToString());
                System.Diagnostics.Trace.WriteLine("Return Value[1] = " + (returnValue.GetIndexedProperty(JavaScriptValue.FromInt32(1))).ToBoolean());
                System.Diagnostics.Trace.WriteLine("szWelcomMessage = " + szWelcomMessage);
                System.Diagnostics.Trace.WriteLine("szWhoamI = " + szWhoamI);

                bSuccess = true;
            }
            finally
            {
                if (true == bSuccess)
                    System.Diagnostics.Trace.WriteLine("Success");
                else
                    System.Diagnostics.Trace.WriteLine("Error");
            }
        }


        public JavaScriptValue DbgString(JavaScriptValue callee, [MarshalAs(UnmanagedType.U1)] bool isConstructCall, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] JavaScriptValue[] arguments, ushort argumentCount, IntPtr callbackData)
        {
            System.Diagnostics.Trace.WriteLine("Enter DbgString");
            
            for (int nIndex = 1; nIndex < argumentCount; nIndex++)
            {
                if(JavaScriptValueType.String == arguments[nIndex].ValueType)
                {
                    System.Diagnostics.Trace.WriteLine(arguments[nIndex].ToString());
                }
            }
            
            return JavaScriptValue.Null;
        }

        public JavaScriptValue Sum(JavaScriptValue callee, [MarshalAs(UnmanagedType.U1)] bool isConstructCall, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] JavaScriptValue[] arguments, ushort argumentCount, IntPtr callbackData)
        {
            int nSum = 0;
            int nStart = 0;
            int nEnd = 0;

            System.Diagnostics.Trace.WriteLine("Enter Sum");

            nStart = (int)arguments[1].ToDouble();
            nEnd = (int)arguments[2].ToDouble();

            for (int nIndex = nStart; nIndex <= nEnd; nIndex++)
            {
                nSum += nIndex;
            }

            return JavaScriptValue.FromInt32(nSum);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            JavaScriptRuntime runtime;
            JavaScriptContext context;
            JavaScriptSourceContext currentSourceContext = JavaScriptSourceContext.FromIntPtr(IntPtr.Zero);

            JavaScriptValue DbgStringFn;
            JavaScriptValue DbgStringName;
            JavaScriptPropertyId DbgStringId;
            JavaScriptValue SumFn;
            JavaScriptValue SumName;
            JavaScriptPropertyId SumId;

            IntPtr callbackState = IntPtr.Zero;

            bool bSuccess = false;

            try
            {
                string script = System.IO.File.ReadAllText("C:/Temp/Script/Sample04.js");


                runtime = JavaScriptRuntime.Create();
                context = runtime.CreateContext();
                JavaScriptContext.Current = context;


                DbgStringName = JavaScriptValue.FromString("DbgString");
                DbgStringId = JavaScriptPropertyId.FromString("DbgString");
                Native.JsCreateNamedFunction(DbgStringName, (ChakraHost.Hosting.JavaScriptNativeFunction)DbgString, callbackState, out DbgStringFn);
                JavaScriptValue.GlobalObject.SetProperty(DbgStringId, DbgStringFn, true);


                SumName = JavaScriptValue.FromString("Sum");
                SumId = JavaScriptPropertyId.FromString("Sum");
                Native.JsCreateNamedFunction(SumName, (ChakraHost.Hosting.JavaScriptNativeFunction)Sum, callbackState, out SumFn);
                JavaScriptValue.GlobalObject.SetProperty(SumId, SumFn, true);

                JavaScriptContext.RunScript(script, currentSourceContext++, "");

                bSuccess = true;
            }
            finally
            {
                if (true == bSuccess)
                    System.Diagnostics.Trace.WriteLine("Success");
                else
                    System.Diagnostics.Trace.WriteLine("Error");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
