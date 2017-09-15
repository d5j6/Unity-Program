using HttpUtility;

namespace KWS
{
    public static class KWSClient
    {
        private static IAsyncRequestCommandFactory _commandFactory = new JsonCommandFactory();
        public static AsyncRequestResult<System.String> Test_Test(System.String param1, System.Int32 param2)
        {
            return KWSProxyObject.Instance.Request(_commandFactory.CreateCommand<System.String>(KWSProxyObject.Instance.GetActionUrl("Test", "Test"), param1, param2));
        }

        public static AsyncRequestResult<System.Int32> Test_Test2(System.Single param1, System.Int32 param2)
        {
            return KWSProxyObject.Instance.Request(_commandFactory.CreateCommand<System.Int32>(KWSProxyObject.Instance.GetActionUrl("Test", "Test2"), param1, param2));
        }
    }
}