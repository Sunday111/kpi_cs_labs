using System;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;

namespace lab_10
{
    class CompiledExpression
    {
        public CompiledExpression(string expression, string args)
        {
            string[] code = {
                    "using System;                                                              \n"+
                    "namespace Expression                                                       \n"+
                    "{                                                                          \n"+
                    "    delegate float OneArgFn(float arg);                                    \n"+
                    "    delegate float TwoArgsFn(float a, float b);                            \n"+
                    "    public class Expression                                                \n"+
                    "    {                                                                      \n"+
                    "        static readonly TwoArgsFn pow = (n, p) => (float)Math.Pow(n, p);   \n"+
                    "        static readonly OneArgFn sin = arg => (float)Math.Sin(arg);        \n"+
                    "        static readonly OneArgFn cos = arg => (float)Math.Cos(arg);        \n"+
                    "        static readonly OneArgFn tg  = arg => (float)Math.Tan(arg);        \n"+
                    "        static readonly float pi = (float)Math.PI;                         \n"+
                    "        static public float Exec(" + args + ")                             \n"+
                    "        {                                                                  \n"+
                    "            return " + expression + ";                                     \n"+
                    "        }                                                                  \n"+
                    "    }                                                                      \n"+
                    "}                                                                          \n"
                };

            CompilerParameters CompilerParams = new CompilerParameters();
            CompilerParams.GenerateInMemory = true;
            CompilerParams.TreatWarningsAsErrors = false;
            CompilerParams.GenerateExecutable = false;
            CompilerParams.CompilerOptions = "/optimize";
            string[] references = { "System.dll" };
            CompilerParams.ReferencedAssemblies.AddRange(references);
            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerResults compile = provider.CompileAssemblyFromSource(CompilerParams, code);
            if (compile.Errors.HasErrors)
            {
                string text = "Compile error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    text += "\r\n" + ce.ToString();
                }

                throw new Exception(text);
            }

            Module = compile.CompiledAssembly.GetModules()[0];

            if (Module == null)
            {
                throw new Exception("No modules in assembly");
            }

            Type = Module.GetType("Expression.Expression");

            if (Type == null)
            {
                throw new Exception("Failed to find type");
            }

            Method = Type.GetMethod("Exec");

            if (Method == null)
            {
                throw new Exception("Failed to find method");
            }
        }

        public float Eval(object[] args)
        {
            return (float)Method.Invoke(null, args);
        }

        public static float CompileAndEval(string expression, string argTypes, object[] argValues)
        {
            var compiledExpression = new CompiledExpression(expression, argTypes);
            var result = compiledExpression.Eval(argValues);
            return result;
        }

        Module Module;
        Type Type;
        MethodInfo Method;
    };
}
